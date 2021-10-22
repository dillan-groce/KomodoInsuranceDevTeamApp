using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komodo_ConsoleApp
{
    public class DevTeam_Repo
    {
        private List<DevTeam> _devTeams = new List<DevTeam>();
        public bool AddDevTeamToList(DevTeam devTeam)
        {
            int initialTeamCount = _devTeams.Count();
            _devTeams.Add(devTeam);

            if (_devTeams.Count() > initialTeamCount)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public List<DevTeam> GetDevTeams()
        {
            return _devTeams;
        }
        public bool UpdateDevTeams(DevTeam oldTeam, DevTeam newTeam)
        {
            if (oldTeam != null && newTeam != null)
            {
                oldTeam.DevTeamName = newTeam.DevTeamName;
                oldTeam.DevTeamId = newTeam.DevTeamId;
                oldTeam.DevTeamMembers = newTeam.DevTeamMembers;
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool RemoveDevTeamFromList(int devTeamId)
        {

            DevTeam removeDevTeamId = GetDevTeamId(devTeamId);

            int initialDevTeamCount = _devTeams.Count;
            _devTeams.Remove(removeDevTeamId);

            if (initialDevTeamCount > _devTeams.Count)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public DevTeam GetDevTeamId(int getDevId)
        {
            foreach (DevTeam devTeam in _devTeams)
            {
                if (devTeam.DevTeamId == getDevId)
                {
                    return devTeam;
                }

            }

            return null;
        }
        public bool AddDevToDevTeam(int developerAddToTeam)
        {
            DevTeam newDevId = GetDevTeamId(developerAddToTeam);

            int initialTeamCount = _devTeams.Count();
            _devTeams.Add(newDevId);

            if (_devTeams.Count > initialTeamCount)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
