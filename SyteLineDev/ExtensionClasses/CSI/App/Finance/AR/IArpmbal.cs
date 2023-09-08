//PROJECT NAME: Finance
//CLASS NAME: IArpmbal.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance.AR
{
	public interface IArpmbal
	{
		(int? ReturnCode,
			string Infobar) ArpmbalSp(
			Guid? RowPointer,
			DateTime? ReceiptDate,
			string Infobar);
	}
}

