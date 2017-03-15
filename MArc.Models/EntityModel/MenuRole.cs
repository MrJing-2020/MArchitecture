using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MArc.Models
{
    public class MenuRole : BaseModel
    {
        [Key]
        public new int Id { get; set; }
        public string MenuId { get; set; }
        public string RoleId { get; set; }
    }
}
