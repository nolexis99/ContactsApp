using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace ContactsApp
{
    /// <summary>
    /// Класс менеджер проекта.
    /// </summary>
    public class ProjectManager
    {
        /// <summary>
        /// Метод, который загружает контакты из файла.
        /// </summary>
        public Project LoadFromFile( string path)
        {
            Project project = null;
            JsonSerializer serializer = new JsonSerializer();
            using (StreamReader sr = new StreamReader(path))
            using (JsonReader reader = new JsonTextReader(sr))
            {
                project = (Project)serializer.Deserialize<Project>(reader);
            }
            if (project == null)
            {
                project = new Project();
                project.Contacts = new List<Contact>();
            }
            return project;
        }

        /// <summary>
        /// Метод, который сохраняет контакты в файл.
        /// </summary>
        public void SaveToFile(Project project, string path)
        {
            if (!File.Exists(path)) using (FileStream fs = File.Create(path)) { }
            JsonSerializer serializer = new JsonSerializer();
            using (StreamWriter sw = new StreamWriter(path))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, project);
            }
        }
    }
}
