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
    
    public partial class ord_purchaseOrdersBody
    {
        public long id { get; set; }
        public Nullable<System.DateTime> date { get; set; }
        public long idOrder { get; set; }
        public long idProduct { get; set; }
        public int cant { get; set; }
        public decimal valueUnit { get; set; }
        public decimal valueTotal { get; set; }
        public bool priority { get; set; }
    
        public virtual ord_products ord_products { get; set; }
        public virtual ord_purchaseOrders ord_purchaseOrders { get; set; }
    }
}
