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
        /// Сохраняет объект <see cref="Project"/>
        /// </summary>
        /// <param name="project">Сохраняемый объект</param>
        public static void SaveToFile(Project project)
        {
            Directory.CreateDirectory(@"c:\My Documents\ContactsAppData");
            JsonSerializer jsonSerializer = new JsonSerializer();

            using (StreamWriter stream
                = new StreamWriter(@"c:\My Documents\ContactsAppData\Contacts.txt"))
            using (JsonWriter writer = new JsonTextWriter(stream))
            {
                jsonSerializer.Serialize(writer, project);
            }

            
        }

        /// <summary>
        /// Загружает из файла объект <see cref="Project"/>
        /// </summary>
        /// <returns>Загруженный объект <see cref="Project"/></returns>
        public static Project LoadFromFile()
        {
            Project project = null;

            JsonSerializer jsonSerializer = new JsonSerializer();

            using (StreamReader stream
                = new StreamReader(@"c:\My Documents\ContactsAppData\Contacts.txt"))
            using (JsonReader reader = new JsonTextReader(stream))
            {
                project = jsonSerializer.Deserialize<Project>(reader);
            }

            return project;
        }
    }
}
