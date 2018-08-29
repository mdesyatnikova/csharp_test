﻿using System;
using System.Text;
using System.Collections.Generic;
using NUnit.Framework;
using System.IO;
using System.Net.FtpClient;

namespace mantis_tests
{
    [TestFixture]
    public class AccountCreationTests: TestBase
    {
        [OneTimeSetUp]

        public void SetUpConfig()
        {
            app.Ftp.BackupFile("/config_inc.php");
            using (Stream localFile = File.Open("C:/Users/mdesy/source/repos/csharp_test/mantis_tests/mantis_tests/config_inc.php", FileMode.Open))
            {
                app.Ftp.Upload("/config_inc.php", localFile);
            }
        }

        [Test]
        public void TestAccountRegistration()
        {
            AccountData account = new AccountData()
            {
                Name = "test.user",
                Password = "password",
                Email = "test.user@localhost.localdomain"
            };

            app.Registration.Registrator(account);
        
        }

        [OneTimeTearDown]

        public void RestoreConfig()
        {
           app.Ftp.RestoreBackupFile("/config_inc.php");
        }
    }
}
