namespace SD_125_W22SD_Lab_Database_Testing.DAL
{
    public interface IRepository<T> where T : class
    {
        //Create
        void Create(T entity);
        //Read
        T Get(int id);
        T Get(Func<T, bool> predicate);
        ICollection<T> GetAll();
        ICollection<T> GetList(Func<T, bool> predicate);
        //Update
        T Update(T entity);
        //Delete
        void Delete(T entity);
        //Save
        void Save();
    }
}
