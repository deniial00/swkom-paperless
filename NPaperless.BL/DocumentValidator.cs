using FluentValidation;
using NPaperless.BL.Entities;

namespace  NPaperless.BL {

    public class DocumentValidator : AbstractValidator<Document> {
        public DocumentValidator() {
			RuleFor(document => document.Correspondent).NotEmpty();
            RuleFor(document => document.DocumentType).NotEmpty();
            RuleFor(document => document.Title).NotEmpty();
            RuleFor(document => document.Tags).NotEmpty();
			RuleFor(document => document.Created).NotEmpty();
        }
    }
}