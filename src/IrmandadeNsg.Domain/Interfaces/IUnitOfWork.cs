namespace IrmandadeNsg.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        bool Commit();
    }
}
