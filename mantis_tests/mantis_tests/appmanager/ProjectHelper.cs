using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace mantis_tests
{
    public class ProjectHelper: HelperBase
    {
        public ProjectHelper(ApplicationManager manager) : base(manager) { }

        public ProjectHelper Add(ProjectData project)
        {
            manager.Menu.GoToManageMenu();
            manager.Menu.GoToProjectForm();
            InitAddProject();
            FillProjectForm(project);
            SubmitAddProject();
            return this;
        }

        public void Remove(int p)
        {
            manager.Menu.GoToManageMenu();
            manager.Menu.GoToProjectForm();
            SelectProject(p);
            RemoveProject();
            SubmitRemoveProject();
        }

        public void SubmitAddProject()
        {
            driver.FindElement(By.XPath("//input[@type='submit' and @value='Add Project']")).Click();
        }

        public ProjectHelper FillProjectForm(ProjectData project)
        {
            driver.FindElement(By.Name("name")).SendKeys(project.Name);
            driver.FindElement(By.Name("description")).SendKeys(project.Description);
            return this;
        }

        public void InitAddProject()
        {
            driver.FindElement(By.CssSelector("[type='submit']")).Click();
        }

        public void RemoveProject()
        {
            driver.FindElement(By.XPath("//input[@type='submit' and @value='Delete Project']")).Click();            
        }

        public void SubmitRemoveProject()
        {
            driver.FindElement(By.XPath("//input[@type='submit' and @value='Delete Project']")).Click();
        }

        public void SelectProject(int p)
        {
            driver.FindElement(By.XPath("//a[@href='manage_proj_edit_page.php?project_id="+p+"']")).Click();
        }
    }
}