using System.ComponentModel.DataAnnotations;

namespace MatchDataManager.Api.Models.DTO
{
    public class LocationForCreationDTO
    {
        [Required, MaxLength(255)]
        public string Name { get; set; }

        [Required, MaxLength(55)]
        public string City { get; set; }
    }
}
