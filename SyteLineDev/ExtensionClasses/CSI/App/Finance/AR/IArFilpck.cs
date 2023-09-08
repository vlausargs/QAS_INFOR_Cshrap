//PROJECT NAME: Finance
//CLASS NAME: IArFilpck.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance.AR
{
	public interface IArFilpck
	{
		(int? ReturnCode,
			string Infobar) ArFilpckSp(
			string PBankCode,
			string PCustNum,
			string PType,
			int? PCheckNum,
			string InvoiceSite,
			string Infobar,
			string PCreditMemoNum,
			Guid? PProcessId);
	}
}

