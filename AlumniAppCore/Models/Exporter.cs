using System;
using System.Data;
namespace AlumniAppCore.Models
{
    public abstract class Exporter
    {
        public abstract void Export(DataTable dataTable);
    }
}
