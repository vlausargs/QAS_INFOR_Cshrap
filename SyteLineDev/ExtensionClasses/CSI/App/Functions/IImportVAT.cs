//PROJECT NAME: Data
//CLASS NAME: IImportVAT.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IImportVAT
	{
		(int? ReturnCode,
			string Infobar) ImportVATSp(
			string Filename,
			string Infobar);
	}
}

