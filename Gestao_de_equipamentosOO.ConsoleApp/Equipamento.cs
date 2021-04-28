using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Gestao_de_equipamentosOO.ConsoleApp
{
    class Equipamento
    {
        private string nome;
        private string preco;
        private string numero_serie;
        private DateTime data_fabricacao;
        private string fabricante;

        public void Registrar()
        {
            Console.Clear();
            Console.WriteLine(" REGISTRAR EQUIPAMENTO\n\n");
            this.nome = NovoNome();

            Console.WriteLine("Digite o preço do equipamento: ");
            this.preco = (Console.ReadLine());

            Console.WriteLine("Digite o número de série do equipamento: ");
            this.numero_serie = (Console.ReadLine());

            DateTime Date = NovaData();
            this.data_fabricacao = Date;

            Console.WriteLine("Digite o fabricante do equipamento: ");
            this.fabricante = (Console.ReadLine());
        }
        private DateTime NovaData()
        {
            do
            {
                Console.WriteLine("Digite a data de aquisição do equipamento (dd/mm/aaaa): ");
                string data = Console.ReadLine();

                if (data.Length < 10)
                {
                    Console.WriteLine("Formato inválido.");
                }
                else
                {
                    string dia;
                    string mes;
                    string ano;
                    int d_temp;
                    int m_temp;
                    int a_temp;

                    dia = data.Split('/')[0];
                    mes = data.Split('/')[1];
                    ano = data.Split('/')[2];

                    d_temp = Convert.ToInt32(dia);
                    m_temp = Convert.ToInt32(mes);
                    a_temp = Convert.ToInt32(ano);

                    var date = new DateTime(a_temp, m_temp, d_temp);
                    return date;
                }

            } while (true);
        }
        private string NovoNome()
        {
            do
            {
                Console.WriteLine("Digite o nome do equipamento: ");
                string nome = Console.ReadLine();

                if (nome.Length < 6)
                {
                    Console.WriteLine("Formato inválido. Mínimo 6 caracteres.");
                }
                else
                {
                    return nome;
                }
            } while (true);
        }
        public void Mostrar()
        {
            Console.WriteLine($"Nome do equipamento: {nome}");
            Console.WriteLine($"Preco do equipamento: {preco}");
            Console.WriteLine($"Nº de série do equipamento: {numero_serie}");
            Console.WriteLine($"Data de aquisição do equipamento: {data_fabricacao}");
            Console.WriteLine($"Fabricante do equipamento: {fabricante}");
        }

        public void Editar()
        {
            Console.WriteLine(" Digite o que quer editar no item:\n 1.   Nome\n 2.   Preço\n 3.   Número de série\n 4.   Data de aquisição\n 5.   Fabricante\n 6.   Voltar");
            string item = Console.ReadLine();

            switch (item)
            {
                case "1":
                    this.nome = NovoNome();
                    break;
                case "2":
                    Console.WriteLine("Digite o preço do equipamento: ");
                    this.preco = (Console.ReadLine());
                    break;
                case "3":
                    Console.WriteLine("Digite o número de série do equipamento: ");
                    this.numero_serie = (Console.ReadLine());
                    break;
                case "4":
                    DateTime Date = NovaData();
                    this.data_fabricacao = Date;
                    break;
                case "5":
                    Console.WriteLine("Digite o fabricante do equipamento: ");
                    this.fabricante = (Console.ReadLine());
                    break;
                case "6": break;
                default: Console.WriteLine("Input errado!"); Console.ReadLine(); Console.Clear(); break;
            }
        }
        public string ChamarNome()
        {
            return nome;
        }
    }
}
