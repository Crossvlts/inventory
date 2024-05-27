//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SistemaInventario.Modelos
{
    using System;
    using System.Collections.Generic;
    
    public partial class MetodosPago
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MetodosPago()
        {
            this.ComprasPago = new HashSet<ComprasPago>();
            this.VentasPago = new HashSet<VentasPago>();
        }
    
        public int metodoPagoID { get; set; }
        public string nombre { get; set; }
        public Nullable<bool> estatus { get; set; }
        public Nullable<bool> aplicaIGTF { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ComprasPago> ComprasPago { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VentasPago> VentasPago { get; set; }
    }
}
