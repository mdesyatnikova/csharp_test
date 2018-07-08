using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebArrdessbookTests
{
    [TestFixture]
    public class ContactCreationTests: TestBase
    {
        
        [Test]
        public void ContactCreationTest()
        {
            app.Navigator.GoToHomePage();
            app.Auth.Login(new AccountData ("admin", "secret"));
            app.Contact.InitNewContactCreation();
            ContactData contact = new ContactData("Ivan", "Petrov");
            contact.Nickname = "ipetrov";
            contact.Address = "NN";
            app.Contact.FillContactForm(contact);
            app.Contact.SubmitContactCreation();
        }
            
    }
}
