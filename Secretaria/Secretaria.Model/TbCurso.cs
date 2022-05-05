﻿ // <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Secretaria.Model
{
    [Table("tbCurso")]
    public partial class TbCurso
    {
        public TbCurso()
        {
            TbAluno = new HashSet<TbAluno>();
            TbMatricula = new HashSet<TbMatricula>();
        }

        [Key]
        [Column("idCurso")]
        public int IdCurso { get; set; }
        [Column("nomeCurso")]
        [StringLength(50)]
        [Unicode(false)]
        [Display(Name ="Nome do Curso")]
        public string NomeCurso { get; set; }
        [Column("descricao")]
        [StringLength(35)]
        [Unicode(false)]
        [Display(Name ="Descrição")]
        public string Descricao { get; set; }

        [InverseProperty("CursoIdCursoNavigation")]
        public virtual ICollection<TbAluno> TbAluno { get; set; }
        [InverseProperty("CursoIdCursoNavigation")]
        public virtual ICollection<TbMatricula> TbMatricula { get; set; }
        
    }
}