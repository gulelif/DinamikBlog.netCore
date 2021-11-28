using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CommentManager : ICommentService
    {
        ICommentDal _commentDal;
        private EfCategoryRepository efCategoryRepository;

        public CommentManager(ICommentDal commentDal)
        {
            _commentDal = commentDal;
        }

        public CommentManager(EfCategoryRepository efCategoryRepository)
        {
            this.efCategoryRepository = efCategoryRepository;
        }

        public void CommentAdd(Comment comment)
        {
            _commentDal.Insert(comment);
        }

        public List<Comment> GetList(int id)
        {
            return _commentDal.GetListAll(x=>x.BlogID==id);
        }
    }
}
