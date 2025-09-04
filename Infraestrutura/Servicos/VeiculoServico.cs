using System.Data.Common;
using Microsoft.EntityFrameworkCore;
using MinimalAPI.Dominio.Entidades;
using MinimalAPI.Dominio.Interfaces;
using MinimalAPI.DTOs;
using MinimalAPI.Infraestrutura.Db;

namespace MinimalAPI.Dominio.Servicos
{
    public class VeiculoServico : IVeiculosServico
    {
        private readonly dbContexto _contexto;

        public void AdicionarVeiculo(Veiculo veiculo)
        {
            _contexto.Veiculos.Add(veiculo);
            _contexto.SaveChanges();
        }

        public void AtualizarVeiculo(Veiculo veiculo)
        {
            _contexto.Veiculos.Update(veiculo);
            _contexto.SaveChanges();
        }

        public List<Veiculo> ObterTodosVeiculos(int pagina = 1, string? nome = null, string? marca = null)
        {
            var query = _contexto.Veiculos.AsQueryable();
            if (!string.IsNullOrEmpty(nome))
            {
                query = query.Where(v => EF.Functions.Like(v.Nome.ToLower(), $"%{nome.ToLower()}%"));
            }

            int itensPorPagina = 10;
            query = query.Skip((pagina - 1) * itensPorPagina).Take(itensPorPagina);

            return query.ToList();

        }

        public Veiculo? ObterVeiculoPorId(int id)
        {
            return _contexto.Veiculos.Where(v => v.Id == id).FirstOrDefault();
        }

        public void RemoverVeiculo(Veiculo veiculo)
        {
            _contexto.Veiculos.Remove(veiculo);
            _contexto.SaveChanges();
        }
    }
}
            