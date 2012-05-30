﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace LondonUbfWeb.Helpers
{
    public class PagedList<T> : List<T>
    {
        public int PageIndex { get; private set; }
        public int PageSize { get; private set; }
        public int TotalCount { get; private set; }
        public int TotalPages { get; private set; }

        public PagedList() {}    

        public PagedList(IEnumerable<T> source, int pageIndex, int pageSize) : this(source.AsQueryable<T>(), pageIndex, pageSize) { }
        public PagedList(IQueryable<T> source, int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            TotalCount = source.Count();
            TotalPages = (int)Math.Ceiling(TotalCount / (double)PageSize);

            AddRange(source.Skip(PageIndex * PageSize).Take(PageSize));
        }


        public bool HasPreviousPage
        {
            get
            {
                return (PageIndex > 0);
            }
        }

        public bool HasNextPage
        {
            get
            {
                return (PageIndex + 1 < TotalPages);
            }
        }
    }
}
