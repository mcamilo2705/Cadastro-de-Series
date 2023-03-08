using System;
using CadastroSeries.Interfaces;

namespace CadastroSeries
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch(opcaoUsuario)
                {
                    case "1":
                       ListarSeries(); 
                       break;
                    case "2":
                        InserirSerie();
                        break;
                    case "3":
                       AtualizarSeries(); 
                       break;
                    case "4":
                        ExcluirSerie();
                        break;
                    case "5":
                       VisualizarSeries(); 
                       break;
                    case "C":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();

                }

                opcaoUsuario = ObterOpcaoUsuario();
            }
        }

        private static void VisualizarSeries()
        {
            Console.WriteLine("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            var serie = repositorio.RetonraPorId(indiceSerie);

            Console.WriteLine(serie);
        }

        private static void ExcluirSerie()
        {
           Console.WriteLine("Digite o id da série: ");
           int indiceSerie = int.Parse(Console.ReadLine());

           repositorio.Exclui(indiceSerie);
        }

        private static void AtualizarSeries()
        {
            Console.WriteLine("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            foreach(int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("Digite o genêro entre as opções acima: ");
                int entradaGenero = int.Parse(Console.ReadLine());

                Console.WriteLine("Digite o título da série: ");
                string entradaTitulo = Console.ReadLine();

                Console.WriteLine("Digite o ano de início da série: ");
                int entradaAno = int.Parse(Console.ReadLine());

                Console.WriteLine("Digite a descição da série: ");
                string entradaDescricao = Console.ReadLine();

                Serie atualizaSerie = new Serie (id: indiceSerie,
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);
            
            repositorio.Atualiza(indiceSerie, atualizaSerie);

            }
        }

        private static void InserirSerie()
        {
            Console.WriteLine("Inserir uma nova série");

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.WriteLine("Digite o genêro entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o título da série: ");
            string entradaTitulo = Console.ReadLine();

            Console.WriteLine("Digite o ano de início da série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a descição da série: ");
            string entradaDescricao = Console.ReadLine();

            Serie novaSerie = new Serie (id: repositorio.ProximoId(),
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);
            
            repositorio.Insere(novaSerie);
        }

        private static void ListarSeries()
        {
            Console.WriteLine("Listar séries");

            var lista = repositorio.Lista();

            if(lista.Count == 0)
            {
                Console.WriteLine("Nenhuma série cadastrada");
                return;
            }

            foreach(var serie in lista)
            {
                var excluido  = serie.retornaExcluido();

                Console.WriteLine("#ID {0}: - {1} - {2}", serie.retornId(), serie.retornaTitulo(), (excluido ? "*Excluído*" : ""));
            }
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Olá, seja bem vindo !");
            Console.WriteLine("Informe a opção desejada: ");
            Console.WriteLine("1- Listar série");
            Console.WriteLine("2- Inserir nova série");
            Console.WriteLine("3- Atualizar série");
            Console.WriteLine("4- Excluir série");
            Console.WriteLine("5- Visualizar série");
            Console.WriteLine("C- Limpar Tela");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;

        }
    }

}
