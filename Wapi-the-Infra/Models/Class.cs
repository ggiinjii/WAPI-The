using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Wapi_the_Infra.Models
{
    [ExcludeFromCodeCoverage]

    public partial class Class
    {
        public int Id { get; set; }
        public int IdHeroEleve { get; set; }
        public int IdHeroProfPrincipal { get; set; }
        public int IdClassroom { get; set; }
        public string Name { get; set; }

        public virtual Classroom IdClassroomNavigation { get; set; }
        public virtual Hero IdHeroProfPrincipalNavigation { get; set; }
    }
}
