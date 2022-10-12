using System;
using System.Diagnostics.CodeAnalysis;

namespace Wapi_the_Core.DTO
{
    [ExcludeFromCodeCoverage]
    [Serializable]
    public class HeroDto
    {
        public HeroDto(int id, string name, string alter)
        {
            Id = id;
            Name = name;
            Alter = alter;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Alter { get; set; }
    }
}
