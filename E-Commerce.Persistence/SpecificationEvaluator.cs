using E_Commerce.Domain.Interfaces;
using E_Commerce.Domain.Models.BaseClasses;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Persistence
{
    static class SpecificationEvaluator
    {
        public static IQueryable<T> CreateQuery<T, TKey>(IQueryable<T> EnteryPoint, ISpecifications<T, TKey> specifications)
            where T : Base<TKey>
        {
            var Query = EnteryPoint;
            if(specifications is not null) 
            {
                if (specifications.Criteria is not null)
                {
                    Query = Query.Where(specifications.Criteria);
                }
                if (specifications.IncludeExpressions is not null && specifications.IncludeExpressions.Any())
                {
                    Query = specifications.IncludeExpressions.Aggregate(Query, (CurrentQuery, IncludeExp) => CurrentQuery.Include(IncludeExp));
                }
                if (specifications.OrderBy is not null)
                {
                    Query = Query.OrderBy(specifications.OrderBy);
                }
                if (specifications.OrderByDescending is not null)
                {
                    Query = Query.OrderByDescending(specifications.OrderByDescending);
                }
                if (specifications.IsPaginated)
                {
                    Query = Query.Skip(specifications.Skip).Take(specifications.Take);
                } 
            }
            
            return Query;
        }
    }
}
