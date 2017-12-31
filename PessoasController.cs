using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FL.Entity;
using FL.Business; 
 
namespace FL.API.Controllers
{
    [RoutePrefix("FriendsLocstion/pessoas")]

    public class PessoasController : ApiController
    {
        
        [Route("GetAllPessoas", Name = "FLGetAllPessoas")]
        [HttpGet]
        public List<Pessoa> GetAllPessoas()
        {
            try
            {
                PessoasBusiness objPessoasBus = new PessoasBusiness();
                return objPessoasBus.getAllPessoas();
            }
            catch (Exception ex)
            {
                throw ex;
            }             
        }

        [Route("GetPessoa/{IDPessoa:int}", Name = "FLGetPessoa")]
        [HttpGet]
        public Pessoa GetPessoa(int pIDPessoa)
        {
            try
            {
                PessoasBusiness objPessoasBus = new PessoasBusiness();
                return objPessoasBus.getPessoa(pIDPessoa);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [Route("GetPessoa/{IDPessoa:int,Latitude:float,Longitude:float}", Name = "FLGetPessoa")]
        [HttpGet]
        public Pessoa GetPessoa(int IDPessoa, float pLatitude, float pLongitude)
        {
            try
            {
                PessoasBusiness objPessoasBus = new PessoasBusiness();
                return objPessoasBus.getPessoa(IDPessoa, pLatitude, pLongitude);
            }
            catch (Exception ex)
            {
                throw ex;
            }            
        }

        [Route("PostPessoa", Name = "FLPostPessoa")]
        [HttpPost]
        public HttpResponseMessage PostPessoa(Pessoa pessoa)
        {
            try
            {
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [Route("PutPessoa", Name = "FLPutPessoa")]
        [HttpPut]
        public HttpResponseMessage PutPessoa(Pessoa pessoa)
        {
            try
            {
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [Route("uploadFile", Name = "DWHUploadPackage")]
        [HttpPut]
        public HttpResponseMessage DeletePessoa(int IDPessoa)
        {
            try
            {
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
