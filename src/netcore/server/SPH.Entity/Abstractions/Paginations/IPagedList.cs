﻿using System.Collections.Generic;

namespace SPH.Entity.Abstractions.Paginations
{
    public interface IPagedList<TEntity>
    {
        int IndexFrom { get; }

        int PageIndex { get; set; }

        int PageSize { get; set; }

        int TotalCount { get; }

        int TotalPages { get; }

        IList<TEntity> Items { get; }

        bool HasPreviousPage { get; }

        bool HasNextPage { get; }
    }
}
