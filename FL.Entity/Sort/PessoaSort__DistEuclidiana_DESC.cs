using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FL.Entity
{    public class PessoaSort__DistEuclidiana_DESC : IComparer<Pessoa>
    {
        public int Compare(Pessoa x, Pessoa y)
        {
            return y.LocalidadePessoa.DistanciaEuclidiana.CompareTo(x.LocalidadePessoa.DistanciaEuclidiana);

        }
    }
}
