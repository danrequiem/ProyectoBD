using System;
using Gtk;
namespace Proyecto
{
	public partial class Editar : Gtk.Window
	{
		private MainWindow padre;
		private string id;
		private  Registros Persona;

		public Editar (MainWindow padre, string id) : base(Gtk.WindowType.Toplevel)
		{
			this.Build ();
			this.padre = padre;
			this.id = id;
			this.cargaAlumno();
			this.cargaDatos();
		}

		private void cargaAlumno(){
			AccionesDeRegistros acciones = new AccionesDeRegistros();
			this.Persona = acciones.obtenerPorId(this.id);
			if(this.Persona.id == ""){
				throw new Exception("El alumno no existe.");
			}
		}

		private void cargaDatos(){	

			this.Title = "Editar registro con ID " + this.Persona.id;
			this.txtApellidoM.Text = this.Persona.apellidoM;
			this.txtApellidoP.Text = this.Persona.apellidoP;
			this.txtNombre.Text = this.Persona.nombre;
			this.txtDomicilio.Text = this.Persona.domicilio;
			this.txtCP.Text = this.Persona.cp;
			this.txtMun.Text = this.Persona.municipio;
			this.txtEstado.Text = this.Persona.estado;
			this.Persona.pais = this.txtPais.Active.ToString ();
			this.txtMail.Text = this.Persona.mapa;
			this.txtTel.Text = this.Persona.telefono;
			this.txtCel.Text = this.Persona.celular;
			this.txtRadio.Text = this.Persona.radio;
			this.txtObs.Text = this.Persona.observaciones;


		}

		private void validaciones(){
			try{

				if(!this.validarNoVacio()){
					throw new Exception("Uno de los campos esta vacio.");
				}

				if(!this.validarTamano()){
					throw new Exception("La longitd de los datos no es valida.");
				}


			}catch(Exception e){
				MessageDialog md = new MessageDialog (
					null, 
					DialogFlags.Modal,
					MessageType.Error, 
					ButtonsType.None, "Ocurrio un error: " + e.Message
				);
				md.Show();
			}
		}

		private bool validarNoVacio(){
			return 
				(this.txtApellidoP.Text.Trim() != "" && this.txtNombre.Text.Trim() != "");
		}

		private bool validarTamano(){
			return 
				(this.txtApellidoP.Text.Length <= 10 && this.txtNombre.Text.Length <= 256);
		}
		protected virtual void OnButton2Clicked (object sender, System.EventArgs e)
		{
			this.validaciones();
			this.editarRegistro();
		}
		private void editarRegistro(){

			AccionesDeRegistros acciones = new AccionesDeRegistros();
			this.Persona.nombre = this.txtNombre.Text.Trim();
			this.Persona.apellidoM = this.txtApellidoM.Text.Trim();
			this.Persona.apellidoP = this.txtApellidoP.Text.Trim ();
			this.Persona.domicilio = this.txtDomicilio.Text.Trim ();
			this.Persona.municipio = this.Entry.Text.Trim ();
			this.Persona.estado = this.txtEstado.Text.Trim ();
			this.Persona.pais = this.txtPais.Active.ToString ();
			this.Persona.mapa = this.txtMail.Text.Trim ();
			this.Persona.telefono = this.txtTel.Text.Trim ();
			this.Persona.celular  = this.txtCel.Text.Trim ();
			this.Persona.radio = this.txtRadio.Text.Trim ();
			this.Persona.observaciones = this.txtObs.Text.Trim ();

			bool editado = acciones.editarCodigoYNombreDeRegistro(Persona);

			if(editado){
				MessageDialog md = new MessageDialog (null, 
					DialogFlags.Modal,
					MessageType.Info, 
					ButtonsType.None, "Acción realizada con exito." );
				md.Show();
				this.Persona.nombre = this.txtNombre.Text.Trim();
				this.Persona.apellidoM = this.txtApellidoM.Text.Trim();
				this.Persona.apellidoP = this.txtApellidoP.Text.Trim ();
				this.padre.tabla();
			}else{
				MessageDialog md = new MessageDialog (null, 
					DialogFlags.Modal,
					MessageType.Error, 
					ButtonsType.None, "Ocurrio un error al editar." );
				md.Show();
			}
		}

	}
}

