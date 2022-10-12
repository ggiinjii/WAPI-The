using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Wapi_the_Infra.Models
{
    [ExcludeFromCodeCoverage]
    public partial class School
    {
        public School()
        {
            Classroom = new HashSet<Classroom>();
        }

        public int Id { get; set; }
        public string NomEcole { get; set; }

        public virtual ICollection<Classroom> Classroom { get; set; }
    }
}
