using System;
using MySql.Data.MySqlClient;
using System.Data;
namespace Proyecto
{
	public class MySQL
	{
		protected MySqlConnection myConnection;
		public MySQL ()
		{
		}

		protected void abrirConexion(){
			string connectionString =
				"Server=localhost;" +
				"Database=Project;" +
				"User ID=root;" +
				"Password=root;" +
				"Pooling=false;";
			this.myConnection = new MySqlConnection(connectionString);
			this.myConnection.Open();
		}

		protected void cerrarConexion(){
			this.myConnection.Close(); 
			this.myConnection = null;
		}
	}
}

