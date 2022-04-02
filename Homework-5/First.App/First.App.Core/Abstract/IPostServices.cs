using First.App.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace First.App.Business.Abstract
{
    public interface IPostServices
    {
        void AddPost(Posts post);
        void AddPosts(List<Posts> posts);
    }
}
