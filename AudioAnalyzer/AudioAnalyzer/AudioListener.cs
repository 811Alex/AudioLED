using NAudio.CoreAudioApi;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioAnalyzer
{
    class AudioListener
    {
        private int lowLimit;
        private int midLimit;
        private readonly int bufferSize;
        private BufferedWaveProvider bwp;
        private WaveIn wi;
        private int rate;

        public AudioListener(int lowLimit, int midLimit, int bufferSize)
        {
            setLowLimit(lowLimit);
            setMidLimit(midLimit);
            this.bufferSize = bufferSize;
        }

        public void setLowLimit(int lowLimit)
        {
            this.lowLimit = lowLimit;
        }

        public void setMidLimit(int midLimit)
        {
            this.midLimit = midLimit;
        }

        public void StartListening(int deviceID, int rate)
        {
            this.rate = rate;
            wi = new WaveIn
            {
                DeviceNumber = deviceID,
                WaveFormat = new NAudio.Wave.WaveFormat(rate, 1),
                BufferMilliseconds = (int)((double)bufferSize / (double)rate * 1000.0)
            };
            wi.DataAvailable += new EventHandler<WaveInEventArgs>(AudioDataAvailable);
            bwp = new BufferedWaveProvider(wi.WaveFormat)
            {
                BufferLength = bufferSize * 2,
                DiscardOnBufferOverflow = true
            };
            wi.StartRecording();
        }

        public void StopListening()
        {
            wi.StopRecording();
            wi.Dispose();
        }

        private void AudioDataAvailable(object sender, WaveInEventArgs e)
        {
            bwp.AddSamples(e.Buffer, 0, e.BytesRecorded);
        }

        public double[] GetData()
        {
            var audioBytes = new byte[bufferSize];
            bwp.Read(audioBytes, 0, bufferSize);

            if (audioBytes.Length == 0)
                return new double[] {0, 0, 0};
            if (audioBytes[bufferSize - 2] == 0)
                return new double[] { 0, 0, 0 };

            int BYTES_PER_BIN = 2;

            int binCount = audioBytes.Length / BYTES_PER_BIN;

            double[] pcm = new double[binCount];
            double[] fftReal = new double[binCount / 2]; // we only care about the first half of the bins
            double[] fft;

            for (int i = 0; i < binCount; i++)
            {
                Int16 val = BitConverter.ToInt16(audioBytes, i * 2);
                pcm[i] = (double)(val) / Math.Pow(2, 16) * 200.0;
            }
            fft = FFT(pcm);
            Array.Copy(fft, fftReal, fftReal.Length);
            double l = 0, m = 0, h = 0;
            double multiplier = rate / fft.Length;
            for (int i = 0; i < fftReal.Length; i++)
            {
                double frequency = i * multiplier;
                if (frequency < lowLimit) l += fftReal[i];
                else if (frequency < midLimit) m += fftReal[i];
                else h += fftReal[i];
            }
            return new double[] { l, m, h };
        }
        private double[] FFT(double[] data)
        {
            double[] fft = new double[data.Length];
            System.Numerics.Complex[] fftComplex = new System.Numerics.Complex[data.Length];
            for (int i = 0; i < data.Length; i++)
                fftComplex[i] = new System.Numerics.Complex(data[i], 0.0);
            Accord.Math.FourierTransform.FFT(fftComplex, Accord.Math.FourierTransform.Direction.Forward);
            for (int i = 0; i < data.Length; i++)
                fft[i] = fftComplex[i].Magnitude;
            return fft;
        }
    }
}
