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
            ContactData contact = new ContactData("Ivan", "Petrov");
            contact.Nickname = "ipetrov";
            contact.Address = "NN";
            ContactData newData = new ContactData("Petr", "Ivanov");
            newData.Nickname = "pivanov";
            newData.Address = null;
            app.Contact.Modify (1, contact, newData);
        }
    }
}
