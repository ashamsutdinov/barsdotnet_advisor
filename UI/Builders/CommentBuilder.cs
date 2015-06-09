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
        private readonly IRatingManager _ratingManager = Services.Factory.Get<IRatingManager>();


        public CommentModel Build(Comment comment)
        {
            var rating= _ratingManager.Get(comment.UserId, comment.ProductId);
            //if (rating == null) { return null; }
            CommentModel cm = new CommentModel();
            cm.Id = comment.Id;
            cm.Text = comment.Text;
            cm.ProductId = comment.ProductId;
            cm.DateOfCreate = comment.DateOfCreate;
            cm.AuthorLogin = _userManager.Get(comment.UserId).Login;
            cm.Rating = rating.Value;
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