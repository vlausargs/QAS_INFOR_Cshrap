//PROJECT NAME: Data
//CLASS NAME: IPackagePackageCheck.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IPackagePackageCheck
	{
		(int? ReturnCode,
			int? DuplicateFlag,
			string InfoBar) PackagePackageCheckSp(
			int? RefPackageid,
			int? NewPackageId,
			decimal? ShipmentId,
			int? DuplicateFlag,
			string InfoBar);
	}
}

