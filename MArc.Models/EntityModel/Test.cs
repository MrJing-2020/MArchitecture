using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MArc.Models
{
    public class Test:BaseModel
    {
        public new int Id { get; set; }
        public string TestString { get; set; }
    }
}
