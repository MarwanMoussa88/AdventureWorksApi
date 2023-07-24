using AdventureWorksAPI.Repository.IRepository;

namespace AdventureWorksAPI.Repository
{
    public class UnitOfWork:IUnitOfWork
    {
        public IAddressRepository AddressRepository { get; private set; }
        public IContactTypeRepository ContactTypeRepository { get; private set; }

        public UnitOfWork(IConfiguration configuration) 
        {
            AddressRepository = new AddressRepository(configuration);
            ContactTypeRepository = new ContactTypeRepository(configuration);
        }
    }
}
