using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChecklistThingy.Models
{
    public class ListItemsViewModel
    {
        public ChecklistModel Checklist { get; set; } 

        public IEnumerable<ChecklistItemModel> Items { get; set; } 
    }
}