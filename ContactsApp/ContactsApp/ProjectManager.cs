using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;


namespace ContactsApp
{
    /// <summary>
    /// Класс менеджер проекта, осуществляtт сериализацию списка контактов
    /// </summary>
    public static class ProjectManager
    {
        /// <summary>
        /// Поле с путём по умолчанию для сериализации проекта
        /// </summary>
        public static string DefaultFilePath { get; private set; } =
               Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) 
                + @"\ContactsApp\ContactsApp.notes"; //TODO: используй @строки

        /// <summary>
        /// Сохраняет объект <see cref="Project"/>
        /// </summary>
        /// <param name="project">Сохраняемый объект</param>
        public static void SaveToFile(Project project, string path)
        {
            if (!Directory.Exists(Path.GetDirectoryName(path)))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(path));
            }
            JsonSerializer jsonSerializer = new JsonSerializer();

            using (StreamWriter stream = new StreamWriter(path))
            using (JsonWriter writer = new JsonTextWriter(stream))
            {
                jsonSerializer.Serialize(writer, project);
            }
        }

        /// <summary>
        /// Загружает из файла объект <see cref="Project"/>
        /// </summary>
        /// <returns>Загруженный объект <see cref="Project"/></returns>
        public static Project LoadFromFile(string path)
        {
            Project project = new Project();

            if (!File.Exists(path))
            {
                return project; 
            }

            //TODO: надо обрабатывать исключения на невозможность прочитать файл, ошибки файла и десериализации - на любую ошибку возвращать пустой проект
            using (StreamReader stream = new StreamReader(path))
            {
                string projectContent = stream.ReadLine();
                if (string.IsNullOrEmpty(projectContent))
                {
                    return project;
                }

                try
                {
                    project = JsonConvert.DeserializeObject<Project>(projectContent);
                }
                catch (Newtonsoft.Json.JsonReaderException)
                {
                    return project;
                }
            }
            return project;
        }
    }
}
