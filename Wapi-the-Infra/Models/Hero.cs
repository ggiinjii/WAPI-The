using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Wapi_the_Infra.Models
{
    [ExcludeFromCodeCoverage]
    public partial class Hero
    {
        public Hero()
        {
            Class = new HashSet<Class>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string HeroAlter { get; set; }

        public virtual ICollection<Class> Class { get; set; }
    }
}
