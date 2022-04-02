using System;
using System.Collections.Generic;
using System.Text;

namespace First.App.Domain.Entities
{
    public class Posts : BaseEntity
    {
        public string username { get; set; }
        public string title { get; set; }
        public string Body { get; set; }
    }
}
