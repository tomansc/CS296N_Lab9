using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Toman296Lab6.Models;

namespace Toman296Lab6.DAL
{
    public class ForumviewRepository : IDisposable, IForumviewRepository
    {
        Toman296Lab2Context db = new Toman296Lab2Context();
        public void AddMessageToForumView(ForumView forum, Message message)
        {
            forum.Messages.Add(message);
            db.SaveChanges();
        }

        public Message DeleteForumMessage(int? id)
        {
            Message m = GetMessageByID(id);
            db.Messages.Remove(m);
            db.SaveChanges();
            return m;
        }

        public void Dispose()
        {
            db.Dispose();
        }

        public List<ForumView> GetAllForumViews()
        {
            List<ForumView> forumList = new List<ForumView>();
            var fora = from forum in db.ForumViews.Include("Messages")
                         select forum;

            foreach (ForumView f in fora)
            {
                forumList.Add(f);
            }
            return forumList;
        }

        public ForumView GetForumViewByID(int? id)
        {
            return db.ForumViews.Find(id);
        }

        public Member GetMemberById(int? id)
        {
           return db.Users.Find(id);
        }

        public Member GetMemberByUsername(string username)
        {
            return db.Users.Find(username);
        }

        public Message GetMessageByID(int? id)
        {
            return db.Messages.Find(id);
        }

        public List<Message> GetMessagesByID(int? id) //Model binding would be nice here and in other places, but it relies on HTTP requests and an object being passed as a param.
        {
            ForumView f = GetForumViewByID(id);
            
            return f.Messages;
        }

        public Message UpdateForumMessage(Message message)
        {
            db.Entry(message).State = EntityState.Modified;
            db.SaveChanges();
            return message;
        }
        public ForumView CreateForumView(ForumView forum)
        {
            ForumView f = db.ForumViews.Add(forum);
            db.SaveChanges();
            return f;
        }
    }
}