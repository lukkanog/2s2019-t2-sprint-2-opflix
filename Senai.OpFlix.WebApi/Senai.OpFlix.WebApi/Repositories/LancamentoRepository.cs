using Microsoft.EntityFrameworkCore;
using Senai.OpFlix.WebApi.Domains;
using Senai.OpFlix.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.OpFlix.WebApi.Repositories
{
    public class LancamentoRepository : ILancamentoRepository
    {
        public void Atualizar(Lancamentos lancamento)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                var lancamentoBuscado = ctx.Lancamentos.Find(lancamento.IdLancamento);
                if (lancamentoBuscado == null)
                    return;

                lancamentoBuscado.IdCategoria = lancamento.IdCategoria;
                lancamentoBuscado.IdPlataforma = lancamento.IdPlataforma;
                lancamentoBuscado.IdTipoLancamento = lancamento.IdTipoLancamento;
                lancamentoBuscado.Titulo = lancamento.Titulo;
                lancamentoBuscado.Sinopse = lancamento.Sinopse;
                lancamentoBuscado.DataLancamento = lancamento.DataLancamento;
                lancamentoBuscado.Duracao = lancamento.Duracao;
                lancamentoBuscado.Sinopse = lancamento.Sinopse;


                ctx.Update(lancamentoBuscado);
                ctx.SaveChanges();
            }
        }

        public Lancamentos BuscarPorId(int id)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                var lancamento = ctx.Lancamentos.Find(id);
                if (lancamento == null)
                    return null;
                return lancamento;
            }
        }

        public void Cadastrar(Lancamentos lancamento)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                ctx.Lancamentos.Add(lancamento);
                ctx.SaveChanges();
            }
        }


        public void ExcluirPorId(int id)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                var lancamentoBuscado = ctx.Lancamentos.Find(id);
                if (lancamentoBuscado == null)
                    return;

                ctx.Lancamentos.Remove(lancamentoBuscado);
                ctx.SaveChanges();
            }
        }

        public List<Lancamentos> Listar()
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                var lista =  ctx.Lancamentos.Include(x => x.IdCategoriaNavigation).Include(x => x.IdPlataformaNavigation).Include(x => x.IdTipoLancamentoNavigation).ToList();

                foreach (var item in lista)
                {
                    item.IdCategoriaNavigation.Lancamentos = null;
                    item.IdPlataformaNavigation.Lancamentos = null;
                    item.IdTipoLancamentoNavigation.Lancamentos = null;
                }
                return lista;
            }
        }


    }//#############################################################################################################################
}
