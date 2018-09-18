﻿using CsGoPedia.DTO.Players;
using GamerPedia.DTO.Teams;
using GamerPedia.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GamerPedia.Controllers
{
    public class PlayersController : ApiController
    {
        public AppDB db = new AppDB();

        //get api/players/id with statistics and achivements
        [HttpGet, Route("api/players/{id}")]
        public IHttpActionResult GetPlayer(int? id) {

            if(id == null) {
                return BadRequest();
            }

            var player = db.Players
                .Where(p => p.Id == id)
                .Select(p => new GetSinglePlayerOfTeam {
                    Id = p.Id,
                    Name = p.Name,
                    BirthDate = p.BirthDate,
                    Coutry = p.Coutry,
                    Hltv = p.Hltv,
                    ImgCountry = p.ImgCountry,
                    Instagram = p.Instagram,
                    Nickname = p.Nickname,
                    Photo = p.Photo,
                    Role = p.Role,
                    Team = p.Team,
                    TotalWinnings = p.TotalWinnings,
                    VideoHighlight = p.VideoHighlight,
                    Achievements = p.ListAchievements
                        //.Where(a => a.PlayerFK == p.Id)
                        .Select(a => new GetSinglePlayerOfTeam.GetAchievements {
                            
                            Id = a.Id,
                            Name = a.Name,
                            Placement = a.Placement
                            
                        }).ToList(),
                    
                    Statistics = p.ListStatistics
                                 .Select(s => new GetSinglePlayerOfTeam.GetStatistics {
                                     Id = s.Id,
                                     DeadthsRound = s.DeadthsRound,
                                     HS = s.HS,
                                     KillsRound = s.KillsRound,
                                     MapsPlayed = s.MapsPlayed,
                                     Rating = s.Rating,
                                     RoundsContributed = s.RoundsContributed,
                                     TotalDeaths = s.TotalDeaths,
                                     TotalKills = s.TotalKills
                                 }).ToList(),
                                 
                }).FirstOrDefault();
                
            if(player == null) {
                return NotFound();
            }

            return Ok(player);
        }

        // para o filtro da search bar
//        //get api/players/id with statistics and achivements
//        [HttpGet, Route("api/players")]
//        public IHttpActionResult GetPlayers(string Name = "") {

//            object Players;

//    	    if(Name == ""){
//                Players = db.Players.Select(
//                    p => new GetAllPlayers {
//                        Id = p.Id,
//                        Name = p.Name,
//                        BirthDate = p.BirthDate,
//                        Coutry = p.Coutry,
//                        Hltv = p.Hltv,
//                        ImgCountry = p.ImgCountry,
//                        Instagram = p.Instagram,
//                        Nickname = p.Nickname,
//                        Photo = p.Photo,
//                        Role = p.Role,
//                        Team = p.Team,
//                        TotalWinnings = p.TotalWinnings,
//                        VideoHighlight = p.VideoHighlight
//                    })
//                    .OrderBy(p=>p.Id)
//                    .ToList();
//                }
//                else {
//                Players = db.Players
//                    .Where(p =>p.Name.ToLower().Contains(Name.ToLower()))
//                    .Select(
//                    p => new GetAllPlayers {
//                        Id = p.Id,
//                        Name = p.Name,
//                        BirthDate = p.BirthDate,
//                        Coutry = p.Coutry,
//                        Hltv = p.Hltv,
//                        ImgCountry = p.ImgCountry,
//                        Instagram = p.Instagram,
//                        Nickname = p.Nickname,
//                        Photo = p.Photo,
//                        Role = p.Role,
//                        Team = p.Team,
//                        TotalWinnings = p.TotalWinnings,
//                        VideoHighlight = p.VideoHighlight
//                    })
//                    .OrderBy(p=>p.Id)
//                    .ToList();
//                }

//            return Ok(Players);
//        }
//    }
//}

//get api/players/id with statistics and achivements
        [HttpGet, Route("api/players")]
        public IHttpActionResult GetPlayers() {

            var players = db.Players.Select(
                p => new GetAllPlayers {
                    Id = p.Id,
                    Name = p.Name,
                    BirthDate = p.BirthDate,
                    Coutry = p.Coutry,
                    Hltv = p.Hltv,
                    ImgCountry = p.ImgCountry,
                    Instagram = p.Instagram,
                    Nickname = p.Nickname,
                    Photo = p.Photo,
                    Role = p.Role,
                    Team = p.Team,
                    TotalWinnings = p.TotalWinnings,
                    VideoHighlight = p.VideoHighlight
                })
                .OrderBy(p => p.Id)
                .ToList();

            if(players.Count() == 0) {
                return NotFound();
            }
            return Ok(players);
        }
            }
        }