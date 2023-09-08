//PROJECT NAME: Logistics
//CLASS NAME: IPOReceivingProjShip.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface IPOReceivingProjShip
	{
		(int? ReturnCode, string Infobar) POReceivingProjShipSp(string WorkKey,
		string Infobar);
	}
}

