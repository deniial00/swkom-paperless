namespace NPaperless.SA.Interfaces;
public interface IMinioService
{
    public Task UploadDocument(string objectName, Stream fileStream, string contentType);
    public Task<Stream> GetDocument(string objectName);
    public Task DeleteDocument(string objectName);
}