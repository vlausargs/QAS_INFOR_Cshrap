//PROJECT NAME: Logistics
//CLASS NAME: InvPostingBG.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class InvPostingBG : IInvPostingBG
	{
		readonly IApplicationDB appDB;
		
		
		public InvPostingBG(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? InvPostingBGSp(string StartingCustNum = null,
		string EndingCustNum = null,
		string InvNumStarting = null,
		string InvNumEnding = null,
		DateTime? InvoiceDateStarting = null,
		DateTime? InvoiceDateEnding = null,
		DateTime? DueDateStarting = null,
		DateTime? DueDateEnding = null,
		string InvoiceFlag = null,
		string DebitMemoFlag = null,
		string CreditMemoFlag = null,
		int? DisplayTotals = null,
		int? SortBy = null,
		int? DisplayHeader = null,
		int? SeparateDrCrAmounts = null,
		string SessionIDChar = null,
		string ToSite = null,
		string StartBuilderInvNum = null,
		string EndBuilderInvNum = null,
		string PSite = null,
		decimal? UserId = null)
		{
			CustNumType _StartingCustNum = StartingCustNum;
			CustNumType _EndingCustNum = EndingCustNum;
			InvNumType _InvNumStarting = InvNumStarting;
			InvNumType _InvNumEnding = InvNumEnding;
			DateTimeType _InvoiceDateStarting = InvoiceDateStarting;
			DateTimeType _InvoiceDateEnding = InvoiceDateEnding;
			DateTimeType _DueDateStarting = DueDateStarting;
			DateTimeType _DueDateEnding = DueDateEnding;
			StringType _InvoiceFlag = InvoiceFlag;
			StringType _DebitMemoFlag = DebitMemoFlag;
			StringType _CreditMemoFlag = CreditMemoFlag;
			ListYesNoType _DisplayTotals = DisplayTotals;
			ListYesNoType _SortBy = SortBy;
			ListYesNoType _DisplayHeader = DisplayHeader;
			ListYesNoType _SeparateDrCrAmounts = SeparateDrCrAmounts;
			StringType _SessionIDChar = SessionIDChar;
			SiteType _ToSite = ToSite;
			BuilderInvNumType _StartBuilderInvNum = StartBuilderInvNum;
			BuilderInvNumType _EndBuilderInvNum = EndBuilderInvNum;
			SiteType _PSite = PSite;
			TokenType _UserId = UserId;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "InvPostingBGSp";
				
				appDB.AddCommandParameter(cmd, "StartingCustNum", _StartingCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingCustNum", _EndingCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvNumStarting", _InvNumStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvNumEnding", _InvNumEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvoiceDateStarting", _InvoiceDateStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvoiceDateEnding", _InvoiceDateEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DueDateStarting", _DueDateStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DueDateEnding", _DueDateEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvoiceFlag", _InvoiceFlag, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DebitMemoFlag", _DebitMemoFlag, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CreditMemoFlag", _CreditMemoFlag, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayTotals", _DisplayTotals, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SortBy", _SortBy, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayHeader", _DisplayHeader, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SeparateDrCrAmounts", _SeparateDrCrAmounts, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SessionIDChar", _SessionIDChar, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToSite", _ToSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartBuilderInvNum", _StartBuilderInvNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndBuilderInvNum", _EndBuilderInvNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSite", _PSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UserId", _UserId, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
