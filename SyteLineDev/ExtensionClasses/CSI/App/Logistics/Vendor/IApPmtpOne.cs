//PROJECT NAME: Logistics
//CLASS NAME: IApPmtpOne.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface IApPmtpOne
	{
		(int? ReturnCode, string Infobar) ApPmtpOneSp(Guid? PSessionID,
		Guid? PAppmtRowPointer,
		string PPayType = null,
		string Infobar = null);
	}
}

