using FluentValidation;
using NPaperless.BL.Entities;

namespace NPaperless.BL {

    public class CorrespondentValidator : AbstractValidator<Correspondent> {
        public CorrespondentValidator() {
			RuleFor(correspondent => correspondent.Slug).NotEmpty();
            RuleFor(correspondent => correspondent.Name).NotEmpty();
            RuleFor(correspondent => correspondent.Match).NotEmpty();
            RuleFor(correspondent => correspondent.MatchingAlgorithm).NotEmpty();
            RuleFor(correspondent => correspondent.DocumentCount).NotEmpty();
            RuleFor(correspondent => correspondent.LastCorrespondence).NotEmpty();
        }
    }
}