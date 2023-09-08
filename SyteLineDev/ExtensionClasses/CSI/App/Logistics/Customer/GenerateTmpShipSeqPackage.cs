//PROJECT NAME: Logistics
//CLASS NAME: GenerateTmpShipSeqPackage.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class GenerateTmpShipSeqPackage : IGenerateTmpShipSeqPackage
	{
		readonly IApplicationDB appDB;
		
		
		public GenerateTmpShipSeqPackage(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string InfoBar) GenerateTmpShipSeqPackageSp(Guid? ProcessId,
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
		string InfoBar)
		{
			RowPointerType _ProcessId = ProcessId;
			ListYesNoType _Select = Select;
			ShipmentIDType _ShipmentId = ShipmentId;
			PackageIDType _PackageId = PackageId;
			DoPackageTypeType _PackageType = PackageType;
			RateCodeType _RateCode = RateCode;
			DoMotorFreightCodeType _NMFC = NMFC;
			LineWeightType _Weight = Weight;
			ListYesNoType _Hazard = Hazard;
			DescriptionType _Description = Description;
			DoMarksType _Marksexcept = Marksexcept;
			PackageIDType _RefPackageId = RefPackageId;
			TH_CartonPrefixType _TH_CartonPrefix = TH_CartonPrefix;
			TH_MeasurementType _TH_Measurement = TH_Measurement;
			TH_CartonSizeType _TH_CartonSize = TH_CartonSize;
			InfobarType _InfoBar = InfoBar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GenerateTmpShipSeqPackageSp";
				
				appDB.AddCommandParameter(cmd, "ProcessId", _ProcessId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Select", _Select, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShipmentId", _ShipmentId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PackageId", _PackageId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PackageType", _PackageType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RateCode", _RateCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NMFC", _NMFC, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Weight", _Weight, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Hazard", _Hazard, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Description", _Description, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Marksexcept", _Marksexcept, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefPackageId", _RefPackageId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TH_CartonPrefix", _TH_CartonPrefix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TH_Measurement", _TH_Measurement, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TH_CartonSize", _TH_CartonSize, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InfoBar", _InfoBar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				InfoBar = _InfoBar;
				
				return (Severity, InfoBar);
			}
		}
	}
}
