using System;
using System.Collections.Generic;
using FL.Business;
using FL.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FL.Tests
{
    [TestClass]
    public class PessoasBusinessTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void InsertAmigo_PessoaNull_OutOfRangeExceptionTest() 
        {
            Pessoa pessoa = null;
            PessoasBusiness pessoabus = new PessoasBusiness();
            Boolean retorno = pessoabus.InsertAmigo(pessoa);            
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void InsertAmigo_Nome_OutOfRangeExceptionTest()
        {
            Pessoa pessoa = new Pessoa { NomePessoa = "", LocalidadePessoa = new Localidade { Latitude = 1, Longitude = 1 } };
            PessoasBusiness pessoabus = new PessoasBusiness();
            Boolean retorno = pessoabus.InsertAmigo(pessoa);
            
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void InsertAmigo_Latitude_OutOfRangeExceptionTest()
        {
            Pessoa pessoa = new Pessoa { NomePessoa = "Pedro", LocalidadePessoa = new Localidade { Latitude = 0, Longitude = 1 } };
            PessoasBusiness pessoabus = new PessoasBusiness();
            Boolean retorno = pessoabus.InsertAmigo(pessoa);
            Assert.IsTrue(retorno);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void InsertAmigo_Longitude_OutOfRangeExceptionTest()
        {
            Pessoa pessoa = new Pessoa { NomePessoa = "Pedro", LocalidadePessoa = new Localidade { Latitude = 1, Longitude = 0 } };
            PessoasBusiness pessoabus = new PessoasBusiness();
            Boolean retorno = pessoabus.InsertAmigo(pessoa);
            Assert.IsTrue(retorno);
        }
        
        [TestMethod]
        public void InsertAmigoTest()
        {
            Pessoa pessoa = new Pessoa { NomePessoa = "Pedro", LocalidadePessoa = new Localidade { Latitude = 1, Longitude = 1 } };
            PessoasBusiness pessoabus = new PessoasBusiness();
            Boolean retorno = pessoabus.InsertAmigo(pessoa);
            Assert.IsTrue(retorno); 
        }

        [TestMethod]
        public void getPessoaTest()
        {
            Pessoa pessoa = new Pessoa {IDPessoa = 1};
            PessoasBusiness pessoabus = new PessoasBusiness();
            Pessoa pessoaRet = pessoabus.getPessoa(pessoa);
            Assert.IsTrue(pessoaRet.NomePessoa == "Pedro");
        }
        

        [TestMethod]
        public void getAllPessoasTest()
        {
            PessoasBusiness pessoabus = new PessoasBusiness();
            List<Pessoa> pessoas = pessoabus.getAllPessoas();
            Assert.IsTrue(pessoas.Count > 0);
        }
                
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void getPessoaLatLong_PessoaNull_OutOfRangeExceptionTest()
        {
            Pessoa pessoa = null;
            PessoasBusiness pessoabus = new PessoasBusiness();
            Pessoa pessoaRet = pessoabus.getPessoaLatLong(pessoa);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void getPessoaLatLong_Latitude_OutOfRangeExceptionTest()
        {
            Pessoa pessoa = new Pessoa { LocalidadePessoa = new Localidade { Latitude = 0, Longitude = 1 } };
            PessoasBusiness pessoabus = new PessoasBusiness();
            Pessoa pessoaRet = pessoabus.getPessoaLatLong(pessoa);            
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void getPessoaLatLong_Longitude_OutOfRangeExceptionTest()
        {
            Pessoa pessoa = new Pessoa { LocalidadePessoa = new Localidade { Latitude = 1, Longitude = 0 } };
            PessoasBusiness pessoabus = new PessoasBusiness();
            Pessoa pessoaRet = pessoabus.getPessoaLatLong(pessoa);            
        }

        [TestMethod]
        public void getPessoaLatLong_LongitudeTest()
        {
            Pessoa pessoa = new Pessoa { LocalidadePessoa = new Localidade { Latitude = 1, Longitude = 1 } };
            PessoasBusiness pessoabus = new PessoasBusiness();
            Pessoa pessoaRet = pessoabus.getPessoaLatLong(pessoa);
            Assert.IsTrue(pessoaRet.NomePessoa == "Pedro");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void getAmigos_PessoaNull_OutOfRangeExceptionTest()
        {
            Pessoa pessoa = null;
            PessoasBusiness pessoabus = new PessoasBusiness();
            List<Pessoa> pessoaRet = pessoabus.getAmigos(pessoa, 3);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void getAmigos_ID_Pessoa_OutOfRangeExceptionTest()
        {
            Pessoa pessoa = new Pessoa { IDPessoa = 0 };
            PessoasBusiness pessoabus = new PessoasBusiness();
            List<Pessoa> pessoaRet = pessoabus.getAmigos(pessoa, 3);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void getAmigos_QTD_Amigos_OutOfRangeExceptionTest()
        {
            Pessoa pessoa = new Pessoa { IDPessoa = 1 };
            PessoasBusiness pessoabus = new PessoasBusiness();
            List<Pessoa> pessoaRet = pessoabus.getAmigos(pessoa, 0);
        }

        [TestMethod]
        public void getAmigos_Test()
        {
            Pessoa pessoa = new Pessoa { NomePessoa = "Joao", LocalidadePessoa = new Localidade { Latitude = 2, Longitude = 2 } };
            PessoasBusiness pessoabus = new PessoasBusiness();
            Boolean retorno = pessoabus.InsertAmigo(pessoa);
            Assert.IsTrue(retorno);

            retorno = false;
            pessoa = new Pessoa { NomePessoa = "Maria", LocalidadePessoa = new Localidade { Latitude = 3, Longitude = 3 } };
            retorno = pessoabus.InsertAmigo(pessoa);
            Assert.IsTrue(retorno);

            retorno = false;
            pessoa = new Pessoa { NomePessoa = "Carlos", LocalidadePessoa = new Localidade { Latitude = 4, Longitude = 4 } };
            retorno = pessoabus.InsertAmigo(pessoa);
            Assert.IsTrue(retorno);

            retorno = false;
            pessoa = new Pessoa { NomePessoa = "Joana", LocalidadePessoa = new Localidade { Latitude = 5, Longitude = 5 } };
            retorno = pessoabus.InsertAmigo(pessoa);
            Assert.IsTrue(retorno);
                        
            pessoa = pessoabus.getPessoa(new Pessoa { IDPessoa = 2 });            
            List<Pessoa> pessoaRet = pessoabus.getAmigos(pessoa, 3);
            Assert.IsTrue(pessoaRet.Count == 3);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DeleteAmigo_PessoaNull_OutOfRangeExceptionTest()
        {
            Pessoa pessoa = null;
            PessoasBusiness pessoabus = new PessoasBusiness();
            Boolean Retorno = pessoabus.DeleteAmigo(pessoa);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void DeleteAmigo_ID_Pessoa_OutOfRangeExceptionTest()
        {
            Pessoa pessoa = new Pessoa { IDPessoa = 0 };
            PessoasBusiness pessoabus = new PessoasBusiness();
            Boolean Retorno = pessoabus.DeleteAmigo(pessoa);
        }

        [TestMethod]
        public void DeleteAmigo_Test()
        {
            Pessoa pessoa = new Pessoa { IDPessoa = 2 };
            PessoasBusiness pessoabus = new PessoasBusiness();
            Boolean Retorno = pessoabus.DeleteAmigo(pessoa);
            Assert.IsTrue(Retorno);

            pessoa = new Pessoa { IDPessoa = 2 };
            pessoabus = new PessoasBusiness();
            Pessoa pessoaRet = pessoabus.getPessoa(pessoa);
            Assert.IsTrue(pessoaRet == null);
        }

    }
}
