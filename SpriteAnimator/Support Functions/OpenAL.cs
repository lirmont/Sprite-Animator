using System;
using System.Drawing;
using System.IO;
using System.Threading;
using OpenTK.Audio;

#pragma warning disable
namespace SpriteAnimator
{
	partial class SupportFunctions
	{
		// Sound-related
		public static bool soundDisabled = true;
		public static XRamExtension XRam = new XRamExtension();

		public delegate void SoundCreatedHandled(bool success, Sound sound);

		public static unsafe void generateSoundBuffers(string name = "0", string filename = @"Audio/406__TicTacShutUp__click_1_d.ogg", Color? color = null, string colorName = "", int imageWidth = 1024, SupportFunctions.SoundCreatedHandled handler = null)
		{
			if (color == null)
				color = Color.White;

			uint soundBuffer;
			int soundSource;

			AL.GenBuffers(1, out soundBuffer);
			AL.GenSources(1, out soundSource);

			if (XRam.IsInitialized) XRam.SetBufferMode(1, ref soundBuffer, XRamExtension.XRamStorage.Hardware); // optional

			if (File.Exists(filename) && !soundDisabled)
			{
				Thread decodeAudioThread = new Thread(new ThreadStart(delegate()
				{
					DecodeAudioFileAndPushToAudioContext(name, filename, color, colorName, handler, soundBuffer, soundSource, imageWidth: imageWidth);
				}));
				decodeAudioThread.Name = string.Format("Decode Audio: {0}", filename);
				decodeAudioThread.Start();
			}
			else {
				// Perform the handler on a unloaded sound.
				if (handler != null)
					handler(false, new Sound(name: name, filename: filename, colorName: colorName, color: color.Value));
			}
		}

		unsafe private static void DecodeAudioFileAndPushToAudioContext(string name, string filename, Color? color, string colorName, SupportFunctions.SoundCreatedHandled handler, uint soundBuffer, int soundSource, int imageWidth = 1024)
		{
			int totalSamples = 0, waveForm = 0;
			double lengthInSeconds = 0;
			bool success = true;
			// Return object.
			Sound thisSound = null;
			// OpenAL objects.
			AudioReader sound = null;
			AudioReader soundLines = null;
			// Handle file types: WAV, OGG.
			if (Path.GetExtension(filename) == ".wav")
			{
				sound = new AudioReader(filename);
				soundLines = new AudioReader(filename);
				/*
				 * Length in Seconds
				 */
				int size = 0, bits = 0, channels = 0, freq = 0;
				AL.GetBuffer(soundBuffer, ALGetBufferi.Size, out size);
				AL.GetBuffer(soundBuffer, ALGetBufferi.Bits, out bits);
				AL.GetBuffer(soundBuffer, ALGetBufferi.Channels, out channels);
				AL.GetBuffer(soundBuffer, ALGetBufferi.Frequency, out freq);
				lengthInSeconds = (size / channels / (bits / 8)) / freq;
				totalSamples = ((size * 8) / bits / channels);
			}
			else if (Path.GetExtension(filename) == ".ogg")
			{
				MemoryStream audioData = new MemoryStream(), backupData = new MemoryStream();
				OggDecoder.Decoder.Decode(new string[] { filename }, ref audioData, ref totalSamples, ref lengthInSeconds);
				backupData = new MemoryStream(audioData.ToArray());
				//
				sound = new AudioReader(audioData);
				soundLines = new AudioReader(backupData);
			}
			else
				success = false;
			// If the OpenAL sound data is available, then buffer it so that it can be played, generating the waveform's visualization. Otherwise, just make sure there is a Sound description to return (via delegate).
			if (sound != null)
			{
				//
				AL.BufferData(soundBuffer, sound.ReadToEnd());
				// Generate waveform image.
				SoundData s = soundLines.ReadSamples(totalSamples);
				Bitmap image = GetWaveFormBitmap(s, totalSamples, imageWidth: imageWidth);
				//
				if (AL.GetError() == ALError.NoError)
				{
					AL.Source(soundSource, ALSourcei.Buffer, (int)soundBuffer);
					thisSound = new Sound(name: name, filename: filename, colorName: colorName, soundBuffer: soundBuffer, soundSource: soundSource, totalSamples: totalSamples, lengthInSeconds: lengthInSeconds, waveForm: waveForm, waveFormData: image, color: color.Value);
				}
				else
				{
					success = false;
					thisSound = new Sound(name: name, filename: filename, colorName: colorName, totalSamples: totalSamples, lengthInSeconds: lengthInSeconds, waveForm: waveForm, waveFormData: image, color: color.Value);
				}
			}
			else
				thisSound = new Sound(name: name, filename: filename, colorName: colorName, color: color.Value);
			// Perform the handler.
			if (handler != null)
				handler(success, thisSound);
		}

		unsafe private static Bitmap GetWaveFormBitmap(SoundData s, int totalSamples, int imageWidth = 4096)
		{
			int columns = totalSamples / imageWidth;
			Bitmap image = new Bitmap(imageWidth, 128);
			using (Graphics lines = Graphics.FromImage(image))
			{
				for (int i = 0; i < imageWidth; i++)
				{
					int max = 0, min = 255;
					int rmsSum = 0;
					for (int r = 0; r < columns; r++)
					{
						if (s.Data.Length > columns * i + r)
						{
							byte value = s.Data[columns * i + r];
							if (value < min)
								min = value;
							if (value > max)
								max = value;
							rmsSum += value ^ 2;
						}
					}
					double rms = Math.Sqrt((1.0 / s.Data.Length) * rmsSum), avg = rmsSum / (double)columns / 255.0;
					lines.DrawLine(Pens.White, new Point(i, (int)(rms * image.Height)), new Point(i, (int)(avg * image.Height)));
				}
			}
			image.MakeTransparent(Color.Black);
			return image;
		}
	}
}
