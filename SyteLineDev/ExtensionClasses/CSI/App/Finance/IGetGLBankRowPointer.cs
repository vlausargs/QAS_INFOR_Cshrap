//PROJECT NAME: Finance
//CLASS NAME: IGetGLBankRowPointer.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
	public interface IGetGLBankRowPointer
	{
		(int? ReturnCode, Guid? RowPointer) GetGLBankRowPointerSp(string BankCode,
		string ReferenceNum,
		string Type,
		Guid? RowPointer);
	}
}

