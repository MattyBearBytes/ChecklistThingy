using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ChecklistThingy.Models;
using PetaPoco;

namespace ChecklistThingy.DataAccess
{
    public class ItemDao : BaseDao
    {
        private const string TableName = "ChecklistItem";

        public ItemDao(int userId) : base(userId) { }

        public ChecklistItemModel GetSingle(int recordId)
        {
            return DataContext.SingleOrDefault<ChecklistItemModel>(Sql.Builder
                            .Select("*")
                            .From(TableName)
                            .Where("Id = @0", recordId)
                            .Where("UserId = @0", UserId)
            );
        }

        public IEnumerable<ChecklistItemModel> FetchMany(int checklistId)
        {
            return DataContext.Query<ChecklistItemModel>(Sql.Builder
                            .Select("*")
                            .From(TableName)
                            .Where("ChecklistId = @0", checklistId)
                            .Where("UserId = @0", UserId)
            );
        }

        public void Insert(ChecklistItemModel checklistItem)
        {
            DataContext.Insert(TableName, IdColumn, new { Name = checklistItem.Name, ChecklistId = checklistItem.ChecklistId, UserId = UserId });
        }

        public void Update(ChecklistItemModel checklistItem)
        {
            DataContext.Update(TableName, IdColumn, new { Id = checklistItem.Id, Name = checklistItem.Name, ModifiedDate = DateTime.Now });
        }

        public void Delete(int id)
        {
            DataContext.Delete(TableName, IdColumn, new { Id = id, UserId = UserId });
        }
    }
}