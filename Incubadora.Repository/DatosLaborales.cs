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
    
    public partial class DatosLaborales
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DatosLaborales()
        {
            this.Emprendedores = new HashSet<Emprendedores>();
        }
    
        public System.Guid Id { get; set; }
        public string StrOcupacion { get; set; }
        public string StrObservaciones { get; set; }
        public Nullable<System.Guid> IdUnidadAcademica { get; set; }
        public Nullable<System.Guid> IdCarrera { get; set; }
        public Nullable<System.Guid> IdCuatrimestre { get; set; }
        public int IdStatus { get; set; }
    
        public virtual CatCarreras CatCarreras { get; set; }
        public virtual CatCuatrimestres CatCuatrimestres { get; set; }
        public virtual CatUnidadesAcademicas CatUnidadesAcademicas { get; set; }
        public virtual Status Status { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Emprendedores> Emprendedores { get; set; }
    }
}
