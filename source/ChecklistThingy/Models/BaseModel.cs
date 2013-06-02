using System;
using PetaPoco;

namespace ChecklistThingy.Models
{
    [PrimaryKey("Id")]
    public class BaseModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int UserId { get; set; }

        public DateTime AddedDate { get; set; }

        public DateTime ModifiedDate { get; set; }
    }
}