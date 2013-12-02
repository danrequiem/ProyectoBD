using System;
using Gtk;
using System.Web;
using System.Net.Mail;

namespace Proyecto
{
	public partial class Mail: Gtk.Window
	{
		private MainWindow padre;

		public Mail (MainWindow padre) : base(Gtk.WindowType.Toplevel)
		{
			this.Build ();
			this.padre = padre;
		}
	}
}