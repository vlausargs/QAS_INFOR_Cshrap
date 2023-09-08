//PROJECT NAME: CSIVendor
//CLASS NAME: AP01RIPrelimReg.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public interface IAP01RIPrelimReg
	{
		(int? ReturnCode, string Infobar) AP01RIPrelimRegSP(Guid? PSessionID = null,
		decimal? PUserID = 1,
		byte? PAddToExisting = (byte)0,
		string PStartingVendNum = null,
		string PEndingVendNum = null,
		string PStartingVendName = null,
		string PEndingVendName = null,
		string PPayCode = null,
		string PBankCode = null,
		string PSortBy = "Number",
		string Infobar = null,
		DateTime? PPayDateStarting = null,
		DateTime? PPayDateEnding = null);
	}
	
	public class AP01RIPrelimReg : IAP01RIPrelimReg
	{
		readonly IApplicationDB appDB;
		
		public AP01RIPrelimReg(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) AP01RIPrelimRegSP(Guid? PSessionID = null,
		decimal? PUserID = 1,
		byte? PAddToExisting = (byte)0,
		string PStartingVendNum = null,
		string PEndingVendNum = null,
		string PStartingVendName = null,
		string PEndingVendName = null,
		string PPayCode = null,
		string PBankCode = null,
		string PSortBy = "Number",
		string Infobar = null,
		DateTime? PPayDateStarting = null,
		DateTime? PPayDateEnding = null)
		{
			RowPointerType _PSessionID = PSessionID;
			TokenType _PUserID = PUserID;
			FlagNyType _PAddToExisting = PAddToExisting;
			VendNumType _PStartingVendNum = PStartingVendNum;
			VendNumType _PEndingVendNum = PEndingVendNum;
			NameType _PStartingVendName = PStartingVendName;
			NameType _PEndingVendName = PEndingVendName;
			StringType _PPayCode = PPayCode;
			BankCodeType _PBankCode = PBankCode;
			LongDescType _PSortBy = PSortBy;
			Infobar _Infobar = Infobar;
			DateType _PPayDateStarting = PPayDateStarting;
			DateType _PPayDateEnding = PPayDateEnding;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "AP01RIPrelimRegSP";
				
				appDB.AddCommandParameter(cmd, "PSessionID", _PSessionID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PUserID", _PUserID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PAddToExisting", _PAddToExisting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PStartingVendNum", _PStartingVendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEndingVendNum", _PEndingVendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PStartingVendName", _PStartingVendName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEndingVendName", _PEndingVendName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPayCode", _PPayCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PBankCode", _PBankCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSortBy", _PSortBy, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PPayDateStarting", _PPayDateStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPayDateEnding", _PPayDateEnding, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
