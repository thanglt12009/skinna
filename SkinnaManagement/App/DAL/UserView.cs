using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SkinnaManagement.App.DAL
{
    public class UserView
    {
        public int UserId { get; set; }

        public string UserName { get; set; }

        public string UserRole { get; set; }

        public string Edit { get; set; }
    }
    public class DataTablesUser
    {
        public int draw { get; set; }

        public int recordsTotal { get; set; }

        public int recordsFiltered { get; set; }

        public List<UserView> data { get; set; }
    }
}