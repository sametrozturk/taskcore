using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.XPath;
using TaskCore.Dal.Models;

namespace TaskCore.Dal.FileSystem
{
    internal class FileManager
    {
        private readonly DirectoryInfo _activeTasksDir;
        private readonly DirectoryInfo _completedTasksDir;
        private readonly DirectoryInfo _categoriesDir;

        public FileManager()
        {
            if (!Directory.Exists("./db"))
            {
                Directory.CreateDirectory("./db");
                Directory.CreateDirectory("./db/active");
                Directory.CreateDirectory("./db/completed");
                Directory.CreateDirectory("./db/categories");
            }

            _activeTasksDir = new DirectoryInfo("./db/active");
            _completedTasksDir = new DirectoryInfo("./db/completed");
            _categoriesDir = new DirectoryInfo("./db/categories");
        }

        public void SaveActiveTask(string fileName, string content)
        {
            File.WriteAllText(Path.Combine(_activeTasksDir.FullName, fileName),
                content);
        }

        public void SaveCompletedTask(string fileName, string content)
        {
            File.WriteAllText(Path.Combine(_completedTasksDir.FullName, fileName),
                content);
        }

        public void DeleteActiveTask(string fileName)
        {
            File.Delete(Path.Combine(_activeTasksDir.FullName, fileName));
        }

        public void DeleteCompletedTask(string fileName)
        {
            File.Delete(Path.Combine(_completedTasksDir.FullName, fileName));
        }

        public List<string> GetActiveTasksContents()
        {
            var allTaskFiles = _activeTasksDir.GetFiles();
            return allTaskFiles.Select(a => File.ReadAllText(a.FullName)).ToList();
        }

        public List<string> GetCompletedTasksContents()
        {
            var allTaskFiles = _completedTasksDir.GetFiles();
            return allTaskFiles.Select(a => File.ReadAllText(a.FullName)).ToList();
        }

        public void SaveCategory(string fileName, string content)
        {
            File.WriteAllText(Path.Combine(_categoriesDir.FullName, fileName), content);
        }

        public void DeleteCategory(string fileName)
        {
            var fileAbsolutePath = Path.Combine(_categoriesDir.FullName, fileName);
            if (File.Exists(fileAbsolutePath))
            {
                File.Delete(fileAbsolutePath);
            }
        }

        public string? GetCategory(string fileName)
        {
            var fileAbsolutePath = Path.Combine(_categoriesDir.FullName, fileName);
            return File.Exists(fileAbsolutePath) ? File.ReadAllText(fileAbsolutePath) : null;
        }
    }
}