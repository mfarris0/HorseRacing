﻿using System.Collections.Generic;

namespace HorseRacing.Domain
{
    public class RaceCardViewerViewModel
    {

        public RawRaceDay RawRaceDay { get; set; }
        public List<RawRace> RaceCard { get; set; } = new List<RawRace>();
        public List<RawRaceHorse> RaceHorseList { get; set; } = new List<RawRaceHorse>();

    }



}
