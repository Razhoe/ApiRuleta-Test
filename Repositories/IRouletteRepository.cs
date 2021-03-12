using ApiRuletaOnline.Models;
using System.Collections.Generic;

namespace ApiRuletaOnline.Repositories
{
    public interface IRouletteRepository : IRepository
    {
        public Roulette GetById(string Id);
        public List<Roulette> GetAll();
        public Roulette Update(string Id, Roulette roulette);
        public Roulette Save(Roulette roulette);
        
    }
}