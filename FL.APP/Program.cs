using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FL.Business;
using FL.Entity;

namespace FL.APP
{
    class Program
    {
        static void Main(string[] args)
        {
            MontarMenu();
        }

        private static void MontarMenu() 
        {
            try
            {
                Console.Clear();
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("                 ********************************************************************");
                Console.WriteLine("                 *                            Menu                                  *");
                Console.WriteLine("                 ********************************************************************");
                Console.WriteLine("                 *                    [ 1 ] - Inserir Amigo                         *");
                Console.WriteLine("                 *                    [ 2 ] - Excluir Amigo                         *");
                Console.WriteLine("                 *                    [ 3 ] - Listar Todos os Amigos                *");
                Console.WriteLine("                 *                    [ 4 ] - Procurar Amigos Próximos              *");
                Console.WriteLine("                 *                    [ 5 ] - Sair do Sistema                       *");
                Console.WriteLine("                 ********************************************************************");

                String strOpcao = "";
                int Opcao = 0;

                Boolean Sair = false;
                while (!Sair)
                {
                    strOpcao = Console.ReadLine();
                    if (int.TryParse(strOpcao, out Opcao))
                    {
                        switch (Opcao)
                        {
                            case 1:
                                InserirAmigos();
                                break;
                            case 2:
                                ExcluirAmigos();
                                break;
                            case 3:
                                ListarAmigos();
                                break;
                            case 4:
                                ProcurarAmigos();
                                break;
                            case 5:
                                SairPrograma();
                                break;
                            default:
                                Sair = false;
                                break;
                        }
                    }
                    Console.WriteLine("Opcao invalida!");
                }
            }
            catch(ArgumentNullException ex)
            {
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine(ex.Message);
                Console.ReadKey();
                MontarMenu();
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine(ex.Message);
                Console.ReadKey();
                MontarMenu();
            }
            catch (Exception ex)
            {
                Console.Clear();
                Console.WriteLine("Ocorreu um erro no sistema:");
                Console.WriteLine(ex.Message);
                Console.ReadKey();
                Environment.Exit(1);
            }                       
        }
        
        private static void InserirAmigos()
        {
            try
            {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine("Inserir amigos:");
                Console.WriteLine("");

                String Nome = "";
                while (Nome.Trim().Length == 0)
                {
                    Console.WriteLine("Informe o nome:");
                    Nome = Console.ReadLine();
                }

                String strlatitude = "";
                float latitude;
                Console.WriteLine("Informe a Latitude:");
                strlatitude = Console.ReadLine();
                while (!float.TryParse(strlatitude, out latitude))
                {
                    Console.WriteLine("Latitude deve ser numerico");
                    Console.WriteLine("Informe a Latitude:");
                    strlatitude = Console.ReadLine();
                }

                Console.WriteLine("Informe a Longitude:");
                String strlongitude = Console.ReadLine();
                float longitude;
                while (!float.TryParse(strlongitude, out longitude))
                {
                    Console.WriteLine("Longitude deve ser numerico");
                    Console.WriteLine("Informe a Longitude:");
                    strlongitude = Console.ReadLine();
                }

                Console.WriteLine("");
                Console.WriteLine("Você informou:");
                Console.WriteLine("*********************************************");
                Console.WriteLine("Nome:" + Nome);
                Console.WriteLine("Latitude:" + latitude);
                Console.WriteLine("Longitude:" + longitude);
                Console.WriteLine("*********************************************");
                Console.WriteLine("");

                PessoasBusiness Pessoabus = new PessoasBusiness();
                Pessoa AmigoExist = Pessoabus.getPessoaLatLong(new Pessoa { LocalidadePessoa = new Localidade { Latitude = latitude, Longitude = longitude } });
                if (AmigoExist != null)
                {
                    Console.WriteLine("Já existe um amigo com a latitude e longitude informada.");
                    Console.WriteLine("*********************************************");
                    Console.WriteLine("Nome:" + AmigoExist.NomePessoa);
                    Console.WriteLine("Latitude:" + AmigoExist.LocalidadePessoa.Latitude);
                    Console.WriteLine("Longitude:" + AmigoExist.LocalidadePessoa.Longitude);
                    Console.WriteLine("*********************************************");
                    Console.WriteLine("");

                    Console.WriteLine("Tecle qualquer tecla para inserir outro amigo");
                    Console.ReadKey();
                    InserirAmigos();
                }


                int Opcao = 0;
                String strOpcao = "";
                Boolean Confirma = false;
                while (Confirma == false)
                {
                    Console.WriteLine("Confirma? (S = Sim    /  N = Não)");
                    strOpcao = Console.ReadLine();
                    Confirma = (strOpcao.ToUpper() == "S") || (strOpcao.ToUpper() == "N");
                }

                if (strOpcao.ToUpper() == "S")
                {
                    Pessoa pessoa = new Pessoa { IDPessoa = 0, NomePessoa = Nome, LocalidadePessoa = new Localidade { IDLocalidade = 0, Latitude = latitude, Longitude = longitude } };
                    PessoasBusiness pessoabus = new PessoasBusiness();
                    if (pessoabus.InsertAmigo(pessoa))
                    {
                        Console.Clear();
                        Console.WriteLine("");
                        Console.WriteLine("Dados inseridos com sucesso");
                    }
                    else
                        Console.WriteLine("Erro ao inserir os dados");
                }

                Console.WriteLine("");
                if (strOpcao.ToUpper() == "N")
                    Console.Clear();

                Boolean Sair = false;
                while (!Sair)
                {
                    Console.WriteLine("Digite 0 para inserir novo registro");
                    Console.WriteLine("Digite 99 para voltar ao menu principal");
                    strOpcao = Console.ReadLine();
                    if (int.TryParse(strOpcao, out Opcao))
                    {
                        switch (Opcao)
                        {
                            case 0:
                                InserirAmigos();
                                break;
                            case 99:
                                MontarMenu();
                                break;
                        }
                    }
                }
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine(ex.Message);
                Console.ReadKey();
                InserirAmigos();
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine(ex.Message);
                Console.ReadKey();
                InserirAmigos();
            }
            catch (Exception ex)
            {
                Console.Clear();
                Console.WriteLine("Ocorreu um erro no sistema:");
                Console.WriteLine(ex.Message);
                Console.ReadKey();                
                Environment.Exit(2);
            }
        }

