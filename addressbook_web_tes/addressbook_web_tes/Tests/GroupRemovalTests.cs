using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;


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
            if (app.Group.CheckElement(1) == false)
            {
                GroupData group = new GroupData("grop1");
                group.Header = "group1";
                group.Footer = "comment1";
                app.Group.Create(group);

            }

            //action     
            app.Group.Remove(1);
        }
          
    }
}
