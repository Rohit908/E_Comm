using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoMVC.Models.Html
{
    public class Menu
    {
        [Key]
        public int Id { get; set; }
        public int Sequence { get; set; }
        public string? CSS_Class { get; set; }
        public string? Title { get; set; }
        public string? Icon { get; set; }
        public string? URL { get; set; }
        public int ParentId { get; set; }
        [NotMapped]
        public virtual List<Menu>? SubMenus { get; set; }
    }
}
