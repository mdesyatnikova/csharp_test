using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebArrdessbookTests
{
    [TestFixture]
    public class ContactModificationTests: Auth_TestBase
    {
        [Test]
        public void ContactModificationTest()
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
            ContactData newData = new ContactData("Petr", "Ivanov");
            newData.Nickname = "pivanov";
            newData.Address = null;
            app.Contact.Modify (1, newData);
        }
    }
}
