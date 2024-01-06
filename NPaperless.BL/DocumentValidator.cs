using FluentValidation;
using NPaperless.BL.Entities;

namespace  NPaperless.BL {

    public class DocumentValidator : AbstractValidator<Document> {
        public DocumentValidator() {
			RuleFor(document => document.Correspondent).NotEmpty();
            RuleFor(document => document.DocumentType).NotEmpty();
            RuleFor(document => document.StoragePath).NotEmpty();
            RuleFor(document => document.Title).NotEmpty();
            RuleFor(document => document.Content).NotEmpty();
            RuleFor(document => document.Tags).NotEmpty();
			RuleFor(document => document.Created).NotEmpty();
            RuleFor(document => document.CreatedDate).NotEmpty();
            RuleFor(document => document.Modified).NotEmpty();
            RuleFor(document => document.Added).NotEmpty();
            RuleFor(document => document.ArchiveSerialNumber).NotEmpty();
            RuleFor(document => document.OriginalFileName).NotEmpty();
			RuleFor(document => document.ArchivedFileName).NotEmpty();
        }
    }
}