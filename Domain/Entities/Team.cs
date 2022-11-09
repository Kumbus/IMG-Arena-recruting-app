using System.ComponentModel.DataAnnotations;


namespace MatchDataManager.Domain.Entities;

public class Team : Entity
{
    [Required, MaxLength(255)]
    public string Name { get; set; }

    [MaxLength(55)]
    public string CoachName { get; set; }
}