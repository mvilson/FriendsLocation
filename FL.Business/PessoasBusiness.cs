using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FL.Entity;
using FL.DataAcess;
using FL.Common;

namespace FL.Business
{
    public class PessoasBusiness : IPessoasBusiness
    {
        public List<Pessoa> getAllPessoas()
        {
            try
            {
                PessoasDataAcess objPessoaDB = Singleton<PessoasDataAcess>.Intance;
                List<Pessoa> PessoasTemp = objPessoaDB.getAllPessoas();
                
                return PessoasTemp;
            }
            catch
            {
                throw;
            }

        }

        public Pessoa getPessoa(Pessoa pessoa)
        {
            try
            {
                if (pessoa == null)
                    throw new ArgumentNullException("Objeto Pessoa não pode ser null");

                if (pessoa.IDPessoa <= 0)
                    throw new ArgumentOutOfRangeException("ID Pessoa não pode ser 0 ou menor que 0");

                PessoasDataAcess objPessoaDB = Singleton<PessoasDataAcess>.Intance;
                Pessoa pessoaTemp = objPessoaDB.getPessoaID(pessoa);
                if(pessoaTemp != null)
                    pessoaTemp.LocalidadePessoa.getDistanciaEuclidiana(pessoaTemp.LocalidadePessoa.Latitude, pessoaTemp.LocalidadePessoa.Longitude);
                 
                return pessoaTemp;
            }
            catch
            {
                throw;
            }

        }

        public Pessoa getPessoaLatLong(Pessoa pessoa)
        {
            try
            {
                if (pessoa == null)
                    throw new ArgumentNullException("Objeto Pessoa não pode ser null");

                if (pessoa.LocalidadePessoa.Latitude == 0)
                    throw new ArgumentOutOfRangeException("Latitude não pode ser 0");

                if (pessoa.LocalidadePessoa.Longitude == 0)
                    throw new ArgumentOutOfRangeException("Longitude não pode ser 0");

                PessoasDataAcess objPessoaDB = Singleton<PessoasDataAcess>.Intance;
                Pessoa pessoaTemp = objPessoaDB.getPessoaLatLong(pessoa);                
                return pessoaTemp;
            }
            catch
            {
                throw;
            }

        }

        public List<Pessoa> getAmigos(Pessoa pPessoa, int QtdAmigos)
        {
            try
            {
                if (pPessoa == null)
                    throw new ArgumentNullException("Objeto Pessoa não pode ser null");

                if (pPessoa.IDPessoa <= 0)
                    throw new ArgumentOutOfRangeException("ID Pessoa não pode ser 0 ou menor que 0");


                if (QtdAmigos <= 0)
                    throw new ArgumentOutOfRangeException("Quantidade de Amigos não pode ser 0 ou menor que 0");

                PessoasDataAcess objPessoaDB = Singleton<PessoasDataAcess>.Intance;

                //recuperando todos os amigos
                List<Pessoa> PessoasTemp = objPessoaDB.getAllAmigos();

                //Calculando a distanccia euclidiana
                foreach (Pessoa pessoa in PessoasTemp)
                    pessoa.LocalidadePessoa.getDistanciaEuclidiana(pPessoa.LocalidadePessoa.Latitude, pPessoa.LocalidadePessoa.Longitude);

                //Remove a pessoa informada no parametro pessoa
                PessoasTemp.RemoveAll(pessoa => pessoa.IDPessoa == pPessoa.IDPessoa);

                //Ordenando pela distancia mais proxima
                PessoasTemp.Sort(new PessoaSort__DistEuclidiana_ASC());

                //Retorna apenas os primeiros amigos mais proximos conforme informado no parametro QtdAmigos
                if (QtdAmigos > PessoasTemp.Count())
                    QtdAmigos = PessoasTemp.Count();
                PessoasTemp.RemoveRange(QtdAmigos, PessoasTemp.Count() - QtdAmigos);

                return PessoasTemp;
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
                if (pessoa == null)
                    throw new ArgumentNullException("Objeto Pessoa não pode ser null");

                if (pessoa.NomePessoa.Trim().Length == 0)
                    throw new ArgumentOutOfRangeException("Nome Pessoa deve ser informado");

                if (pessoa.LocalidadePessoa.Latitude == 0)
                    throw new ArgumentOutOfRangeException("Latitude não pode ser 0");

                if (pessoa.LocalidadePessoa.Longitude == 0)
                    throw new ArgumentOutOfRangeException("Longitude não pode ser 0");

                PessoasDataAcess objPessoaDB = Singleton<PessoasDataAcess>.Intance;
                return objPessoaDB.InsertAmigo(pessoa);
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
                if (pPessoa == null)
                    throw new ArgumentNullException("Objeto Pessoa não pode ser null");

                if (pPessoa.IDPessoa == 0)
                    throw new ArgumentOutOfRangeException("Id Pessoa não pode ser 0");

                PessoasDataAcess objPessoaDB = Singleton<PessoasDataAcess>.Intance;
                return objPessoaDB.DeleteAmigo(pPessoa);                
            }
            catch
            {
                throw;
            }
        }
    }
}
