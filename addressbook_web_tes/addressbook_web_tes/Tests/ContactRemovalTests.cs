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
            ContactData contact = new ContactData("Ivan", "Petrov");
            contact.Nickname = "ipetrov";
            contact.Address = "NN";
            app.Contact.Remove(1, contact);
        }
    }
}
