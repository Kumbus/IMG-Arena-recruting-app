using MatchDataManager.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchDataManager.UnitTests
{
    public class LocationsControllerTestData
    {
        public static IEnumerable<object[]> GetAllData =>
        new List<object[]>
        {
            new object [] { new List<LocationDTO>() { new LocationDTO(), new LocationDTO() }, 2 },
            new object [] { new List<LocationDTO>() { new LocationDTO() }, 1 },
            new object [] { new List<LocationDTO>() { }, 0 },
            new object [] { new List<LocationDTO>() { new LocationDTO(), new LocationDTO(), new LocationDTO() }, 3 },

        };


        public static IEnumerable<object[]> GetLocationByIdData =>
        new List<object[]>
        {
            new object [] { Guid.Empty,
                new LocationDTO() { Id=Guid.Empty, City="Katowice", Name="Spodek" },
                new LocationDTO() { Id=Guid.Empty, City="Katowice", Name="Spodek" } },

            new object [] { Guid.Parse("31243005-c19b-41da-8c8b-2030671fa450"),
                new LocationDTO() { Id= Guid.Parse("31243005-c19b-41da-8c8b-2030671fa450"), City="Warszawa", Name="PGE Narodowy" },
                new LocationDTO() { Id= Guid.Parse("31243005-c19b-41da-8c8b-2030671fa450"), City="Warszawa", Name="PGE Narodowy" } },

            new object [] { Guid.Parse("4840ff44-d945-4321-ad99-e14b9a159d4a"),
                new LocationDTO() { Id= Guid.Parse("4840ff44-d945-4321-ad99-e14b9a159d4a"), City="Gliwice", Name="Arena Gliwice" },
                new LocationDTO() { Id= Guid.Parse("4840ff44-d945-4321-ad99-e14b9a159d4a"), City="Gliwice", Name="Arena Gliwice" } },

            new object [] { Guid.Parse("04485659-ee83-456a-b1e1-55d5cc7273e6"),
                new LocationDTO() { Id= Guid.Parse("04485659-ee83-456a-b1e1-55d5cc7273e6"), City="Chorzów", Name="Stadion Śląski" },
                new LocationDTO() { Id= Guid.Parse("04485659-ee83-456a-b1e1-55d5cc7273e6"), City="Chorzów", Name="Stadion Śląski" } }


        };


        public static IEnumerable<object[]> AddLocationData =>
        new List<object[]>
        {
            new object [] { new LocationForCreationDTO() { City="Katowice", Name="Spodek"},
                new LocationDTO() { Id=Guid.Empty, City="Katowice", Name="Spodek" },
                new LocationDTO() { Id=Guid.Empty, City="Katowice", Name="Spodek" } },

            new object [] { new LocationForCreationDTO() { City="Warszawa", Name="PGE Narodowy" },
                new LocationDTO() { Id= Guid.Parse("31243005-c19b-41da-8c8b-2030671fa450"), City="Warszawa", Name="PGE Narodowy" },
                new LocationDTO() { Id= Guid.Parse("31243005-c19b-41da-8c8b-2030671fa450"), City="Warszawa", Name="PGE Narodowy" } },

            new object [] { new LocationForCreationDTO() { City="Gliwice", Name="Arena Gliwice" },
                new LocationDTO() { Id= Guid.Parse("4840ff44-d945-4321-ad99-e14b9a159d4a"), City="Gliwice", Name="Arena Gliwice" },
                new LocationDTO() { Id= Guid.Parse("4840ff44-d945-4321-ad99-e14b9a159d4a"), City="Gliwice", Name="Arena Gliwice" } },

            new object [] { new LocationForCreationDTO() { City="Chorzów", Name="Stadion Śląski" },
                new LocationDTO() { Id= Guid.Parse("04485659-ee83-456a-b1e1-55d5cc7273e6"), City="Chorzów", Name="Stadion Śląski" },
                new LocationDTO() { Id= Guid.Parse("04485659-ee83-456a-b1e1-55d5cc7273e6"), City="Chorzów", Name="Stadion Śląski" } }


        };
    }
}
