using FluentValidation;
using NPaperless.BL.Entities;

namespace  NPaperless.BL {

    public class DocTagValidator : AbstractValidator<DocTag> {
        public DocTagValidator() {
        	RuleFor(docTag => docTag.Slug).NotEmpty();
            RuleFor(docTag => docTag.Name).NotEmpty();
            RuleFor(docTag => docTag.Color).NotEmpty();
            RuleFor(docTag => docTag.Match).NotEmpty();
            RuleFor(docTag => docTag.MatchingAlgorithm).NotEmpty();
            RuleFor(docTag => docTag.IsInsensitive).NotEmpty();
			RuleFor(docTag => docTag.IsInboxTag).NotEmpty();
            RuleFor(docTag => docTag.DocumentCount).NotEmpty();
        }
    }
}