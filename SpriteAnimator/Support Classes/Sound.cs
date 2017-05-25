using System;
using System.Drawing;
using OpenTK.Audio;

namespace SpriteAnimator
{
	public class Sound : IDisposable
	{
		public uint soundBuffer;
		public int soundSource, totalSamples;
		public double lengthInSeconds;
		public int waveForm;
		public Color color;
		public Bitmap waveFormData;
		public bool pushedToContext = false;
		public string name = "0", filename = "", colorName = "";

        // Make sure the object doesn't get disposed more than once.
        private bool disposedValue = false;

        public Sound(uint soundBuffer = 10000000, int soundSource = 10000000, int totalSamples = 0, double lengthInSeconds = 0, int waveForm = 0, Bitmap waveFormData = null, Color? color = null, string name = "0", string filename = "", string colorName = "")
		{
			// Required to store in XML:
			this.name = name;
			this.filename = filename;
			this.colorName = colorName;
			// Required to playback audio:
			this.soundBuffer = soundBuffer;
			this.soundSource = soundSource;
			this.totalSamples = totalSamples;
			this.lengthInSeconds = lengthInSeconds;
			// Required for displaying wave-form image:
			this.waveForm = waveForm;
			if (waveFormData != null)
				this.waveFormData = waveFormData;
			else
				this.waveFormData = new Bitmap(1, 1);
			if (color != null)
				this.color = color.Value;
			else
				this.color = Color.White;
		}

		public void PushToContext()
		{
			pushedToContext = true;
		}

		public void Play(int playXMilliseconds = -1)
		{
			if (playXMilliseconds >= 0)
			{
				System.Timers.Timer t = new System.Timers.Timer(Math.Max(0, Math.Min(lengthInSeconds * 1000, playXMilliseconds)));
				t.Elapsed += new System.Timers.ElapsedEventHandler(delegate(object nsender, System.Timers.ElapsedEventArgs ne)
				{
					AL.SourceStop(soundSource);
					AL.SourceRewind(soundSource);
					t.Enabled = false;
				});
				t.Enabled = true;
			}
			AL.SourcePlay(soundSource);
		}

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                // Dispose wave form image.
                if (disposing)
                    waveFormData.Dispose();
                // Don't do this more than once.
                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }
    }
}
