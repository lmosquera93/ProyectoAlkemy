﻿using OngProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace OngProject.Repositories
{
    public class QueryProperty<T> where T : BaseEntity
    {
        public QueryProperty()
        {

        }

        public QueryProperty(int page, int pageCount)
        {
            page = page > 0 ? page : 1;
            pageCount = pageCount > 0 ? pageCount : 1;

            Skip = (page - 1) * pageCount;
            Take = pageCount;
        }

        public int Skip { get; set; }
        public int Take { get; set; }
        public Expression<Func<T, bool>> Where { get; set; }
        public List<Expression<Func<T, object>>> Includes { get; set; } = new List<Expression<Func<T, object>>>();
        public Expression<Func<T, object>> OrderBy { get; set; }
        public bool Descending { get; set; }
    }
}
