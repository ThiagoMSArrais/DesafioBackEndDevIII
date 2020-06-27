using Dapper;
using DesafioBackEndDevIII.Domain.Clientes;
using DesafioBackEndDevIII.Domain.Clientes.Interfaces;
using DesafioBackEndDevIII.Infra.Data.Connection;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace DesafioBackEndDevIII.Infra.Data.Repository
{
    public class ClienteRepository : ConnectionDB, IClienteRepository
    {
        public ClienteRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public void AdicionarCliente(Cliente cliente)
        {
            using (IDbConnection con = Connection)
            {

                string sqlAdicionarCliente = @"INSERT INTO TB_CLIENTE
                                                  (ID_CLIENTE,
                                                   NM_CLIENTE,
                                                   NU_CPF,
                                                   NU_IDADE)
                                               VALUES
                                                   (@ID_CLIENTE,
                                                    @NM_CLIENTE,
                                                    @NU_CPF,
                                                    @NU_IDADE)";

                string sqlAdicionarEndereco = @"INSERT INTO TB_ENDERECO
                                                   (ID_ENDERECO,
                                                    NM_LOGRADOURO,
                                                    NM_BAIRRO,
                                                    NM_CIDADE,
                                                    NM_ESTADO,
                                                    CD_CLIENTE)
                                                VALUES
                                                    (@ID_ENDERECO,
                                                     @NM_LOGRADOURO,
                                                     @NM_BAIRRO,
                                                     @NM_CIDADE,
                                                     @NM_ESTADO,
                                                     @CD_CLIENTE)";

                try
                {

                    if (con.State == ConnectionState.Closed)
                        con.Open();

                    DynamicParameters parametrosCliente = new DynamicParameters();
                    parametrosCliente.Add("ID_CLIENTE", cliente.ClienteId, DbType.Guid, ParameterDirection.Input);
                    parametrosCliente.Add("NM_CLIENTE", cliente.Nome, DbType.String, ParameterDirection.Input);
                    parametrosCliente.Add("NU_CPF", cliente.Cpf, DbType.String, ParameterDirection.Input);
                    parametrosCliente.Add("NU_IDADE", cliente.Idade, DbType.String, ParameterDirection.Input);

                    con.Execute(sqlAdicionarCliente, param: parametrosCliente);

                    DynamicParameters parametrosEndereco = new DynamicParameters();
                    parametrosEndereco.Add("ID_ENDERECO", cliente.Endereco.EnderecoId, DbType.Guid, ParameterDirection.Input);
                    parametrosEndereco.Add("NM_LOGRADOURO", cliente.Endereco.Logradouro, DbType.String, ParameterDirection.Input);
                    parametrosEndereco.Add("NM_BAIRRO", cliente.Endereco.Bairro, DbType.String, ParameterDirection.Input);
                    parametrosEndereco.Add("NM_CIDADE", cliente.Endereco.Cidade, DbType.String, ParameterDirection.Input);
                    parametrosEndereco.Add("NM_ESTADO", cliente.Endereco.Estado, DbType.String, ParameterDirection.Input);
                    parametrosEndereco.Add("CD_CLIENTE", cliente.ClienteId, DbType.Guid, ParameterDirection.Input);

                    con.Execute(sqlAdicionarEndereco, param: parametrosEndereco);

                    
                    

                }
                catch
                {
                    throw;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }
                    
            }

        }

        public void AtualizarCliente(Cliente cliente)
        {
            using (IDbConnection con = Connection)
            {

                string sqlAtualizarCliente = @"UPDATE TB_CLIENTE
                                               SET NM_CLIENTE = @NM_CLIENTE,
                                                   NU_CPF = @NU_CPF,
                                                   NU_IDADE = @NU_IDADE
                                               WHERE ID_CLIENTE = @ID_CLIENTE";

                string sqlAtualizarEndereco = @"UPDATE INTO TB_ENDERECO
                                                SET NM_LOGRADOURO = @NM_LOGRADOURO,
                                                    NM_BAIRRO = @NM_BAIRRO,
                                                    NM_CIDADE = @NM_CIDADE,
                                                    NM_ESTADO = @NM_ESTADO
                                                WHERE ID_ENDERECO = @ID_ENDERECO";

                try
                {

                    if (con.State == ConnectionState.Closed)
                        con.Open();

                    DynamicParameters parametrosCliente = new DynamicParameters();
                    parametrosCliente.Add("ID_CLIENTE", cliente.ClienteId, DbType.Guid, ParameterDirection.Input);
                    parametrosCliente.Add("NM_CLIENTE", cliente.Nome, DbType.String, ParameterDirection.Input);
                    parametrosCliente.Add("NU_CPF", cliente.Cpf, DbType.String, ParameterDirection.Input);
                    parametrosCliente.Add("NU_IDADE", cliente.Idade, DbType.String, ParameterDirection.Input);

                    con.Execute(sqlAtualizarCliente, param: parametrosCliente);

                    DynamicParameters parametrosEndereco = new DynamicParameters();
                    parametrosEndereco.Add("ID_ENDERECO", cliente.Endereco.EnderecoId, DbType.Guid, ParameterDirection.Input);
                    parametrosEndereco.Add("NM_LOGRADOURO", cliente.Endereco.Logradouro, DbType.String, ParameterDirection.Input);
                    parametrosEndereco.Add("NM_BAIRRO", cliente.Endereco.Bairro, DbType.String, ParameterDirection.Input);
                    parametrosEndereco.Add("NM_CIDADE", cliente.Endereco.Cidade, DbType.String, ParameterDirection.Input);
                    parametrosEndereco.Add("NM_ESTADO", cliente.Endereco.Estado, DbType.String, ParameterDirection.Input);

                    con.Execute(sqlAtualizarEndereco, param: parametrosEndereco);

                }
                catch
                {
                    throw;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }

            }
        }

        public Cliente ObterClientePorId(Guid clienteId)
        {
            using (IDbConnection con = Connection)
            {

                string sqlObterClientePorId = @"SELECT 
                                                    C.ID_CLIENTE AS ClienteId,
                                                    C.NM_CLIENTE AS Nome,
                                                    C.NU_IDADE AS Idade,
                                                    C.NU_CPF AS Cpf,
                                                    E.ID_ENDERECO AS EnderecoId,
                                                    E.NM_LOGRADOURO AS Logradouro,
                                                    E.NM_BAIRRO AS Bairro,
                                                    E.NM_CIDADE AS Cidade,
                                                    E.NM_ESTADO AS Estado
                                                FROM TB_CLIENTE AS C 
                                                INNER JOIN TB_ENDERECO AS E
                                                ON C.ID_CLIENTE = E.CD_CLIENTE
                                                WHERE
                                                    C.ID_CLIENTE = @ID_CLIENTE";

                IEnumerable<Cliente> cliente = default(IEnumerable<Cliente>);

                try
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();

                    DynamicParameters parametros = new DynamicParameters();
                    parametros.Add("ID_CLIENTE", clienteId, DbType.Guid, ParameterDirection.Input);

                    cliente = con.Query<Cliente, Endereco, Cliente>(sqlObterClientePorId, param: parametros,
                                    map: (cliente, endereco) =>
                                    {
                                        cliente.Endereco = endereco;
                                        return cliente;
                                    }, splitOn: "EnderecoId");
                }
                catch
                {
                    throw;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }

                return cliente.First();
            }
        }

        public IEnumerable<Cliente> ObterClientes()
        {
            using (IDbConnection con = Connection)
            {

                string sqlObterCliente = @"SELECT 
                                               C.ID_CLIENTE AS ClienteId,
                                               C.NM_CLIENTE AS Nome,
                                               C.NU_IDADE AS Idade,
                                               C.NU_CPF AS Cpf,
                                               E.ID_ENDERECO AS EnderecoId,
                                               E.NM_LOGRADOURO AS Logradouro,
                                               E.NM_BAIRRO AS Bairro,
                                               E.NM_CIDADE AS Cidade,
                                               E.NM_ESTADO AS Estado
                                           FROM TB_CLIENTE AS C 
                                           INNER JOIN TB_ENDERECO AS E
                                           ON C.ID_CLIENTE = E.CD_CLIENTE";

                IEnumerable<Cliente> cliente = default(IEnumerable<Cliente>);

                try
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();

                    cliente = con.Query<Cliente, Endereco, Cliente>(sqlObterCliente, 
                                    map: (cliente, endereco) =>
                                    {
                                        cliente.Endereco = endereco;
                                        return cliente;
                                    }, splitOn: "EnderecoId");


                }
                catch
                {
                    throw;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }

                return cliente;
            }
        }

        public void RemoverCliente(Guid clienteId)
        {
            using (IDbConnection con = Connection)
            {

                string sqlAtualizarCliente = @"DELETE FROM TB_CLIENTE WHERE ID_CLIENTE = @ID_CLIENTE";

                string sqlAtualizarEndereco = @"DELETE FROM TB_ENDERECO WHERE CD_CLIENTE = @ID_CLIENTE";

                try
                {

                    if (con.State == ConnectionState.Closed)
                        con.Open();

                    DynamicParameters parametros = new DynamicParameters();
                    parametros.Add("ID_CLIENTE", clienteId, DbType.Guid, ParameterDirection.Input);

                    con.Execute(sqlAtualizarEndereco, param: parametros);

                    con.Execute(sqlAtualizarCliente, param: parametros);

                }
                catch
                {
                    throw;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }

            }
        }
    }
}
