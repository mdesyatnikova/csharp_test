﻿using System;
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

        internal ContactHelper Modify(int p, ContactData newData)
        {
            InitContactModify(p);
            FillContactForm(newData);
            SubmitContactModify();
            manager.Navigator.ReturnToHomePage();
            return this;
        }



        public ContactHelper Remove(int p)
        {
            SelectContact(p);
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

        public ContactHelper SelectContact(int p)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + (p+1) + "]")).Click();
            return this;
        }

        public ContactHelper SubmitContactModify()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }

        public ContactHelper InitContactModify(int p)
        {
            driver.FindElement(By.XPath("(//img[@alt='Edit'])[" + (p+1) + "]")).Click();
            return this;
        }

        public ContactHelper CloseAlert()
        {
            driver.SwitchTo().Alert().Accept();
            return this;
        }

        public bool CheckElement()
        {
            return IsElementPresent(By.XPath("(//input[@name='selected[]'])[1]"));            
        }

        public List<ContactData> GetContactList()
        {
            List<ContactData> contacts = new List<ContactData>();
            manager.Navigator.GoToHomePage();
            ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("tr[name=\"entry\"]"));
            foreach (IWebElement element in elements)
            {
                ICollection<IWebElement> cells = element.FindElements(By.TagName("td"));
                int i = 0;
                string firstname = null;
                string lastname = null;
                foreach (IWebElement cell in cells)
                {
                    i++;
                    if (i == 2)
                    {
                        lastname = cell.Text;
                    }
                    else if (i == 3)
                    {
                        firstname = cell.Text;
                    }
                }
                contacts.Add(new ContactData(firstname, lastname));
            }
            return contacts;
        }
    }
}
