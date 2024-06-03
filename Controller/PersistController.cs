using Model;
using Service;

namespace Controller
{
    public class PersistController
    {
        private PersistService _service;
        public PersistController()
        {
            _service = new PersistService();
        }
        public bool Insert(List<Infracao> infracoes)
        {

            return _service.Insert(infracoes);
        }
        public List<Infracao> GetAll() { return _service.GetAll(); }
    }
}