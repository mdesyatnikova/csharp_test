using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;


namespace WebArrdessbookTests
{
    [TestFixture]
    public class GroupRemovalTests: TestBase
    {
        
        [Test]
        public void GroupRemovalTest()
        {
            app.Navigator.GoToHomePage();
            app.Auth.Login(new AccountData("admin","secret"));
            app.Navigator.GoToGroupPage();
            app.Group.SelectGroup(1);
            app.Group.RemoveGroup();
            app.Group.ReturnToGroupPage();
        }
          
    }
}
