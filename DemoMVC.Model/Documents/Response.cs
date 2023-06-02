using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoMVC.Models.Documents
{
    public class Response
    {
        public int ResponseId { get; set; } 
        public int DocumentId { get; set; }
        public int QuestionnaireId { get; set; }
        public int UserId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
