using Senai.OpFlix.WebApi.Domains;
using Senai.OpFlix.WebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.OpFlix.WebApi.Interfaces
{
    interface ILancamentoRepository
    {
        /// <summary>
        /// Cadastra um novo lançamento no banco de dados
        /// </summary>
        /// <param name="lancamento">Lançamento a ser cadastrado</param>
        void Cadastrar(Lancamentos lancamento);

        /// <summary>
        /// Lista todos os lançamentos cadastrados
        /// </summary>
        /// <returns>Uma lista de lançamentos</returns>
        List<Lancamentos> Listar();

        /// <summary>
        /// Atualiza um lançamento já existente
        /// </summary>
        /// <param name="lancamento">Lançamento</param>
        void Atualizar(Lancamentos lancamento);

        /// <summary>
        /// Busca um lançamento pelo seu id e em seguida o exclui.
        /// </summary>
        /// <param name="id">Id do lançamento</param>
        void ExcluirPorId(int id);

        /// <summary>
        /// busca um lançamento pelo seu id
        /// </summary>
        /// <param name="id">id</param>
        /// <returns></returns>
        Lancamentos BuscarPorId(int id);

        /// <summary>
        /// Filtra os lançamentos apenas pela data, apenas pela plataforma, ou pelos dois
        /// </summary>
        /// <param name="filtro">FiltroViewModel</param>
        /// <returns>Lista de lançamentos com os filtros aplicados</returns>
        List<Lancamentos> Filtrar(FiltroViewModel filtro);

    }
}
