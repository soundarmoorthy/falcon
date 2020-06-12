using System;
using System.Linq;
using System.Collections.Generic;

namespace falcon.Falcon
{
    public class Falcon
    {
        public static Falcon Instance { get; } = new Falcon();

        IEnumerable<Stage> stages;

        private Falcon()
        {
        }

        public bool Deploy(Context context)
        {
            stages = new List<Stage>()
            {
                new Stage1Copy(),
                new Stage2Unzip(),
                new Stage3Command(),
            };

            return stages.All(
                stage => stage.Run(context) == 0
                );
        }

    }
}
