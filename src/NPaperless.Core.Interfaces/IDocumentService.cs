using Microsoft.AspNetCore.Http;
using NPaperless.Core.Entities;

namespace NPaperless.Core.Interfaces;

public interface IDocumentService
{
    public abstract Document ProcessDocument(IFormFile file);
}