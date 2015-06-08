using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Advisor.Dal.Domain;
using UI.Models;
using Advisor.Data;

namespace UI.Builders
{
    public class CommentBuilder
        :IBuilder<CommentModel,Comment>
    {
        //private readonly ICategoryManager _categoryManager = Services.Factory.Get<ICategoryManager>();
        private readonly IUserManager _userManager = Services.Factory.Get<IUserManager>();


        public CommentModel Build(Comment comment)
        {
            CommentModel cm = new CommentModel();
            cm.Id = comment.Id;
            cm.Text = comment.Text;
            cm.ProductId = comment.ProductId;
            cm.DateOfCreate = comment.DateOfCreate;
            cm.AuthorLogin = _userManager.Get(comment.UserId).Login;
            return cm;
        }

        public IEnumerable<CommentModel> BuildIEnumerable(IEnumerable<Comment> comments)
        {
            List<CommentModel> res = new List<CommentModel>();
            foreach (Comment p in comments)
            {
                res.Add(this.Build(p));
            }
            return res;
        }
    }
}