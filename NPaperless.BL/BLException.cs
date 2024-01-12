using Microsoft.VisualBasic;

namespace NPaperless.BL {
	public class BLException : Exception {
		public BLException() : base() { }
		public BLException(string message) : base(message) { }
		public BLException(string message, Exception e) : base(message, e) { }
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