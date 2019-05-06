using DataAccessLayer.Models.Contracts;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Models.Tables
{
    public class MainTable : IBusinessEntity
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
