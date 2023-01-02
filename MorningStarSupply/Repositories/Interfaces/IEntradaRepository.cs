using MorningStarSupply.Models;
using System.Security.Cryptography;

namespace MorningStarSupply.Repositories.Interfaces
{
    public interface IEntradaRepository
    {
        IEnumerable<Entrada> Entradas { get; }
        IEnumerable<Mercadoria> Mercadorias { get; }

        IEnumerable<Mercadoria> GetListMercadorias();

        void AddToEntradas(Entrada entrada);
        

    }
}
