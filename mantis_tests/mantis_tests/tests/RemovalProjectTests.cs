using System;
using System.Text;
using System.Collections.Generic;
using NUnit.Framework;


namespace mantis_tests
{
    [TestFixture]
    public class RemovalProjectTests : Auth_TestBase
    {
        [Test]
        public void TestRemovalProject()
        {
            app.Project.Remove(1);
        }
    }
}
