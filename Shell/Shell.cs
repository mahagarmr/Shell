namespace Shell
{
    public class Shell
    {
        public string currentDirectory;
        public List<string> commandHistory;

        public Shell()
        {
            currentDirectory = Directory.GetCurrentDirectory();
            commandHistory = new List<string>();
        }

        public void Run()
        {
            while (true)
            {
                Console.Write($"{currentDirectory} ");
                string command = Console.ReadLine();

                if (command.Trim() == "") continue;

                commandHistory.Add(command);

                if (command == "exit") break;

                string[] commandParts = command.Split(' ');
                string commandName = commandParts[0];

                switch (commandName)
                {
                    case "ls":
                        Commands.ListFiles(currentDirectory);
                        break;
                    case "cd":
                        if (commandParts.Length <= 1) break;
                        Commands.ChangeDirectory(ref currentDirectory, commandParts[1]);
                        break;
                    case "mkdir":
                        if (commandParts.Length <= 1) break;
                        Commands.CreateDirectory(currentDirectory, commandParts[1]);
                        break;
                    case "rm":
                        if (commandParts.Length <= 1) break;
                        Commands.DeleteFile(currentDirectory, commandParts[1]);
                        break;
                    case "cat":
                        if (commandParts.Length <= 1) break;
                        Commands.PrintFile(currentDirectory, commandParts[1]);
                        break;
                    case "cat&":
                        if (commandParts.Length <= 1) break;
                        Thread backgroundThread = new Thread(()=>Commands.PrintFile(currentDirectory, commandParts[1]));
                        backgroundThread.IsBackground = true;
                        backgroundThread.Start();
                        backgroundThread.Join();

                        break;
                    default:
                        Commands.RunExternalProgram(currentDirectory, command);
                        break;
                }
            }
        }
    }
}