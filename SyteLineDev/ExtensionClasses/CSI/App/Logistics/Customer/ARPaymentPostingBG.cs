//PROJECT NAME: Logistics
//CLASS NAME: ARPaymentPostingBG.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class ARPaymentPostingBG : IARPaymentPostingBG
	{
		readonly IApplicationDB appDB;
		
		
		public ARPaymentPostingBG(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? ARPaymentPostingBGSp(int? DisplayHeader = 1,
		int? DisplayDetail = 1,
		string StartingCustNum = null,
		string EndingCustNum = null,
		string StartBnkCode = null,
		string EndBnkCode = null,
		DateTime? StartRecDate = null,
		DateTime? EndRecDate = null,
		int? StartChkNum = null,
		int? EndChkNum = null,
		Guid? PSessionID = null,
		string StartCreditMemo = null,
		string EndCreditMemo = null,
		string PSite = null,
		string PayType = null,
		decimal? UserId = null)
		{
			ListYesNoType _DisplayHeader = DisplayHeader;
			ListYesNoType _DisplayDetail = DisplayDetail;
			CustNumType _StartingCustNum = StartingCustNum;
			CustNumType _EndingCustNum = EndingCustNum;
			BankCodeType _StartBnkCode = StartBnkCode;
			BankCodeType _EndBnkCode = EndBnkCode;
			DateTimeType _StartRecDate = StartRecDate;
			DateTimeType _EndRecDate = EndRecDate;
			ArCheckNumType _StartChkNum = StartChkNum;
			ArCheckNumType _EndChkNum = EndChkNum;
			RowPointer _PSessionID = PSessionID;
			InvNumType _StartCreditMemo = StartCreditMemo;
			InvNumType _EndCreditMemo = EndCreditMemo;
			SiteType _PSite = PSite;
			ArpmtTypeType _PayType = PayType;
			TokenType _UserId = UserId;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ARPaymentPostingBGSp";
				
				appDB.AddCommandParameter(cmd, "DisplayHeader", _DisplayHeader, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayDetail", _DisplayDetail, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartingCustNum", _StartingCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingCustNum", _EndingCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartBnkCode", _StartBnkCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndBnkCode", _EndBnkCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartRecDate", _StartRecDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndRecDate", _EndRecDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartChkNum", _StartChkNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndChkNum", _EndChkNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSessionID", _PSessionID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartCreditMemo", _StartCreditMemo, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndCreditMemo", _EndCreditMemo, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSite", _PSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PayType", _PayType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UserId", _UserId, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
