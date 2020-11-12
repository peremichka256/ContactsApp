using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using ContactsApp;
using NUnit.Framework;

namespace ContactsAppUnitTests
{
    [TestFixture]
    class ProjectManagerTests
    {
        private string _testPath =
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)
            +"\\TestDirectory\\TestData.notes";

        private Project _testProject;

        public void InitProject()
        {
            _testProject = new Project();

            _testProject.Contacts.Add(new Contact(
                "3TestSurname",
                "TestFirstName",
                new PhoneNumber(79998877666),
                new DateTime(2000, 1, 1),
                "TestEmail",
                "TestiDVK"));

            ProjectManager.SaveToFile(_testProject, _testPath);
        }

        [Test(Description = "Попытка загрузки несуществующего файла")]
        public void TestLoad_FromNonExistentDirectory()
        {
            InitProject();

            if (File.Exists(_testPath))
            {
                File.Delete(_testPath);
            }

            _testProject = ProjectManager.LoadFromFile(_testPath);
            Assert.IsFalse(File.Exists(_testPath),
                "Новый файл не был создан при загрузки");
        }

        [Test(Description = "Попытка сохраненения файла в несуществующую директорию")]
        public void TestSave_ToNonExistentFile()
        {
            InitProject();

            if (!Directory.Exists(Path.GetDirectoryName(_testPath)))
            {
                Directory.Delete(Path.GetDirectoryName(_testPath));
            }

            ProjectManager.SaveToFile(_testProject, _testPath);

            Assert.IsFalse(File.Exists(Path.GetDirectoryName(_testPath)),
                "Директория, а значит и файл не были созданы при сохранении");
        }
    }
}
