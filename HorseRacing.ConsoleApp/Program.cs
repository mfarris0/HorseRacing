using System;
using System.IO;
using System.Collections.Generic;
using System.Configuration;
using HorseRacing.Domain;
using HorseRacing.Service;
using HorseRacing.Data;
using System.Linq;

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


        private static void Initialize()
        {
            _applicationTitle = ConfigurationManager.AppSettings[Constants.AppSettings.ApplicationTitle];

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
                HorseRacingDbContext horseRacingDbContext = new HorseRacingDbContext();
                HorseRacingRepository horseRacingRepository = new HorseRacingRepository(horseRacingDbContext);
                Console.WriteLine($"Importing file {file.FullName}");
                ImportTrack(horseRacingRepository, raceCardViewerViewModel.Track);
                ImportRaceTypes(horseRacingRepository, raceCardViewerViewModel.RaceTypeLookup);
                ImportDistances(horseRacingRepository, raceCardViewerViewModel.DistanceLookup);
                ImportRaceSurfaces(horseRacingRepository, raceCardViewerViewModel.RaceSurfaceLookup);
                ImportRaceDay(horseRacingRepository, raceCardViewerViewModel.RaceDay);
                ImportRawRaces(horseRacingRepository, raceCardViewerViewModel.RaceCard, raceCardViewerViewModel);

                Console.WriteLine();
            }
        }


        private static void ImportTrack(HorseRacing.Data.HorseRacingRepository horseRacingRepository, Track track)
        {
            var dto = CreateTrackDto(track);
            TrackService trackService = new TrackService(horseRacingRepository);
            trackService.Add(dto);
        }

        private static void ImportRaceTypes(HorseRacingRepository horseRacingRepository, Dictionary<string, RaceType> raceTypeLookup)
        {
            foreach (var raceType in raceTypeLookup)
            {
                var dto = CreateRaceTypeDto(raceType.Value);
                RaceTypeService raceTypeService = new RaceTypeService(horseRacingRepository);
                raceTypeService.Add(dto);
            }
        }

        private static void ImportDistances(HorseRacingRepository horseRacingRepository, Dictionary<string, Distance> distanceLookup)
        {
            foreach (var distance in distanceLookup)
            {
                var dto = CreateDistanceDto(distance.Value);
                DistanceService distanceService = new DistanceService(horseRacingRepository);
                distanceService.Add(dto);
            }
        }

        private static void ImportRaceSurfaces(HorseRacingRepository horseRacingRepository, Dictionary<string, RaceSurface> raceSurfaceLookup)
        {
            Console.WriteLine($"Importing race surfaces...");
            foreach (var raceSurface in raceSurfaceLookup)
            {
                Console.WriteLine($"...{raceSurface.Value}");
                var dto = CreateRaceSurfaceDto(raceSurface.Value);
                RaceSurfaceService raceSurfaceService = new RaceSurfaceService(horseRacingRepository);
                raceSurfaceService.Add(dto);
            }
        }

        private static void ImportRaceDay(HorseRacing.Data.HorseRacingRepository horseRacingRepository, RaceDay raceDay)
        {
            var dto = CreateRaceDayDto(raceDay);
            RaceDayService raceDayService = new RaceDayService(horseRacingRepository);
            dto = raceDayService.Add(dto);
            raceDay.Id = dto.Id;
        }

        private static void ImportRawRaces(HorseRacing.Data.HorseRacingRepository horseRacingRepository, List<RawRace> rawRaces, RaceCardViewerViewModel raceCardViewerViewModel)
        {
            foreach (var rawRace in rawRaces)
            {
                Console.WriteLine($"Importing Race {rawRace.Id}...");
                rawRace.DistanceId = raceCardViewerViewModel.DistanceLookup.Where(r => r.Value.BRISCode == rawRace.Distance.BRISCode).FirstOrDefault().Value.Id;
                rawRace.RaceSurfaceId = raceCardViewerViewModel.RaceSurfaceLookup.Where(r => r.Value.BRISCode == rawRace.RaceSurface.BRISCode).FirstOrDefault().Value.Id;
                rawRace.RaceTypeId = raceCardViewerViewModel.RaceTypeLookup.Where(r => r.Value.BRISCode == rawRace.RaceType.BRISCode).FirstOrDefault().Value.Id;
                rawRace.RaceDayId = raceCardViewerViewModel.RaceDay.Id;
                var dto = CreateRawRaceDto(rawRace);
                RawRaceService rawRaceService = new RawRaceService(horseRacingRepository);
                rawRaceService.Add(dto);

                ImportRawRaceHorses(horseRacingRepository, rawRace);
            }
        }

        private static void ImportRawRaceHorses(HorseRacingRepository horseRacingRepository, RawRace rawRace)
        {
            Console.WriteLine($"...getting horses for race {rawRace.Id}");
            foreach (var horse in rawRace.RaceHorseList)
            {
                Console.WriteLine($"...importing horse {horse.HorseName}");
                var dto = CreateRawRaceHorseDto(horse);
                RawRaceHorseService service = new RawRaceHorseService(horseRacingRepository);
                service.Add(dto);
            }
        }

        private static DTO.Track CreateTrackDto(Track track)
        {
            DTO.Track dto = null;
            if (track != null)
            {
                dto = new DTO.Track
                {
                    Id = track.Id,
                    BRISCode = track.BRISCode,
                    Name = track.Name
                };
            }
            return dto;
        }

        private static DTO.RaceType CreateRaceTypeDto(RaceType raceType)
        {
            DTO.RaceType dto = null;
            if (raceType != null)
            {
                dto = new DTO.RaceType
                {
                    Id = raceType.Id,
                    BRISCode = raceType.BRISCode,
                    Name = raceType.Name
                };
            }
            return dto;
        }

        private static DTO.Distance CreateDistanceDto(Distance distance)
        {
            DTO.Distance dto = null;
            if (distance != null)
            {
                dto = new DTO.Distance
                {
                    Id = distance.Id,
                    BRISCode = distance.BRISCode,
                    Name = distance.Name
                };
            }
            return dto;
        }

        private static DTO.RaceSurface CreateRaceSurfaceDto(RaceSurface raceSurface)
        {
            DTO.RaceSurface dto = null;
            if (raceSurface != null)
            {
                dto = new DTO.RaceSurface
                {
                    Id = raceSurface.Id,
                    BRISCode = raceSurface.BRISCode,
                    Name = raceSurface.Name
                };
            }
            return dto;
        }

        private static DTO.RaceDay CreateRaceDayDto(RaceDay raceDay)
        {
            DTO.RaceDay dto = null;
            if (raceDay != null)
            {
                dto = new DTO.RaceDay
                {
                    Id = raceDay.Id,
                    TrackId = raceDay.Track.Id,
                    TrackCode = raceDay.TrackCode,
                    RaceDate = (DateTime)raceDay.RaceDate,
                    RaceDateString = raceDay.RaceDateString,
                    RaceDayIdString = raceDay.RaceDayIdString
                };
            }
            return dto;
        }

        private static DTO.RawRace CreateRawRaceDto(RawRace data)
        {
            DTO.RawRace dto = null;
            if (data != null)
            {
                dto = new DTO.RawRace
                {
                    Id = data.Id,
                    RaceDayId = data.RaceDayId,
                    RaceNumber = data.RaceNumber,
                    DistanceId = data.DistanceId,
                    RaceSurfaceId = data.RaceSurfaceId,
                    Purse = data.Purse,
                    Classification = data.Classification,
                    Conditions = data.Conditions,
                    RaceTypeId = data.RaceTypeId,
                    RaceDayIdString = data.RaceDayIdString
                };
            }

            return dto;
        }

        private static DTO.RawRaceHorse CreateRawRaceHorseDto(RawRaceHorse rawRaceHorse)
        {
            DTO.RawRaceHorse dto = null;
            if (rawRaceHorse != null)
            {
                dto = new DTO.RawRaceHorse
                {
                    Id = rawRaceHorse.Id,
                    PostPosition = rawRaceHorse.PostPosition,
                    HorseName = rawRaceHorse.HorseName,
                    MorningLineOdds = rawRaceHorse.MorningLineOdds,
                    JockeyName = rawRaceHorse.JockeyName,
                    WeightCarried = rawRaceHorse.WeightCarried,
                    TrainerName = rawRaceHorse.TrainerName,
                    RawRaceId = rawRaceHorse.RawRaceId
                };
            }
            return dto;
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
