
// This file has been generated by the GUI designer. Do not modify.
namespace MonoDevelop.D
{
	public partial class ProjectIncludesWidget
	{
		private global::Gtk.VBox vbox7;
		private global::Gtk.Table table2;
		private global::Gtk.ScrolledWindow GtkScrolledWindow1;
		private global::Gtk.TextView text_Includes;
		private global::Gtk.Label label14;
		private global::Gtk.Table table3;
		private global::Gtk.Button button_AddInclude;

		protected virtual void Build ()
		{
			global::Stetic.Gui.Initialize (this);
			// Widget MonoDevelop.D.ProjectIncludesWidget
			global::Stetic.BinContainer.Attach (this);
			this.Name = "MonoDevelop.D.ProjectIncludesWidget";
			// Container child MonoDevelop.D.ProjectIncludesWidget.Gtk.Container+ContainerChild
			this.vbox7 = new global::Gtk.VBox ();
			this.vbox7.Name = "vbox7";
			this.vbox7.Spacing = 6;
			this.vbox7.BorderWidth = ((uint)(3));
			// Container child vbox7.Gtk.Box+BoxChild
			this.table2 = new global::Gtk.Table (((uint)(2)), ((uint)(2)), false);
			this.table2.Name = "table2";
			this.table2.RowSpacing = ((uint)(6));
			this.table2.ColumnSpacing = ((uint)(6));
			// Container child table2.Gtk.Table+TableChild
			this.GtkScrolledWindow1 = new global::Gtk.ScrolledWindow ();
			global::Gtk.Tooltips w1 = new Gtk.Tooltips ();
			w1.SetTip (this.GtkScrolledWindow1, "Line-separated list of paths where the compiler (and the code completion engine!) shall look in to resolve imports.", "Line-separated list of paths where the compiler (and the code completion engine!) shall look in to resolve imports.");
			this.GtkScrolledWindow1.Name = "GtkScrolledWindow1";
			this.GtkScrolledWindow1.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child GtkScrolledWindow1.Gtk.Container+ContainerChild
			this.text_Includes = new global::Gtk.TextView ();
			this.text_Includes.CanFocus = true;
			this.text_Includes.Name = "text_Includes";
			this.GtkScrolledWindow1.Add (this.text_Includes);
			this.table2.Add (this.GtkScrolledWindow1);
			global::Gtk.Table.TableChild w3 = ((global::Gtk.Table.TableChild)(this.table2 [this.GtkScrolledWindow1]));
			w3.TopAttach = ((uint)(1));
			w3.BottomAttach = ((uint)(2));
			w3.XOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table2.Gtk.Table+TableChild
			this.label14 = new global::Gtk.Label ();
			this.label14.Name = "label14";
			this.label14.Xalign = 0F;
			this.label14.LabelProp = global::MonoDevelop.Core.GettextCatalog.GetString ("Note: Relative paths will be related to the project's base directory!");
			this.table2.Add (this.label14);
			global::Gtk.Table.TableChild w4 = ((global::Gtk.Table.TableChild)(this.table2 [this.label14]));
			w4.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table2.Gtk.Table+TableChild
			this.table3 = new global::Gtk.Table (((uint)(2)), ((uint)(1)), false);
			this.table3.Name = "table3";
			this.table3.RowSpacing = ((uint)(6));
			this.table3.ColumnSpacing = ((uint)(6));
			// Container child table3.Gtk.Table+TableChild
			this.button_AddInclude = new global::Gtk.Button ();
			this.button_AddInclude.CanFocus = true;
			this.button_AddInclude.Name = "button_AddInclude";
			this.button_AddInclude.UseUnderline = true;
			this.button_AddInclude.Label = global::MonoDevelop.Core.GettextCatalog.GetString ("Browse & Add");
			this.table3.Add (this.button_AddInclude);
			global::Gtk.Table.TableChild w5 = ((global::Gtk.Table.TableChild)(this.table3 [this.button_AddInclude]));
			w5.XOptions = ((global::Gtk.AttachOptions)(4));
			w5.YOptions = ((global::Gtk.AttachOptions)(4));
			this.table2.Add (this.table3);
			global::Gtk.Table.TableChild w6 = ((global::Gtk.Table.TableChild)(this.table2 [this.table3]));
			w6.TopAttach = ((uint)(1));
			w6.BottomAttach = ((uint)(2));
			w6.LeftAttach = ((uint)(1));
			w6.RightAttach = ((uint)(2));
			w6.XOptions = ((global::Gtk.AttachOptions)(4));
			this.vbox7.Add (this.table2);
			global::Gtk.Box.BoxChild w7 = ((global::Gtk.Box.BoxChild)(this.vbox7 [this.table2]));
			w7.Position = 0;
			this.Add (this.vbox7);
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
			this.Show ();
			this.button_AddInclude.Clicked += new global::System.EventHandler (this.OnButtonAddIncludeClicked);
		}
	}
}
