using NPaperless.BL.Interfaces;
using FluentValidation;
using NPaperless.BL.Entities;

namespace NPaperless.BL {
	public class DocumentLogic : IDocumentLogic {
		private readonly IValidator<Document> _validator;
        public DocumentLogic(IValidator<Document> validator) {
            _validator = validator;
        }
		public string CreateDocument(){
			throw new NotImplementedException();
		}
		public string GetDocument(){
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