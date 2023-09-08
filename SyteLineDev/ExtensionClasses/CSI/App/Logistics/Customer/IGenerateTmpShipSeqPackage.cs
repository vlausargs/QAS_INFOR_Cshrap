//PROJECT NAME: Logistics
//CLASS NAME: IGenerateTmpShipSeqPackage.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IGenerateTmpShipSeqPackage
	{
		(int? ReturnCode, string InfoBar) GenerateTmpShipSeqPackageSp(Guid? ProcessId,
		int? Select,
		decimal? ShipmentId,
		int? PackageId,
		string PackageType,
		string RateCode,
		string NMFC,
		decimal? Weight,
		int? Hazard,
		string Description,
		string Marksexcept,
		int? RefPackageId,
		string TH_CartonPrefix,
		decimal? TH_Measurement,
		string TH_CartonSize,
		string InfoBar);
	}
}

