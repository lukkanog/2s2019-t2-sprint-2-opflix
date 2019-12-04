using Microsoft.EntityFrameworkCore;
using Senai.OpFlix.WebApi.Domains;
using Senai.OpFlix.WebApi.Interfaces;
using Senai.OpFlix.WebApi.ViewModels;
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
                var lancamento = ctx.Lancamentos.Include(x => x.IdCategoriaNavigation).Include(x => x.IdPlataformaNavigation).Include(x => x.IdTipoLancamentoNavigation).FirstOrDefault(x => x.IdLancamento == id);
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

        public List<Lancamentos> Filtrar(FiltroViewModel filtro)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                if (filtro.Data == null || filtro.Data == DateTime.Parse("0001-01-01"))
                {
                    var plataformaBuscada = ctx.Plataformas.FirstOrDefault(x => x.Nome.Equals(filtro.NomePlataforma));

                    return ctx.Lancamentos.Where(x => x.IdPlataformaNavigation == plataformaBuscada).ToList();

                } else if (string.IsNullOrEmpty(filtro.NomePlataforma))
                {
                    return ctx.Lancamentos.Where(x => x.DataLancamento == filtro.Data).ToList();
                }
                else
                {
                    return ctx.Lancamentos.Where(x => x.DataLancamento == filtro.Data && x.IdPlataformaNavigation.Nome == filtro.NomePlataforma).ToList();
                }

            }
        }

        public List<Lancamentos> Listar()
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                var lista =  ctx.Lancamentos.Include(x => x.IdCategoriaNavigation).Include(x => x.IdPlataformaNavigation).Include(x => x.IdTipoLancamentoNavigation).OrderByDescending(x => x.IdLancamento).ToList();

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
