using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ChecklistThingy.Models;
using PetaPoco;

namespace ChecklistThingy.DataAccess
{
    public class ChecklistDao : BaseDao
    {
        private const string TableName = "Checklist";

        public ChecklistDao(int userId) : base(userId) { }

        public ChecklistModel GetSingle(int recordId)
        {
            return DataContext.SingleOrDefault<ChecklistModel>(Sql.Builder
                            .Select("*")
                            .From(TableName)
                            .Where("Id = @0", recordId)
                            .Where("UserId = @0", UserId)
            );
        }

        public IEnumerable<ChecklistModel> FetchMany()
        {
            return DataContext.Query<ChecklistModel>(Sql.Builder
                            .Select("*")
                            .From(TableName)
                            .Where("UserId = @0", UserId)
            );
        }

        public void Insert(ChecklistModel checklist)
        {
            DataContext.Insert(TableName, IdColumn, new { Name = checklist.Name, UserId = UserId });
        }

        public void Update(ChecklistModel checklist)
        {
            DataContext.Update(TableName, IdColumn, new { Id = checklist.Id, Name = checklist.Name, ModifiedDate = DateTime.Now });
        }

        public void Delete(int id)
        {
            DataContext.Delete(TableName, IdColumn, new { Id = id });
        }
    }
}