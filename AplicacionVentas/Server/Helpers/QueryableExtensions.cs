﻿using AplicacionVentas.Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AplicacionVentas.Server.Helpers
{
    public static class QueryableExtensions
    {
        public static IQueryable<T> Paginar<T>(this IQueryable<T> queryable, PaginacionDTO paginacion)
        {
            return queryable
                .Skip((paginacion.Pagina - 1) * paginacion.CantidadRegistros)
                .Take(paginacion.CantidadRegistros);
        }
    }
}
