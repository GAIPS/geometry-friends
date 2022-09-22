using System;
using System.Diagnostics;

namespace GeometryFriendsAgents
{
    class PythonModule
    {
        private readonly string fileName = @"..\..\python\main.py";
        private readonly string pythonLocation = @"C:\Users\Ines Lobo\AppData\Local\Programs\Python\Python39\python.exe"; //change
        private Process p = null;
        public PythonModule()
        {
            p = new Process();

            //insert python location here
            p.StartInfo = new ProcessStartInfo(pythonLocation)
            {
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };
        }

        public String FilePython(String args)
        {
            p.StartInfo.Arguments = fileName + " " + args;
            p.Start();
            string output = p.StandardOutput.ReadToEnd();
            p.WaitForExit();

            //to see logs from python
            Console.WriteLine(output); 
            Console.ReadLine();

            String result = output;
            if (output.Length >= 4)
            {
                result = output.Substring(output.Length - 4);
            }

            return result;

        }
    }
}
