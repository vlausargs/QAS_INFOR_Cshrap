//PROJECT NAME: Logistics
//CLASS NAME: IPostRemVerifyPrint.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface IPostRemVerifyPrint
	{
		(int? ReturnCode, Guid? PSessionID,
		string Infobar) PostRemVerifyPrintSP(Guid? PSessionID,
		string Infobar);
	}
}

