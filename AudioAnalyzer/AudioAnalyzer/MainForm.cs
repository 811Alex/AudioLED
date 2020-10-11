using AudioAnalyzer.Properties;
using Microsoft.Win32;
using NAudio.CoreAudioApi;
using NAudio.Wave;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Windows.Forms;

namespace AudioAnalyzer
{
    public partial class MainForm : Form
    {
        private readonly int LOWLIMIT = 500;
        private readonly int MIDLIMIT = 2000;
        private readonly int BUFFERSIZE = (int)Math.Pow(2, 6);
        private Dictionary<String, int> waveInDict = new Dictionary<String, int>();
        private int sensitivity;
        private readonly AudioListener al;
        private SerialPort port;
        private double[] lastData;


        public MainForm()
        {
            InitializeComponent();
            MMDeviceEnumerator enumerator = new MMDeviceEnumerator();
            var devicesIn = enumerator.EnumerateAudioEndPoints(DataFlow.Capture, DeviceState.Active);
            enumerator.Dispose();

            for(int i = 0; i < WaveIn.DeviceCount; i++)
                waveInDict.Add(devicesIn[i].ID, i);

            comboBoxDevices.Items.AddRange(devicesIn.ToArray());
            if (comboBoxDevices.Items.Count == 0)
            {
                MessageBox.Show("No audio devices found!", "ERROR");
                Application.Exit();
            }

            String[] ports = SerialPort.GetPortNames();
            comboBoxPort.Items.AddRange(ports);

            if (comboBoxPort.Items.Count == 0)
            {
                MessageBox.Show("No serial ports found!", "ERROR");
                Application.Exit();
            }

            LoadSettings();

            timer.Interval = (int)Math.Round(numericUpDownRefreshRate.Value);
            sensitivity = (int)Math.Round(numericUpDownSensitivity.Value);

            al = new AudioListener(LOWLIMIT, MIDLIMIT, BUFFERSIZE);

            if (Settings.Default.start) ButtonStart_Click(null, null);
        }

        private void LoadSettings()
        {
            if(Settings.Default.device != "N/A")
            {
                IEnumerator enu = comboBoxDevices.Items.GetEnumerator();
                for (int i = 0; i < comboBoxDevices.Items.Count; i++)
                {
                    enu.MoveNext();
                    MMDevice d = (MMDevice)enu.Current;
                    if(d.ID == Settings.Default.device)
                    {
                        comboBoxDevices.SelectedIndex = i;
                        break;
                    }
                }
            }
            if(comboBoxDevices.SelectedIndex == -1)
            {
                comboBoxDevices.SelectedIndex = 0;
            }
            if(Settings.Default.port != "N/A")
            {
                if (comboBoxPort.Items.Contains(Settings.Default.port))
                {
                    comboBoxPort.SelectedItem = Settings.Default.port;
                }
            }
            if (comboBoxPort.SelectedIndex == -1)
            {
                comboBoxPort.SelectedIndex = 0;
            }
            comboBoxBaudRate.SelectedIndex = Settings.Default.baudRate;
            comboBoxSampleRate.SelectedIndex = Settings.Default.sampleRate;
            numericUpDownRefreshRate.Value = Settings.Default.refreshRate;
            numericUpDownSensitivity.Value = Settings.Default.sensitivity;
            if (Settings.Default.minimized) this.WindowState = FormWindowState.Minimized;
        }

        private void ComboBoxSampleRate_SelectedIndexChanged(object sender, EventArgs e)
        {
            Settings.Default.sampleRate = comboBoxSampleRate.SelectedIndex;
            Settings.Default.Save();
        }

