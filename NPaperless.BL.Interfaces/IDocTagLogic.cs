namespace NPaperless.BL.Interfaces {
	public interface IDocTagLogic {
		public string CreateDocTag();
		public string GetDocTag();
		public bool DeleteDocTag(int id);
		public string UpdateDocTag();
	}
}