using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebArrdessbookTests
{
    [TestFixture]
    public class GroupModificationTests: Auth_TestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            GroupData group = new GroupData("grop1");
            group.Header = "group1";
            group.Footer = "comment1";
            GroupData newData = new GroupData("group2");
            newData.Header = null;
            newData.Footer = null;
            app.Group.Modify(1, group, newData);
        }
    }
}
