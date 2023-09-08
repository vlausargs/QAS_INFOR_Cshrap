//PROJECT NAME: Logistics
//CLASS NAME: SSSFSContractDefaults.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSContractDefaults : ISSSFSContractDefaults
	{
		readonly IApplicationDB appDB;
		
		
		public SSSFSContractDefaults(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string ProductCode,
		int? ProrateLines,
		DateTime? RenewalDate,
		int? UseEndUserTypes,
		string OpenStatus,
		string CloseStatus,
		string PriceBasis,
		string ServType,
		string BillType,
		string BillFreq,
		int? AllowCustAddrOverride,
		decimal? WaiverCharge,
		string Infobar,
		string TimeZone) SSSFSContractDefaultsSp(string ProductCode,
		int? ProrateLines,
		DateTime? RenewalDate,
		int? UseEndUserTypes,
		string OpenStatus,
		string CloseStatus,
		string PriceBasis,
		string ServType,
		string BillType,
		string BillFreq,
		int? AllowCustAddrOverride,
		decimal? WaiverCharge,
		string Infobar,
		string TimeZone = null)
		{
			ProductCodeType _ProductCode = ProductCode;
			ListYesNoType _ProrateLines = ProrateLines;
			DateType _RenewalDate = RenewalDate;
			ListYesNoType _UseEndUserTypes = UseEndUserTypes;
			FSContStatType _OpenStatus = OpenStatus;
			FSContStatType _CloseStatus = CloseStatus;
			FSContPriceBasisType _PriceBasis = PriceBasis;
			FSContServTypeType _ServType = ServType;
			FSContBillTypeType _BillType = BillType;
			FSContBillFreqType _BillFreq = BillFreq;
			ListYesNoType _AllowCustAddrOverride = AllowCustAddrOverride;
			CostPrcType _WaiverCharge = WaiverCharge;
			Infobar _Infobar = Infobar;
			TimeZoneType _TimeZone = TimeZone;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSContractDefaultsSp";
				
				appDB.AddCommandParameter(cmd, "ProductCode", _ProductCode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ProrateLines", _ProrateLines, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "RenewalDate", _RenewalDate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UseEndUserTypes", _UseEndUserTypes, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "OpenStatus", _OpenStatus, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CloseStatus", _CloseStatus, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PriceBasis", _PriceBasis, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ServType", _ServType, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "BillType", _BillType, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "BillFreq", _BillFreq, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "AllowCustAddrOverride", _AllowCustAddrOverride, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "WaiverCharge", _WaiverCharge, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TimeZone", _TimeZone, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				ProductCode = _ProductCode;
				ProrateLines = _ProrateLines;
				RenewalDate = _RenewalDate;
				UseEndUserTypes = _UseEndUserTypes;
				OpenStatus = _OpenStatus;
				CloseStatus = _CloseStatus;
				PriceBasis = _PriceBasis;
				ServType = _ServType;
				BillType = _BillType;
				BillFreq = _BillFreq;
				AllowCustAddrOverride = _AllowCustAddrOverride;
				WaiverCharge = _WaiverCharge;
				Infobar = _Infobar;
				TimeZone = _TimeZone;
				
				return (Severity, ProductCode, ProrateLines, RenewalDate, UseEndUserTypes, OpenStatus, CloseStatus, PriceBasis, ServType, BillType, BillFreq, AllowCustAddrOverride, WaiverCharge, Infobar, TimeZone);
			}
		}
	}
}
