using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace Project
{
	public class Mysql
	{
		protected  MySqlConnection myConnection;
		public Mysql ()
		{
		}

		protected void abrirConexion(){
			string connectionString =
				"Server=localhost;" +
				"Database=Alumnos;" +
				"User ID=root;" +
				"Password=root;" +
				"Pooling=false";
			this.myConnection = new MySqlConnection(connectionString);
			this.myConnection.Open ();


		}
		protected void cerrarConexion()
		{
			this.myConnection.Close ();
			this.myConnection= null;

		}


	}
}

