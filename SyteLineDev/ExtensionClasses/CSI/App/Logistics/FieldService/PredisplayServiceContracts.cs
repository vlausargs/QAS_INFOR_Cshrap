//PROJECT NAME: Logistics
//CLASS NAME: PredisplayServiceContracts.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class PredisplayServiceContracts : IPredisplayServiceContracts
	{
		readonly IApplicationDB appDB;
		
		
		public PredisplayServiceContracts(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string PProductCode,
		int? PProrateLines,
		DateTime? PRenewalDate,
		int? PUseEndUserTypes,
		string POpenStatus,
		string PCloseStatus,
		string PPriceBasis,
		string PServType,
		string PBillType,
		string PBillFreq,
		int? PAllowCustAddrOverride,
		decimal? PWaiverCharge,
		string PInfobar,
		string PTimeZone,
		int? PCheckSsnEnabled) PredisplayServiceContractsSp(string PProductCode,
		int? PProrateLines,
		DateTime? PRenewalDate,
		int? PUseEndUserTypes,
		string POpenStatus,
		string PCloseStatus,
		string PPriceBasis,
		string PServType,
		string PBillType,
		string PBillFreq,
		int? PAllowCustAddrOverride,
		decimal? PWaiverCharge,
		string PInfobar,
		string PTimeZone = null,
		int? PCheckSsnEnabled = null)
		{
			ProductCodeType _PProductCode = PProductCode;
			ListYesNoType _PProrateLines = PProrateLines;
			DateType _PRenewalDate = PRenewalDate;
			ListYesNoType _PUseEndUserTypes = PUseEndUserTypes;
			FSContStatType _POpenStatus = POpenStatus;
			FSContStatType _PCloseStatus = PCloseStatus;
			FSContPriceBasisType _PPriceBasis = PPriceBasis;
			FSContServTypeType _PServType = PServType;
			FSContBillTypeType _PBillType = PBillType;
			FSContBillFreqType _PBillFreq = PBillFreq;
			ListYesNoType _PAllowCustAddrOverride = PAllowCustAddrOverride;
			CostPrcType _PWaiverCharge = PWaiverCharge;
			Infobar _PInfobar = PInfobar;
			TimeZoneType _PTimeZone = PTimeZone;
			ListYesNoType _PCheckSsnEnabled = PCheckSsnEnabled;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PredisplayServiceContractsSp";
				
				appDB.AddCommandParameter(cmd, "PProductCode", _PProductCode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PProrateLines", _PProrateLines, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PRenewalDate", _PRenewalDate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PUseEndUserTypes", _PUseEndUserTypes, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "POpenStatus", _POpenStatus, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PCloseStatus", _PCloseStatus, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PPriceBasis", _PPriceBasis, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PServType", _PServType, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PBillType", _PBillType, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PBillFreq", _PBillFreq, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PAllowCustAddrOverride", _PAllowCustAddrOverride, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PWaiverCharge", _PWaiverCharge, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PInfobar", _PInfobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PTimeZone", _PTimeZone, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PCheckSsnEnabled", _PCheckSsnEnabled, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PProductCode = _PProductCode;
				PProrateLines = _PProrateLines;
				PRenewalDate = _PRenewalDate;
				PUseEndUserTypes = _PUseEndUserTypes;
				POpenStatus = _POpenStatus;
				PCloseStatus = _PCloseStatus;
				PPriceBasis = _PPriceBasis;
				PServType = _PServType;
				PBillType = _PBillType;
				PBillFreq = _PBillFreq;
				PAllowCustAddrOverride = _PAllowCustAddrOverride;
				PWaiverCharge = _PWaiverCharge;
				PInfobar = _PInfobar;
				PTimeZone = _PTimeZone;
				PCheckSsnEnabled = _PCheckSsnEnabled;
				
				return (Severity, PProductCode, PProrateLines, PRenewalDate, PUseEndUserTypes, POpenStatus, PCloseStatus, PPriceBasis, PServType, PBillType, PBillFreq, PAllowCustAddrOverride, PWaiverCharge, PInfobar, PTimeZone, PCheckSsnEnabled);
			}
		}
	}
}
