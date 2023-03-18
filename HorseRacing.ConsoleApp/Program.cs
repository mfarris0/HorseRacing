using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;

namespace HorseRacing.ConsoleApp
{
    class Program
    {
        private static string _applicationTitle;

        static void Main(string[] args)
        {
            Initialize();
            Run();
            DisplayExitPrompt();
        }

        private static void Run()
        {
            //DisplayDataFiles();

            ImportFiles();
        }

        private static void DisplayExitPrompt()
        {
            Console.WriteLine();
            Console.WriteLine("Press any key to exit");
            Console.ReadLine();
        }

        private static void Initialize()
        {
            _applicationTitle = ConfigurationManager.AppSettings[Constants.AppSettings.ApplicationTitle];

        }

        private static void DisplayDataFiles()
        {
            var fileList = GetFileList();
            DisplayFileList(fileList);
        }

        private static IEnumerable<FileInfo> GetFileList()
        {
            DirectoryManager directoryManager = new DirectoryManager(_applicationTitle);
            var fileList = directoryManager.DataFileDirectory.GetFiles("*.dat");
            return fileList;
        }

        private static void DisplayFileList(IEnumerable<FileInfo> fileList)
        {
            foreach (var file in fileList)
            {
                Console.WriteLine($"{file.FullName}");
            }
        }

        private static void ImportFiles()
        {
            var manager = new RaceCardViewerViewModelManager();

            var fileList = GetFileList();
            foreach (var file in fileList)
            {
                ImportFile(manager, file);
            }
        }

        private static void ImportFile(RaceCardViewerViewModelManager manager, FileInfo file)
        {
            var raceCardViewerViewModel = manager.Load(file);
            if (raceCardViewerViewModel == null)
            {
                Console.WriteLine($"Unable to import file {file.FullName}");
            }
            else
            {
                Console.WriteLine($"Importing file {file.FullName}");
                DisplayRaceList(raceCardViewerViewModel);
                Console.WriteLine();
            }
        }

        private static void DisplayRaceList(RaceCardViewerViewModel raceCardViewerViewModel)
        {
            Console.WriteLine($"Race Day {raceCardViewerViewModel.RaceDay.RaceDate?.ToShortDateString()}  {raceCardViewerViewModel.RaceDay.Track.Name}");
            foreach (var race in raceCardViewerViewModel.RaceCard)
            {
                Console.WriteLine($"Race Number {race.RaceNumber}");
            }
        }

    }
}
