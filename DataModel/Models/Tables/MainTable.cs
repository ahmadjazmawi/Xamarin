using SQLite;

namespace DataModel.Models.Tables
{
    public class MainTable : DataModel.Models.Contracts.IBusinessEntity
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public string Name { get; set; }

        public string Title { get; set; }
        
        public string Email { set; get; }

        public string Notes { get; set; }

        public string Interests { get; set; }
    }
}
