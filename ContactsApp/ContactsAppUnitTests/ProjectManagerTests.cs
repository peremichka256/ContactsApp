using ContactsApp;
using NUnit.Framework;
using System;
using System.Reflection;
using System.IO;


namespace ContactsAppUnitTests
{
    [TestFixture]
    public class ProjectManagerTests
    {
        //TODO: откуда берутся эти файлы? Они должны быть добавлены в сам проект в папку TestData, чтобы ими можно было управлять из студии.
        private string _testPath =
            Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)
            + "\\TestDirectory\\TestData.notes";

        private string _corruptedFilePath =
            Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)
            + "\\TestDirectory\\CorruptedTestData.notes";

        [Test(Description = "Попытка загрузки несуществующего файла")]
        public void TestLoad_FromNonExistentDirectory()
        {
            Project project = ProjectManager.LoadFromFile("");
            Assert.IsEmpty(project.Contacts, "В проект загруженны неизвестные данные");
        }

        [Test(Description = "Попытка сохранения файла в несуществующую директорию")]
        public void TestSave_ToNonExistentFile()
        {
            var testProject = TestProjectInitializer.InitProject();

            if (Directory.Exists(Path.GetDirectoryName(_testPath)))
            {
                File.Delete(_testPath);
            }

            ProjectManager.SaveToFile(testProject, _testPath);

            Assert.IsTrue(File.Exists(_testPath), "Файл не был создан при сохранении");
        }

        [Test(Description = "Позитивный тест на сохранение файла")]
        public void TestSave_Correct()
        {
            var testProject = TestProjectInitializer.InitProject();
            ProjectManager.SaveToFile(testProject, _testPath);
            //TODO: Опять! Здесь ты проверяешь только существование файла, а надо проверять правильно ли он записался. Для этого должен быть эталонный файл проекта, с которым ты будешь сравнивать новый сохраненный файл.
            Assert.IsTrue(File.Exists(_testPath), "Файл не был создан при сохранении");
        }

        [Test(Description = "Позитивный тест на загрузку файла")]
        public void TestLoad_Correct()
        {
            var testProject = TestProjectInitializer.InitProject();
            ProjectManager.SaveToFile(testProject, _testPath);
            var expectedProject = ProjectManager.LoadFromFile(_testPath);

            Assert.Multiple(() =>
            {
                //TODO: Почему проверяются только фамилии? А если другие данные загрузились неправильно? А если в загруженном файле больше контактов, чем в ожидаемом?
                //TODO: опять же - создание метода Equals в классе Contact сделает жизнь проще
                for (int i = 0; i < expectedProject.Contacts.Count; i++)
                {
                    Assert.AreEqual(expectedProject.Contacts[i].Surname,
                        testProject.Contacts[i].Surname,
                        "Контакт из файла был загружен неправильно");
                }
            });
        }

        //TODO: грамошибка в названии
        [Test(Description = "Негативный тест на загрузку поврежденного файл")]
        public void TestLoad_CoruptedFile()
        {
            var testProject = ProjectManager.LoadFromFile(_corruptedFilePath);

            Assert.IsEmpty(testProject.Contacts, "Загружены неизвестные данные");
        }
    }
}
