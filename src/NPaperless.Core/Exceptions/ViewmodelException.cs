using System.Runtime.Serialization;

namespace NPaperless.Core.Exceptions;

[Serializable]
public class ViewmodelException : Exception
{
    public ViewmodelException()
    {
    }

    public ViewmodelException(string? message) 
    : base(message)
    {
    }

    public ViewmodelException(string? message, Exception? innerException) 
    : base(message, innerException)
    {
    }

    protected ViewmodelException(SerializationInfo info, StreamingContext context) 
    : base(info, context)
    {
    }
}