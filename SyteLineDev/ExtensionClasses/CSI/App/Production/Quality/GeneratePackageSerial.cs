//PROJECT NAME: Production
//CLASS NAME: GeneratePackageSerial.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.Quality
{
	public class GeneratePackageSerial : IGeneratePackageSerial
	{
		readonly IApplicationDB appDB;
		
		
		public GeneratePackageSerial(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string InfoBar) GeneratePackageSerialSp(Guid? ProcessId,
		int? PackageId,
		string PackageType,
		string RateCode,
		string NMFC,
		decimal? Weight,
		int? Hazard,
		string MarksExcept,
		string Description,
		string InfoBar)
		{
			RowPointerType _ProcessId = ProcessId;
			PackageIDType _PackageId = PackageId;
			DoPackageTypeType _PackageType = PackageType;
			RateCodeType _RateCode = RateCode;
			DoMarksType _NMFC = NMFC;
			QtyUnitNoNegType _Weight = Weight;
			ListYesNoType _Hazard = Hazard;
			DoMarksType _MarksExcept = MarksExcept;
			DescriptionType _Description = Description;
			InfobarType _InfoBar = InfoBar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GeneratePackageSerialSp";
				
				appDB.AddCommandParameter(cmd, "ProcessId", _ProcessId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PackageId", _PackageId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PackageType", _PackageType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RateCode", _RateCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NMFC", _NMFC, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Weight", _Weight, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Hazard", _Hazard, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MarksExcept", _MarksExcept, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Description", _Description, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InfoBar", _InfoBar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				InfoBar = _InfoBar;
				
				return (Severity, InfoBar);
			}
		}
	}
}
