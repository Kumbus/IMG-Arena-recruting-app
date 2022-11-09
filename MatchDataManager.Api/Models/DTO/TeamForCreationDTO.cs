﻿using System.ComponentModel.DataAnnotations;

namespace MatchDataManager.Api.Models.DTO
{
    public class TeamForCreationDTO
    {
        [Required, MaxLength(255)]
        public string Name { get; set; }

        [MaxLength(55)]
        public string CoachName { get; set; }
    }
}
