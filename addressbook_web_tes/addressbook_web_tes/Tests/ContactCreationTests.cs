using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;
using NUnit.Framework;

namespace WebArrdessbookTests
{
    [TestFixture]
    public class ContactCreationTests: ContactTestBase
    {

        public static IEnumerable<ContactData> RandomContactDataProvider()
        {
            List<ContactData> contacts = new List<ContactData>();
            for (int i = 0; i < 5; i++)
            {
                contacts.Add(new ContactData(GenerateRandomString(30), GenerateRandomString(30))
                {
                    Nickname = GenerateRandomString(100),
                    Address = GenerateRandomString(100)
                });
            }
            return contacts;
        }

        public static IEnumerable<ContactData> ContactDataFromJsonFile()
        {
            return JsonConvert.DeserializeObject<List<ContactData>>(File.ReadAllText(@"contact.json"));
        }

        public static IEnumerable<ContactData> ContactDataFromXmlFile()
        {
            return (List<ContactData>)
                new XmlSerializer(typeof(List<ContactData>)).Deserialize(new StreamReader(@"contact.xml"));
        }

        [Test, TestCaseSource("ContactDataFromXmlFile")]
        public void ContactCreationTest(ContactData contact)
        {  
            List<ContactData> oldContacts = ContactData.GetAll();

            app.Contact.Create(contact);

            Assert.AreEqual(oldContacts.Count + 1, app.Contact.GetContactCount());

            List<ContactData> newContacts = ContactData.GetAll();
            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }

    }
}
