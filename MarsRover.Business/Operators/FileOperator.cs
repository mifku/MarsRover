using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace MarsRover.Business.Operators
{
    public class FileOperator
    {
        public string FilePath;
        public List<string> CurrentFile;
        public FileOperator(string filePath)
        {
            FilePath = filePath;
        }
        public FileOperator Load()
        {
            CurrentFile = File.ReadAllLines(FilePath).ToList();
            CurrentFile.RemoveAll(l => string.IsNullOrWhiteSpace(l));
            return this;
        }
        public bool ValidateInputFile()
        {
            if (CurrentFile.Count < 3) { return false; }
            else if (CurrentFile.First().Trim().Split(" ").Length != 2 || !CurrentFile.First().Replace(" ","").All(char.IsDigit)) { return false; }
            else if (CurrentFile.Where((item, index) =>index > 0 && index % 2 != 0).Any(l=> !ValidateDirectionLine(l))){ return false; }
            else if (CurrentFile.Where((item, index) => index > 0 && index % 2 == 0).Any(l => !ValideteCommandLine(l))) { return false; }

            return true;
        }
        private bool ValideteCommandLine(string line)
        {
            line = line.Trim();
            foreach (var item in Enums.GetValuesOfCommands())
            {
                line = line.Replace(item.ToString(), "");
            }
            return string.IsNullOrEmpty(line);
        }

        private bool ValidateDirectionLine(string line)
        {
            line = line.Trim();
            if (line.Split(" ").Length != 3) { return false; }
            else if (!Enums.GetNamesOfDirections().Contains(line.Last().ToString())) { return false; }
            else if (!line.Replace(" ", "").Substring(0, line.Replace(" ", "").Length - 1).All(char.IsDigit)) { return false; }
            else return true;

        }
    }
}
