using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebArrdessbookTests
{
    [TestFixture]
    public class ContactModificationTests: ContactTestBase
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

            List<ContactData> oldContacts = ContactData.GetAll();
            oldContacts.Sort();
            ContactData toBeModifed = oldContacts[0];
            app.Contact.Modify (toBeModifed, newData);

            Assert.AreEqual(oldContacts.Count, app.Contact.GetContactCount());

            List<ContactData> newContacts = ContactData.GetAll();
            toBeModifed.Firstname = newData.Firstname;
            toBeModifed.Lastname = newData.Lastname;
            toBeModifed.Nickname = newData.Nickname;
            toBeModifed.Address = newData.Address;
            newContacts.Sort();
            oldContacts.Sort();
            
            Assert.AreEqual(oldContacts, newContacts);

            foreach (ContactData contact in newContacts)
            {
                if (contact.Id == toBeModifed.Id)
                {
                    Assert.AreEqual(newData.Firstname, contact.Firstname);
                    Assert.AreEqual(newData.Lastname, contact.Lastname);
                }
            }
        }
    }
}
