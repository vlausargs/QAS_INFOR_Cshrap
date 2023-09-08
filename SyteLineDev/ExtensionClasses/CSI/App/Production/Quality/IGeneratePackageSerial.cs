//PROJECT NAME: Production
//CLASS NAME: IGeneratePackageSerial.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Quality
{
	public interface IGeneratePackageSerial
	{
		(int? ReturnCode, string InfoBar) GeneratePackageSerialSp(Guid? ProcessId,
		int? PackageId,
		string PackageType,
		string RateCode,
		string NMFC,
		decimal? Weight,
		int? Hazard,
		string MarksExcept,
		string Description,
		string InfoBar);
	}
}

