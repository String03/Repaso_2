using Repaso_2.Contracts.Repositories;
using Repaso_2.EE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repaso_2.BLL
{
    public class GeneroBLL
    {
        private readonly IRepository<Genero> _generoRepository;

        public GeneroBLL(IRepository<Genero> generoRepository)
        {
            _generoRepository = generoRepository;
        }

        public List<Genero> Listar()
        {
            return _generoRepository.GetAll();
        }

        public void Alta(Genero genero)
        {
            _generoRepository.Save(genero);
        }

        public void Baja(Genero genero)
        {
            _generoRepository.Delete(genero);
        }

        public void Modificar(Genero genero)
        {
            _generoRepository.Update(genero);
        }
    }
}
