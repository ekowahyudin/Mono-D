
// This file has been generated by the GUI designer. Do not modify.
namespace MonoDevelop.D.OptionPanels
{
	public partial class DubOptionPanel
	{
		private global::Gtk.Table table1;
		private global::Gtk.Label label1;
		private global::Gtk.Label label2;
		private global::Gtk.Entry text_commonArgs;
		private global::Gtk.Entry text_dub;

		protected virtual void Build ()
		{
			global::Stetic.Gui.Initialize (this);
			// Widget MonoDevelop.D.OptionPanels.DubOptionPanel
			global::Stetic.BinContainer.Attach (this);
			this.Name = "MonoDevelop.D.OptionPanels.DubOptionPanel";
			// Container child MonoDevelop.D.OptionPanels.DubOptionPanel.Gtk.Container+ContainerChild
			this.table1 = new global::Gtk.Table (((uint)(3)), ((uint)(2)), false);
			this.table1.Name = "table1";
			this.table1.RowSpacing = ((uint)(6));
			this.table1.ColumnSpacing = ((uint)(6));
			// Container child table1.Gtk.Table+TableChild
			this.label1 = new global::Gtk.Label ();
			this.label1.Name = "label1";
			this.label1.LabelProp = global::MonoDevelop.Core.GettextCatalog.GetString ("dub executable");
			this.table1.Add (this.label1);
			global::Gtk.Table.TableChild w1 = ((global::Gtk.Table.TableChild)(this.table1 [this.label1]));
			w1.XOptions = ((global::Gtk.AttachOptions)(4));
			w1.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.label2 = new global::Gtk.Label ();
			this.label2.Name = "label2";
			this.label2.LabelProp = global::MonoDevelop.Core.GettextCatalog.GetString ("Generic dub arguments");
			this.table1.Add (this.label2);
			global::Gtk.Table.TableChild w2 = ((global::Gtk.Table.TableChild)(this.table1 [this.label2]));
			w2.TopAttach = ((uint)(1));
			w2.BottomAttach = ((uint)(2));
			w2.XOptions = ((global::Gtk.AttachOptions)(4));
			w2.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.text_commonArgs = new global::Gtk.Entry ();
			this.text_commonArgs.CanFocus = true;
			this.text_commonArgs.Name = "text_commonArgs";
			this.text_commonArgs.IsEditable = true;
			this.text_commonArgs.InvisibleChar = '•';
			this.table1.Add (this.text_commonArgs);
			global::Gtk.Table.TableChild w3 = ((global::Gtk.Table.TableChild)(this.table1 [this.text_commonArgs]));
			w3.TopAttach = ((uint)(1));
			w3.BottomAttach = ((uint)(2));
			w3.LeftAttach = ((uint)(1));
			w3.RightAttach = ((uint)(2));
			w3.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.text_dub = new global::Gtk.Entry ();
			this.text_dub.CanFocus = true;
			this.text_dub.Name = "text_dub";
			this.text_dub.IsEditable = true;
			this.text_dub.InvisibleChar = '•';
			this.table1.Add (this.text_dub);
			global::Gtk.Table.TableChild w4 = ((global::Gtk.Table.TableChild)(this.table1 [this.text_dub]));
			w4.LeftAttach = ((uint)(1));
			w4.RightAttach = ((uint)(2));
			w4.YOptions = ((global::Gtk.AttachOptions)(4));
			this.Add (this.table1);
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
			this.Hide ();
		}
	}
}
