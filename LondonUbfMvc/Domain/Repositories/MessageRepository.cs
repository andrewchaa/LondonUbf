using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using LondonUbfWeb.Domain.Interfaces;
using LondonUbfWeb.Domain.Models;

namespace LondonUbfWeb.Domain.Repositories
{
    public class MessageRepository : IRepositoryFile
    {
        private string _baseDir;
        private string _searchword;

        public MessageRepository(string baseDir)
        {
            _baseDir = baseDir;
            _searchword = string.Empty;
        }

        public MessageRepository(string baseDir, string searchCondition)
        {
            if (string.IsNullOrEmpty(searchCondition))
                searchCondition = string.Empty;

            _searchword = GetSearchWord(searchCondition);

            _baseDir = baseDir;
        }

        public IQueryable<ServerFile> ListItems()
        {
            return ListFiles(new DirectoryInfo(_baseDir));
        }

        private IQueryable<ServerFile> ListFiles(DirectoryInfo dir)
        {
            try // fix irregular directory permission issues.
            {
                var files = GetFiles(dir);

                var subDirs = dir.GetDirectories();
                foreach (var d in subDirs)
                {
                    files = files.Concat(ListFiles(d));
                }

                return files.AsQueryable();
            }
            catch (Exception ex)
            {
                return new List<ServerFile>().AsQueryable();
            }


            
        }

        public ServerFile GetItem()
        {
            throw new NotImplementedException();
        }


        private IEnumerable<ServerFile> GetFiles(DirectoryInfo dir)
        {
            try
            {
                var files = dir.GetFiles();
                return files
                    .Where(f => f.Name.ToLower().Contains(_searchword))
                    .Where(f => !f.Name.StartsWith("~"))
                    .Select(f => new ServerFile
                                     {
                                         Date = f.LastWriteTime,
                                         PartialPath = RemoveRootPath(f.FullName),
                                         IsFolder = false,
                                         Name = f.Name
                                     });

            }
            catch (Exception ex)
            {
                return new List<ServerFile>();
            }
        }

        private string RemoveRootPath(string path)
        {
            return path.Replace(_baseDir, string.Empty);
        }

        public static string GetSearchWord(string searchCondition)
        {
            if (searchCondition == "none")
                return string.Empty;

            return searchCondition.ToLower();
        }
    }
}
