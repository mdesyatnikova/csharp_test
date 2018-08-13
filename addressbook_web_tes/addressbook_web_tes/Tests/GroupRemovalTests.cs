using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using System.Collections.Generic;


namespace WebArrdessbookTests
{
    [TestFixture]
    public class GroupRemovalTests: GroupTestBase
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
            List<GroupData> oldGroups = GroupData.GetAll();
            GroupData toBeRemoved = oldGroups[0];
            app.Group.Remove(toBeRemoved);

            Assert.AreEqual(oldGroups.Count - 1, app.Group.GetGroupCount());

            List<GroupData> newGroups = GroupData.GetAll();
            
            oldGroups.RemoveAt(0);
            Assert.AreEqual(oldGroups, newGroups);

            foreach (GroupData group in newGroups)
            {
                Assert.AreNotEqual(group.Id, toBeRemoved.Id);
            }
        }
          
    }
}
