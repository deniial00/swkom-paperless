using System.Text.Json.Nodes;
using NPaperless.BL.Interfaces;

namespace NPaperless.BL.Interfaces {
	public interface IConfigApiLogic {
		public string GetUiSettings();
		public string CreateUiSettings();
	}
}