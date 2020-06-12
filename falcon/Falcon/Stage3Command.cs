namespace falcon.Falcon
{
    internal class Stage3Command : Stage
    {
        public Stage3Command()
            : base("Deploy")
        {

        }

        /// <summary>
        /// Should use  the pubxml file in the deployment and 
        /// use MSDeploy to deploy the application
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        protected override int RunStage(Context context)
        {
            return 0;
        }
    }
}