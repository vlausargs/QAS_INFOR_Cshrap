//PROJECT NAME: Logistics
//CLASS NAME: IUpdateRemitAdviceFlag.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface IUpdateRemitAdviceFlag
	{
		(int? ReturnCode, string Infobar) UpdateRemitAdviceFlagSp(Guid? PSessionID,
		int? RemitAdvicePrintedOK = 0,
		int? ForAPCheckOrAPEft = null,
		string Infobar = null);
	}
}

