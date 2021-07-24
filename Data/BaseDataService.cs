using SuperMerk2.Data.Context;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace SuperMerk2.Data
{
    public class GenericDataRepository<T> : IGenericDataRepository<T> where T : class
    {
        public void Add(params T[] items)
        {
            using (var context = new SuperMerk2Context())
            {
                IQueryable<T> dbQuery = context.Set<T>();

                //Como ya lo traje el objeto, esta attacheado y no lo puedo borrar
                //Para esto, lo marco para borrar en el proximo saveChanges
                foreach (var item in items)
                {
                    context.Entry(item).State = EntityState.Deleted;
                }

                context.SaveChanges();
            }
        }

        public virtual IList<T> GetAll(params Expression<Func<T, object>>[] navigationProperties)
        {
            List<T> list;
            using (var context = new SuperMerk2Context())
            {
                IQueryable<T> dbQuery = context.Set<T>();

                //Apply eager loading
                foreach (Expression<Func<T, object>> navigationProperty in navigationProperties)
                    dbQuery = dbQuery.Include<T, object>(navigationProperty);

                list = dbQuery
                    .AsNoTracking()
                    .ToList<T>();
            }
            return list;
        }

        public virtual IList<T> GetList(Func<T, bool> where,
             params Expression<Func<T, object>>[] navigationProperties)
        {
            List<T> list;
            using (var context = new SuperMerk2Context())
            {
                IQueryable<T> dbQuery = context.Set<T>();

                //Apply eager loading
                foreach (Expression<Func<T, object>> navigationProperty in navigationProperties)
                    dbQuery = dbQuery.Include<T, object>(navigationProperty);

                list = dbQuery
                    .AsNoTracking()
                    .Where(where)
                    .ToList<T>();
            }
            return list;
        }

        public virtual T GetSingle(Func<T, bool> where,
             params Expression<Func<T, object>>[] navigationProperties)
        {
            T item = null;
            using (var context = new SuperMerk2Context())
            {
                IQueryable<T> dbQuery = context.Set<T>();

                //Apply eager loading
                foreach (Expression<Func<T, object>> navigationProperty in navigationProperties)
                    dbQuery = dbQuery.Include<T, object>(navigationProperty);

                item = dbQuery
                    .AsNoTracking() //Don't track any changes for the selected item
                    .FirstOrDefault(where); //Apply where clause
            }
            return item;
        }

        public void Remove(params T[] items)
        {
            using (var context = new SuperMerk2Context())
            {
                IQueryable<T> dbQuery = context.Set<T>();

                //Como ya lo traje el objeto, esta attacheado y no lo puedo borrar
                //Para esto, lo marco para borrar en el proximo saveChanges
                foreach (var item in items)
                {
                    context.Entry(item).State = EntityState.Deleted;
                }

                context.SaveChanges();
            }
        }

        public void Update(T item, Func<T, bool> where,
             params Expression<Func<T, object>>[] navigationProperties)
        {
            T itemViejo = null;
            using (var context = new SuperMerk2Context())
            {
                IQueryable<T> dbQuery = context.Set<T>();

                //Apply eager loading
                foreach (Expression<Func<T, object>> navigationProperty in navigationProperties)
                    dbQuery = dbQuery.Include<T, object>(navigationProperty);

                itemViejo = dbQuery
                    .FirstOrDefault(where);

                context.Entry(itemViejo).CurrentValues.SetValues(item);

                context.SaveChanges();
            }
        }

    }
}