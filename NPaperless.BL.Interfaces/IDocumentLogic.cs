using NPaperless.BL.Entities;
﻿using Microsoft.AspNetCore.Http;


namespace NPaperless.BL.Interfaces {
	public interface IDocumentLogic {
		public Task<bool> CreateDocument(Document newDocument, IEnumerable<IFormFile> documentFile);
		public Task<Stream> GetDocument(Guid guid);
		public bool DeleteDocument(Guid guid);
		public string UpdateDocument();
	}
}