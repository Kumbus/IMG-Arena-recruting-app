using System.ComponentModel.DataAnnotations;

namespace MatchDataManager.Services.DTO
{
    public class TeamForUpdateDTO
    {
        [Required, MaxLength(255)]
        public string Name { get; set; }

        [MaxLength(55)]
        public string CoachName { get; set; }
    }
}
