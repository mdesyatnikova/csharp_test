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
            if (app.Contact.CheckElement() == false)
            {
                ContactData contact = new ContactData("Ivan", "Petrov");
                contact.Nickname = "ipetrov";
                contact.Address = "NN";
                app.Contact.Create(contact);
            }

            //action
            List<ContactData> oldContacts = app.Contact.GetContactList();
            ContactData toBeRemoved = oldContacts[0];
            app.Contact.Remove(0);

            Assert.AreEqual(oldContacts.Count - 1, app.Contact.GetContactCount());

            List<ContactData> newContacts = app.Contact.GetContactList();
            oldContacts.RemoveAt(0);
            Assert.AreEqual(oldContacts, newContacts);

            foreach (ContactData contact in newContacts)
            {
                Assert.AreNotEqual(contact.Id, toBeRemoved.Id);
            }
        }
    }
}
