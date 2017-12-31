using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FL.Entity
{
    public class Pessoa : IPessoa
    {
        private int _IDPessoa;
        private string _NomePessoa;
        private Localidade _LocalidadePessoa;
        public int IDPessoa
        {
            get
            {
                return _IDPessoa;
            }

            set
            {
                _IDPessoa = value;
            }
        }

        public string NomePessoa
        {
            get
            {
                return _NomePessoa;
            }

            set
            {
                _NomePessoa = value;
            }
        }      
        
        public Localidade LocalidadePessoa
        {
            get
            {
                return _LocalidadePessoa;
            }

            set
            {
                _LocalidadePessoa = value;
            }
        }

        public int CompareTo(Pessoa pessoa)
        {
            return this.NomePessoa.CompareTo(pessoa.NomePessoa);
        }
    }
    
}

