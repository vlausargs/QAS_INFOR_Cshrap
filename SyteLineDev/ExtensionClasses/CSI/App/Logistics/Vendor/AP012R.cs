//PROJECT NAME: Logistics
//CLASS NAME: AP012R.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class AP012R : IAP012R
	{
		readonly IApplicationDB appDB;
		
		
		public AP012R(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? RAppmtCnt,
		string Infobar) AP012RSP(Guid? PSessionID,
		int? PAddToExisting = 1,
		int? PManualOnly = 0,
		string PPayCode = null,
		string PBankCode = null,
		string PStartingVendNum = null,
		string PEndingVendNum = null,
		string PStartingVendName = null,
		string PEndingVendName = null,
		string PSortNameNum = "Number",
		int? RAppmtCnt = null,
		string Infobar = null,
		DateTime? PPayDateStarting = null,
		DateTime? PPayDateEnding = null)
		{
			RowPointerType _PSessionID = PSessionID;
			FlagNyType _PAddToExisting = PAddToExisting;
			FlagNyType _PManualOnly = PManualOnly;
			StringType _PPayCode = PPayCode;
			BankCodeType _PBankCode = PBankCode;
			VendNumType _PStartingVendNum = PStartingVendNum;
			VendNumType _PEndingVendNum = PEndingVendNum;
			NameType _PStartingVendName = PStartingVendName;
			NameType _PEndingVendName = PEndingVendName;
			LongDescType _PSortNameNum = PSortNameNum;
			GenericNoType _RAppmtCnt = RAppmtCnt;
			InfobarType _Infobar = Infobar;
			DateType _PPayDateStarting = PPayDateStarting;
			DateType _PPayDateEnding = PPayDateEnding;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "AP012RSP";
				
				appDB.AddCommandParameter(cmd, "PSessionID", _PSessionID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PAddToExisting", _PAddToExisting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PManualOnly", _PManualOnly, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPayCode", _PPayCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PBankCode", _PBankCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PStartingVendNum", _PStartingVendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEndingVendNum", _PEndingVendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PStartingVendName", _PStartingVendName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEndingVendName", _PEndingVendName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSortNameNum", _PSortNameNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RAppmtCnt", _RAppmtCnt, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PPayDateStarting", _PPayDateStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPayDateEnding", _PPayDateEnding, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				RAppmtCnt = _RAppmtCnt;
				Infobar = _Infobar;
				
				return (Severity, RAppmtCnt, Infobar);
			}
		}
	}
}
