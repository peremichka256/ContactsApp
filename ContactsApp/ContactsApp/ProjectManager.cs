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
                + "\\ContactsApp\\ContactsApp.notes";

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
            if (!File.Exists(path))
            {
                return new Project(); 
            }
            Project project = null;

            JsonSerializer jsonSerializer = new JsonSerializer();

            using (StreamReader stream = new StreamReader(path))
            using (JsonReader reader = new JsonTextReader(stream))
            {
                project = jsonSerializer.Deserialize<Project>(reader);
            }

            return project;
        }
    }
}
