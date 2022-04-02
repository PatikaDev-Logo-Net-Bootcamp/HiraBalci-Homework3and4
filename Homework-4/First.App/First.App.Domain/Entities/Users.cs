using System;
using System.Collections.Generic;
using System.Text;

namespace First.App.Domain.Entities
{
    public class Users : BaseEntity
    {
        public string username { get; set; }
        public string password { get; set; }
    }
}
