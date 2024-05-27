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
    
    public partial class Compras
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Compras()
        {
            this.ComprasDetalle = new HashSet<ComprasDetalle>();
            this.ComprasPago = new HashSet<ComprasPago>();
        }
    
        public int compraID { get; set; }
        public Nullable<int> proveedorID { get; set; }
        public Nullable<System.DateTime> fecha { get; set; }
        public string codigofactura { get; set; }
        public Nullable<bool> estatus { get; set; }
        public string descripcion { get; set; }
        public Nullable<int> usuarioID { get; set; }
    
        public virtual Proveedores Proveedores { get; set; }
        public virtual Usuarios Usuarios { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ComprasDetalle> ComprasDetalle { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ComprasPago> ComprasPago { get; set; }
    }
}