        private static void ExcluirAmigos()
        {
            try
            {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine("Excluir amigos:");
                Console.WriteLine("");

                Console.WriteLine("Informe o ID do amigo a ser excluido:");
                Console.WriteLine("(Para saber o ID do amigo, pesqyuse na opcao 3 - Listar Amigos)");

                String strID = "";
                int ID;
                strID = Console.ReadLine();
                while (!int.TryParse(strID, out ID))
                {
                    Console.WriteLine("O ID do amigo deve numerico");
                    Console.WriteLine("Informe o ID do amigo a ser excluido:");
                    strID = Console.ReadLine();
                }

                Pessoa pessoa = new Pessoa { IDPessoa = ID };
                PessoasBusiness pessoabus = new PessoasBusiness();
                if (pessoabus.DeleteAmigo(pessoa))
                {
                    Console.Clear();
                    Console.WriteLine("");
                    Console.WriteLine("Amigo excluido com sucesso");
                }
                else
                    Console.WriteLine("Erro ao excluir amigo");

                Boolean Sair = false;
                int Opcao = 0;
                String strOpcao = "";

                while (!Sair)
                {
                    Console.WriteLine("Digite 0 para excluir outro amigo");
                    Console.WriteLine("Digite 99 para voltar ao menu principal");
                    strOpcao = Console.ReadLine();
                    if (int.TryParse(strOpcao, out Opcao))
                    {
                        switch (Opcao)
                        {
                            case 0:
                                ExcluirAmigos();
                                break;
                            case 99:
                                MontarMenu();
                                break;
                        }
                    }
                }
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine(ex.Message);
                Console.ReadKey();
                ExcluirAmigos();
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine(ex.Message);
                Console.ReadKey();
                ExcluirAmigos();
            }
            catch (Exception ex)
            {
                Console.Clear();
                Console.WriteLine("Ocorreu um erro no sistema:");
                Console.WriteLine(ex.Message);
                Console.ReadKey();
                Environment.Exit(3);
            }            
        }

        private static void ListarAmigos()
        {
            try
            {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine("Listando todos os amigos. (Digite 99 para voltar ao menu principal)");

                PessoasBusiness pessoaBus = new PessoasBusiness();
                List<Pessoa> objPessoas = pessoaBus.getAllPessoas();

                Console.WriteLine("......................................................");
                foreach (Pessoa pessoa in objPessoas)
                {
                    Console.WriteLine("ID: " + pessoa.IDPessoa);
                    Console.WriteLine("Nome: " + pessoa.NomePessoa);
                    Console.WriteLine("Latitude: " + pessoa.LocalidadePessoa.Latitude.ToString().Replace(",", "."));
                    Console.WriteLine("Longitude: " + pessoa.LocalidadePessoa.Longitude.ToString().Replace(",", "."));
                    Console.WriteLine("......................................................");
                }

                string strCodigo = "";
                int Codigo = 0;
                Boolean Sair = false;
                while (!Sair)
                {
                    Console.WriteLine("Digite 99 para voltar ao menu principal");
                    strCodigo = Console.ReadLine();
                    if (int.TryParse(strCodigo, out Codigo))
                        Sair = (Codigo == 99);
                }
                MontarMenu();
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine(ex.Message);
                Console.ReadKey();
                ListarAmigos();
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.Message);
                Console.ReadKey();
                ListarAmigos();
            }
            catch (Exception ex)
            {
                Console.Clear();
                Console.WriteLine("Ocorreu um erro no sistema:");
                Console.WriteLine(ex.Message);
                Console.ReadKey();
                Environment.Exit(4);
            }            
        }

