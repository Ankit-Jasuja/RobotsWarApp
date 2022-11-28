namespace RobotWarsLibrary.Executors.Interfaces
{
    public interface IExecutor
    {
        void Execute(string input);

        string regexPattern { get; set; }
    }
}
