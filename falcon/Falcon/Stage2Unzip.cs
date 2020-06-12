using System;
using System.IO;
using System.IO.Compression;

namespace falcon.Falcon
{
    public class Stage2Unzip : Stage
    {
        public Stage2Unzip() :
            base("Unzip")
        {
        }

        protected sealed override int RunStage(Context context)
        {
            return Unzip(context);
        }

        private int Unzip(Context context)
        {
            try
            {
                if (!Directory.Exists(context.DestPath))
                    Directory.CreateDirectory(context.DestPath);

                ZipFile.ExtractToDirectory(context.SourceArchiveFile,
                    context.DestPath);
                return 0;
            }
            catch (Exception ex)
            {
                context.Exception = new StageException("Unzip", ex);
                return -2;
            }
        }
    }
}
