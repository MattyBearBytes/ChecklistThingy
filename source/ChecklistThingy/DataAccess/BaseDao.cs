using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using PetaPoco;

namespace ChecklistThingy.DataAccess
{
    public class BaseDao
    {
        protected const string IdColumn = "Id";
        protected int UserId;
        protected Database DataContext;

        public BaseDao(int userId)
        {
            UserId = userId;
            DataContext = new Database(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString, ConfigurationManager.ConnectionStrings["DefaultConnection"].ProviderName);
        }

        #region Database Tranactions...

        public void BeginTransaction()
        {
            DataContext.BeginTransaction();
        }

        public void AbortTransaction()
        {
            DataContext.AbortTransaction();
        }

        public void CompleteTransaction()
        {
            DataContext.CompleteTransaction();
        }

        #endregion
    }
}