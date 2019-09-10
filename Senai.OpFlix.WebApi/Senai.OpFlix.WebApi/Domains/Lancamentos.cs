﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Senai.OpFlix.WebApi.Domains
{
    public partial class Lancamentos
    {
        public int IdLancamento { get; set; }
        [Required(ErrorMessage = "O lançamento deve ter uma categoria vinculada.")]
        public int IdCategoria { get; set; }
        public int IdTipoLancamento { get; set; }
        public string Titulo { get; set; }
        public string Sinopse { get; set; }
        public int? IdPlataforma { get; set; }
        [Required(ErrorMessage = "O lançamento deve ter uma data de lançamento.")]
        public DateTime DataLancamento { get; set; }
        public int? Duracao { get; set; }

        public Categorias IdCategoriaNavigation { get; set; }
        public Plataformas IdPlataformaNavigation { get; set; }
        public TiposLancamentos IdTipoLancamentoNavigation { get; set; }
        public List<LancamentosFavoritos> LancamentosFavoritos { get; set; }
    }
}