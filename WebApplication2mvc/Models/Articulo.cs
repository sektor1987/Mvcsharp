//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication2mvc.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public partial class Articulo
    {
        public int Id { get; set; }
        //http://www.c-sharpcorner.com/UploadFile/4b0136/model-first-approach-in-Asp-Net-mvc-5/
        [Required] //para forzar q campo nombre sea obligatorio
        public string NombreArticulo { get; set; }
        public string DescArticulo { get; set; }
        public Nullable<decimal> PrecioArt { get; set; }
        public Nullable<int> UnidadesExistencia { get; set; }
    }
}
