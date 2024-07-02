namespace MultitrabajosSecurity.Services
{
    public interface IServiceUsers
    {
        Task<IEnumerable<Models.User>> getAll();
        Task<Models.User> getUserById(int id);

        Task<Models.User> getUserbyEmail (string email);   
        
        Task<bool> save(Models.User user);
        Task<bool> update(Models.User user);   

        Task<bool> delete(int id);  
    }
}
