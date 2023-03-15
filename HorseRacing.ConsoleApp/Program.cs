using System;
using System.Configuration;
using System.IO;

namespace HorseRacing.ConsoleApp
{
    class Program
    {
        private static string _applicationTitle;
        private static string _exit = "";
        static void Main(string[] args)
        {
            Initialize();
            ImportData();

            DisplayExitPrompt();
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

        private static void ImportData()
        {
            DirectoryManager directoryManager = new DirectoryManager(_applicationTitle);
            var dataFiles = directoryManager.DataFileDirectory.GetFiles("*.dat");
            //DisplayDataFileList(dataFiles);

            //---------------------------------------------------------------
            LoadData(dataFiles);
         
        }

        private static void LoadData(FileInfo[] dataFiles)
        {
            //foreach (var file in dataFiles)
            //{
            //    LoadFile(file);
            //}

            var file = dataFiles[0];
            LoadFile(file);
        }

        private static void LoadFile(FileInfo file)
        {
            RaceCardViewerViewModel raceCardViewerViewModel = new RaceCardViewerViewModel();
            RaceCardViewerViewModelManager manager = new RaceCardViewerViewModelManager();
            manager.Load(file, raceCardViewerViewModel);

            DisplayRaceList(raceCardViewerViewModel);
        }

        private static void DisplayRaceList(RaceCardViewerViewModel raceCardViewerViewModel)
        {
            foreach (var race in raceCardViewerViewModel.RaceCard)
            {
                Console.WriteLine(race.ToString());
            }
        }

        private static void DisplayDataFileList(FileInfo[] dataFiles)
        {
            foreach (var file in dataFiles)
            {
                Console.WriteLine($"{file.FullName}");
            }
        }


    }
}
