//PROJECT NAME: CSIVendor
//CLASS NAME: AP01RIVoidChecksRange.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public interface IAP01RIVoidChecksRange
	{
		(int? ReturnCode, int? RStartCheckNum, int? REndCheckNum, string Infobar) AP01RIVoidChecksRangeSP(string PPayCode,
		string PBankCode,
		string PStartingVendNum,
		string PEndingVendNum,
		string PStartingVendName,
		string PEndingVendName,
		int? RStartCheckNum = null,
		int? REndCheckNum = null,
		string Infobar = null);
	}
	
	public class AP01RIVoidChecksRange : IAP01RIVoidChecksRange
	{
		readonly IApplicationDB appDB;
		
		public AP01RIVoidChecksRange(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? RStartCheckNum, int? REndCheckNum, string Infobar) AP01RIVoidChecksRangeSP(string PPayCode,
		string PBankCode,
		string PStartingVendNum,
		string PEndingVendNum,
		string PStartingVendName,
		string PEndingVendName,
		int? RStartCheckNum = null,
		int? REndCheckNum = null,
		string Infobar = null)
		{
			AppmtPayTypeType _PPayCode = PPayCode;
			BankCodeType _PBankCode = PBankCode;
			VendNumType _PStartingVendNum = PStartingVendNum;
			VendNumType _PEndingVendNum = PEndingVendNum;
			NameType _PStartingVendName = PStartingVendName;
			NameType _PEndingVendName = PEndingVendName;
			ApCheckNumType _RStartCheckNum = RStartCheckNum;
			ApCheckNumType _REndCheckNum = REndCheckNum;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "AP01RIVoidChecksRangeSP";
				
				appDB.AddCommandParameter(cmd, "PPayCode", _PPayCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PBankCode", _PBankCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PStartingVendNum", _PStartingVendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEndingVendNum", _PEndingVendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PStartingVendName", _PStartingVendName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEndingVendName", _PEndingVendName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RStartCheckNum", _RStartCheckNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "REndCheckNum", _REndCheckNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				RStartCheckNum = _RStartCheckNum;
				REndCheckNum = _REndCheckNum;
				Infobar = _Infobar;
				
				return (Severity, RStartCheckNum, REndCheckNum, Infobar);
			}
		}
	}
}
