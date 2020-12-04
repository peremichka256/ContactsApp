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
        private readonly string _testFilePath = 
            Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)
            + @"\TestData\TestData.notes";

        private readonly string _corruptedFilePath =
            Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)
            + @"\TestData\CorruptedTestData.notes";


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

            if (Directory.Exists(Path.GetDirectoryName(_testFilePath)))
            {
                File.Delete(_testFilePath);
            }

            ProjectManager.SaveToFile(testProject, _testFilePath);

            Assert.IsTrue(File.Exists(_testFilePath), "Файл не был создан при сохранении");
        }

        [Test(Description = "Позитивный тест на сохранение файла")]
        public void TestSave_Correct()
        {
            var testProject = TestProjectInitializer.InitProject();
            string location =
             Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)
             + @"\TestData\TestSavedData.notes";

            if (File.Exists(location))
            {
                File.Delete(location);
            }
            ProjectManager.SaveToFile(testProject, location);
            //TODO: Опять! Здесь ты проверяешь только существование файла, а надо проверять правильно ли он записался. Для этого должен быть эталонный файл проекта, с которым ты будешь сравнивать новый сохраненный файл.
            Assert.IsTrue(File.Exists(location), "Файл не был создан при сохранении");
            Assert.AreEqual(File.ReadAllText(location), File.ReadAllText(_testFilePath),
                "Содержание файлов отличается");
        }

        [Test(Description = "Позитивный тест на загрузку файла")]
        public void TestLoad_Correct()
        {
            var testProject = TestProjectInitializer.InitProject();
            ProjectManager.SaveToFile(testProject, _testFilePath);
            var expectedProject = ProjectManager.LoadFromFile(_testFilePath);

            Assert.Multiple(() =>
            {
                Assert.AreEqual(expectedProject.Contacts.Count, testProject.Contacts.Count,
                    "Загруженные проекты отличаются количеством контактов");
                //TODO: Почему проверяются только фамилии? А если другие данные загрузились неправильно? А если в загруженном файле больше контактов, чем в ожидаемом?
                //TODO: опять же - создание метода Equals в классе Contact сделает жизнь проще
                for (int i = 0; i < expectedProject.Contacts.Count; i++)
                {
                    Assert.IsTrue(expectedProject.Contacts[i].Equals(testProject.Contacts[i]),
                        "Контакт из файла был загружен неправильно");
                }
            });
        }

        //TODO: грамошибка в названии
        [Test(Description = "Негативный тест на загрузку поврежденного файл")]
        public void TestLoad_CorruptedFile()
        {
            var testProject = ProjectManager.LoadFromFile(_corruptedFilePath);

            Assert.IsEmpty(testProject.Contacts, "Загружены неизвестные данные");
        }
    }
}