        private static void ProcurarAmigos()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("");
                Console.WriteLine("");

                string strQtdAmigos = "";
                int QtdAmigos = 0;
                Boolean FimLoop = false;
                Console.WriteLine("Informe quantos amigos próximos deverão ser localizados:");
                while (!FimLoop)
                {                    
                    strQtdAmigos = Console.ReadLine();
                    if (int.TryParse(strQtdAmigos, out QtdAmigos))
                    {
                        FimLoop = true;                        
                    }
                    else
                    {
                        Console.WriteLine("Quantidade de amigos deve numerico.");
                        Console.WriteLine("Informe quantos amigos próximos deverão ser localizados:");
                        FimLoop = false;
                    }
                        
                }


                PessoasBusiness pessoaBus = new PessoasBusiness();
                List<Pessoa> objPessoas = pessoaBus.getAllPessoas();
                List<Pessoa> objAmigosProximos;

                Console.WriteLine(".................................................................................");
                Console.WriteLine("..................Listando todos os amigos e amigos proximos.....................");
                Console.WriteLine(".................................................................................");
                Console.WriteLine("");
                Console.WriteLine("**********************************************************************************");
                foreach (Pessoa pessoa in objPessoas)
                {
                    Console.WriteLine("ID: " + pessoa.IDPessoa);
                    Console.WriteLine("Nome: " + pessoa.NomePessoa);
                    Console.WriteLine("Latitude: " + pessoa.LocalidadePessoa.Latitude.ToString().Replace(",", "."));
                    Console.WriteLine("Longitude: " + pessoa.LocalidadePessoa.Longitude.ToString().Replace(",", "."));
                    pessoa.LocalidadePessoa.getDistanciaEuclidiana(pessoa.LocalidadePessoa.Latitude, pessoa.LocalidadePessoa.Longitude);
                    Console.WriteLine("Distancia Euclidiana: " + pessoa.LocalidadePessoa.DistanciaEuclidiana.ToString().Replace(",", "."));

                    objAmigosProximos = pessoaBus.getAmigos(pessoa, QtdAmigos);
                    Console.WriteLine("");
                    Console.WriteLine("        Listando abaixo o(s) " + objAmigosProximos.Count() + " amigo(s) mais próximo(s) de " + pessoa.NomePessoa);
                    Console.WriteLine("        ......................................................................");
                    Console.WriteLine("");
                    foreach (Pessoa amigo in objAmigosProximos)
                    {
                        Console.WriteLine("ID: " + amigo.IDPessoa);
                        Console.WriteLine("Nome: " + amigo.NomePessoa);
                        Console.WriteLine("Latitude: " + amigo.LocalidadePessoa.Latitude.ToString().Replace(",", "."));
                        Console.WriteLine("Longitude: " + amigo.LocalidadePessoa.Longitude.ToString().Replace(",", "."));
                        Console.WriteLine("Distancia Euclidiana: " + amigo.LocalidadePessoa.DistanciaEuclidiana.ToString().Replace(",", "."));
                        Console.WriteLine("");
                        Console.WriteLine("");
                        Console.WriteLine("");
                    }
                    Console.WriteLine("");
                    Console.WriteLine("**********************************************************************************");
                }
                Console.WriteLine("");

                string strCodigo = "";
                int Codigo = 0;
                Boolean Sair = false;
                while (!Sair)
                {
                    Console.WriteLine("Digite 99 para voltar ao menu principal");
                    strCodigo = Console.ReadLine();
                    if (int.TryParse(strCodigo, out Codigo))
                        Sair = (Codigo == 99);
                }

                MontarMenu();
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine(ex.Message);
                Console.ReadKey();
                ProcurarAmigos();
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine(ex.Message);
                Console.ReadKey();
                ProcurarAmigos();
            }
            catch (Exception ex)
            {
                Console.Clear();
                Console.WriteLine("Ocorreu um erro no sistema:");
                Console.WriteLine(ex.Message);
                Console.ReadKey();
                Environment.Exit(5);
            }            
        }

        private static void SairPrograma()
        {
            try
            {
                String Opcao;
                Boolean Sair = false;
                Console.WriteLine();
                while (!Sair)
                {
                    Console.WriteLine("Confirma? (S = Sim    /  N = Não)");
                    Opcao = Console.ReadLine();
                    switch (Opcao.ToUpper())
                    {
                        case "S":
                            Environment.Exit(0);
                            break;
                        case "N":
                            MontarMenu();
                            break;
                    }
                }
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine(ex.Message);
                Console.ReadKey();
                SairPrograma();
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine(ex.Message);
                Console.ReadKey();
                SairPrograma();

            }
            catch (Exception ex)
            {
                Console.Clear();
                Console.WriteLine("Ocorreu um erro no sistema:");
                Console.WriteLine(ex.Message);
                Console.ReadKey();
                Environment.Exit(6);
            }                        
        }
    }
}
