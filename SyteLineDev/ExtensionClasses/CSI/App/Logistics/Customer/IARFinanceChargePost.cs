//PROJECT NAME: Logistics
//CLASS NAME: IARFinanceChargePost.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IARFinanceChargePost
	{
		(int? ReturnCode, string Infobar) ARFinanceChargePostSp(Guid? PSessionID,
		string PCustNum,
		Guid? PJHeaderRowPointer,
		string Infobar);
	}
}

