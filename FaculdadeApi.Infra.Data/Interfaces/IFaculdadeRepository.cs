using FaculdadeApi.Infra.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaculdadeApi.Infra.Data.Interfaces
{
    public interface IFaculdadeRepository : IBaseRepository<Faculdad>
    {
        Faculdad Obter(string Turma);
    }
}
