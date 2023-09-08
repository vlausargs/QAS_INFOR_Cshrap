using System;
using System.Collections.Generic;
using System.Text;

namespace CSI.MG.MGCore
{
	public interface IFormatFileSpec
	{
		string FormatFileSpecFn(string StorageMethod,
		int? UseServerPathAsRootPath,
		string FileSpec,
		string RootPath);
	}
}
