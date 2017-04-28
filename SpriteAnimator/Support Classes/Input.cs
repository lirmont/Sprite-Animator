using System;
using System.Collections.Generic;
using System.Text;

namespace SpriteAnimator
{
	class Input
	{
		public enum InputType
		{
			Keyboard,
			Mouse
		}

		public delegate void Handler(Input i);

		private bool isActivated = false;
		public bool firstFireHandled = false;
		public Handler handler = null, finallyHandler = null;
		private int activatedStart = 0;
		public int activatedDuration = 0;
		public InputType type = InputType.Keyboard;
		public string signature = "no-signature";

		public Input(object signature = null, InputType type = InputType.Keyboard, Handler handler = null, Handler finallyHandler = null)
		{
			if (signature != null)
			{
				if (signature is string)
					this.signature = signature as string;
				else if (signature is System.Windows.Forms.Keys)
				{
					type = InputType.Keyboard;
					this.signature = string.Format("{0}-key", signature);
				}
				else if (signature is System.Windows.Forms.MouseButtons)
				{
					type = InputType.Mouse;
					this.signature = string.Format("{0}", signature);
				}
			}
			this.type = type;
			if (handler != null)
				this.handler = handler;
			if (finallyHandler != null)
				this.finallyHandler = finallyHandler;
		}

		public bool activate()
		{
			if (!this.isActivated)
			{
				this.isActivated = true;
				this.activatedStart = Environment.TickCount & Int32.MaxValue;
				return true;
			}
			else
				return false;
		}

		public bool deactivate(bool suppressFinallyHandler = false)
		{
			if (this.isActivated)
			{
				this.activatedDuration = (Environment.TickCount & Int32.MaxValue) - activatedStart;
				this.isActivated = false;
				if (!suppressFinallyHandler && finallyHandler != null)
					this.finallyHandler(this);
				this.activatedStart = 0;
				this.firstFireHandled = false;
				return true;
			}
			else
				return false;
		}

		public bool isDragging()
		{
			if (type != InputType.Mouse)
				return false;
			else if (isActivated && (activatedStart + 10) < (Environment.TickCount & Int32.MaxValue))
				return true;
			else
				return false;
		}

		public bool isActive()
		{
			return isActivated;
		}

		public bool firstResponseNotHandledByThisYet()
		{
			if (!this.firstFireHandled)
			{
				this.firstFireHandled = true;
				return true;
			}
			else
				return false;
		}
	}
}
