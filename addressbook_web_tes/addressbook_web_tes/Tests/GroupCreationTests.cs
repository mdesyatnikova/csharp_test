using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;


namespace WebArrdessbookTests
{
    [TestFixture]
    public class GroupCreationTests: Auth_TestBase
    {
        [Test]
        public void GroupCreationTest()
        {
            GroupData group = new GroupData("grop1");
            group.Header = "group1";
            group.Footer = "comment1";

            List<GroupData> oldGroups = app.Group.GetGroupList();
            
            app.Group.Create(group);

            List<GroupData> newGroups =app.Group.GetGroupList();
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);

        }
                
    }
}
