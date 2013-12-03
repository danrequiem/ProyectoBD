using System;
using System.Web;
using System.Net.Mail;
using Gtk;

namespace Proyecto
{
	public partial class mailForm : Gtk.Window
	{
		 

		private MainWindow padre;
		private string id;
		private  Registros Persona;

		public mailForm (MainWindow padrem , string id) : base(Gtk.WindowType.Toplevel)
		{
			this.Build ();
			this.padre = padre;
			this.id = id;
			this.cargaAlumno();
			this.cargaDatos();
			Para.Sensitive = false;


		}

		protected void OnEnviarClicked (object sender, EventArgs e)
		{

			SmtpClient client = new SmtpClient ("smtp.gmail.com");
			client.Port = 587;
			client.EnableSsl = true;
			client.DeliveryMethod = SmtpDeliveryMethod.Network;
			client.UseDefaultCredentials = false;
			client.Credentials = new System.Net.NetworkCredential("dgarciaverdin@gmail.com", "abcjpr_f4e");
			MailMessage mail = new MailMessage ();
			mail.To.Add (Para.Text);
			mail.From = new MailAddress ("dgarciaverdin@gmail.com");
			mail.Subject = Asunto.Text;
			mail.Body = Body.Text;      
			client.Send (mail);
			MessageDialog md = new MessageDialog (
				null, 
				DialogFlags.Modal,
				MessageType.Error, 
				ButtonsType.None, "Se envio con exito"
			);
			md.Show ();

		}
		private void cargaAlumno(){
			AccionesDeRegistros acciones = new AccionesDeRegistros();
			this.Persona = acciones.obtenerPorId(this.id);
			if(this.Persona.id == ""){
				throw new Exception("El alumno no existe.");
			}
		}

		private void cargaDatos(){


			this.Title = "Enviar mail al registro con ID " + this.Persona.id;
			Para.Text = this.Persona.mapa;

		}


	}
}

