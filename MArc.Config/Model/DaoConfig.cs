using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MArc.Config.Model
{
    [Serializable]
    public class DaoConfig : ConfigFileBase
    {
        public DaoConfig()
        {
        }
        public String MArc_Base { get; set; }

        public String MArc_Account { get; set; }
    }
}
