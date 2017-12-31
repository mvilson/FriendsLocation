using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FL.Entity;

namespace FL.Business
{
    interface IPessoasBusiness
    {
        List<Pessoa> getAllPessoas();
        Pessoa getPessoa(Pessoa pessoa);
        Pessoa getPessoaLatLong(Pessoa pessoa);
        List<Pessoa> getAmigos(Pessoa pPessoa, int QtdAmigos);
        Boolean InsertAmigo(Pessoa pessoa);
        Boolean DeleteAmigo(Pessoa pPessoa);        
    }
}
