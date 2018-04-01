

namespace EJ4_ParcialFinal_WPF
{
    using System;
    using System.Collections.ObjectModel;
    using System.Data;
    using System.Data.SqlClient;

    public class DBControler
    {
        #region Variables
        private SqlDataReader datareader;
        private SqlTransaction transaction;
        private SqlConnection connection;
        private SqlCommand command;
        private string stringConnection = Properties.Settings.Default.Connection;
        #endregion

        public Contact getContact(int id)
        {
            connection = new SqlConnection(stringConnection);
            command = new SqlCommand("SELECT * FROM Contactos WHERE Id = @p1", connection);
            command.Parameters.AddWithValue("@p1", id);
            command.CommandType = CommandType.Text;

            try 
            {
                connection.Open(); 
                datareader = command.ExecuteReader(CommandBehavior.SingleRow);

                if (datareader.Read()) 
                {
                   
                    Contact contactoEncontrado =
                        new Contact((int)datareader["Id"], (string)datareader["Nombres"], (string)datareader["Apellidos"],
                            (string)datareader["Telefono"], (string)datareader["Direccion"]);

                    return contactoEncontrado; 
                }
                else 
                {
                    return null; 
                }

            }
            catch (Exception ex)
            {
                throw ex; 
            }
            finally 
            {
                connection.Close();
            }

        }
        #region Methods
        // Bringing all our contacts fron DB
        public ObservableCollection<Contact> getContacts()
        {
            connection = new SqlConnection(stringConnection);
            command = new SqlCommand("SELECT * FROM Contactos", connection);
            command.CommandType = CommandType.Text;
            ObservableCollection<Contact> ContactList =
                new ObservableCollection<Contact>();

            try 
            {
                connection.Open(); 
                datareader = command.ExecuteReader();

                while (datareader.Read()) 
                {
                    string temp = datareader["Direccion"] as string ?? "[NOT SPECIFIED ADDRESS]";
                    Contact selected =
                        new Contact((int)datareader["Id"], (string)datareader["Nombres"], (string)datareader["Apellidos"],
                            (string)datareader["Telefono"], temp);
                    ContactList.Add(selected);
                }
            }
            catch (Exception ex)
            {
                throw ex; 
            }
            finally
            {
                connection.Close(); 
            }

            return ContactList; 
        }

        // Saving new contact
        public int Save(Contact contact)
        {
            connection = new SqlConnection(stringConnection);
            command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = CommandType.Text;
            command.CommandText = "INSERT Contactos (Nombres, Apellidos, Telefono, Direccion) " +
                "VALUES (@p1,@p2,@p3,@p4);" +
                "SELECT Scope_Identity()";
            command.Parameters.AddWithValue("@p1", contact.Names);
            command.Parameters.AddWithValue("@p2", contact.LastNames);
            command.Parameters.AddWithValue("@p3", contact.Phone);
            command.Parameters.AddWithValue("@p4", contact.Address);

            int aux = 0; 

            try
            {
                connection.Open();
                transaction = connection.BeginTransaction();
                command.Transaction = transaction;
                aux = (int)((decimal)command.ExecuteScalar());
                transaction.Commit();
            }
            catch (Exception ex)
            {
                if (transaction != null)
                {
                    transaction.Rollback();          
                }
                throw ex;
            }
            finally
            {
                connection.Close();
            }

            return aux;
        }

        //Updating our contact
        public int Update(int id, string names, string lastN, string phone,
            string address)
        {
            connection = new SqlConnection(stringConnection);
            command = new SqlCommand
            ("UPDATE Contactos " +
            "SET Nombres = @p1, Apellidos = @p2, Telefono = @p3, Direccion = @p4 " +
            "WHERE Id = @p0", connection);

            command.CommandType = CommandType.Text;

            command.Parameters.AddWithValue("@p0", id);
            command.Parameters.AddWithValue("@p1", names);
            command.Parameters.AddWithValue("@p2", lastN);
            command.Parameters.AddWithValue("@p3", phone);
            command.Parameters.AddWithValue("@p4", address);

            try
            {
                connection.Open();
                return command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
        }
        public int Erase(int id)
        {
            connection = new SqlConnection(stringConnection);
            command = new SqlCommand("DELETE FROM Contactos WHERE Id = @p0", connection);
            command.CommandType = CommandType.Text;
            command.Parameters.AddWithValue("@p0", id);

            try
            {
                connection.Open();
                return command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
        }
        #endregion
    }
}
