using System;
using System.Collections.Generic;
using System.Text;

namespace SpriteAnimator
{
	public class OpenGLConfiguration
	{
		public int MajorVersion
		{
			get { return majorVersion; }
			set {
				majorVersion = value;
				reloadAbilities();
			}
		}

		public int MinorVersion
		{
			get { return minorVersion; }
			set {
				minorVersion = value;
				reloadAbilities();
			}
		}

		public bool BlendingEquationsAreSupported
		{
			get { return blendingEquationsAreSupported; }
			set { blendingEquationsAreSupported = value; }
		}

		public bool SeparateBlendingEquationsAreSupported
		{
			get { return separateBlendingEquationsAreSupported; }
			set { separateBlendingEquationsAreSupported = value; }
		}

		public bool SeparateBlendingFunctionsAreSupported
		{
			get { return separateBlendingFunctionsAreSupported; }
			set { separateBlendingFunctionsAreSupported = value; }
		}

		public bool NewFrameBuffersAreSupported
		{
			get { return newFrameBuffersAreSupported; }
			set { newFrameBuffersAreSupported = value; }
		}

		public bool OnlyBlendFunctionIsSupported
		{
			get { return onlyBlendFunctionIsSupported; }
			set { onlyBlendFunctionIsSupported = value; }
		}

		public int MaximumTextureSize
		{
			get { return maximumTextureSize; }
			set { maximumTextureSize = value; }
		}

		// Queried. Default: oldest production.
		private int majorVersion = 0;
		private int minorVersion = 9;
		// glBlendEquation at 1.4
		private bool blendingEquationsAreSupported = false;
		// glBlendEquationSeparate at 1.5
		private bool separateBlendingEquationsAreSupported = false;
		// glBlendFuncSeparate at 2.0
		private bool separateBlendingFunctionsAreSupported = false;
		// glBindFramebuffer at 3.0
		private bool newFrameBuffersAreSupported = false;
		//
		private int maximumTextureSize = 4096;
		// Derived.
		private bool onlyBlendFunctionIsSupported = true;

		public OpenGLConfiguration() { }

		public void setMajorMinorVersion(int major, int minor) {
			this.majorVersion = major;
			this.minorVersion = minor;
			reloadAbilities();
		}

		private void reloadAbilities() {
			// Blend Equation < 1.4
			blendingEquationsAreSupported = (majorVersion < 0 || minorVersion < 4) ? false : true;
			// Blend Equation Separate < 1.5
			separateBlendingEquationsAreSupported = (majorVersion < 0 || minorVersion < 5) ? false : true;
			// Blend Func Separate < 2.0
			separateBlendingFunctionsAreSupported = (majorVersion < 2) ? false : true;
			// Bind Framebuffer < 3.0
			newFrameBuffersAreSupported = (majorVersion < 3) ? false : true;
			// If controlling the blending equation(s) is not allowed, true. Otherwise, false.
			onlyBlendFunctionIsSupported = (!blendingEquationsAreSupported && !separateBlendingEquationsAreSupported) ? true : false;
		}
	}
}
