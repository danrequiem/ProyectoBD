using System;
using Gtk;
using MySql.Data.MySqlClient;
using Proyecto;

public partial class MainWindow: Gtk.Window
{
	private int x;
	private int y;

	public MainWindow () : base (Gtk.WindowType.Toplevel)
	{
		Build ();
		this.tabla ();
	}


	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}
	public void tabla(){
		this.eliminarElementos();
		this.encabezado();	
		this.cuerpo();
		this.Child.ShowAll();
	}

	private void eliminarElementos()
	{
		foreach (Gtk.Widget child in this.fixed2.AllChildren){ 
			if (child is Gtk.Label || child is Gtk.Button){
				this.fixed2.Remove(child);
			} 
		}
	}

	private void encabezado(){		
		this.x = 25;
		this.y = 58;
		this.etiqueta("lblID", "<span size=\"14000\" foreground=\"BLACK\" weight=\"bold\">ID</span>");
		this.x += 100;
		this.etiqueta("lblCodigo", "<span size=\"14000\" foreground=\"BLACK\" weight=\"bold\">NOMBRE</span>");
		this.x += 150;
		this.etiqueta("lblNombre", "<span size=\"14000\" foreground=\"BLACK\" weight=\"bold\"> TELEFONO</span>");
		this.x += 200;
		this.etiqueta("lblOpciones", "<span size=\"14000\" foreground=\"BLACK\" weight=\"bold\">OPCIONES</span>");
	}

	private void cuerpo()
	{
		AccionesDeRegistros acciones = new AccionesDeRegistros();
		System.Collections.ArrayList personas = acciones.obtenerTodos();
		foreach(Registros alumno in personas){
			this.x = 25;
			this.y += 40;
			this.registro(alumno);
		}
	}

	private void registro(Registros registro)
	{
		this.etiqueta("lblID_" + registro.id, "<span size=\"12000\" foreground=\"#000000\">" + registro.id + "</span>");
		this.x += 100;
		this.etiqueta("lblCodigo_" + registro.id, "<span size=\"12000\" foreground=\"#000000\">" + registro.nombre+" "+ registro.apellidoM + " "+ registro.apellidoP+ "</span>");
		this.x += 150; 
		this.etiqueta("lblNombre_" + registro.id, "<span size=\"12000\" foreground=\"#000000\">" + registro.telefono+"</span>");
		this.x += 200;
		this.opciones(registro);
	}

	private void opciones(Registros registros)
	{ 	this.boton ("btnVer_" + registros.id, "Ver", "gtk-Ver");
		this.x += 50;
		this.boton("btnEditar_" + registros.id, "Editar", "gtk-edit");
		this.x += 70;
		this.boton("btnEliminar_" + registros.id, "Eliminar", "gtk-delete");
	}
	private void boton(string nombre, string label, string imagen){
		Gtk.Button boton = new global::Gtk.Button ();
		boton.CanFocus = true;
		boton.Name = nombre;
		boton.UseUnderline = true;
		// Container child btnNuevo.Gtk.Container+ContainerChild
		global::Gtk.Alignment w1 = new global::Gtk.Alignment (0.5f, 0.5f, 0f, 0f);
		// Container child GtkAlignment.Gtk.Container+ContainerChild
		global::Gtk.HBox w2 = new global::Gtk.HBox ();
		w2.Spacing = 2;
		// Container child GtkHBox.Gtk.Container+ContainerChild
		global::Gtk.Image w3 = new global::Gtk.Image ();
		//w3.Pixbuf = global::Stetic.IconLoader.LoadIcon (this, imagen, global::Gtk.IconSize.Button);
		w2.Add (w3);
		//Container child GtkHBox.Gtk.Container+ContainerChild
		global::Gtk.Label w5 = new global::Gtk.Label ();
		w5.LabelProp = global::Mono.Unix.Catalog.GetString (label);
		w5.UseUnderline = true;
		w2.Add (w5);
		w1.Add (w2);
		boton.Add (w1);
		this.fixed2.Add (boton);
		global::Gtk.Fixed.FixedChild w9 = ((global::Gtk.Fixed.FixedChild)(this.fixed2[boton]));
		w9.X = this.x;
		w9.Y = this.y - 10;




		if (imagen == "gtk-delete") {
			boton.Clicked += new global::System.EventHandler (this.OnDeleteClicked);
		} else if (imagen == "gtk-edit") {
			boton.Clicked += new global::System.EventHandler (this.OnEditClicked);
		} else {
			boton.Clicked += new global::System.EventHandler (this.OnVerClicked);
		}

	}
	protected virtual void OnDeleteClicked (object sender, System.EventArgs e)
	{
		Gtk.Button btnDelete = (Gtk.Button) sender;
		string id = btnDelete.Name.Replace("btnEliminar_", "");
		AccionesDeRegistros accion = new AccionesDeRegistros();		
		if(accion.eliminarRegistroPorId(id)){
			MessageDialog md = new MessageDialog (null, 
				DialogFlags.Modal,
				MessageType.Info, 
				ButtonsType.None, "Accion realizada con exito.");
			md.Show();
			this.tabla();
		}else{
			MessageDialog md = new MessageDialog (null, 
				DialogFlags.Modal,
				MessageType.Error, 
				ButtonsType.None, "Ocurrio un error al tratar de eliminar. ");
			md.Show();
		}
	}

	protected virtual void OnEditClicked (object sender, System.EventArgs e)
	{
		Gtk.Button btnEdit = (Gtk.Button) sender;
		string id = btnEdit.Name.Replace("btnEditar_", "");
		Editar editar = new Editar(this, id);
		editar.Show();
	}
	protected virtual void OnVerClicked (object sender, System.EventArgs e)
	{
		Gtk.Button btnEdit = (Gtk.Button) sender;
		string id = btnEdit.Name.Replace("btnEliminar_", "");
		Editar editar = new Editar(this, id);
		editar.Show();
	}

	private void etiqueta(string nombre, string markup){
		Gtk.Label etiqueta = new global::Gtk.Label ();
		etiqueta.Name = nombre;
		etiqueta.Markup = markup;
		etiqueta.UseMarkup = true;
		this.fixed2.Add (etiqueta);
		global::Gtk.Fixed.FixedChild w11 = ((global::Gtk.Fixed.FixedChild)(this.fixed2[etiqueta]));
		w11.X = this.x;
		w11.Y = this.y;
	}


	protected void OnNuevoClicked (object sender, EventArgs e)
	{
		NuevoForm nuevo = new NuevoForm(this);
		nuevo.Show();
	}
}
