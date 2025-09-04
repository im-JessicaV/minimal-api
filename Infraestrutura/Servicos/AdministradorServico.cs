using System.Data.Common;
using MinimalAPI.Dominio.Entidades;
using MinimalAPI.Dominio.Interfaces;
using MinimalAPI.DTOs;
using MinimalAPI.Infraestrutura.Db;

namespace MinimalAPI.Dominio.Servicos
{
    public class AdministradorServico : IAdministradorServico
    {
        private readonly dbContexto _contexto;

        public AdministradorServico(dbContexto contexto)
        {
            _contexto = contexto;
        }
        public Administrador? Login(loginDTO loginDTO)
        {
            var administradores = _contexto.Administradores
                .Where(a => a.Email == loginDTO.Email && a.Senha == loginDTO.Password)
                .FirstOrDefault();

            return administradores;
        }
    }
}