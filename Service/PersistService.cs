using Model;
using Repository;

namespace Service
{
    public class PersistService
    {
        PersistRepository _repository;

        public PersistService()
        {
            _repository = new PersistRepository();
        }

        public bool Insert(List<Infracao> infracoes)
        {
            Console.WriteLine("Camada Service");
            return _repository.Insert(infracoes);
        }
        public List<Infracao> GetAll() { return _repository.GetAll(); }

    }
}