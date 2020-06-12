using System;
using System.IO;

namespace falcon.Falcon
{
    public class Stage1Copy : Stage
    {
        public Stage1Copy() :
            base("Copy")
        {
        }

        protected sealed override int RunStage(Context context)
        {
            return CopyFile(context);
        }

        private int CopyFile(Context context)
        {
            try
            {
                if (!Directory.Exists(context.SourceDir))
                    Directory.CreateDirectory(context.SourceDir);

                using (var zip = File.OpenWrite(context.SourceArchiveFile))
                {
                    context.Stream.CopyTo(zip);
                }
                return 0;
            }
            catch (Exception ex)
            {
                context.Exception = new StageException("Copy", ex);
                return -1;

            }
        }
    }
}
