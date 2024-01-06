using NPaperless.BL.Interfaces;
using FluentValidation;
using NPaperless.BL.Entities;

namespace NPaperless.BL {
	public class CorrespondentLogic : ICorrespondentLogic {
        private readonly IValidator<Correspondent> _validator;
        public CorrespondentLogic(IValidator<Correspondent> validator) {
            _validator = validator;
        }
		
		public string CreateCorrespondent(){
			throw new NotImplementedException();
		}
		public string GetCorrespondent(){
			throw new NotImplementedException();
		}
		public bool DeleteCorrespondent(int id){
			throw new NotImplementedException();
		}
		public string UpdateCorrespondent(){
			throw new NotImplementedException();
		}
	}
}