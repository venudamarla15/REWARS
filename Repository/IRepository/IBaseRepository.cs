namespace RewardPoints.Repository.IRepository
{
    public interface IBaseRepository <T>
    {
        
            Task<IEnumerable<T>> GetAllData();
            Task<T> InsertData(T newEntity);
    
    }
}
