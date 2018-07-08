using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;


namespace WebArrdessbookTests
{
    [TestFixture]
    public class GroupCreationTests: TestBase
    {
        [Test]
        public void GroupCreationTest()
        {
            app.Navigator.GoToHomePage();
            app.Auth.Login(new AccountData ("admin", "secret"));
            app.Navigator.GoToGroupPage();
            app.Group.InitNewGroupCreation();
            GroupData group = new GroupData("grop1");
            group.Header = "group1";
            group.Footer = "comment1";
            app.Group.FillGroupForm(group);
            app.Group.SubmitGroupCreation();
            app.Group.ReturnToGroupPage();
        }
                
    }
}
