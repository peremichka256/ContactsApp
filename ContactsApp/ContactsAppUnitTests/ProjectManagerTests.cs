using ContactsApp;
using NUnit.Framework;
using System;
using System.Reflection;
using System.IO;


namespace ContactsAppUnitTests
{
    //TODO: явно модификатор доступа класса
    [TestFixture]
    public class ProjectManagerTests
    {
        //TODO: юнит-тесты не должны работать с AppData, только внутри папки bin самого проекта юнит-тестов (чтобы уменьшить вероятность влияния результатов предыдущих запусков на новый)
        private string _testPath =
            Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)
            + "\\TestDirectory\\TestData.notes";

        private string _corruptedFilePath =
            Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)
            + "\\TestDirectory\\CorruptedTestData.notes";

        //TODO: никакого поля
        //TODO: возвращай объект из метода
        [Test(Description = "Попытка загрузки несуществующего файла")]
        public void TestLoad_FromNonExistentDirectory()
        {
            //TODO: зачем здесь инит?
            //TODO: создаешь не нужный проект в тесте, потом его сохраняешь в файл, затем тут же файл удаляешь и пытаешься его загрузить? Что здесь происходит? Зачем столько действий?
            //TODO: ты проверяешь только путь, а надо проверять и что вернулось из метода загрузки. Действительно ли пустой проект?
            Project project = ProjectManager.LoadFromFile("");
            Assert.IsEmpty(project.Contacts, "В проект загруженны неизвестные данные");
        }

        //TODO: а по здравому смыслу - если папки не существует, почему менеджер проекта не может её просто создать? Также будет удобнее пользоваться классом
        [Test(Description = "Попытка сохранения файла в несуществующую директорию")]
        public void TestSave_ToNonExistentFile()
        {
            //TODO: здесь вызывается лишнее сохранение
            var testProject = TestProjectInitializer.InitProject();

            if (Directory.Exists(Path.GetDirectoryName(_testPath)))
            {
                File.Delete(_testPath);
            }

            //TODO: для сохранения лучше использовать другой путь
            ProjectManager.SaveToFile(testProject, _testPath);

            Assert.IsTrue(File.Exists(_testPath), "Файл не был создан при сохранении");
        }
        //TODO: нужны еще тесты:
        // Позитивный тест на сохранение - то, что сохранение работает и ПРАВИЛЬНО сохраняет данные в файл (два-три контакта в проекте)
        // Позитивный тест на загрузку - проверка, что загрузка ПРАВИЛЬНО загружает данные из файла (два-три контакта в проекте)
        // Негативный тест на загрузку поврежденного файла - файл может существовать, но быть поврежденным

        [Test(Description = "Позитивный тест на сохранение файла")]
        public void TestSave_Correct()
        {
            var testProject = TestProjectInitializer.InitProject();
            ProjectManager.SaveToFile(testProject, _testPath);

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
                for (int i = 0; i < expectedProject.Contacts.Count; i++)
                {
                    Assert.AreEqual(expectedProject.Contacts[i].Surname,
                        testProject.Contacts[i].Surname,
                        "Контакт из файла был загружен неправильно");
                }
            });
        }

        [Test(Description = "Негативный тест на загрузку поврежденного файл")]
        public void TestLoad_CoruptedFile()
        {
            var testProject = ProjectManager.LoadFromFile(_corruptedFilePath);

            Assert.IsEmpty(testProject.Contacts, "Загружены неизвестные данные");
        }
    }
}
