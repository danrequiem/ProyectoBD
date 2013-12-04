using System;
using Gtk;

namespace Proyecto
{
	public partial class NuevoForm : Gtk.Window
	{
		private MainWindow padre;
		public NuevoForm (MainWindow padre) : base(Gtk.WindowType.Toplevel)
		{
			this.Build ();
			this.padre = padre;
		}

		private void validaciones(){
			try{


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
				(this.txtNombre.Text.Trim() != "" && this.txtApellidoM.Text.Trim() != "" && this.txtApellidoP.Text.Trim() != "" &&
					this.txtDomicilio.Text.Trim()!= "" && this.txtMun.Text.Trim()!= "" && this.txtEst.Text.Trim()!= "" && this.txtPais.Active.ToString ()!= "" &&
					this.txtCp.Text.Trim()!= "" && this.txtTel1.Text.Trim()!= "" && this.txtCelular.Text.Trim()!= "" && this.txtRadio.Text.Trim()!= "" &&
					this.txtObs.Text.Trim()!= "" && this.txtMail.Text.Trim() != "" );
		}

		private void insertarNuevo()
		{
			if (!this.validarNoVacio ()) {

				MessageDialog md = new MessageDialog (
					null, 
					DialogFlags.Modal,
					MessageType.Error, 
					ButtonsType.None, "Ocurrio un error: " + "Campos vacios" 
				);
				md.Show ();
			} else {
				AccionesDeRegistros acciones = new AccionesDeRegistros ();
				Registros Persona = new Registros ();

				Persona.apellidoP = txtApellidoP.Text;
				Persona.apellidoM = txtApellidoM.Text;
				Persona.nombre = txtNombre.Text;
				Persona.domicilio = txtDomicilio.Text;
				Persona.cp = txtCp.Text;
				Persona.municipio = txtMun.Text;
				Persona.estado = txtEst.Text;
				Persona.pais = txtPais.ActiveText.ToString ();
				Persona.mapa = txtMail.Text;
				Persona.telefono = txtTel1.Text;
				Persona.celular = txtCelular.Text;
				Persona.radio = txtRadio.Text;
				Persona.observaciones = txtObs.Text;

				if (acciones.insertarRegistroNuevo (Persona, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))) {
					MessageDialog md = new MessageDialog (null, 
						DialogFlags.Modal,
						MessageType.Info, 
						ButtonsType.None, "Acción realizada con exito.");
					md.Show ();
					this.txtNombre.Text = "";
					this.txtApellidoM.Text = "";
					this.txtApellidoP.Text = "";
					this.txtDomicilio.Text = "";
					this.txtCp.Text = "";
					this.txtMail.Text = "";
					this.txtMun.Text= "";
					this.txtEst.Text = "";
					this.txtTel1.Text= "";
					this.txtCelular.Text= "";
					this.txtRadio.Text= "";
					this.txtObs.Text= "";

					this.padre.tabla ();
				} else {
					MessageDialog md = new MessageDialog (
						null, 
						DialogFlags.Modal,
						MessageType.Error, 
						ButtonsType.None, "Ocurrio un error: "
					);
					md.Show ();

				}
			}

		}


		protected void OnGuardarClicked (object sender, EventArgs e)
		{
			this.validaciones ();
			this.insertarNuevo ();
		}
	}
}

