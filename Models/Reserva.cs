using System.Xml;

namespace DesafioProjetoHospedagem.Models
{
    public class Reserva
    {
        public List<Pessoa> Hospedes { get; set; }
        public Suite Suite { get; set; }
        public int DiasReservados { get; set; }

        public Reserva() { }

        public Reserva(int diasReservados)
        {
            DiasReservados = diasReservados;
        }

        public void CadastrarHospedes(List<Pessoa> hospedes)
        {
            // ToDo: Verificar se a capacidade é maior ou igual ao número de hóspedes sendo recebido
            try
            {
                Hospedes = Suite.Capacidade >= hospedes.Count ? hospedes : throw new IndexOutOfRangeException("Hotel sem vagas");
            }
            // ToDo: Retornar uma exception caso a capacidade seja menor que o número de hóspedes recebido
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Environment.Exit(0);
            }
        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes()
        {
            // ToDo: Retorna a quantidade de hóspedes (propriedade Hospedes)
            return Hospedes.Count;
        }

        public decimal CalcularValorDiaria()
        {
            // ToDo: Retorna o valor da diária
            // Cálculo: DiasReservados X Suite.ValorDiaria
            var valor = Suite.ValorDiaria;
            var calcularValorDiaria = DiasReservados * valor;
            Console.WriteLine($"Total a pagar: {calcularValorDiaria}");
            // Regra: Caso os dias reservados forem maior ou igual a 10, conceder um desconto de 10%
            if (DiasReservados >= 10)
            {
                calcularValorDiaria -= calcularValorDiaria * (10M / 100M);
                Console.WriteLine($"Total a pagar com desconto: {calcularValorDiaria}");
            }
            return valor;
        }
    }
}