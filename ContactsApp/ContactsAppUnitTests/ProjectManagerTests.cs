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
    //TODO: явно модификатор доступа класса
    [TestFixture]
    class ProjectManagerTests
    {
        //TODO: юнит-тесты не должны работать с AppData, только внутри папки bin самого проекта юнит-тестов (чтобы уменьшить вероятность влияния результатов предыдущих запусков на новый)
        private string _testPath =
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)
            +"\\TestDirectory\\TestData.notes";

        //TODO: никакого поля
        private Project _testProject;

        //TODO: возвращай объект из метода
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
            //TODO: почему Init занимается сохранением? Это разве для всех тестов нужно?
            ProjectManager.SaveToFile(_testProject, _testPath);
        }

        [Test(Description = "Попытка загрузки несуществующего файла")]
        public void TestLoad_FromNonExistentDirectory()
        {
            //TODO: зачем здесь инит?
            InitProject();

            //TODO: создаешь не нужный проект в тесте, потом его сохраняешь в файл, затем тут же файл удаляешь и пытаешься его загрузить? Что здесь происходит? Зачем столько действий?
            if (File.Exists(_testPath))
            {
                File.Delete(_testPath);
            }

            _testProject = ProjectManager.LoadFromFile(_testPath);
            //TODO: ты проверяешь только путь, а надо проверять и что вернулось из метода загрузки. Действительно ли пустой проект?
            Assert.IsFalse(File.Exists(_testPath),
                "Новый файл не был создан при загрузки");
        }

        //TODO: а по здравому смыслу - если папки не существует, почему менеджер проекта не может её просто создать? Также будет удобнее пользоваться классом
        [Test(Description = "Попытка сохраненения файла в несуществующую директорию")]
        public void TestSave_ToNonExistentFile()
        {
            //TODO: здесь вызывается лишнее сохранение
            InitProject();

            if (!Directory.Exists(Path.GetDirectoryName(_testPath)))
            {
                Directory.Delete(Path.GetDirectoryName(_testPath));
            }

            //TODO: для сохранения лучше использовать другой путь
            ProjectManager.SaveToFile(_testProject, _testPath);

            Assert.IsFalse(File.Exists(Path.GetDirectoryName(_testPath)),
                "Директория, а значит и файл не были созданы при сохранении");
        }

        //TODO: нужны еще тесты:
        // Позитивный тест на сохранение - то, что сохранение работает и ПРАВИЛЬНО сохраняет данные в файл (два-три контакта в проекте)
        // Позитивный тест на загрузку - проверка, что загрузка ПРАВИЛЬНО загружает данные из файла (два-три контакта в проекте)
        // Негативный тест на загрузку поврежденного файла - файл может существовать, но быть поврежденным
    }
}
