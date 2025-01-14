//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Incubadora.Repository
{
    using System;
    using System.Collections.Generic;
    
    public partial class Emprendedores
    {
        public System.Guid Id { get; set; }
        public string StrNombre { get; set; }
        public string StrApellidoPaterno { get; set; }
        public string StrApellidoMaterno { get; set; }
        public string StrCurp { get; set; }
        public Nullable<System.DateTime> StrFechaNacimiento { get; set; }
        public string StrEmail { get; set; }
        public string StrFotoUrl { get; set; }
        public System.Guid IdTelefono { get; set; }
        public System.Guid IdDireccion { get; set; }
        public int IdStatus { get; set; }
        public Nullable<System.Guid> IdAvatar { get; set; }
        public System.Guid IdDatoLaboral { get; set; }
    
        public virtual CatAvatars CatAvatars { get; set; }
        public virtual DatosLaborales DatosLaborales { get; set; }
        public virtual Direcciones Direcciones { get; set; }
        public virtual Status Status { get; set; }
        public virtual Telefonos Telefonos { get; set; }
    }
}
