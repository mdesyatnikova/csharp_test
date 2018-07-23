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
            if (app.Contact.CheckElement() == false)
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

            List<ContactData> oldContacts = app.Contact.GetContactList();
            ContactData oldData = oldContacts[0];
            app.Contact.Modify (0, newData);

            Assert.AreEqual(oldContacts.Count, app.Contact.GetContactCount());

            List<ContactData> newContacts = app.Contact.GetContactList();
            oldContacts[0].Firstname = newData.Firstname;
            oldContacts[0].Lastname = newData.Lastname;
            oldContacts[0].Nickname = newData.Nickname;
            oldContacts[0].Address = newData.Address;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);

            foreach (ContactData contact in newContacts)
            {
                if (contact.Id == oldData.Id)
                {
                    Assert.AreEqual(newData.Firstname, contact.Firstname);
                    Assert.AreEqual(newData.Lastname, contact.Lastname);
                }
            }
        }
    }
}
