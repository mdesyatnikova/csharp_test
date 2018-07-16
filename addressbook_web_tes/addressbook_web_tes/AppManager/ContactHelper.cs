using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebArrdessbookTests
{
    public class ContactHelper : HelperBase
    {
        public ContactHelper(ApplicationManager manager) : base(manager)
        {
        }

        public ContactHelper Create(ContactData contact)
        {
            InitNewContactCreation();
            FillContactForm(contact);
            SubmitContactCreation();
            manager.Navigator.ReturnToHomePage();
            return this;
        }

        internal ContactHelper Modify(int p, ContactData contact, ContactData newData)
        {
            InitContactModify(p, contact);
            FillContactForm(newData);
            SubmitContactModify();
            manager.Navigator.ReturnToHomePage();
            return this;
        }

        public ContactHelper Remove(int p, ContactData contact)
        {
            SelectContact(p, contact);
            RemoveContact();
            CloseAlert();
            return this;
        }

        public ContactHelper FillContactForm(ContactData contact)
        {
            Type(By.Name("firstname"), contact.Firstname);
            Type(By.Name("lastname"), contact.Lastname);
            Type(By.Name("nickname"), contact.Nickname);
            Type(By.Name("address"), contact.Address);
            return this;
        }

        
        public ContactHelper InitNewContactCreation()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }

        public ContactHelper SubmitContactCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            return this;
        }

        public ContactHelper RemoveContact()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            return this;
        }

        public ContactHelper SelectContact(int p, ContactData contact)
        {
            if (IsElementPresent(By.XPath("(//input[@name='selected[]'])[" + p + "]")) == false)
            {
                Create(contact);
            }
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + p + "]")).Click();
            return this;
        }

        public ContactHelper SubmitContactModify()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }

        public ContactHelper InitContactModify(int p, ContactData contact)
        {
            if (IsElementPresent(By.XPath("(//input[@name='selected[]'])[" + p + "]")) == false)
            {
                Create(contact);
            }
                driver.FindElement(By.XPath("(//img[@alt='Edit'])[" + p + "]")).Click();
            return this;
        }

        public ContactHelper CloseAlert()
        {
            driver.SwitchTo().Alert().Accept();
            return this;
        }
    }
}
