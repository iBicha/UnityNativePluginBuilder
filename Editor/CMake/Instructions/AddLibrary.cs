﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using CMake.Types;

namespace CMake.Instructions
{
	[Serializable]
	public class AddLibrary : GenericInstruction {
        
		public static AddLibrary Create(string libraryName, LibraryType libraryType,  params string[] sourceFiles)
		{
			return new AddLibrary()
			{
				LibraryName = libraryName,
				Type = libraryType,
				SourceFiles = new List<string>(sourceFiles)
			};
		}
		
		public string LibraryName;
		public LibraryType Type;
		public List<string> SourceFiles;

		public void AddSourceFilesInFolder(string directory, string pattern, SearchOption searchOption = SearchOption.TopDirectoryOnly)
		{
			if(SourceFiles == null)
				SourceFiles = new List<string>();
			
			
			if(!Directory.Exists(directory)) return;
			SourceFiles.AddRange(Directory.GetFiles(directory, pattern, searchOption));
		}
		
		public override string Command 
		{
			get
			{
				if (SourceFiles == null || SourceFiles.Count == 0)
					return null;
                
				var sb = new StringBuilder();
				sb.Append($"add_library ( {LibraryName} {Type.ToString().ToUpper()}");
				
				Intent++;
				foreach (var file in SourceFiles)
				{
					sb.AppendLine();
					sb.Append($"{CurrentIntentString}\"{file}\"");
				}
				Intent--;
//				sb.AppendLine();
//				sb.Append(CurrentIntentString);
				sb.Append(")");

				return sb.ToString();
			}
		}

		public override string Comment => $"Library source files";
	}

}
