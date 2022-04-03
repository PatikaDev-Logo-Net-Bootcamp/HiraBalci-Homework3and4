using System;
using System.Collections.Generic;
using System.Text;

namespace First.App.Domain.Entities
{
    public class Post:BaseEntity
    {
      //  public int Id { get; set; }
        public int UserId { get; set; }
        public  string Title { get; set; }
        public string Body { get; set; }
    }
}
