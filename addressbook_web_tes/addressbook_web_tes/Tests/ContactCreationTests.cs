using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebArrdessbookTests
{
    [TestFixture]
    public class ContactCreationTests: Auth_TestBase
    {
        
        [Test]
        public void ContactCreationTest()
        {
            ContactData contact = new ContactData("Ivan", "Petrov");
            contact.Nickname = "ipetrov";
            contact.Address = "NN";
            app.Contact.Create(contact);

        }
            
    }
}
