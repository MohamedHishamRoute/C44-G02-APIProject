using E_Commerce.Domain.Interfaces;
using E_Commerce.Domain.Models.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Services.Specifications
{
    public abstract class BaseSpecifications<T, TKey> : ISpecifications<T, TKey> where T : Base<TKey>
    {
        public Expression<Func<T, bool>> Criteria { get; private set; }
        protected BaseSpecifications(Expression<Func<T, bool>> CriteriaExpression)
        {
            this.Criteria = CriteriaExpression;
        }

        #region Includes

        public ICollection<Expression<Func<T, object>>> IncludeExpressions { get; } = [];
        protected void AddInclude(Expression<Func<T, object>> include) => IncludeExpressions.Add(include);

        #endregion

        #region Sorting

        public Expression<Func<T, object>> OrderBy { get; private set; }

        public Expression<Func<T, object>> OrderByDescending { get; private set; }
        protected void AddOrderBy(Expression<Func<T, object>> OrderByExpression) => OrderBy = OrderByExpression;
        protected void AddOrderByDescending(Expression<Func<T, object>> orderByDescending) => OrderByDescending = OrderByDescending;

        #endregion

        #region Pagination
        public int Take { get; private set; }

        public int Skip { get; private set; }

        public bool IsPaginated { get; set; }

        protected void ApplyPagination(int pageSize, int pageIndex)
        {
            IsPaginated = true;
            Take = pageSize;
            Skip = (pageIndex - 1) * pageSize;
        }


        #endregion
    }
}
