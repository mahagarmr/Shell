using System.Diagnostics;

namespace Shell
{
    static public class Commands
    {
        static public void ListFiles(string currentDirectory)
        {
            string[] files = Directory.GetFiles(currentDirectory);
            foreach (string file in files)
            {
                Console.WriteLine(file);
            }
        }

        static public void ChangeDirectory(ref string currentDirectory, string directory)
        {
            string newDirectory = Path.Combine(currentDirectory, directory);
            if (Directory.Exists(newDirectory))
            {
                currentDirectory = newDirectory;
            }
            else
            {
                Console.WriteLine("Directory not found");
            }
        }

        static public void CreateDirectory(string currentDirectory, string directory)
        {
            Directory.CreateDirectory(Path.Combine(currentDirectory, directory));
        }

        static public void DeleteFile(string currentDirectory, string file)
        {
            string filePath = Path.Combine(currentDirectory, file);
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
            else
            {
                Console.WriteLine("File not found");
            }
        }


        static public void PrintFile(string currentDirectory, string file)
        {
            string filePath = Path.Combine(currentDirectory, file);
            if (File.Exists(filePath))
            {
                string fileContent = File.ReadAllText(filePath);
                Console.WriteLine(fileContent);
            }
            else
            {
                if (file != null) { Console.WriteLine(file); }
                else Console.WriteLine("File not found");
            }
        }

        static public void PrintCommandHistory(List<string> commandHistory)
        {
            foreach (string command in commandHistory)
            {
                Console.WriteLine(command);
            }
        }

        static public void RunExternalProgram(string currentDirectory, string command)
        {
            string filePath = Path.Combine(currentDirectory, command);
            if (File.Exists(filePath))
            {
                ProcessStartInfo processInfo = new ProcessStartInfo(command);
                processInfo.WorkingDirectory = currentDirectory;
                processInfo.UseShellExecute = true;

                Process process = Process.Start(processInfo);
                process.WaitForExit();
            }
            else Console.WriteLine("File not found");
        }
    }
}
