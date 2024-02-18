using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uploader
{
	public class FileUtil
	{
		public static string[] GetFiles(string[] arguments)
		{
			var files = new List<string>();
			foreach (var argument in arguments)
			{
				if (Directory.Exists(argument))
				{
					string[] dirFiles = System.IO.Directory.EnumerateFiles(argument, "*.*").ToArray();
					files.AddRange(dirFiles);
				}
				else if (File.Exists(argument))
				{
					files.Add(argument);
				}
			}
			return files.ToArray();
		}
	}
}
