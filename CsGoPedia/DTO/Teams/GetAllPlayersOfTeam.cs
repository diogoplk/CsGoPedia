﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GamerPedia.DTO.Teams {
    public class GetAllPlayersOfTeam {

        public int Id { get; set; }

        public string Name { get; set; }

        public string Nickname { get; set; }

        public string BirthDate { get; set; }

        public string ImgCountry { get; set; }
        public string Country { get; set; }

        public string Team { get; set; }

        public string Role { get; set; }

        public string Instagram { get; set; }

        public string Hltv { get; set; }

        public string Photo { get; set; }

        public string VideoHighlight { get; set; }

        public string TotalWinnings { get; set; }

    }
}