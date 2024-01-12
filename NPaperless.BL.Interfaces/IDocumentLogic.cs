using NPaperless.BL.Entities;
﻿using Microsoft.AspNetCore.Http;


namespace NPaperless.BL.Interfaces {
	public interface IDocumentLogic {
		public Task<bool> CreateDocument(Document newDocument, IEnumerable<IFormFile> documentFile);
		public Document GetDocument(int id, int? page, bool? fullPerms);
		public bool DeleteDocument(int id);
		public string UpdateDocument();
	}
}