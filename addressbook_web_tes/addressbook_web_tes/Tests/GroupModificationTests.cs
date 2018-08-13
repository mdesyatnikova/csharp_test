using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebArrdessbookTests
{
    [TestFixture]
    public class GroupModificationTests: GroupTestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            //prepare
            app.Navigator.GoToGroupPage();
            if (app.Group.CheckElement()==false)
            {
                GroupData group = new GroupData("grop1");
                group.Header = "group1";
                group.Footer = "comment1";
                app.Group.Create(group);

            }

            //action
            GroupData newData = new GroupData("group2");
            newData.Header = null;
            newData.Footer = null;

            List<GroupData> oldGroups = app.Group.GetGroupList();

            GroupData toBeModifed = oldGroups[0];

            app.Group.Modify(toBeModifed, newData);

            Assert.AreEqual(oldGroups.Count, app.Group.GetGroupCount());

            List<GroupData> newGroups = app.Group.GetGroupList();
            toBeModifed.Name = newData.Name;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);

            foreach (GroupData group in newGroups)
            {
                if (group.Id == toBeModifed.Id)
                {
                    Assert.AreEqual(newData.Name, group.Name);
                }
            }
        }
    }
}
