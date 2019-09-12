using Senai.OpFlix.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.OpFlix.WebApi.Repositories
{
    interface IFavoritoRepository
    {
        void Favoritar(LancamentosFavoritos favorito);
        List<Lancamentos> ListarFavoritos(int idUsuario);
        bool FavoritoJaFoiCadastrado(LancamentosFavoritos favorito);
        void Desfavoritar(LancamentosFavoritos favorito);
    }
}
