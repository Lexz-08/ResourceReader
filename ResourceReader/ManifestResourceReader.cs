using System.IO;
using System.Reflection;

namespace ResourceReader
{
	public static class ManifestResourceReader
	{
		/// <summary>
		/// Reads an embedded resource as a string.
		/// </summary>
		/// <param name="ResourceAssembly">The assembly containing the embedded resource.</param>
		/// <param name="Resource">The embedded resource to read.</param>
		/// <returns>Bytes of the embedded resource converted to a string of text.</returns>
		public static string ReadString(Assembly ResourceAssembly, string Resource)
		{
			string value = string.Empty;

			using (Stream s = ResourceAssembly.GetManifestResourceStream(Resource))
			{
				if (s == null)
					return value;

				byte[] buffer = new byte[s.Length];
				s.Read(buffer, 0, buffer.Length);

				foreach (byte char_ in buffer)
					value += (char)char_;

				s.Close();
			}

			return value;
		}

		/// <summary>
		/// Reads an embedded resource as a byte array.
		/// </summary>
		/// <param name="ResourceAssembly">The assembly containing the embedded resource.</param>
		/// <param name="Resource">The embedded resource to read.</param>
		/// <returns>Bytes of the embedded resource.</returns>
		public static byte[] ReadBytes(Assembly ResourceAssembly, string Resource)
		{
			byte[] value = new byte[ResourceAssembly.GetManifestResourceStream(Resource) != null ? ResourceAssembly.GetManifestResourceStream(Resource).Length : 0];

			using (Stream s = ResourceAssembly.GetManifestResourceStream(Resource))
			{
				if (s == null)
					return value;

				s.Read(value, 0, value.Length);

				s.Close();
			}

			return value;
		}

		/// <summary>
		/// Reads an embedded resource as an assembly.
		/// </summary>
		/// <param name="ResourceAssembly">The assembly containing the embedded resource.</param>
		/// <param name="Resource">The embedded resource to read.</param>
		/// <returns>Bytes of the embedded resource loaded into an assembly.</returns>
		public static Assembly ReadAssembly(Assembly ResourceAssembly, string Resource)
		{
			Assembly asm = null;

			using (Stream s = ResourceAssembly.GetManifestResourceStream(Resource))
			{
				if (s == null)
					return asm;

				byte[] buffer = new byte[s.Length];
				s.Read(buffer, 0, buffer.Length);

				asm = Assembly.Load(buffer);

				s.Close();
			}

			return asm;
		}

		/// <summary>
		/// Use for getting your assembly to read an embedded resource.
		/// </summary>
		/// <returns>The current assembly.</returns>
		public static Assembly GetResourceAssembly() => Assembly.GetCallingAssembly();
	}
}
