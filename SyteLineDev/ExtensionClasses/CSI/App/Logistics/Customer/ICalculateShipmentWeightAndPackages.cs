//PROJECT NAME: Logistics
//CLASS NAME: ICalculateShipmentWeightAndPackages.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface ICalculateShipmentWeightAndPackages
	{
		(int? ReturnCode, string Infobar) CalculateShipmentWeightAndPackagesSp(decimal? Shipment,
		int? Recalcflag,
		string Infobar);
	}
}

