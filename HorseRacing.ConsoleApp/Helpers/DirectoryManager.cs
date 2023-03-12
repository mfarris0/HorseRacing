using System;
using System.Configuration;
using System.IO;

namespace HorseRacing.ConsoleApp
{
    public class DirectoryManager
    {
        public DirectoryManager(string applicationTitle)
        {
            InitializeThis(applicationTitle);
        }

        private void InitializeThis(string applicationTitle)
        {
            SetMainDirectory(applicationTitle);
            SetDataFileDirectory();
            SetLogFileDirectory();
        }

        public DirectoryInfo MainDirectory { get; private set; }
        public DirectoryInfo DataFileDirectory { get; private set; }
        public DirectoryInfo LogFileDirectory { get; private set; }

        private void SetMainDirectory(string applicationTitle)
        {
            MainDirectory = new DirectoryInfo
                ($"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\\{applicationTitle}");
        }
        private void SetDataFileDirectory()
        {
            var dataFileDirectory = ConfigurationManager.AppSettings[Constants.AppSettings.DataFileDirectory];
            DataFileDirectory = new DirectoryInfo($"{MainDirectory.FullName}\\{dataFileDirectory}");
        }

        private void SetLogFileDirectory()
        {
            var logFileDirectory = ConfigurationManager.AppSettings[Constants.AppSettings.LogFileDirectory];
            LogFileDirectory = new DirectoryInfo($"{MainDirectory.FullName}\\{logFileDirectory}");
        }
    }
}
