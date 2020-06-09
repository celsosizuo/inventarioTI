using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario.TIC.Class
{
    public class TermoCelularUsuarioRepository
    {
        public void Add(TermoCelularUsuarios termoUsuario)
        {
            try
            {
                SqlCommand command = new SqlCommand()
                {
                    Connection = new SqlConnection(Properties.Settings.Default.conSQL),
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "POSTTERMOCELULARUSUARIO",
                };

                command.Parameters.AddWithValue("@TermoCelularId", termoUsuario.TermoCelularId);
                command.Parameters.AddWithValue("@UsuarioId", termoUsuario.UsuarioId);
                
                if(termoUsuario.DataDevolucao == null)
                    command.Parameters.AddWithValue("@DataDevolucao", DBNull.Value);
                else
                    command.Parameters.AddWithValue("@DataDevolucao", termoUsuario.DataDevolucao);

                if(termoUsuario.Motivo == null)
                    command.Parameters.AddWithValue("@Motivo", DBNull.Value);
                else
                    command.Parameters.AddWithValue("@Motivo", termoUsuario.Motivo);

                if(termoUsuario.LinkEntrega == null)
                    command.Parameters.AddWithValue("@LinkEntrega", DBNull.Value);
                else
                    command.Parameters.AddWithValue("@LinkEntrega", termoUsuario.LinkEntrega);

                if(termoUsuario.LinkDevolucao == null)
                    command.Parameters.AddWithValue("@LinkDevolucao", DBNull.Value);
                else
                    command.Parameters.AddWithValue("@LinkDevolucao", termoUsuario.LinkDevolucao);

                command.Connection.Open();
                command.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Delete(int termoCelularId)
        {
            try
            {
                SqlCommand command = new SqlCommand()
                {
                    Connection = new SqlConnection(Properties.Settings.Default.conSQL),
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "DELETETERMOCELULARUSUARIO",
                };

                command.Parameters.AddWithValue("@TermoCelularId", termoCelularId);

                command.Connection.Open();
                command.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void PathDataDevolucao(TermoCelularUsuarios termoUsuario)
        {
            try
            {
                SqlCommand command = new SqlCommand()
                {
                    Connection = new SqlConnection(Properties.Settings.Default.conSQL),
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "PATHTERMOCELULARUSUARIO",
                };

                command.Parameters.AddWithValue("@TermoCelularId", termoUsuario.TermoCelularId);
                command.Parameters.AddWithValue("@UsuarioId", termoUsuario.UsuarioId);
                command.Parameters.AddWithValue("@DataDevolucao", termoUsuario.DataDevolucao);
                command.Parameters.AddWithValue("@Motivo", termoUsuario.Motivo);

                command.Connection.Open();
                command.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
