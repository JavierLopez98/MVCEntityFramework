using Microsoft.EntityFrameworkCore;
using NVCEntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NVCEntityFramework.Data
{
    public class TodosEmpleadosContext:DbContext
    {

        public TodosEmpleadosContext(DbContextOptions<TodosEmpleadosContext> options) : base(options){ }

        public DbSet<TodosEmpleados> Empleados { get; set; }
    }
}
