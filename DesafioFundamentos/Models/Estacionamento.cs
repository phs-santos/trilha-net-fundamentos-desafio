namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            Console.WriteLine("Modelo de Placa: ABC-1234");
            Console.Write("=> ");

            string placa = Console.ReadLine();

            #region Validando a Placa
            string[] result = placa.Split('-');

            if (result.Length < 2 || result.Length > 2)
            {
                Console.WriteLine("Placa inválida!");
                return;
            }
            #endregion

            #region Validando se ja existe um veiculo com essa Placa
            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                Console.WriteLine("Já existe um veiculo com essa placa!");
                return;
            }
            #endregion

            veiculos.Add(placa.ToUpper());
        }

        public void RemoverVeiculo()
        {
            #region Mostrando para o usuario os veiculos que estão estacionados.
            Console.WriteLine("Os veículos estacionados são:");
            foreach (string veiculo in veiculos)
            {
                Console.WriteLine(veiculo);
            }
            #endregion

            Console.WriteLine("Digite a placa do veículo para remover:");
            Console.Write("=> ");

            string placa = Console.ReadLine();

            // Verifica se o veículo existe
            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");
                Console.Write("=> ");

                int horas = Convert.ToInt32(Console.ReadLine());
                decimal valorTotal = precoInicial + precoPorHora * horas;

                veiculos.Remove(placa.ToUpper());
                Console.WriteLine($"O veículo {placa.ToUpper()} foi removido e o preço total foi de: R$ {valorTotal}");
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                foreach (string veiculo in veiculos)
                {
                    Console.WriteLine(veiculo);
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }

        public bool VerificarSeEstacionamentoEstaVazio()
        {
            if (veiculos.Any())
            {
                Console.WriteLine("Ainda existe veículos no estacionamento.");
                return false;
            }

            return true;
        }
    }
}
