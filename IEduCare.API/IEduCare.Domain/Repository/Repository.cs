using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IEduCare.Domain.Repository
{
    public class Repository<T> : IRepository<T>
    where T : class
    {
        #region Members

        DataContext _currentDataContext;

        #endregion

        #region Constructor

        /// <summary>
        /// Create a new instance of repository
        /// </summary>
        /// <param name="unitOfWork">Associated Unit Of Work</param>
        public Repository(DataContext dataContext)
        {
            if (dataContext == (DataContext)null)
                throw new ArgumentNullException("unitOfWork");

            _currentDataContext = dataContext;
        }

        #endregion

        #region IRepository Members

        /// <summary>
        /// 
        /// </summary>
        public DataContext CurrentContext
        {
            get
            {
                return _currentDataContext;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        public virtual void Add(T item)
        {

            if (item != (T)null)
                GetSet().Add(item); // add new item in this set
            else
            {
                //LoggerFactory.CreateLog()
                //          .LogInfo(Message.info_CannotAddNullEntity, typeof(T).ToString());

            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        public virtual void Remove(T item)
        {
            if (item != (T)null)
            {
                //attach item if not exist
                _currentDataContext.Attach(item);

                //set as "removed"
                GetSet().Remove(item);
            }
            else
            {
                //LoggerFactory.CreateLog()
                //.LogInfo(Message.info_CannotRemoveNullEntity, typeof(T).ToString());
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        public virtual void TrackItem(T item)
        {
            if (item != (T)null)
                _currentDataContext.Attach<T>(item);
            else
            {
                // new LoggerFactory().CreateLogger().LogInformation.LogInfo(Message.info_CannotRemoveNullEntity, typeof(T).ToString());
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        public virtual void Modify(T item)
        {
            if (item != (T)null)
                _currentDataContext.Update(item);
            else
            {
                //LoggerFactory.CreateLog().LogInfo(Message.info_CannotRemoveNullEntity, typeof(T).ToString());
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual T Get(Guid id)
        {
            if (id != Guid.Empty)
                return GetSet().Find(id);
            else
                return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual IQueryable<T> GetAll()
        {
            return GetSet();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="KProperty"></typeparam>
        /// <param name="pageIndex"></param>
        /// <param name="pageCount"></param>
        /// <param name="orderByExpression"></param>
        /// <param name="ascending"></param>
        /// <returns></returns>
        public virtual IEnumerable<T> GetPaged<KProperty>(int pageIndex, int pageCount, System.Linq.Expressions.Expression<Func<T, KProperty>> orderByExpression, bool ascending)
        {
            var set = GetSet();

            if (ascending)
            {
                return set.OrderBy(orderByExpression)
                          .Skip(pageCount * pageIndex)
                          .Take(pageCount);
            }
            else
            {
                return set.OrderByDescending(orderByExpression)
                          .Skip(pageCount * pageIndex)
                          .Take(pageCount);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public virtual IQueryable<T> GetFiltered(System.Linq.Expressions.Expression<Func<T, bool>> filter)
        {
            return GetSet().Where(filter);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="persisted"></param>
        /// <param name="current"></param>
        public virtual void Merge(T persisted, T current)
        {
            // _currentDataContext.ApplyCurrentValues(persisted, current);
        }

        public int Commit()
        {
            return _currentDataContext.SaveChanges();
        }

        public void CommitAndRefreshChanges()
        {
            bool saveFailed = false;

            do
            {
                try
                {
                    _currentDataContext.SaveChanges();

                    saveFailed = false;

                }
                catch (DbUpdateConcurrencyException ex)
                {
                    saveFailed = true;

                    ex.Entries.ToList()
                              .ForEach(entry =>
                              {
                                  entry.OriginalValues.SetValues(entry.GetDatabaseValues());
                              });

                }
            } while (saveFailed);
        }
        #endregion

        #region IDisposable Members

        /// <summary>
        /// <see cref="M:System.IDisposable.Dispose"/>
        /// </summary>
        public void Dispose()
        {
            if (_currentDataContext != null)
                _currentDataContext.Dispose();
        }

        #endregion

        #region Private Methods

        DbSet<T> GetSet()
        {
            return _currentDataContext.Set<T>();
        }

        #endregion

    }
}
