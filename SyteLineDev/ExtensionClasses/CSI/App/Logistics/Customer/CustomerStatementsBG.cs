//PROJECT NAME: Data
//CLASS NAME: CustomerStatementsBG.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class CustomerStatementsBG : ICustomerStatementsBG
	{
		readonly IApplicationDB appDB;
		
		public CustomerStatementsBG(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? CustomerStatementsBGSp(
			DateTime? StatementDate = null,
			int? ShowActive = null,
			string BeginCustNum = null,
			string EndCustNum = null,
			string SiteGroup = null,
			string StateCycle = null,
			int? PrZeroBal = null,
			int? PrCreditBal = null,
			int? PrAgedTot = null,
			string PrOpenItem2 = null,
			string InvDue = null,
			int? SortByInv = null,
			int? HidePaid = null,
			string StComm1 = null,
			string StComm2 = null,
			int? PrOpenPay = null,
			int? AgeDays1 = null,
			int? AgeDays2 = null,
			int? AgeDays3 = null,
			int? AgeDays4 = null,
			int? AgeDays5 = null,
			string AgeDays1Desc = null,
			string AgeDays2Desc = null,
			string AgeDays3Desc = null,
			string AgeDays4Desc = null,
			string AgeDays5Desc = null,
			int? PrintEuro = null,
			int? StatementDateOffset = null,
			int? DisplayHeader = null,
			string LangCode = null,
			int? UseProfile = null,
			string pSite = null,
			string BGUser = null,
			int? CustStateTemplate = null)
		{
			DateType _StatementDate = StatementDate;
			ListYesNoType _ShowActive = ShowActive;
			CustNumType _BeginCustNum = BeginCustNum;
			CustNumType _EndCustNum = EndCustNum;
			SiteGroupType _SiteGroup = SiteGroup;
			StringType _StateCycle = StateCycle;
			ListYesNoType _PrZeroBal = PrZeroBal;
			ListYesNoType _PrCreditBal = PrCreditBal;
			ListYesNoType _PrAgedTot = PrAgedTot;
			StringType _PrOpenItem2 = PrOpenItem2;
			StringType _InvDue = InvDue;
			ListYesNoType _SortByInv = SortByInv;
			IntType _HidePaid = HidePaid;
			StringType _StComm1 = StComm1;
			StringType _StComm2 = StComm2;
			ListYesNoType _PrOpenPay = PrOpenPay;
			IntType _AgeDays1 = AgeDays1;
			IntType _AgeDays2 = AgeDays2;
			IntType _AgeDays3 = AgeDays3;
			IntType _AgeDays4 = AgeDays4;
			IntType _AgeDays5 = AgeDays5;
			StringType _AgeDays1Desc = AgeDays1Desc;
			StringType _AgeDays2Desc = AgeDays2Desc;
			StringType _AgeDays3Desc = AgeDays3Desc;
			StringType _AgeDays4Desc = AgeDays4Desc;
			StringType _AgeDays5Desc = AgeDays5Desc;
			ListYesNoType _PrintEuro = PrintEuro;
			DateOffsetType _StatementDateOffset = StatementDateOffset;
			ListYesNoType _DisplayHeader = DisplayHeader;
			LangCodeType _LangCode = LangCode;
			ListYesNoType _UseProfile = UseProfile;
			SiteType _pSite = pSite;
			UsernameType _BGUser = BGUser;
			IntType _CustStateTemplate = CustStateTemplate;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CustomerStatementsBGSp";
				
				appDB.AddCommandParameter(cmd, "StatementDate", _StatementDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShowActive", _ShowActive, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BeginCustNum", _BeginCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndCustNum", _EndCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SiteGroup", _SiteGroup, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StateCycle", _StateCycle, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrZeroBal", _PrZeroBal, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrCreditBal", _PrCreditBal, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrAgedTot", _PrAgedTot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrOpenItem2", _PrOpenItem2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvDue", _InvDue, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SortByInv", _SortByInv, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "HidePaid", _HidePaid, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StComm1", _StComm1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StComm2", _StComm2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrOpenPay", _PrOpenPay, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AgeDays1", _AgeDays1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AgeDays2", _AgeDays2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AgeDays3", _AgeDays3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AgeDays4", _AgeDays4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AgeDays5", _AgeDays5, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AgeDays1Desc", _AgeDays1Desc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AgeDays2Desc", _AgeDays2Desc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AgeDays3Desc", _AgeDays3Desc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AgeDays4Desc", _AgeDays4Desc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AgeDays5Desc", _AgeDays5Desc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintEuro", _PrintEuro, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StatementDateOffset", _StatementDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayHeader", _DisplayHeader, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LangCode", _LangCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UseProfile", _UseProfile, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pSite", _pSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BGUser", _BGUser, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustStateTemplate", _CustStateTemplate, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
