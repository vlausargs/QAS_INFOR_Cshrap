//PROJECT NAME: Data
//CLASS NAME: ICalculatePackageWeight.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ICalculatePackageWeight
	{
		(int? ReturnCode,
			decimal? PackageWeight,
			string Infobar) CalculatePackageWeightSp(
			decimal? Shipment,
			int? PackageID,
			decimal? PackageWeight,
			string Infobar);
	}
}

