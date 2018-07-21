using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using System.Collections.Generic;


namespace WebArrdessbookTests
{
    [TestFixture]
    public class GroupRemovalTests: Auth_TestBase
    {
        
        [Test]
        public void GroupRemovalTest()
        {
            //prepare
            app.Navigator.GoToGroupPage();
            if (app.Group.CheckElement() == false)
            {
                GroupData group = new GroupData("grop1");
                group.Header = "group1";
                group.Footer = "comment1";
                app.Group.Create(group);

            }

            //action 
            List<GroupData> oldGroups = app.Group.GetGroupList();

            app.Group.Remove(0);

            List<GroupData> newGroups = app.Group.GetGroupList();
            oldGroups.RemoveAt(0);
            Assert.AreEqual(oldGroups, newGroups);
        }
          
    }
}
