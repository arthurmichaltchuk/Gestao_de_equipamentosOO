using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Gestao_de_equipamentosOO.ConsoleApp
{
    class Chamado : Equipamento
    {
        private string titulo;
        private string descricao;
        private string equip;
        private DateTime data_abert;

        public void RegistrarChamado(ref string equip_nome)
        {
            Console.WriteLine(" REGISTRAR CHAMADO\n");
            this.equip = equip_nome;

            Console.WriteLine("Digite o título do chamado: ");
            this.titulo = (Console.ReadLine());
            
            Console.WriteLine("Digite a descrição do chamado: ");
            this.descricao = Console.ReadLine();

            DateTime Date = NovaData();
            this.data_abert = Date;
        }

        private DateTime NovaData()
        {
            do
            {
                Console.WriteLine("Digite a data de abertura do chamado (dd/mm/aaaa): ");
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
        public void MostrarChamado()
        {
            Console.WriteLine($"\nTítulo do chamado: {titulo}");
            Console.WriteLine($"Equipamento atribuído: {equip}");
            Console.WriteLine($"Descrição do equipamento: {descricao}");
            Console.WriteLine($"Data de abertura do chamado: {data_abert}");
            int dia, mes, ano, dia_total;
            dia = DateTime.Now.Day - data_abert.Day;
            mes = DateTime.Now.Month - data_abert.Month;
            ano = DateTime.Now.Year - data_abert.Year;

            dia_total = dia + (mes * 30) + (ano * 365);

            Console.WriteLine("Dias em aberto:" + dia_total);
        }
        public void EditarChamado()
        {

            Console.WriteLine(" Digite o que quer editar no item:\n 1.   Título\n 2.   Descrição\n 3.   Data de abertura\n 4.   Voltar");
            string item = Console.ReadLine();

            switch (item)
            {
                case "1":
                    Console.WriteLine("Digite o título do chamado: ");
                    this.titulo = (Console.ReadLine());
                    break;
                case "2":
                    Console.WriteLine("Digite a descrição do chamado: ");
                    this.descricao = Console.ReadLine();
                    break;
                case "3":
                    DateTime Date = NovaData();
                    this.data_abert = Date;
                    break;
                case "4": break;
                default: Console.WriteLine("Input errado!"); Console.ReadLine(); Console.Clear(); break;

            }
        }
    }
}
