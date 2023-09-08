//PROJECT NAME: Logistics
//CLASS NAME: IPostRemUpdateTT.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface IPostRemUpdateTT
	{
		(int? ReturnCode, string Infobar) PostRemUpdateTTSP(Guid? PSessionID,
		int? PPrintedFlag = null,
		int? PPostedFlag = null,
		string Infobar = null);
	}
}

