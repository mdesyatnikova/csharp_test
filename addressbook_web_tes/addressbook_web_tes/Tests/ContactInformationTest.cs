using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebArrdessbookTests
{
    [TestFixture]
    public class ContactInformationTests : Auth_TestBase
    {
        [Test]
        public void ContactInformationFromTableTest()
        {
            ContactData fromTable = app.Contact.GetContactInformationFromTable(0);
            ContactData fromForm = app.Contact.GetContactInformationFromEditForm(0);

            //verification
            Assert.AreEqual(fromTable, fromForm);
            Assert.AreEqual(fromTable.Address, fromForm.Address);
            Assert.AreEqual(fromTable.AllPhones, fromForm.AllPhones);
            Assert.AreEqual(fromTable.AllEmail, fromForm.AllEmail);
        }

        [Test]
        public void ContactInformationFromDetailsTest()
        {
            ContactData fromDetails = app.Contact.GetContactInformationFromDetails(0);
            ContactData fromForm = app.Contact.GetContactInformationFromEditForm(0);

            //verification
            Assert.AreEqual(fromDetails.AllInfo, fromForm.AllInfo);
        }
    }
}
