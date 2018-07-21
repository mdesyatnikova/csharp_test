using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
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

            List<ContactData> oldContacts = app.Contact.GetContactList();

            app.Contact.Create(contact);
            
            List<ContactData> newContacts = app.Contact.GetContactList();
            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }

    }
}
