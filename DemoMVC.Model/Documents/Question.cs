using System.ComponentModel.DataAnnotations;

namespace DemoMVC.Models.Documents
{
    public class Question
    {
        [Key]
        public int QuestionId { get;set;}
        public string Text {get;set;}
        public string Type {get;set;}
        public List<Option> Options { get; set; }
        public DateTime CreatedAt {get;set;}
        public DateTime? UpdatedAt { get; set; }
    }
}
