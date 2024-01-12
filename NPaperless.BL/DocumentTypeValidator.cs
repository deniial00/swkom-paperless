using FluentValidation;
using NPaperless.BL.Entities;

namespace  NPaperless.BL {

    public class DocumentTypeValidator : AbstractValidator<DocumentType> {
        public DocumentTypeValidator() {
			RuleFor(documentType => documentType.Slug).NotEmpty();
            RuleFor(documentType => documentType.Name).NotEmpty();
            RuleFor(documentType => documentType.Match).NotEmpty();
            RuleFor(documentType => documentType.MatchingAlgorithm).NotEmpty();
            RuleFor(documentType => documentType.IsInsensitive).NotEmpty();
            RuleFor(documentType => documentType.DocumentCount).NotEmpty();
        }
    }
}