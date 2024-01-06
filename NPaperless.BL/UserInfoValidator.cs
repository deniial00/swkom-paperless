using FluentValidation;
using NPaperless.BL.Entities;

namespace  NPaperless.BL {

    public class UserInfoValidator : AbstractValidator<UserInfo> {
        public UserInfoValidator() {
			RuleFor(correspondent => correspondent.Username).NotEmpty();
            RuleFor(correspondent => correspondent.Password).NotEmpty();
        }
    }
}