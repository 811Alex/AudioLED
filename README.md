# AudioAnalyzer
A simple program that analyzes a device's audio, on your computer, using FFT and sends related data to a serial port. The data is 3 numbers, corresponding to mids, highs and lows. 
# AudioLed
An arduino program that reads the data from the serial port and adjusts the brightness of 3 LEDs accordingly.

### notes
- AudioAnalyzer reads from input devices. You can get around that if you want to use an output device, like your speakers, by using software like VoiceMeeter.
- Borrowed some code from https://github.com/swharden/Csharp-Data-Visualization
