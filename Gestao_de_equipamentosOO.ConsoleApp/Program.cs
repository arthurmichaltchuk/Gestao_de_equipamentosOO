using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Gestao_de_equipamentosOO.ConsoleApp
{
    public class Program
    {
        static bool vazioChamado;
        static bool vazio;
        static bool entradaValida;
        static void Main(string[] args)
        {
            List<Equipamento> listaEquipamentos = new List<Equipamento>();
            List<Chamado> listaChamados = new List<Chamado>();

            string opcao;
            do
            {
                Console.Clear();
                Console.WriteLine("\n                      Menu Principal\n__________________________________________________________\n\n 1.   Registrar equipamentos\n 2.   Visualizar inventário\n 3.   Gerenciar inventário\n 4.   Chamados de manutenções\n 5.   Sair\n__________________________________________________________\n");
                opcao = Console.ReadLine();
                
                switch (opcao)
                {
                    case "1":
                        Equipamento eq = new Equipamento();
                        eq.Registrar();
                        listaEquipamentos.Add(eq);
                        break;
                    case "2":
                        MostrarListaEquipamentos(listaEquipamentos);
                        Console.ReadLine();
                        break;
                    case "3": MenuEdicao(listaEquipamentos); break;
                    case "4": MenuChamados(listaChamados, listaEquipamentos); break;
                    case "5": break;
                    default: Console.WriteLine("Input errado!"); Console.ReadLine(); Console.Clear(); break;
                }
            } while (opcao != "5");
        }

        private static void MostrarListaEquipamentos(List<Equipamento> listaEquipamentos)
        {
            Console.Clear();
            if (listaEquipamentos.Count == 0)
            {
                Console.WriteLine("Sem equipamentos no inventário...");
                Console.ReadLine();
                vazio = true;
            }
            else
            {
                vazio = false;
                for (int i = 0; i < listaEquipamentos.Count; i++)
                {
                    Console.WriteLine($"\n\nNÚMERO DO ITEM: {i}\n");
                    listaEquipamentos[i].Mostrar();
                }
            }
        }
        private static void MenuChamados(List<Chamado> listaChamados, List<Equipamento> listaEquipamentos)
        {
            string opcao;
            do
            {
                bool verificar;
                int num_equip;
                Console.Clear();
                Console.WriteLine("\n                      Menu de chamados\n__________________________________________________________\n\n 1.   Registrar chamado\n 2.   Visualizar chamados\n 3.   Gerenciar Chamados\n 4.   Voltar\n__________________________________________________________\n");
                opcao = Console.ReadLine();
                
                switch (opcao)
                {
                    case "1":
                        MostrarListaEquipamentos(listaEquipamentos);
                        if (vazio == true)
                            break;
                        Console.WriteLine("Digite o número do item que deseja atribuir o chamado");
                        verificar = int.TryParse(Console.ReadLine(), out num_equip);

                        VerificarEntradas(listaEquipamentos, num_equip, verificar);
                        if (entradaValida == true)
                        {
                            string equip_nome = listaEquipamentos[num_equip].ChamarNome();
                            Chamado cha = new Chamado();

                            cha.RegistrarChamado(ref equip_nome);
                            listaChamados.Add(cha);   
                        }                                           
                        break;
                    case "2":
                        MostrarListaChamados(listaChamados);
                        Console.ReadLine();
                        break;
                    case "3":
                        MenuEdicaoChamado(listaChamados, listaEquipamentos);
                        break;
                    case "4": break;
                    default: Console.WriteLine("Input errado!"); Console.ReadLine(); Console.Clear(); break;
                }
            } while (opcao != "4");
        }

        private static void MenuEdicaoChamado(List<Chamado> listaChamados, List<Equipamento> listaEquipamentos)
        {
            int num_equip;
            string opcao;
            bool verificar;
            do
            {
                Console.Clear();
                Console.WriteLine("\n                      Menu edição de chamados\n__________________________________________________________\n\n 1.   Escolher chamado para editar\n 2.   Excluir chamado\n 3.   Voltar\n__________________________________________________________\n");
                opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        MostrarListaChamados(listaChamados);
                        if (vazioChamado == true)
                            break;
                        Console.WriteLine("\nDigite o número do equipamento que deseja alterar: ");
                        verificar = int.TryParse(Console.ReadLine(), out num_equip);

                        VerificarEntradasChamado(listaChamados, num_equip, verificar);
                        if (entradaValida == true)
                            listaChamados[num_equip].EditarChamado();
                        break;
                    case "2":
                        MostrarListaEquipamentos(listaEquipamentos);
                        if (vazioChamado == true)
                            break;
                        Console.WriteLine("\nDigite o número do chamado que deseja excluir: ");
                        verificar = int.TryParse(Console.ReadLine(), out num_equip);

                        VerificarEntradasChamado(listaChamados, num_equip, verificar);
                        if (entradaValida == true)
                            listaChamados.RemoveAt(num_equip);
                        break;
                    case "3": break;
                    default: Console.WriteLine("Input errado!"); Console.ReadLine(); Console.Clear(); break;
                }
            } while (opcao != "3");
        }

        private static void VerificarEntradasChamado(List<Chamado> listaChamados, int num_equip, bool verificar)
        {
            if (verificar == false)
            {
                Console.WriteLine("Entrada inválida, use números...");
                Console.ReadLine();
                entradaValida = false;
            }
            else
            {
                if (num_equip >= listaChamados.Count || num_equip < 0)
                {
                    Console.WriteLine("Equipamento inválido...");
                    Console.ReadLine();
                    entradaValida = false;
                }
                else
                {
                    entradaValida = true;
                }
            }
        }

        private static void MostrarListaChamados(List<Chamado> listaChamados)
        {
            Console.Clear();
            if (listaChamados.Count == 0)
            {
                Console.WriteLine("Sem chamados registrados...");
                Console.ReadLine();
                vazioChamado = true;
            }
            else
            {
                vazioChamado = false;
                for (int i = 0; i < listaChamados.Count; i++)
                {
                    Console.WriteLine($"\nNÚMERO DO CHAMADO: {i}");
                    listaChamados[i].MostrarChamado();
                }
            }
        }

        private static void MenuEdicao(List<Equipamento> listaEquipamentos)
        {
            string opcao;
            do
            {
                Console.Clear();
                Console.WriteLine("\n                      Menu de edição\n__________________________________________________________\n\n 1.   Escolher item para editar\n 2.   Excluir item\n 3.   Voltar\n__________________________________________________________\n");
                opcao = Console.ReadLine();
                bool verificar;
                int num_equip;
                switch (opcao)
                {
                    case "1":                        
                        MostrarListaEquipamentos(listaEquipamentos);
                        if (vazio == true)                       
                            break;                      
                        Console.WriteLine("\nDigite o número do equipamento que deseja alterar: ");
                        verificar = int.TryParse(Console.ReadLine(), out num_equip);

                        VerificarEntradas(listaEquipamentos, num_equip, verificar);
                        if (entradaValida == true)
                            listaEquipamentos[num_equip].Editar(); 
                        break;
                    case "2":
                        MostrarListaEquipamentos(listaEquipamentos);
                        if (vazio == true)
                            break;
                        Console.WriteLine("\nDigite o número do equipamento que deseja excluir: ");
                        verificar = int.TryParse(Console.ReadLine(), out num_equip);

                        VerificarEntradas(listaEquipamentos, num_equip, verificar);
                        if (entradaValida == true)
                            listaEquipamentos.RemoveAt(num_equip);
                        break;
                    case "3": break;
                    default: Console.WriteLine("Input errado!"); Console.ReadLine(); Console.Clear(); break;
                }
            } while (opcao != "3");
        }

        private static void VerificarEntradas(List<Equipamento> listaEquipamentos, int num_equip, bool verificar)
        {
            if (verificar == false)
            {
                Console.WriteLine("Entrada inválida, use números...");
                Console.ReadLine();
                entradaValida = false;
            }
            else
            {
                if (num_equip >= listaEquipamentos.Count || num_equip < 0)
                {
                    Console.WriteLine("Equipamento inválido...");
                    Console.ReadLine();
                    entradaValida = false;
                }
                else
                {
                entradaValida = true;
                }
            }
        }
    }
}
