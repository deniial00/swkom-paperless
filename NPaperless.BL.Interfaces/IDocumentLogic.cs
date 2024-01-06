namespace NPaperless.BL.Interfaces {
	public interface IDocumentLogic {
		public string CreateDocument();
		public string GetDocument();
		public bool DeleteDocument(int id);
		public string UpdateDocument();
	}
}