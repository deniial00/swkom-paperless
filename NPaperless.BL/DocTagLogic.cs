using NPaperless.BL.Interfaces;
using FluentValidation;
using NPaperless.BL.Entities;

namespace NPaperless.BL {
	public class DocTagLogic : IDocTagLogic {
		private readonly IValidator<DocTag> _validator;
        public DocTagLogic(IValidator<DocTag> validator) {
            _validator = validator;
        }
		public string CreateDocTag(){
			throw new NotImplementedException();
		}
		public string GetDocTag(){
			throw new NotImplementedException();
		}
		public bool DeleteDocTag(int id){
			throw new NotImplementedException();
		}
		public string UpdateDocTag(){
			throw new NotImplementedException();
		}
	}
}