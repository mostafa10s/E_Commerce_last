


using System.Linq.Expressions;

namespace E_Commerce.Infrastructure.Repository
{
    public class BassRepository<T>: IBassRepository<T> where T : class
    {

        private readonly IMongoCollection<T> _collection;
        public BassRepository(MongoDbContext context, string collectionName) {


            _collection = context.GetCollection<T>(collectionName);
        }
        protected IMongoCollection<T> Collection => _collection;
        public async Task CreateAsync(T entity)
        {
             await _collection.InsertOneAsync(entity);
          


        }

        public async Task DeleteAsync(FilterDefinition<T> filter)
        {
           
            await _collection.DeleteOneAsync(filter);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _collection.Find(FilterDefinition<T>.Empty).ToListAsync();
        }
        //public async Task<IEnumerable<T>> GetAllAsync(
        //Expression<Func<T, bool>> filter = null,
        //Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
        //int? page = null,
        //int? pageSize = null)
        //{
        //    // Apply filtering
        //    var query = _collection.AsQueryable();
        //    if (filter != null)
        //    {
        //        query = query.Where(filter);
        //    }

        //    // Apply sorting
        //    if (orderBy != null)
        //    {
        //        query = orderBy(query);
        //    }

        //    // Apply pagination
        //    if (page.HasValue && pageSize.HasValue)
        //    {
        //        query = query.Skip((page.Value - 1) * pageSize.Value).Take(pageSize.Value);
        //    }

        //    return await Task.FromResult(query.ToList());
        //}


        public async Task<T> GetOne(FilterDefinition<T> filter)
        {
              var  user= await _collection.Find(filter).FirstOrDefaultAsync();
            return user;
        }

        public async Task UpdateAsync(FilterDefinition<T> filter, T entity  )
        
        {
            await _collection.ReplaceOneAsync(filter, entity);
        }

       
    }

 
    }

