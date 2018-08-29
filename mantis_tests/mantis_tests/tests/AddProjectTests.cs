using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace mantis_tests
{
    [TestFixture]
    public class AddProjectTests : Auth_TestBase
    {
        [Test]
        public void TestAddProject ()
        {
            ProjectData newData = new ProjectData()
            {
                Name = "project1",
                Description = "description1"
            };

            app.Project.Add(newData);
        }

    }
}