        private void ComboBoxDevices_SelectedIndexChanged(object sender, EventArgs e)
        {
            Settings.Default.device = ((MMDevice)comboBoxDevices.SelectedItem).ID;
            Settings.Default.Save();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (comboBoxDevices.SelectedItem != null)
            {
                MMDevice device = device = (MMDevice)comboBoxDevices.SelectedItem;
                progressBarVol.Value = (int)Math.Round(device.AudioMeterInformation.MasterPeakValue * 100);
                double[] data = al.GetData();
                if (lastData == null || !data.SequenceEqual(lastData))
                {
                    lastData = new double[data.Length];
                    data.CopyTo(lastData, 0);
                    if (this.WindowState != FormWindowState.Minimized)
                    {
                        int ph = (int)Math.Round(data[2] * sensitivity);
                        int pm = (int)Math.Round(data[1] * sensitivity);
                        int pl = (int)Math.Round(data[0] * sensitivity);
                        progressBarHigh.Value = ph <= 100 ? ph : 100;
                        progressBarMid.Value = pm <= 100 ? pm : 100;
                        progressBarLow.Value = pl <= 100 ? pl : 100;
                    }
                    int sh = (int)Math.Round(data[2] * sensitivity * 2.5);
                    int sm = (int)Math.Round(data[1] * sensitivity * 2.5);
                    int sl = (int)Math.Round(data[0] * sensitivity * 2.5);
                    if (sh > 255) sh = 255;
                    if (sm > 255) sm = 255;
                    if (sl > 255) sl = 255;
                    try
                    {
                        port.Write(sl.ToString() + " " + sm.ToString() + " " + sh.ToString() + "|");
                    }
                    catch (Exception ex)
                    {
                        timer.Enabled = false;
                        MessageBox.Show("Could not write to port!", "ERROR");
                        Application.Exit();
                    }
                }
            }
        }

        private void ButtonStart_Click(object sender, EventArgs e)
        {
            bool hasStarted = (buttonStart.Text != "Start");
            comboBoxDevices.Enabled = hasStarted;
            comboBoxSampleRate.Enabled = hasStarted;
            comboBoxPort.Enabled = hasStarted;
            comboBoxBaudRate.Enabled = hasStarted;
            if (buttonStart.Text == "Start")
            {
                Start();
            }
            else
            {
                buttonStart.Text = "Start";
                timer.Enabled = false;
                progressBarHigh.Value = 0;
                progressBarMid.Value = 0;
                progressBarLow.Value = 0;
                Stop();
            }
            Settings.Default.start = (buttonStart.Text == "Stop");
            Settings.Default.Save();
        }

        private void Start()
        {
            MMDevice device = (MMDevice)comboBoxDevices.SelectedItem;
            int rate = int.Parse(comboBoxSampleRate.Text);
            try
            {
                al.StartListening(waveInDict[device.ID], rate);
                timer.Enabled = true;
                buttonStart.Text = "Stop";
                try
                {
                    port = new SerialPort(comboBoxPort.Text, int.Parse(comboBoxBaudRate.Text));
                    port.Open();
                }
                catch
                {
                    timer.Enabled = false;
                    MessageBox.Show("Could not connect to the serial port!", "ERROR");
                }
            }
            catch
            {
                MessageBox.Show("Could not record from audio device!", "ERROR");
            }
        }

        private void Stop()
        {
            al.StopListening();
            if (port.IsOpen)
            {
                port.Write("0 0 0");
                port.Close();
                port.Dispose();
            }
        }

        private void NumericUpDownRefreshRate_ValueChanged(object sender, EventArgs e)
        {
            timer.Interval = (int)Math.Round(numericUpDownRefreshRate.Value);
            Settings.Default.refreshRate = (int)Math.Round(numericUpDownRefreshRate.Value);
            Settings.Default.Save();
        }

        private void NumericUpDownSensitivity_ValueChanged(object sender, EventArgs e)
        {
            sensitivity = (int)Math.Round(numericUpDownSensitivity.Value);
            Settings.Default.sensitivity = (int)Math.Round(numericUpDownSensitivity.Value);
            Settings.Default.Save();
        }

        private void comboBoxPort_SelectedIndexChanged(object sender, EventArgs e)
        {
            Settings.Default.port = (String)comboBoxPort.SelectedItem;
            Settings.Default.Save();
        }

        private void comboBoxBaudRate_SelectedIndexChanged(object sender, EventArgs e)
        {
            Settings.Default.baudRate = comboBoxBaudRate.SelectedIndex;
            Settings.Default.Save();
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            bool mini = (this.WindowState == FormWindowState.Minimized);
            Settings.Default.minimized = mini;
            Settings.Default.Save();
            notifyIcon.Visible = mini;
            if (mini) this.Hide();
        }

        private void notifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        private void checkBoxStartup_CheckedChanged(object sender, EventArgs e)
        {
            RegistryKey rk = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            if (checkBoxStartup.Checked) rk.SetValue(Application.ProductName, Application.ExecutablePath);
            else rk.DeleteValue(Application.ProductName, false);
        }
    }
}
