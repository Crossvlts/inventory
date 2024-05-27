using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Comun
{
    static public int usuarioID { get; set; }
    static public string usuario { get; set; }
    static public bool esAdmin { get; set; }
    static public bool clientes { get; set; }
    static public bool proveedores { get; set; }
    static public bool categorias { get; set; }
    static public bool stock { get; set; }
    static public bool instrumentoPago { get; set; }
    static public bool unidadMedida { get; set; }
    static public bool configuracionGeneral { get; set; }
    static public bool usuarios { get; set; }
    static public bool listadoCompras { get; set; }
    static public bool nuevaCompra { get; set; }
    static public bool listadoVenta { get; set; }
    static public bool nuevaVenta { get; set; }
    static public bool reportes { get; set; }
    static public bool pestanaMantenimiento { get; set; }
    static public bool productos { get; set; }
    static public bool pestanaCompras { get; set; }
    static public bool pestanaVentas { get; set; }
    static public bool pestanaReporte { get; set; }

    static public bool monedas { get; set; }
    // Util para compra y ventas, almacena el ID de la ultima venta o compra para procesar el pago 
    static public int IDSeleccionado { get; set; }
    static public string ItemSeleccionado { get; set; }


    public static string formatoMoneda = "#,##.##";


}



