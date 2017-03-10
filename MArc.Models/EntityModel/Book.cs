using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MArc.Models
{
    public class Book:BaseModel
    {
        public string BookName { get; set; }
        public int Price { get; set; }
    }
}
