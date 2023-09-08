//PROJECT NAME: Logistics
//CLASS NAME: ApVchPostingBG.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class ApVchPostingBG : IApVchPostingBG
	{
		readonly IApplicationDB appDB;
		
		
		public ApVchPostingBG(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? ApVchPostingBGSp(string StartingVendNum = null,
		string EndingVendNum = null,
		int? VoucherStarting = null,
		int? VoucherEnding = null,
		DateTime? DueDateStarting = null,
		DateTime? DueDateEnding = null,
		DateTime? DisDateStarting = null,
		DateTime? DisDateEnding = null,
		string AuthorizationStatus = null,
		string SortBy = null,
		int? DisplayTotals = null,
		int? DisplayHeader = null,
		int? SeparateDrCrAmounts = null,
		string SessionIDChar = null,
		string pSite = null,
		decimal? UserId = null)
		{
			VendNumType _StartingVendNum = StartingVendNum;
			VendNumType _EndingVendNum = EndingVendNum;
			VoucherType _VoucherStarting = VoucherStarting;
			VoucherType _VoucherEnding = VoucherEnding;
			DateType _DueDateStarting = DueDateStarting;
			DateType _DueDateEnding = DueDateEnding;
			DateType _DisDateStarting = DisDateStarting;
			DateType _DisDateEnding = DisDateEnding;
			StringType _AuthorizationStatus = AuthorizationStatus;
			StringType _SortBy = SortBy;
			ByteType _DisplayTotals = DisplayTotals;
			ByteType _DisplayHeader = DisplayHeader;
			ByteType _SeparateDrCrAmounts = SeparateDrCrAmounts;
			StringType _SessionIDChar = SessionIDChar;
			SiteType _pSite = pSite;
			TokenType _UserId = UserId;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ApVchPostingBGSp";
				
				appDB.AddCommandParameter(cmd, "StartingVendNum", _StartingVendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingVendNum", _EndingVendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VoucherStarting", _VoucherStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VoucherEnding", _VoucherEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DueDateStarting", _DueDateStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DueDateEnding", _DueDateEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisDateStarting", _DisDateStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisDateEnding", _DisDateEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AuthorizationStatus", _AuthorizationStatus, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SortBy", _SortBy, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayTotals", _DisplayTotals, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayHeader", _DisplayHeader, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SeparateDrCrAmounts", _SeparateDrCrAmounts, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SessionIDChar", _SessionIDChar, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pSite", _pSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UserId", _UserId, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
