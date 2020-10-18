using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO;
using DAL;

namespace BLL
{
    public class CommentBLL
    {
        public static List<Comment> getAllCommentOfJob(int jobID)
        {
            return CommentDAL.getAllCommentOfJob(jobID);
        }

        public static bool canReadWriteComment(int jobID, int userID)
        {
            if (UserBLL.isManager(userID))
                return true;
            if (JobBLL.isPublic(jobID))
                return true;
            if (JobBLL.canAccess(userID, jobID))
                return true;
            return false;
        }

        public static bool canEditComment(int cmtID, int userID)
        {
            return CommentDAL.canEditComment(cmtID, userID);
        }

        public static Comment getComment(int id)
        {
            return CommentDAL.getComment(id);
        }

        public static bool addComment(Comment cmt)
        {
            return CommentDAL.addComment(cmt);
        }

        public static bool deleteComment(int id)
        {
            return CommentDAL.deleteComment(id);
        }

        public static bool editComment(Comment cmt)
        {
            return CommentDAL.editComment(cmt);
        }
    }
}
