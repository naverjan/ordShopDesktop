//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ordShop
{
    using System;
    using System.Collections.Generic;
    
    public partial class ord_products
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ord_products()
        {
            this.ord_purchaseOrdersBody = new HashSet<ord_purchaseOrdersBody>();
        }
    
        public long id { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public decimal value { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ord_purchaseOrdersBody> ord_purchaseOrdersBody { get; set; }
    }
}
