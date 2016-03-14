using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Toman296Lab6.Models;

namespace Toman296Lab6.DAL
{
    public class DummyForumviewRepository : IForumviewRepository
    {
        public void AddMessageToForumView(ForumView forum, Message message)
        {
            throw new NotImplementedException();
        }

        public Message DeleteForumMessage(int? id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public List<ForumView> GetAllForumViews()
        {
            throw new NotImplementedException();
        }

        public ForumView GetForumViewByID(int? id)
        {
            throw new NotImplementedException();
        }

        public Member GetMemberById(int? id)
        {
            throw new NotImplementedException();
        }

        public Message GetMessageByID(int? id)
        {
            throw new NotImplementedException();
        }

        public List<Message> GetMessagesByID(int? id)
        {
            throw new NotImplementedException();
        }

        public Message UpdateForumMessage(Message message)
        {
            throw new NotImplementedException();
        }
        public Member GetMemberByUsername(string username)
        {
            throw new NotImplementedException();
        }

        public ForumView CreateForumView(ForumView forum)
        {
            throw new NotImplementedException();
        }

    }
}