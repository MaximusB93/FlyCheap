using System.Runtime.Serialization;

namespace FlyCheap;

public class ExceptionBot : Exception 
{
    public override Exception GetBaseException()
    {
        return base.GetBaseException();
    }

    public override void GetObjectData(SerializationInfo info, StreamingContext context)
    {
        base.GetObjectData(info, context);
    }

    public override string ToString()
    {
        return base.ToString();
    }

    public override string Message { get; }
}