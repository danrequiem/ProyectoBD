using System;
using System.Web;
using System.Net.Mail;
using Gtk;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;

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

			try{
				MailMessage mail = new MailMessage();
				SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
				mail.From = new MailAddress("dgarciaverdin@gmail.com");
				mail.To.Add(Para.Text);
				mail.Subject =  Asunto.Text;
				mail.Body = Body.Text;
				SmtpServer.Port = 587;
				SmtpServer.Credentials = new System.Net.NetworkCredential("dgarciaverdin", "abcjpr_f4e");
				SmtpServer.EnableSsl = true;
				ServicePointManager.ServerCertificateValidationCallback = delegate(object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };
				SmtpServer.Send(mail);

				MessageDialog md = new MessageDialog (null, 
					DialogFlags.Modal,
					MessageType.Info,
					ButtonsType.None, "Mail enviado correctamente");
				md.Show();
				this.padre.tabla();

		
			}
			catch(Exception Msg){

				MessageDialog md = new MessageDialog (null, 
					DialogFlags.Modal,
					MessageType.Error, 
					ButtonsType.None, "Ouch"+ Msg.ToString() );
				md.Show();
			}

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

