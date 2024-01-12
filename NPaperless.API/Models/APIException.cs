using Microsoft.VisualBasic;
using System;

namespace NPaperless.API.DTOs {
	public class APIException : Exception {
		public APIException() : base() { }
		public APIException(string message) : base(message) { }
		public APIException(string message, Exception e) : base(message, e) { }
		//If there is extra error information that needs to be captured
		//create properties for them.

		private string strExtraInfo;
		public string ExtraErrorInfo
		{
			get
			{
				return strExtraInfo;
			}

			set
			{
				strExtraInfo = value;
			}
		}
	}
}