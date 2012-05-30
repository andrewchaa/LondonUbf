﻿using System;
using System.Collections.Generic;
using System.Linq;
using LondonUbfWeb.Domain.Interfaces;
using LondonUbfWeb.Domain.Models;

namespace LondonUbfWeb.Test.Repositories
{
    class RepositoryFileTest : IRepositoryFile
    {
        List<ServerFile> _list;

        public RepositoryFileTest()
        {
            _list = new List<ServerFile>();
            _list.Add(new ServerFile() {Date = DateTime.Now, IsFolder=false, Name="mvc.docx", PartialPath = "" });
        }

        #region IRepositoryFile Members

        public ServerFile GetItem(string path)
        {
            throw new NotImplementedException();
        }

        public IQueryable<ServerFile> ListItems(string path)
        {
            return _list.AsQueryable();
        }

        #endregion

        #region IRepositoryFile Members


        public ServerFile GetItem()
        {
            throw new NotImplementedException();
        }

        public IQueryable<ServerFile> ListItems()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
