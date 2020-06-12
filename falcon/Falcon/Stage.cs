using System;

namespace falcon.Falcon
{
    public abstract class Stage
    {
        protected string name { get; private set; }
        protected Stage(string name)
        {
            this.name = name;
        }
        public int Run(Context context)
        {
            var code = RunStage(context);
            return code;
        }

        protected abstract int RunStage(Context context);
    }
}