using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;

namespace bt1.Models
{
    public class Jobs
    {
        public int id { get; set; }
        public string userId { get; set; }
        [ForeignKey("userId")]
        public Profiles User { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string price { get; set; }
        public string date { get; set; }
        public string deadline { get; set; }
        public int CategoriesId { get; set; }
        [ForeignKey("CategoriesId")]
        [ValidateNever]
        public Categories Categories { get; set; }
    }
}
