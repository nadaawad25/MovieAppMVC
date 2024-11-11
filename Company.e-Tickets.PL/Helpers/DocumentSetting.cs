using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using System.Net;

namespace Company.e_Tickets.PL.Helpers
{
	public static class DocumentSetting
	{
		//Upload 
		public static string UploadFile(IFormFile formFile , string FolderName)
		{
			string FolderPath = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot//Files",FolderName);
			string FileName = $"{Guid.NewGuid()}{formFile.FileName}";
			string FilePath = Path.Combine(FolderPath, FileName);
            using var FS = new FileStream(FilePath, FileMode.Create);
            formFile.CopyTo(FS);
            //5.return name of file
            return FileName;
        }
        public static void DeleteFile(string FileName,string FolderName)
		{
			string FilePath = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot//Files", FileName);
			if (File.Exists(FilePath))
			{
				File.Delete(FilePath);
			}
		}

	}
}
