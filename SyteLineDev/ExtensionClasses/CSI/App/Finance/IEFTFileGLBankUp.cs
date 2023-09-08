//PROJECT NAME: Finance
//CLASS NAME: IEFTFileGLBankUp.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
	public interface IEFTFileGLBankUp
	{
		(int? ReturnCode, string Infobar) EFTFileGLBankUpSp(int? BankRecon,
		Guid? RowPointer,
		string Infobar);
	}
}

