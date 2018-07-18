using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebArrdessbookTests
{
    [TestFixture]
    public class ContactRemovalTests: Auth_TestBase
    {
        [Test]
        public void ContactRemovalTest()
        {
            //prepare
            app.Navigator.GoToHomePage();
            if (app.Contact.CheckElement(1) == false)
            {
                ContactData contact = new ContactData("Ivan", "Petrov");
                contact.Nickname = "ipetrov";
                contact.Address = "NN";
                app.Contact.Create(contact);
            }

            //action
            app.Contact.Remove(1);
        }
    }
}
