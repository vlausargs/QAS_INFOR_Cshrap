//PROJECT NAME: Logistics
//CLASS NAME: IPostRemClearTT.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface IPostRemClearTT
	{
		(int? ReturnCode, string Infobar) PostRemClearTTSP(Guid? PSessionID,
		int? PPrintedFlag = null,
		int? PPostedFlag = null,
		string Infobar = null);
	}
}

