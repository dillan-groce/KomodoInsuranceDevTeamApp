using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komodo_ConsoleApp
{
    public class DevTeam
    {
        public string DevTeamName { get; set; }
        public int? DevTeamId { get; set; }
        public List<Developer> DevTeamMembers { get; set; }

        public DevTeam() { }

        public DevTeam(string devTeamName, int devTeamID, List<Developer> devTeamMembers)
        {
            DevTeamName = devTeamName;
            DevTeamId = devTeamID;
            DevTeamMembers = devTeamMembers;
        }
    }
}
