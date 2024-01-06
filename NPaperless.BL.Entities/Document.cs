namespace NPaperless.BL.Entities {
	public class Document
	{
		public Guid Id { get; set; }
		public int Correspondent { get; set; }
		public string DocumentType { get; set; }
		public int StoragePath { get; set; }
		public string Title { get; set; }
		public readonly byte[] Content;
		public List<int> Tags { get; set; }
		public DateTime Created { get; set; }
		public DateTime CreatedDate { get; set; }
		public DateTime Modified { get; set; }
		public DateTime Added { get; set; }
		public string ArchiveSerialNumber { get; set; }
		public string OriginalFileName { get; set; }
		public string ArchivedFileName { get; set; }
	}
}