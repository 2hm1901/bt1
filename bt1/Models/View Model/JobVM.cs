using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace bt1.Models.View_Model
{
    public class JobVM
    {
        public Jobs Job { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> Categories { get; set; }
    }
}
