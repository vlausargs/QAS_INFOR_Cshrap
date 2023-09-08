using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace CSI.Data.Utilities
{
    public class FileNameUtil: IFileNameUtil
    {

        public string RemoveInvalidCharFromFileName(string fileName)
        {
            string validFilename = fileName;

            if (!string.IsNullOrEmpty(validFilename))
            {
                foreach (char c in Path.GetInvalidFileNameChars())
                {
                    validFilename = validFilename.Replace(c.ToString(), string.Empty);
                }
            }

            return validFilename;
        }
    }
}
