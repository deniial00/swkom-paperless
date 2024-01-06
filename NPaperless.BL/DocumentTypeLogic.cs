using NPaperless.BL.Interfaces;
using FluentValidation;
using NPaperless.BL.Entities;

namespace NPaperless.BL {
	public class DocumentTypeLogic : IDocumentTypeLogic {
		private readonly IValidator<DocumentType> _validator;
        public DocumentTypeLogic(IValidator<DocumentType> validator) {
            _validator = validator;
        }
		public string CreateDocumentType(){
			throw new NotImplementedException();
		}
		public string GetDocumentType(){
			throw new NotImplementedException();
		}
		public bool DeleteDocumentType(int id){
			throw new NotImplementedException();
		}
		public string UpdateDocumentType(){
			throw new NotImplementedException();
		}
	}
}