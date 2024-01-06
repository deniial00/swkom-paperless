using NPaperless.BL.Interfaces;
using FluentValidation;
using NPaperless.BL.Entities;

namespace NPaperless.BL {
	public class UserInfoLogic : IUserInfoLogic {
		private readonly IValidator<UserInfo> _validator;
        public UserInfoLogic(IValidator<UserInfo> validator) {
            _validator = validator;
        }
		
	}
}