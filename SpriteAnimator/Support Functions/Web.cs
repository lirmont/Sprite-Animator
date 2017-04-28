using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Web;
using System.Security.Cryptography;

namespace SpriteAnimator
{
	partial class SupportFunctions
	{
		public static byte[] GetParameterBytes(string Parameters)
		{
			return Encoding.ASCII.GetBytes(Parameters);
		}

		public static string HttpPost(string URI, string Parameters, string authInfo = null)
		{
			Uri thisUri = new Uri(URI);
			WebRequest req = WebRequest.Create(thisUri);
			//Add these, as we're doing a POST
			req.ContentType = "application/x-www-form-urlencoded";
			req.Method = "POST";
			if (authInfo != null)
			{
				authInfo = string.Format("Basic {0}", Convert.ToBase64String(Encoding.Default.GetBytes(authInfo)));
				req.Headers["Authorization"] = authInfo;
			}
			//We need to count how many bytes we're sending. Post'ed Faked Forms should be name=value&
			byte[] bytes = GetParameterBytes(Parameters);
			req.ContentLength = bytes.Length;
			try
			{
				System.IO.Stream os = req.GetRequestStream();
				os.Write(bytes, 0, bytes.Length); //Push it out there
				os.Close();
				//
				System.Net.WebResponse resp = req.GetResponse();
				if (resp == null) return null;
				System.IO.StreamReader sr = new System.IO.StreamReader(resp.GetResponseStream());
				return HttpUtility.UrlDecode(sr.ReadToEnd().Trim());
			}
			catch (Exception) { }
			return null;
		}

		// Hash an input string and return the hash as a 32 character hexadecimal string.
		public static string GetMD5Hash(string input)
		{
			// Create a new instance of the MD5CryptoServiceProvider object.
			MD5 md5Hasher = MD5.Create();
			// Convert the input string to a byte array and compute the hash.
			byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(input));
			// Create a new Stringbuilder to collect the bytes and create a string.
			StringBuilder sBuilder = new StringBuilder();
			// Loop through each byte of the hashed data and format each one as a hexadecimal string.
			for (int i = 0; i < data.Length; i++)
			{
				sBuilder.Append(data[i].ToString("x2"));
			}
			// Return the hexadecimal string.
			return sBuilder.ToString();
		}
	}
}
