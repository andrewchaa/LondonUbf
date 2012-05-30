using System.Linq;
using System.IO;
using LondonUbfWeb.Domain.Interfaces;
using LondonUbfWeb.Domain.Models;

namespace LondonUbfWeb.Domain.Repositories
{
    public class FileRepository : IRepositoryFile
    {
        private string _baseDir, _path, _searchword;

        public FileRepository() { }
        public FileRepository(string baseDir, string path, string searchword)
        {
            _baseDir = baseDir;
            _path = _baseDir + path;
            _searchword = MessageRepository.GetSearchWord(searchword);
        }

        #region IRepositoryFile Members

        public ServerFile GetItem()
        {
            DirectoryInfo dir = new DirectoryInfo(_path);
            ServerFile item = new ServerFile()
            {
                Date = dir.LastWriteTime,
                PartialPath = RemoveRoot(dir.FullName),
                Name = dir.Name,
                IsFolder = true,
                ParentDirectory = GetParentDirectory(dir.FullName, dir.Name),
            };

            return item;
        }

        public IQueryable<ServerFile> ListItems()
        {
            var dir = new DirectoryInfo(_path);

            var folders = dir
                .GetDirectories()
                .Where(d => d.Name.ToLower().Contains(_searchword))
                .Select(d => new ServerFile
                                 {
                                     Date = d.LastWriteTime,
                                     PartialPath = RemoveRoot(d.FullName),
                                     Name = d.Name,
                                     IsFolder = true
                                 });

            var files = dir
                .GetFiles()
                .Where(f => f.Name.ToLower().Contains(_searchword))
                .Where(f => !f.Name.StartsWith("~"))
                .Select(f => new ServerFile
                                 {
                                     Date = f.LastWriteTime,
                                     PartialPath = RemoveRoot(f.FullName),
                                     Name = f.Name,
                                     IsFolder = false
                                 });


            return folders.Concat(files).AsQueryable();
        }

        #endregion

        private string RemoveRoot(string path)
        {
            if (path.Length <= _baseDir.Length)
                return string.Empty;

            return path.Replace(_baseDir, string.Empty);
        }

        private string GetParentDirectory(string path, string fileName)
        {
            return RemoveRoot(path.Replace(fileName, string.Empty));
        }
    }
}
