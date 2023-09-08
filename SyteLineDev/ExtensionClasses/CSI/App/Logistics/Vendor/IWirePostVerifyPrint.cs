//PROJECT NAME: Logistics
//CLASS NAME: IWirePostVerifyPrint.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface IWirePostVerifyPrint
	{
		(int? ReturnCode, Guid? PSessionID,
		string Infobar) WirePostVerifyPrintSp(Guid? PSessionID,
		string Infobar);
	}
}

