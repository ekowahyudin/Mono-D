using MonoDevelop.Core.Serialization;
using System.Collections.Generic;
using D_Parser.Completion;
using System.Collections.ObjectModel;
using System;

namespace MonoDevelop.D.Building
{
	/// <summary>
	/// Stores compiler commands and arguments for compiling and linking D source files.
	/// </summary>
	public class DCompilerConfiguration
	{
		/// <summary>
		/// Initializes all commands and arguments (also debug&amp;release args!) with default values depending on given target compiler type
		/// </summary>
		public static DCompilerConfiguration CreateWithDefaults(DCompilerVendor Compiler)
		{
			var cfg = new DCompilerConfiguration {  Vendor=Compiler };

			CompilerDefaultArgumentProvider cmp = null;
			switch (Compiler)
			{
				case DCompilerVendor.DMD:
					cmp = new Dmd(cfg);
					break;
				case DCompilerVendor.GDC:
					cmp = new Gdc(cfg);
					break;
				case DCompilerVendor.LDC:
					cmp = new Ldc(cfg);
					break;
			}

			// Reset arguments BEFORE reset compiler commands - only then, the 4 link target config objects will be created.
			cmp.ResetBuildArguments();
			cmp.ResetCompilerConfiguration();

			return cfg;
		}

		public readonly ASTStorage GlobalParseCache = new ASTStorage();

		public DCompilerVendor Vendor;

		protected List<LinkTargetConfiguration> LinkTargetConfigurations = new List<LinkTargetConfiguration>();

		public LinkTargetConfiguration GetTargetConfiguration(DCompileTarget Target)
		{
			foreach (var t in LinkTargetConfigurations)
				if (t.TargetType == Target)
					return t;

			var newTarget = new LinkTargetConfiguration { TargetType=Target };
			LinkTargetConfigurations.Add(newTarget);
			return newTarget;
		}

		public void SetAllCompilerBuildArgs(string NewCompilerArguments, bool AffectDebugArguments)
		{
			foreach (var t in LinkTargetConfigurations)
				t.GetArguments(AffectDebugArguments).CompilerArguments=NewCompilerArguments;
		}

		/// <summary>
		/// Overrides all compiler command strings of all LinkTargetConfigurations
		/// </summary>
		public void SetAllCompilerCommands(string NewCompilerPath)
		{
			foreach (var t in LinkTargetConfigurations)
				t.Compiler = NewCompilerPath;
		}

		public void SetAllLinkerCommands(string NewLinkerPath)
		{
			foreach (var t in LinkTargetConfigurations)
				t.Linker= NewLinkerPath;
		}
		
		/*
		 * Do not add default library paths, 
		 * because it would make building the argument strings more complicated 
		 * - there had to be compiler-specific composers 
		 * which created the lib path chain then 
		 * - for each single compiler/linker!
		 */
		/*
		public List<string> DefaultLibPaths=new List<string>();
		*/
		public List<string> DefaultLibraries = new List<string>();

		#region Loading & Saving
		public void ReadFrom(System.Xml.XmlReader x)
		{
			while(x.Read())
				switch (x.LocalName)
				{
					case "TargetConfiguration":
						var s2 = x.ReadSubtree();
						var t = new LinkTargetConfiguration();
						t.LoadFrom(s2);
						LinkTargetConfigurations.Add(t);
						break;

					case "DefaultLibs":
						var s = x.ReadSubtree();
						while (s.Read())
							if (s.LocalName == "lib")
								DefaultLibraries.Add(s.ReadString());
						break;
				}
		}

		public void SaveTo(System.Xml.XmlWriter x)
		{
			foreach (var t in LinkTargetConfigurations)
			{
				x.WriteStartElement("TargetConfiguration");

				t.SaveTo(x);

				x.WriteEndElement();
			}

			x.WriteStartElement("DefaultLibs");
			foreach (var lib in DefaultLibraries)
			{
				x.WriteStartElement("lib");
				x.WriteCData(lib);
				x.WriteEndElement();
			}
			x.WriteEndElement();
		}
		#endregion
	}

	public class LinkTargetConfiguration
	{
		public DCompileTarget TargetType;

		public string Compiler;
		public string Linker;

		#region Patterns
		/// <summary>
		/// Describes how each .obj/.o file shall be enumerated in the $objs linking macro
		/// </summary>
		public string ObjectFileLinkPattern = "\"{0}\"";
		/// <summary>
		/// Describes how each include path shall be enumerated in the $includes compiling macro
		/// </summary>
		public string IncludePathPattern = "-I\"{0}\"";
		#endregion

		public BuildConfiguration DebugArguments = new BuildConfiguration();
		public BuildConfiguration ReleaseArguments = new BuildConfiguration();

		public BuildConfiguration GetArguments(bool IsDebug)
		{
			return IsDebug ? DebugArguments : ReleaseArguments;
		}

		public void SaveTo(System.Xml.XmlWriter x)
		{
			x.WriteAttributeString("Target",TargetType.ToString());

			x.WriteStartElement("Compiler");
			x.WriteCData(Compiler);
			x.WriteEndElement();

			x.WriteStartElement("Linker");
			x.WriteCData(Linker);
			x.WriteEndElement();

			x.WriteStartElement("ObjectLinkPattern");
			x.WriteCData(ObjectFileLinkPattern);
			x.WriteEndElement();

			x.WriteStartElement("IncludePathPattern");
			x.WriteCData(IncludePathPattern);
			x.WriteEndElement();

			x.WriteStartElement("DebugArgs");
			DebugArguments.SaveTo(x);
			x.WriteEndElement();

			x.WriteStartElement("ReleaseArgs");
			ReleaseArguments.SaveTo(x);
			x.WriteEndElement();
		}

		public void LoadFrom(System.Xml.XmlReader x)
		{
			if (x.MoveToAttribute("Target"))
				TargetType = (DCompileTarget)Enum.Parse(typeof(DCompileTarget), x.ReadContentAsString());

			while(x.Read())
				switch (x.LocalName)
				{
					case "Compiler":
						Compiler = x.ReadString();
						break;
					case "Linker":
						Linker = x.ReadString();
						break;
					case "ObjectLinkPattern":
						ObjectFileLinkPattern = x.ReadString();
						break;
					case "IncludePathPattern":
						IncludePathPattern = x.ReadString();
						break;

					case "DebugArgs":
						var s = x.ReadSubtree();
						DebugArguments.ReadFrom(s);
						break;

					case "ReleaseArgs":
						var s2 = x.ReadSubtree();
						ReleaseArguments.ReadFrom(s2);
						break;
				}
		}
	}

	public class BuildConfiguration
	{
		public string CompilerArguments;
		public string LinkerArguments;

		public void SaveTo(System.Xml.XmlWriter x)
		{
			x.WriteStartElement("CompilerArg");
			x.WriteCData(CompilerArguments);
			x.WriteEndElement();

			x.WriteStartElement("LinkerArgs");
			x.WriteCData(LinkerArguments);
			x.WriteEndElement();
		}

		public void ReadFrom(System.Xml.XmlReader x)
		{
			while(x.Read())
				switch (x.LocalName)
				{
					case "CompilerArg":
						CompilerArguments = x.ReadString();
						break;
					case "LinkerArg":
						LinkerArguments = x.ReadString();
						break;
				}
		}
	}
}

