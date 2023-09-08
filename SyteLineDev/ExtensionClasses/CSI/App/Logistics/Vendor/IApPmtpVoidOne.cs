//PROJECT NAME: Logistics
//CLASS NAME: IApPmtpVoidOne.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface IApPmtpVoidOne
	{
		(int? ReturnCode, string Infobar) ApPmtpVoidOneSp(Guid? PSessionID,
		Guid? PAppmtRowPointer,
		string PPayType = null,
		string Infobar = null);
	}
}

