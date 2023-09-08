//PROJECT NAME: CSICustomer
//CLASS NAME: InvoiceBuilderReprint.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public interface IInvoiceBuilderReprint
	{
		(int? ReturnCode, string Infobar) InvoiceBuilderReprintSp(string pSessionIDChar = null,
		string BGSessionID = "",
		string InvType = "R",
		string CustNum = null,
		DateTime? InvoiceDate = null,
		string ToSite = null,
		string StartInvNum = null,
		string EndInvNum = null,
		DateTime? StartInvDate = null,
		DateTime? EndInvDate = null,
		string StartBuilderInvNum = null,
		string EndBuilderInvNum = null,
		string PrintConfigurationDetail = "N",
		string PrintItemCustomerItem = "CI",
		byte? PrintOrderBlanketLineNotes = (byte)1,
		byte? DisplayHeader = (byte)0,
		byte? PrintPlanItemMaterial = (byte)0,
		byte? PrintEuro = (byte)0,
		byte? TransToDomCurr = (byte)0,
		byte? PrintLineReleaseDescription = (byte)1,
		byte? PrintDiscountAmt = (byte)0,
		byte? PrintSerialNumbers = (byte)1,
		byte? PrintLotNumbers = (byte)1,
		byte? PrintLineReleaseNotes = (byte)1,
		byte? PrintStandardOrderText = (byte)1,
		byte? PrintOrderNotes = (byte)1,
		byte? PrintCustomerNotes = (byte)1,
		byte? PrintBillToNotes = (byte)1,
		byte? PrintProgressiveBillingNotes = (byte)0,
		byte? PrintInternalNotes = (byte)1,
		byte? PrintExternalNotes = (byte)1,
		byte? PrintItemOverview = (byte)0,
		string InvCred = "I",
		string FormType = "L",
		byte? UseProfile = (byte)0,
		byte? NonDraftCust = (byte)0,
		string CurrentCultureName = null,
		string pSite = null,
		decimal? UserId = null,
		string Infobar = null);
	}
	
	public class InvoiceBuilderReprint : IInvoiceBuilderReprint
	{
		readonly IApplicationDB appDB;
		
		public InvoiceBuilderReprint(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) InvoiceBuilderReprintSp(string pSessionIDChar = null,
		string BGSessionID = "",
		string InvType = "R",
		string CustNum = null,
		DateTime? InvoiceDate = null,
		string ToSite = null,
		string StartInvNum = null,
		string EndInvNum = null,
		DateTime? StartInvDate = null,
		DateTime? EndInvDate = null,
		string StartBuilderInvNum = null,
		string EndBuilderInvNum = null,
		string PrintConfigurationDetail = "N",
		string PrintItemCustomerItem = "CI",
		byte? PrintOrderBlanketLineNotes = (byte)1,
		byte? DisplayHeader = (byte)0,
		byte? PrintPlanItemMaterial = (byte)0,
		byte? PrintEuro = (byte)0,
		byte? TransToDomCurr = (byte)0,
		byte? PrintLineReleaseDescription = (byte)1,
		byte? PrintDiscountAmt = (byte)0,
		byte? PrintSerialNumbers = (byte)1,
		byte? PrintLotNumbers = (byte)1,
		byte? PrintLineReleaseNotes = (byte)1,
		byte? PrintStandardOrderText = (byte)1,
		byte? PrintOrderNotes = (byte)1,
		byte? PrintCustomerNotes = (byte)1,
		byte? PrintBillToNotes = (byte)1,
		byte? PrintProgressiveBillingNotes = (byte)0,
		byte? PrintInternalNotes = (byte)1,
		byte? PrintExternalNotes = (byte)1,
		byte? PrintItemOverview = (byte)0,
		string InvCred = "I",
		string FormType = "L",
		byte? UseProfile = (byte)0,
		byte? NonDraftCust = (byte)0,
		string CurrentCultureName = null,
		string pSite = null,
		decimal? UserId = null,
		string Infobar = null)
		{
			StringType _pSessionIDChar = pSessionIDChar;
			StringType _BGSessionID = BGSessionID;
			StringType _InvType = InvType;
			CustNumType _CustNum = CustNum;
			DateType _InvoiceDate = InvoiceDate;
			SiteType _ToSite = ToSite;
			InvNumType _StartInvNum = StartInvNum;
			InvNumType _EndInvNum = EndInvNum;
			DateType _StartInvDate = StartInvDate;
			DateType _EndInvDate = EndInvDate;
			BuilderInvNumType _StartBuilderInvNum = StartBuilderInvNum;
			BuilderInvNumType _EndBuilderInvNum = EndBuilderInvNum;
			StringType _PrintConfigurationDetail = PrintConfigurationDetail;
			StringType _PrintItemCustomerItem = PrintItemCustomerItem;
			ListYesNoType _PrintOrderBlanketLineNotes = PrintOrderBlanketLineNotes;
			ListYesNoType _DisplayHeader = DisplayHeader;
			ListYesNoType _PrintPlanItemMaterial = PrintPlanItemMaterial;
			ListYesNoType _PrintEuro = PrintEuro;
			ListYesNoType _TransToDomCurr = TransToDomCurr;
			ListYesNoType _PrintLineReleaseDescription = PrintLineReleaseDescription;
			ListYesNoType _PrintDiscountAmt = PrintDiscountAmt;
			ListYesNoType _PrintSerialNumbers = PrintSerialNumbers;
			ListYesNoType _PrintLotNumbers = PrintLotNumbers;
			ListYesNoType _PrintLineReleaseNotes = PrintLineReleaseNotes;
			ListYesNoType _PrintStandardOrderText = PrintStandardOrderText;
			ListYesNoType _PrintOrderNotes = PrintOrderNotes;
			ListYesNoType _PrintCustomerNotes = PrintCustomerNotes;
			ListYesNoType _PrintBillToNotes = PrintBillToNotes;
			ListYesNoType _PrintProgressiveBillingNotes = PrintProgressiveBillingNotes;
			ListYesNoType _PrintInternalNotes = PrintInternalNotes;
			ListYesNoType _PrintExternalNotes = PrintExternalNotes;
			ListYesNoType _PrintItemOverview = PrintItemOverview;
			StringType _InvCred = InvCred;
			StringType _FormType = FormType;
			ListYesNoType _UseProfile = UseProfile;
			ListYesNoType _NonDraftCust = NonDraftCust;
			LanguageIDType _CurrentCultureName = CurrentCultureName;
			SiteType _pSite = pSite;
			TokenType _UserId = UserId;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "InvoiceBuilderReprintSp";
				
				appDB.AddCommandParameter(cmd, "pSessionIDChar", _pSessionIDChar, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BGSessionID", _BGSessionID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvType", _InvType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvoiceDate", _InvoiceDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToSite", _ToSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartInvNum", _StartInvNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndInvNum", _EndInvNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartInvDate", _StartInvDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndInvDate", _EndInvDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartBuilderInvNum", _StartBuilderInvNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndBuilderInvNum", _EndBuilderInvNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintConfigurationDetail", _PrintConfigurationDetail, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintItemCustomerItem", _PrintItemCustomerItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintOrderBlanketLineNotes", _PrintOrderBlanketLineNotes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayHeader", _DisplayHeader, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintPlanItemMaterial", _PrintPlanItemMaterial, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintEuro", _PrintEuro, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransToDomCurr", _TransToDomCurr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintLineReleaseDescription", _PrintLineReleaseDescription, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintDiscountAmt", _PrintDiscountAmt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintSerialNumbers", _PrintSerialNumbers, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintLotNumbers", _PrintLotNumbers, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintLineReleaseNotes", _PrintLineReleaseNotes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintStandardOrderText", _PrintStandardOrderText, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintOrderNotes", _PrintOrderNotes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintCustomerNotes", _PrintCustomerNotes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintBillToNotes", _PrintBillToNotes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintProgressiveBillingNotes", _PrintProgressiveBillingNotes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintInternalNotes", _PrintInternalNotes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintExternalNotes", _PrintExternalNotes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintItemOverview", _PrintItemOverview, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvCred", _InvCred, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FormType", _FormType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UseProfile", _UseProfile, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NonDraftCust", _NonDraftCust, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CurrentCultureName", _CurrentCultureName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pSite", _pSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UserId", _UserId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
