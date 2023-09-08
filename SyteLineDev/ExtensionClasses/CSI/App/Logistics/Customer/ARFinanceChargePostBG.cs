//PROJECT NAME: Logistics
//CLASS NAME: ARFinanceChargePostBG.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class ARFinanceChargePostBG : IARFinanceChargePostBG
	{
		readonly IApplicationDB appDB;
		
		
		public ARFinanceChargePostBG(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? ARFinanceChargePostBGSp(string pStartingCustNum = null,
		string pEndingCustNum = null,
		int? pDisplayHeader = null,
		string pSessionIdChar = null,
		DateTime? pCutoffDate = null,
		int? pCutoffDateOffset = null,
		string pSite = null,
		decimal? pUserId = null)
		{
			CustNumType _pStartingCustNum = pStartingCustNum;
			CustNumType _pEndingCustNum = pEndingCustNum;
			ListYesNoType _pDisplayHeader = pDisplayHeader;
			LongDescType _pSessionIdChar = pSessionIdChar;
			DateType _pCutoffDate = pCutoffDate;
			DateOffsetType _pCutoffDateOffset = pCutoffDateOffset;
			SiteType _pSite = pSite;
			TokenType _pUserId = pUserId;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ARFinanceChargePostBGSp";
				
				appDB.AddCommandParameter(cmd, "pStartingCustNum", _pStartingCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pEndingCustNum", _pEndingCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pDisplayHeader", _pDisplayHeader, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pSessionIdChar", _pSessionIdChar, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pCutoffDate", _pCutoffDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pCutoffDateOffset", _pCutoffDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pSite", _pSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pUserId", _pUserId, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
