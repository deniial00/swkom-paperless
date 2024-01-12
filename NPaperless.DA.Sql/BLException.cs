using Microsoft.VisualBasic;

namespace NPaperless.DA.Sql {
	public class DAException : Exception {
		public DAException() : base() { }
		public DAException(string message) : base(message) { }
		public DAException(string message, Exception e) : base(message, e) { }
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