//PROJECT NAME: Logistics
//CLASS NAME: IARPayPostVerifyPrint.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IARPayPostVerifyPrint
	{
		(int? ReturnCode, Guid? PSessionID,
		string Infobar) ARPayPostVerifyPrintSp(Guid? PSessionID,
		string Infobar);
	}
}

