namespace NPaperless.BL.Entities {
	public class Document
	{
		public Guid Id { get; set; }
		public int Correspondent { get; set; }
		public string? DocumentType { get; set; }
		public int StoragePath { get; set; }
		public string? Title { get; set; }
		public readonly byte[] _content;
		public List<int>? Tags { get; set; }
		public DateTime Created { get; set; }
		public DateTime CreatedDate { get; set; }
		public DateTime Modified { get; set; }
		public DateTime Added { get; set; }
		public string? ArchiveSerialNumber { get; set; }
		public string? OriginalFileName { get; set; }
		public string? ArchivedFileName { get; set; }
		public Document(byte[] stream)
		{
			try {
				_content = stream;
			} catch (ArgumentException e) {
				throw new DocumentNotReadableException("Could not get bytes",stream, e);
			}
		}

		public Document(byte[] stream, string contentType, string fileName)
		: this(stream)
		{
			if (contentType is null)
				throw new NullReferenceException("Could not set contentType");
			if (fileName is null)
				throw new NullReferenceException("Could not set fileName");
			
			DocumentType = contentType; // hmm auch nd dasselbe => hab hier den typ auf string gemacht
		
		}

		public ReadOnlyMemory<byte> ToBytes()
		{
			return _content;
		}
	}

	public class DocumentNotReadableException : Exception
	{
		public readonly byte[]? _stream;
		public DocumentNotReadableException(string message, Exception inner) : base(message, inner) { }
		public DocumentNotReadableException(string? message, byte[]? stream, Exception? innerException) : base(message, innerException)
		{
			_stream = stream;
		}
	}
}