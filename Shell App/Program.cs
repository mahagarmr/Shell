namespace Shell
{
    internal static class Program
    {
        static void Main()
        {
            Shell shell = new Shell();
            shell.Run();
            Commands.PrintCommandHistory(shell.commandHistory);
        }

    }
}
