using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace PruebaLucasFelizIBSystems.Models
{
    public enum EstatusOrden
    {
        [Description("Aprobada")]
        Aprobada = 1,
        [Description("Cancelada")]
        Cancelada = 2,
        [Description("Cerrada")]
        Cerrada = 3,
        [Description("Suspendida")]
        Suspendida = 4,
        [Description("En progreso")]
        Progreso = 5,
        [Description("En revisión")]
        Revision = 6,
        [Description("Revisada")]
        Revisada = 7,
        [Description("En espera de aprobación")]
        Espera = 8
    }
}