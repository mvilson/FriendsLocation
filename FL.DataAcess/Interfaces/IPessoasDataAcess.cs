using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FL.Entity;

namespace FL.DataAcess
{
    interface IPessoasDataAcess
    {
        List<Pessoa> getAllPessoas();
        List<Pessoa> getAllAmigos();
        Pessoa getPessoaID(Pessoa pPessoa);
        Pessoa getPessoaLatLong(Pessoa pPessoa);
        Boolean InsertAmigo(Pessoa pessoa);
        Boolean DeleteAmigo(Pessoa pPessoa);
    }
}
