namespace NPaperless.BL.Interfaces {
	public interface IDocumentTypeLogic {
		public string CreateDocumentType();
		public string GetDocumentType();
		public bool DeleteDocumentType(int id);
		public string UpdateDocumentType();
	}
}