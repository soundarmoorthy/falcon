using System;
using System.IO;

namespace falcon.Falcon
{
    public class Context
    {
        public StageException Exception { get; set; }
        public Stream Stream { get; }
        public string FileName { get; }
        public string SourceDir { get; }
        public string SourceArchiveFile { get; }
        public string DestPath { get; }
        public Context(Stream stream, string sourcePath, string fileName)
        {
            this.Stream = stream;
            this.SourceDir = sourcePath;
            this.FileName = fileName;
            var uuid = Guid.NewGuid();
            DestPath = Path.Combine(sourcePath, uuid.ToString());
            SourceArchiveFile = Path.Combine(SourceDir, FileName);
        }
    }
}
