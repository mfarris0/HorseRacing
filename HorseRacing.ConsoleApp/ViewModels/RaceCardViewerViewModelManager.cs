using HorseRacing.ConsoleApp.ImportManagers;
using HorseRacing.Domain;
using Microsoft.VisualBasic.FileIO;
using System;
using System.IO;

namespace HorseRacing.ConsoleApp
{
    public class RaceCardViewerViewModelManager
    {
        public RaceCardViewerViewModelManager()
        {

        }

        public void Load(FileInfo file, RaceCardViewerViewModel viewer)
        {
            TextFieldParser textFieldParser = GetTextFieldParser(file);
            int previousRaceNumber = 0;

            while (!textFieldParser.EndOfData)
            {
                var fields = textFieldParser.ReadFields();
                string tempRaceNumber = fields[2];
                LoadTrack(fields, viewer);
                if (int.TryParse(tempRaceNumber, out int currentRaceNumber))
                {
                    if (currentRaceNumber > previousRaceNumber)
                    {
                        if (currentRaceNumber == 1)
                        {
                            LoadRaceDay(fields, viewer);
                        }

                        var raceSurface = GetRaceSurface(fields, viewer);
                        var distance = GetDistance(fields, viewer);
                        var raceType = GetRaceType(fields, viewer);
                        AddRace(fields, viewer, raceSurface, distance, raceType);
                        previousRaceNumber = currentRaceNumber;
                    }
                    AddRaceHorse(fields, viewer, viewer.RaceCard[^1]);// ^1 gets last item in a list
                }
            }
        }

        private TextFieldParser GetTextFieldParser(FileInfo file)
        {
            TextFieldParser textFieldParser = new TextFieldParser(file.FullName)
            {
                TextFieldType = FieldType.Delimited,
                HasFieldsEnclosedInQuotes = true,
                Delimiters = new string[] { "," }
            };
            return textFieldParser;
        }

        private void LoadRaceDay(string[] fields, RaceCardViewerViewModel viewer)
        {
            var raceDayImportManager = new RaceDayImportManager(fields, viewer.Track);
            viewer.RaceDay = raceDayImportManager.CreateRaceDay();
        }

        private void LoadTrack(string[] fields, RaceCardViewerViewModel viewer)
        {
            var trackImportManager = new TrackImportManager(fields);
            viewer.Track = trackImportManager.CreateTrack();
        }

        private RaceSurface GetRaceSurface(string[] fields, RaceCardViewerViewModel viewer)
        {
            RaceSurfaceImportManager raceSurfaceImportManager = new RaceSurfaceImportManager(fields);
            var raceSurface = raceSurfaceImportManager.CreateRaceSurface();
            try
            {
                viewer.RaceSurfaceLookup.Add(raceSurface.Id, raceSurface);
            }
            catch (Exception)
            {
                //ignore; key already exists
            }
            return raceSurface;
        }

        private Distance GetDistance(string[] fields, RaceCardViewerViewModel viewer)
        {
            DistanceImportManager distanceImportManager = new DistanceImportManager(fields);
            var distance = distanceImportManager.CreateDistance();

            try
            {
                viewer.DistanceLookup.Add(distance.Id, distance);
            }
            catch (Exception)
            {
                //ignore; key already exists
            }
            return distance;
        }

        private RaceType GetRaceType(string[] fields, RaceCardViewerViewModel viewer)
        {
            RaceTypeImportManager raceTypeImportManager = new RaceTypeImportManager(fields);
            var raceType = raceTypeImportManager.CreateRaceType();
            try
            {
                viewer.RaceTypeLookup.Add(raceType.Id, raceType);
            }
            catch (Exception)
            {
                //ignore; key already exists
            }
            return raceType;

        }


        private void AddRace(string[] fields, RaceCardViewerViewModel raceCardViewer, RaceSurface raceSurface, Distance distance, RaceType raceType)
        {
            var rawRaceImportManager = new RawRaceImportManager(fields, raceCardViewer.RaceDay, raceType, distance, raceSurface);
            RawRace rawRace = rawRaceImportManager.CreateRawRace();
            raceCardViewer.RaceCard.Add(rawRace);
        }

        private void AddRaceHorse(string[] fields, RaceCardViewerViewModel viewer, RawRace rawRace)
        {
            var rawRaceHorseImportManager = new RawRaceHorseImportManager(fields, rawRace);
            var rawRaceHorse = rawRaceHorseImportManager.CreateRawRaceHorse();
            rawRace.RaceHorseList.Add(rawRaceHorse);
        }


    }



}
