﻿using System.Collections.Generic;

namespace SPH.Entity.Abstractions.Paginations
{
    public class PagedList<TEntity> : IPagedList<TEntity> where TEntity : class
    {
        public int IndexFrom { get; }

        public int PageIndex { get; set; }

        public int PageSize { get; set; }

        public int TotalCount { get; }

        public int TotalPages { get; }

        public IList<TEntity> Items { get; }

        public bool HasPreviousPage
            => PageIndex > IndexFrom;

        public bool HasNextPage
            => PageIndex < TotalPages;

        public PagedList(
            int pageIndex,
            int pageSize,
            int indexFrom,
            int totalCount,
            int totalPages,
            IList<TEntity> items)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            IndexFrom = indexFrom;
            TotalCount = totalCount;
            TotalPages = totalPages;
            Items = items;
        }

        internal PagedList() => Items = new TEntity[0];
    }
}
