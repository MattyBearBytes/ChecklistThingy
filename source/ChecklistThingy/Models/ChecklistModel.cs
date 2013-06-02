using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChecklistThingy.Models
{
    public class ChecklistModel : BaseModel
    {
        public IEnumerable<ChecklistItemModel> ChecklistItems { get; set; } 
    }
}