namespace AdventureWorksAPI.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IAddressRepository AddressRepository { get; }
        IContactTypeRepository ContactTypeRepository { get; }
    }
}
