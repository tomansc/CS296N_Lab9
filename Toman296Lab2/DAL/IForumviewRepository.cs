using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toman296Lab6.Models;

namespace Toman296Lab6.DAL
{
    public interface IForumviewRepository
    {
        List<ForumView> GetAllForumViews();
        ForumView GetForumViewByID(int? id);
        List<Message> GetMessagesByID(int? id);
        Message GetMessageByID(int? id);
        Message UpdateForumMessage(Message message);
        Message DeleteForumMessage(int? id);
        Member GetMemberById(int? id);
        Member GetMemberByUsername(string username);
        void AddMessageToForumView(ForumView forum, Message message);
        ForumView CreateForumView(ForumView forum);
        void Dispose();
    }
}
