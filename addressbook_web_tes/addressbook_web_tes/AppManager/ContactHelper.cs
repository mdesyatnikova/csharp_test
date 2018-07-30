using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Text.RegularExpressions;

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
            manager.Navigator.GoToHomePage();
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
            contactCache = null;
            return this;
        }

        public ContactHelper RemoveContact()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            contactCache = null;
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
            contactCache = null;
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

        private List<ContactData> contactCache = null;

        public List<ContactData> GetContactList()
        {
            if (contactCache == null)
            {
            contactCache = new List<ContactData>();
            manager.Navigator.GoToHomePage();
            ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("tr[name=\"entry\"]"));
                foreach (IWebElement element in elements)
                {
                    IList<IWebElement> cells = element.FindElements(By.TagName("td"));

                    string firstName = cells[2].Text;
                    string lastName = cells[1].Text;

                    contactCache.Add(new ContactData(firstName, lastName) { 
                        Id = element.FindElement(By.TagName("input")).GetAttribute("value")});
                }
            }
            return new List<ContactData>(contactCache);
        }

        public int GetContactCount()
        {
            return driver.FindElements(By.CssSelector("tr[name=\"entry\"]")).Count;
        }

        public ContactData GetContactInformationFromTable(int p)
        {
            manager.Navigator.GoToHomePage();
            IList<IWebElement> cells = driver.FindElements(By.Name("entry"))[p].FindElements(By.TagName("td"));
            string lastName = cells[1].Text;
            string firstName = cells[2].Text;
            string address = cells[3].Text;
            string allEmail = cells[4].Text;
            string allPhones = cells[5].Text;

            return new ContactData(firstName, lastName)
            {
                Address = address,
                AllPhones = allPhones,
                AllEmail = allEmail
            };

        }

        public ContactData GetContactInformationFromEditForm(int p)
        {
            manager.Navigator.GoToHomePage();
            InitContactModify(p);
            string firstName = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string lastName = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string nickName = driver.FindElement(By.Name("nickname")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");
            string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");
            string email = driver.FindElement(By.Name("email")).GetAttribute("value");
            string email2 = driver.FindElement(By.Name("email2")).GetAttribute("value");
            string email3 = driver.FindElement(By.Name("email3")).GetAttribute("value");

            return new ContactData(firstName, lastName)
            {
                Nickname = nickName,
                Address = address,
                HomePhone = homePhone,
                MobilePhone = mobilePhone,
                WorkPhone = workPhone,
                Email = email,
                Email2 = email2,
                Email3 = email3,
            };
        }

        public ContactData GetContactInformationFromDetails(int p)
        {
            manager.Navigator.GoToHomePage();
            InitContactDetais(p);
            string name = driver.FindElement(By.Id("content")).FindElement(By.TagName("b")).Text;
            string[] split = name.Split(' ');
            string firstName = split[0];
            string lastName = split[1];
            string allInfo = driver.FindElement(By.Id("content")).Text;
            allInfo = Regex.Replace(allInfo, "[ :HMW]", "");

            return new ContactData(firstName, lastName)
            {
                AllInfo = allInfo
            };
        }

        public ContactHelper InitContactDetais(int p)
        {
            driver.FindElement(By.XPath("(//img[@alt='Details'])[" + (p + 1) + "]")).Click();
            return this;
        }

        public int GetNumberOfSearchResults()
        {
            manager.Navigator.GoToHomePage();
            string text = driver.FindElement(By.Id("search_count")).Text;
            return Int32.Parse(text);
        }
    }
}
