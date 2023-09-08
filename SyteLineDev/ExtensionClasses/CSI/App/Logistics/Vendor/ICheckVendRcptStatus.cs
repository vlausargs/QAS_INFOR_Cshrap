//PROJECT NAME: Logistics
//CLASS NAME: ICheckVendRcptStatus.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface ICheckVendRcptStatus
	{
		(int? ReturnCode, int? PReceived,
		string Infobar) CheckVendRcptStatusSp(string PoNum,
		int? PReceived,
		int? PWithMessage = 0,
		string Infobar = null);
	}
}

