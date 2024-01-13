using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using log4net;
using Microsoft.CSharp;
using Microsoft.VisualBasic;

namespace Game.Server.Managers
{
	// Token: 0x02000004 RID: 4
	public class ScriptMgr
	{
		// Token: 0x17000001 RID: 1
		// (get) Token: 0x0600000B RID: 11 RVA: 0x0000225C File Offset: 0x0000045C
		public static Assembly[] Scripts
		{
			get
			{
				Dictionary<string, Assembly> scripts = ScriptMgr.m_scripts;
				Assembly[] result;
				lock (scripts)
				{
					result = ScriptMgr.m_scripts.Values.ToArray<Assembly>();
				}
				return result;
			}
		}

		// Token: 0x0600000C RID: 12 RVA: 0x000022A8 File Offset: 0x000004A8
		public static bool InsertAssembly(Assembly ass)
		{
			Dictionary<string, Assembly> scripts = ScriptMgr.m_scripts;
			bool result;
			lock (scripts)
			{
				if (!ScriptMgr.m_scripts.ContainsKey(ass.FullName))
				{
					ScriptMgr.m_scripts.Add(ass.FullName, ass);
					result = true;
				}
				else
				{
					result = false;
				}
			}
			return result;
		}

		// Token: 0x0600000D RID: 13 RVA: 0x0000230C File Offset: 0x0000050C
		public static bool RemoveAssembly(Assembly ass)
		{
			Dictionary<string, Assembly> scripts = ScriptMgr.m_scripts;
			bool result;
			lock (scripts)
			{
				result = ScriptMgr.m_scripts.Remove(ass.FullName);
			}
			return result;
		}

		// Token: 0x0600000E RID: 14 RVA: 0x00002358 File Offset: 0x00000558
		public static bool CompileScripts(bool compileVB, string path, string dllName, string[] asm_names)
		{
			if (!path.EndsWith("\\") && !path.EndsWith("/"))
			{
				path += "/";
			}
			ArrayList files = ScriptMgr.ParseDirectory(new DirectoryInfo(path), compileVB ? "*.vb" : "*.cs", true);
			if (files.Count != 0)
			{
				if (File.Exists(dllName))
				{
					File.Delete(dllName);
				}
				CompilerResults res = null;
				try
				{
					CodeDomProvider compiler;
					if (compileVB)
					{
						compiler = new VBCodeProvider();
					}
					else
					{
						compiler = new CSharpCodeProvider();
					}
					CompilerParameters param = new CompilerParameters(asm_names, dllName, true);
					param.GenerateExecutable = false;
					param.GenerateInMemory = false;
					param.WarningLevel = 2;
					param.CompilerOptions = "/lib:.";
					string[] filepaths = new string[files.Count];
					for (int i = 0; i < files.Count; i++)
					{
						filepaths[i] = ((FileInfo)files[i]).FullName;
					}
					res = compiler.CompileAssemblyFromFile(param, filepaths);
					GC.Collect();
					if (res.Errors.HasErrors)
					{
						foreach (object obj in res.Errors)
						{
							CompilerError err = (CompilerError)obj;
							if (!err.IsWarning)
							{
								StringBuilder builder = new StringBuilder();
								builder.Append("   ");
								builder.Append(err.FileName);
								builder.Append(" Line:");
								builder.Append(err.Line);
								builder.Append(" Col:");
								builder.Append(err.Column);
								if (ScriptMgr.log.IsErrorEnabled)
								{
									ScriptMgr.log.Error("Script compilation failed because: ");
									ScriptMgr.log.Error(err.ErrorText);
									ScriptMgr.log.Error(builder.ToString());
								}
							}
						}
						return false;
					}
				}
				catch (Exception e)
				{
					if (ScriptMgr.log.IsErrorEnabled)
					{
						ScriptMgr.log.Error("CompileScripts", e);
					}
				}
				if (res != null && !res.Errors.HasErrors)
				{
					ScriptMgr.InsertAssembly(res.CompiledAssembly);
				}
				return true;
			}
			return true;
		}

		// Token: 0x0600000F RID: 15 RVA: 0x000025C8 File Offset: 0x000007C8
		private static ArrayList ParseDirectory(DirectoryInfo path, string filter, bool deep)
		{
			ArrayList files = new ArrayList();
			ArrayList result;
			if (!path.Exists)
			{
				result = files;
			}
			else
			{
				files.AddRange(path.GetFiles(filter));
				if (deep)
				{
					foreach (DirectoryInfo subdir in path.GetDirectories())
					{
						files.AddRange(ScriptMgr.ParseDirectory(subdir, filter, deep));
					}
				}
				result = files;
			}
			return result;
		}

		// Token: 0x06000010 RID: 16 RVA: 0x00002624 File Offset: 0x00000824
		public static Type GetType(string name)
		{
			Assembly[] scripts = ScriptMgr.Scripts;
			for (int i = 0; i < scripts.Length; i++)
			{
				Type t = scripts[i].GetType(name);
				if (t != null)
				{
					return t;
				}
			}
			return null;
		}

		// Token: 0x06000011 RID: 17 RVA: 0x0000265C File Offset: 0x0000085C
		public static object CreateInstance(string name)
		{
			Assembly[] scripts = ScriptMgr.Scripts;
			for (int i = 0; i < scripts.Length; i++)
			{
				Type t = scripts[i].GetType(name);
				if (t != null && t.IsClass)
				{
					return Activator.CreateInstance(t);
				}
			}
			return null;
		}

		// Token: 0x06000012 RID: 18 RVA: 0x000026A0 File Offset: 0x000008A0
		public static object CreateInstance(string name, Type baseType)
		{
			Assembly[] scripts = ScriptMgr.Scripts;
			for (int i = 0; i < scripts.Length; i++)
			{
				Type t = scripts[i].GetType(name);
				if (t != null && t.IsClass && baseType.IsAssignableFrom(t))
				{
					return Activator.CreateInstance(t);
				}
			}
			return null;
		}

		// Token: 0x06000013 RID: 19 RVA: 0x000026F0 File Offset: 0x000008F0
		public static Type[] GetDerivedClasses(Type baseType)
		{
			Type[] result;
			if (baseType == null)
			{
				result = new Type[0];
			}
			else
			{
				ArrayList types = new ArrayList();
				foreach (object obj in new ArrayList(ScriptMgr.Scripts))
				{
					foreach (Type t in ((Assembly)obj).GetTypes())
					{
						if (t.IsClass && baseType.IsAssignableFrom(t))
						{
							types.Add(t);
						}
					}
				}
				result = (Type[])types.ToArray(typeof(Type));
			}
			return result;
		}

		// Token: 0x06000014 RID: 20 RVA: 0x000027B4 File Offset: 0x000009B4
		public static Type[] GetImplementedClasses(string baseInterface)
		{
			ArrayList types = new ArrayList();
			foreach (object obj in new ArrayList(ScriptMgr.Scripts))
			{
				foreach (Type t in ((Assembly)obj).GetTypes())
				{
					if (t.IsClass && t.GetInterface(baseInterface) != null)
					{
						types.Add(t);
					}
				}
			}
			return (Type[])types.ToArray(typeof(Type));
		}

		// Token: 0x0400000C RID: 12
		private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

		// Token: 0x0400000D RID: 13
		private static readonly Dictionary<string, Assembly> m_scripts = new Dictionary<string, Assembly>();
	}
}
