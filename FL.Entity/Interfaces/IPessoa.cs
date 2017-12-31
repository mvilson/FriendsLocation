using System;

namespace FL.Entity
{
    public interface IPessoa : IComparable<Pessoa>
    {
        int IDPessoa { get; set; }
        string NomePessoa { get; set; }
        Localidade LocalidadePessoa { get; set; }               
    } 
}
