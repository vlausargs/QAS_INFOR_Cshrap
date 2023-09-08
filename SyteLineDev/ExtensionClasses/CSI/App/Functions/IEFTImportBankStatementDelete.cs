//PROJECT NAME: Data
//CLASS NAME: IEFTImportBankStatementDelete.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IEFTImportBankStatementDelete
	{
		(int? ReturnCode,
			string Infobar) EFTImportBankStatementDeleteSp(
			string FileName,
			string Infobar);
	}
}

