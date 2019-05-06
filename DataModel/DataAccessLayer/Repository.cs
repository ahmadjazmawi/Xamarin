using System;
using System.Collections.Generic;
using System.Text;
using Utility.Logs;

namespace DataModel.DAL
{
    class Repository
    {
        public DL.Database db = null;
        protected static string dbLocation;
        protected static Repository me;

        static Repository()
        {
            try
            {
                me = new Repository();
            }
            catch (Exception Ex)
            {
                LogsHandler.WriteException(Ex);
            }
        }

        protected Repository()
        {
            try
            {
                LogsHandler.WriteDebug("DataModel.DAL.Repository: Initiate Repository");

                // set the db location
                dbLocation = DatabaseFilePath;

                // instantiate the database	
                db = new DL.Database(dbLocation);
            }
            catch (Exception Ex)
            {
                LogsHandler.WriteException(Ex);
            }
        }

        public static string DatabaseFilePath
        {
            get
            {
                LogsHandler.WriteDebug(String.Format("DataModel.DAL.Repository: Initiate DatabaseFilePath"));

                string applicationFolderPath = System.IO.Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData), "SaleRecord");

                LogsHandler.WriteDebug(applicationFolderPath);

                // Create the folder path.
                System.IO.Directory.CreateDirectory(applicationFolderPath);

                LogsHandler.WriteDebug("DataModel.DAL.Repository: Directory created");

                return System.IO.Path.Combine(applicationFolderPath, "Database.db");
            }
        }

        public static DL.Database Database
        {
            get
            {
                return me.db;
            }
        }
    }
}
