using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MArc.Models
{
    public class Menu:BaseModel
    {
        [Key]
        public new string Id { get; set; }
        public string MenuName { get; set; }
        public string Area { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public int Type { get; set; }
    }
}
