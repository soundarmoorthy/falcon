using System;
namespace falcon.Falcon
{
    public class StageException : Exception
    {
        readonly string stageName;
        public StageException(string stageName, Exception inner)
            : base($"Failed at Stage {stageName} with message {inner.Message}"
                  , inner)
        {
            this.stageName = stageName;
        }
    }
}
