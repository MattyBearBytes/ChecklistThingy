using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChecklistThingy.Models
{
    public class ChecklistItemModel : BaseModel
    {
        public ChecklistModel Checklist { get; set; }
    }
}