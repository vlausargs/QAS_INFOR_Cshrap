//PROJECT NAME: Logistics
//CLASS NAME: IARFinChgPostVerifyPrint.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IARFinChgPostVerifyPrint
	{
		(int? ReturnCode, Guid? PSessionID,
		string Infobar) ARFinChgPostVerifyPrintSp(Guid? PSessionID,
		string Infobar);
	}
}

