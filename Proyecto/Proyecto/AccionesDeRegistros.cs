using System;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections;

namespace Proyecto
{
	public class AccionesDeRegistros:MySQL
	{
		public AccionesDeRegistros ()
		{
		}

		public ArrayList obtenerTodos()
		{
			this.abrirConexion();
			MySqlCommand myCommand = new MySqlCommand(this.querySelect(), 
				this.myConnection);
			MySqlDataReader myReader = myCommand.ExecuteReader();	

			ArrayList personas = new ArrayList();
			while (myReader.Read()){
				Registros persona = new Registros();
				persona.id = myReader["id"].ToString();
				persona.nombre= myReader["Nombre"].ToString();
				persona.apellidoM = myReader["ApellidoM"].ToString();
				persona.apellidoP = myReader ["ApellidoP"].ToString ();
				persona.telefono = myReader ["Telefono"].ToString ();
				personas.Add(persona);
			}

			myReader.Close();
			myReader = null;
			myCommand.Dispose();
			myCommand = null;
			this.cerrarConexion();
			return personas;
		}

		public bool insertarRegistroNuevo(Registros Persona)
		{
			this.abrirConexion();
			string sql = "INSERT INTO `Project`.`Registros` (`ApellidoP`, `ApellidoM`, `Nombre`, `Domicilio`, `CP`, `Municipio`, `Estado`, `Pais`, `Mapa`, `Telefono`, `Celular`, `Radio`, `Observaciones`) " +
			             "VALUES ('" + Persona.apellidoP + "', '" + Persona.apellidoM + "', '" + Persona.nombre + "', '" + Persona.domicilio + "', '" + Persona.cp+"', '"+Persona.municipio+"', '"+Persona.estado+"', '"+Persona.pais+"', '"+Persona.mapa+"', '"+Persona.telefono+"', '"+Persona.celular+"', '"+Persona.radio+"', '"+Persona.observaciones+"'); ";
			int afectadas = this.ejecutarComando(sql);
			this.cerrarConexion();
			return (afectadas>0);
		}

		private string querySelect(){
			return "SELECT * " +
				"FROM Registros";
		}

		public bool eliminarRegistroPorId(string id)
		{
			this.abrirConexion();
			string sql = "DELETE FROM `Registros` WHERE (`id`='" + id + "')";
			int afectadas = this.ejecutarComando(sql);
			this.cerrarConexion();
			return (afectadas>0);
		}

		public bool existeCodigo(string codigo)
		{
			this.abrirConexion();
			MySqlCommand myCommand = new MySqlCommand("SELECT * FROM Registros WHERE Id = '"+codigo+"'", 
				this.myConnection);
			MySqlDataReader myReader = myCommand.ExecuteReader();	
			return myReader.HasRows;
		}

		private int ejecutarComando(string sql)
		{
			MySqlCommand myCommand = new MySqlCommand(sql,this.myConnection);
			int afectadas = myCommand.ExecuteNonQuery();
			myCommand.Dispose();
			myCommand = null;
			return afectadas;
		}

		public bool editarCodigoYNombreDeRegistro(Registros Persona)
		{
			this.abrirConexion();
			string sql = "UPDATE `Project`.`Registros` SET `ApellidoP`='"+Persona.apellidoP+"', `ApellidoM`='"+Persona.apellidoM+"', " +
			             "`Nombre`='"+Persona.nombre+"', `Domicilio`='"+Persona.domicilio+"', `CP`='"+Persona.cp+"', `Municipio`='"+Persona.municipio+"', " +
			             "`Estado`='"+Persona.estado+"', `Pais`='"+Persona.pais+"', `Mapa`='"+Persona.mapa+"', `Telefono`='"+Persona.telefono+"', " +
			             "`Celular`='"+Persona.celular+"', `Radio`='"+Persona.radio+"',`Observaciones`= '"+Persona.observaciones+"'  WHERE `Id`='"+Persona.id+"'";
			int afectadas = this.ejecutarComando(sql);
			this.cerrarConexion();
			return (afectadas>0);
		}
		public Registros obtenerPorId(string id)
		{
			this.abrirConexion();
			MySqlCommand myCommand = new MySqlCommand("SELECT * FROM Registros WHERE id = '"+id+"'", 
				this.myConnection);
			MySqlDataReader myReader = myCommand.ExecuteReader();	
			Registros  persona = new Registros();
			if(myReader.HasRows){
				myReader.Read();

				persona.id = myReader["id"].ToString();
				persona.nombre= myReader["Nombre"].ToString();
				persona.apellidoM = myReader["ApellidoM"].ToString();
				persona.apellidoP = myReader ["ApellidoP"].ToString ();
				persona.domicilio = myReader["Domicilio"].ToString();
				persona.cp = myReader ["CP"].ToString ();
				persona.municipio = myReader["Municipio"].ToString();
				persona.estado = myReader ["Estado"].ToString ();
				persona.pais = myReader["Pais"].ToString();
				persona.mapa = myReader ["Mapa"].ToString ();
				persona.telefono = myReader ["Telefono"].ToString ();
				persona.celular = myReader ["Celular"].ToString ();		
				persona.radio = myReader ["Radio"].ToString ();
				persona.observaciones = myReader ["Observaciones"].ToString ();	

			}
			myReader.Close();
			myReader = null;
			myCommand.Dispose();
			myCommand = null;
			this.cerrarConexion();
			return persona;
		}


	}
}

