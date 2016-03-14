using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Toman296Lab6.Models;
using System.Collections.Generic;
using Toman296Lab6.DAL;
using Toman296Lab2.Controllers;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ForumTests
{

    [TestClass]
    public class ForumTest
    {
        [TestMethod]
        public void TestIndex()
        {
            // arrange
            var fora = new List<ForumView>()
            {
                new ForumView { ForumID = 1, ForumName = "First forum", LastModified = DateTime.Now },
                new ForumView { ForumID = 2, ForumName = "Second forum", LastModified = DateTime.Now },
                new ForumView { ForumID = 3, ForumName = "Third forum", LastModified = DateTime.Now }
            };

            Message m = new Message { Date = DateTime.Now, MessageID = 1, Subject = "Test messages are falling from the sky", Topic = "Tests", Body = "είναι απλά ένα κείμενο χωρίς νόημα για τους επαγγελματίες της τυπογραφίας και στοιχειοθεσίας. Το Lorem Ipsum είναι το επαγγελματικό πρότυπο όσον αφορά το κείμενο χωρίς νόημα, από τον 15ο αιώνα, όταν ένας ανώνυμος τυπογράφος πήρε ένα δοκίμιο και ανακάτεψε τις λέξεις για να δημιουργήσει ένα δείγμα βιβλίου."};
            Message m2 = new Message { Date = DateTime.Now, MessageID = 2, Subject = "Test messages are still falling from the sky", Topic = "Precipitation", Body = "είναι απλά ένα κείμενο χωρίς νόημα για τους επαγγελματίες της τυπογραφίας και στοιχειοθεσίας. Το Lorem Ipsum είναι το επαγγελματικό πρότυπο όσον αφορά το κείμενο χωρίς νόημα, από τον 15ο αιώνα, όταν ένας ανώνυμος τυπογράφος πήρε ένα δοκίμιο και ανακάτεψε τις λέξεις για να δημιουργήσει ένα δείγμα βιβλίου." };

            var repo = new ForumviewRepository();
            var target = new ForumViewController(repo);

            // act
            repo.AddMessageToForumView(fora[0], m2);
            repo.AddMessageToForumView(fora[1], m);
            repo.AddMessageToForumView(fora[2], m2);
            var result = (ViewResult)target.Index();

            // assert
            var model = (List<ForumView>)result.Model; // This is presumably the Stack model being sent to the view by the controller method. We will run our asserts on this model.  
            Assert.AreEqual(model[0].Messages[0].Topic, "Precipitation");
            Assert.AreEqual(model[1].Messages[0].MessageID, 1);
        }
    }
}
