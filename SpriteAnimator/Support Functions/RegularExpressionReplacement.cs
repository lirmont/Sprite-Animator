namespace SpriteAnimator
{
	public class RegularExpressionReplacement
	{
		private string regularExpression;
		private string replacementText;
		private bool caseSensitive;

		public string RegularExpression
		{
			get { return regularExpression; }
			set { regularExpression = value; }
		}

		public string ReplacementText
		{
			get { return replacementText; }
			set { replacementText = value; }
		}

		public bool CaseSensitive
		{
			get { return caseSensitive; }
			set { caseSensitive = value; }
		}

		public RegularExpressionReplacement(string regularExpression, string replacementText, bool caseSensitive)
		{
			this.regularExpression = regularExpression;
			this.replacementText = replacementText;
			this.caseSensitive = caseSensitive;
		}
	}
}
