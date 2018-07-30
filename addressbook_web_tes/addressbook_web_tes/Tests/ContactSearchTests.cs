using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebArrdessbookTests
{
    [TestFixture]
    public class ContactSearchTests : Auth_TestBase
    {
        [Test]
        public void ContactSearchTest()
        {
            System.Console.Out.Write(app.Contact.GetNumberOfSearchResults());
        }

    }
}
