//PROJECT NAME: CSIVendor
//CLASS NAME: AP01RIVoidChecks.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public interface IAP01RIVoidChecks
	{
		(int? ReturnCode, byte? RUnpostedVoid, string Infobar) AP01RIVoidChecksSP(Guid? PSessionID,
		decimal? PUserID,
		byte? PCreateNew = (byte)0,
		string PPayCode = null,
		string PBankCode = null,
		string PStartingVendNum = null,
		string PEndingVendNum = null,
		string PStartingVendName = null,
		string PEndingVendName = null,
		int? PStartingCheckNum = null,
		int? PEndingCheckNum = null,
		byte? RUnpostedVoid = null,
		string Infobar = null);
	}
	
	public class AP01RIVoidChecks : IAP01RIVoidChecks
	{
		readonly IApplicationDB appDB;
		
		public AP01RIVoidChecks(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, byte? RUnpostedVoid, string Infobar) AP01RIVoidChecksSP(Guid? PSessionID,
		decimal? PUserID,
		byte? PCreateNew = (byte)0,
		string PPayCode = null,
		string PBankCode = null,
		string PStartingVendNum = null,
		string PEndingVendNum = null,
		string PStartingVendName = null,
		string PEndingVendName = null,
		int? PStartingCheckNum = null,
		int? PEndingCheckNum = null,
		byte? RUnpostedVoid = null,
		string Infobar = null)
		{
			RowPointerType _PSessionID = PSessionID;
			TokenType _PUserID = PUserID;
			FlagNyType _PCreateNew = PCreateNew;
			AppmtPayTypeType _PPayCode = PPayCode;
			BankCodeType _PBankCode = PBankCode;
			VendNumType _PStartingVendNum = PStartingVendNum;
			VendNumType _PEndingVendNum = PEndingVendNum;
			NameType _PStartingVendName = PStartingVendName;
			NameType _PEndingVendName = PEndingVendName;
			ApCheckNumType _PStartingCheckNum = PStartingCheckNum;
			ApCheckNumType _PEndingCheckNum = PEndingCheckNum;
			FlagNyType _RUnpostedVoid = RUnpostedVoid;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "AP01RIVoidChecksSP";
				
				appDB.AddCommandParameter(cmd, "PSessionID", _PSessionID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PUserID", _PUserID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCreateNew", _PCreateNew, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPayCode", _PPayCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PBankCode", _PBankCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PStartingVendNum", _PStartingVendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEndingVendNum", _PEndingVendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PStartingVendName", _PStartingVendName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEndingVendName", _PEndingVendName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PStartingCheckNum", _PStartingCheckNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEndingCheckNum", _PEndingCheckNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RUnpostedVoid", _RUnpostedVoid, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				RUnpostedVoid = _RUnpostedVoid;
				Infobar = _Infobar;
				
				return (Severity, RUnpostedVoid, Infobar);
			}
		}
	}
}
