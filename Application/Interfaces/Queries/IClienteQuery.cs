﻿using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Queries
{
    public interface IClienteQuery
    {
        Task<List<Cliente>> ListaClientes();
        Cliente ClientesPorId(int id);
        Cliente ClientesPorDNI(int dni);
    }
}
