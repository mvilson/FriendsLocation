using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FL.Entity;

namespace FL.DataAcess
{
    public class PessoasDataAcess : IPessoasDataAcess
    {
        private List<Pessoa> objPessoas;
        private List<Pessoa> objAmigos;

        public PessoasDataAcess()
        {
            objPessoas = new List<Pessoa>();
            objAmigos = new List<Pessoa>();
        }

        public List<Pessoa> getAllPessoas()
        {
            try
            {
                return objPessoas;
            }
            catch
            {
                throw;
            }
        }

        public List<Pessoa> getAllAmigos()
        {
            try
            {
                objAmigos = objPessoas.ToList();
                return objAmigos;
            }
            catch
            {
                throw;
            }
        }


        public Pessoa getPessoaID(Pessoa pPessoa)
        {
            try
            {
                return objPessoas.Find(pessoa => pessoa.IDPessoa == pPessoa.IDPessoa);
            }
            catch
            {
                throw;
            }
        }

        public Pessoa getPessoaLatLong(Pessoa pPessoa)
        {
            try
            {
                return objPessoas.Find(pessoa => (pessoa.LocalidadePessoa.Latitude == pPessoa.LocalidadePessoa.Latitude) && (pessoa.LocalidadePessoa.Longitude == pPessoa.LocalidadePessoa.Longitude));
            }
            catch
            {
                throw;
            }
        }

        public Boolean InsertAmigo(Pessoa pessoa)
        {
            try
            {
                pessoa.IDPessoa = objPessoas.Count() + 1;
                objPessoas.Add(pessoa);
                objAmigos = objPessoas.ToList();
                return true;
            }
            catch
            {
                throw;
            }
        }

        public Boolean DeleteAmigo(Pessoa pPessoa)
        {
            try
            {
                objPessoas.RemoveAll(pessoa => pessoa.IDPessoa == pPessoa.IDPessoa);
                objAmigos = objPessoas.ToList();
                return true;
            }
            catch
            {
                throw;
            }
        }
    }
}
