using Senai.OpFlix.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.OpFlix.WebApi.Interfaces
{
    interface ILancamentoRepository
    {
        void Cadastrar(Lancamentos lancamento);
        List<Lancamentos> Listar();
        void Atualizar(Lancamentos lancamento);
        void ExcluirPorId(int id);
        Lancamentos BuscarPorId(int id);
    }
}
