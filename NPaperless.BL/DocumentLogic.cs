using NPaperless.BL.Interfaces;
using FluentValidation;
using NPaperless.BL.Entities;
﻿using Microsoft.AspNetCore.Http;


namespace NPaperless.BL {
	public class DocumentLogic : IDocumentLogic {
		private readonly IValidator<Document> _validator;
        public DocumentLogic(IValidator<Document> validator) {
            _validator = validator;
        }
		public string CreateDocument(Document newDocument, IEnumerable<IFormFile> documentFile){
			throw new NotImplementedException();
		}
		public string GetDocument(int id, int? page, bool? fullPerms){
			throw new NotImplementedException();
		}
		public bool DeleteDocument(int id){
			throw new NotImplementedException();
		}
		public string UpdateDocument(){
			throw new NotImplementedException();
		}
	}
}