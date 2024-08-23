using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace bt1.Models
{
    public class JobApplications
    {
        [Key]
        public int id { get; set; }
        public string userId { get; set; }
        [ValidateNever]
        public Profiles User { get; set; }
        public int? jobId { get; set; }
        [ValidateNever]
        [ForeignKey("jobId")]
        public Jobs Job { get; set; }
        public string date { get; set; }
        public string status { get; set; }
    }
}
