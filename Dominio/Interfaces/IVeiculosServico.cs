using MinimalAPI.Dominio.Entidades;
using MinimalAPI.DTOs;

namespace MinimalAPI.Dominio.Interfaces
{
    public interface IVeiculosServico
    {
        List<Veiculo> ObterTodosVeiculos(int pagina = 1, string? nome = null, string? marca = null);
        Veiculo? ObterVeiculoPorId(int id);
        void AdicionarVeiculo(Veiculo veiculo);
        void AtualizarVeiculo(Veiculo veiculo);
        void RemoverVeiculo(Veiculo veiculo);
    }
}