//PROJECT NAME: CSIFinance
//CLASS NAME: ARDraftRemUpdate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance
{
	public interface IARDraftRemUpdate
	{
		(int? ReturnCode, string rInfobar) ARDraftRemUpdateSp(int? pCustdrftDraftNum,
		string pRsDraftStatus,
		string rInfobar = null,
		decimal? pDiscountAmount = 0);
	}
	
	public class ARDraftRemUpdate : IARDraftRemUpdate
	{
		readonly IApplicationDB appDB;
		
		public ARDraftRemUpdate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string rInfobar) ARDraftRemUpdateSp(int? pCustdrftDraftNum,
		string pRsDraftStatus,
		string rInfobar = null,
		decimal? pDiscountAmount = 0)
		{
			DraftNumType _pCustdrftDraftNum = pCustdrftDraftNum;
			CustdrftStatusType _pRsDraftStatus = pRsDraftStatus;
			InfobarType _rInfobar = rInfobar;
			AmountType _pDiscountAmount = pDiscountAmount;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ARDraftRemUpdateSp";
				
				appDB.AddCommandParameter(cmd, "pCustdrftDraftNum", _pCustdrftDraftNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pRsDraftStatus", _pRsDraftStatus, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "rInfobar", _rInfobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "pDiscountAmount", _pDiscountAmount, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				rInfobar = _rInfobar;
				
				return (Severity, rInfobar);
			}
		}
	}
}
