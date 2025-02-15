﻿using System.ComponentModel.DataAnnotations;

namespace MatchDataManager.Domain.Entities;

public class Location : Entity
{
    [Required, MaxLength(255)]
    public string Name { get; set; }

    [Required, MaxLength(55)]
    public string City { get; set; }
}