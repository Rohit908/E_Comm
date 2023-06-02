using DemoMVC.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace DemoMVC.Models.Documents
{
    public class Document
    {
        [Key]
        public int Id { get; set; }
        public string? Type { get; set; }
        public DateTime RecordedDate { get; set; }
        public RecordedWith RecordedWith { get; set; }
        public string? Book { get; set; }
        public string? Page { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
