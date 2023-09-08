//PROJECT NAME: CSICustomer
//CLASS NAME: InvoiceBuilderProcess.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public interface IInvoiceBuilderProcess
	{
		(int? ReturnCode, string PBuilderInvoiceNum, string Infobar) InvoiceBuilderProcessSp(Guid? PProcessID = null,
		string PCustNum = null,
		string InvCred = "I",
		DateTime? PInvoiceDate = null,
		string InvType = "R",
		string FormType = "L",
		string PrintItemCustomerItem = "CI",
		byte? TransToDomCurr = (byte)0,
		byte? PrintSerialNumbers = (byte)1,
		byte? PrintPlanItemMaterial = (byte)0,
		string PrintConfigurationDetail = "N",
		byte? PrintEuro = (byte)0,
		byte? PrintCustomerNotes = (byte)1,
		byte? PrintOrderNotes = (byte)1,
		byte? PrintOrderLineNotes = (byte)1,
		byte? PrintOrderBlanketLineNotes = (byte)1,
		byte? PrintProgressiveBillingNotes = (byte)0,
		byte? PrintInternalNotes = (byte)1,
		byte? PrintExternalNotes = (byte)1,
		byte? PrintItemOverview = (byte)0,
		byte? DisplayHeader = (byte)0,
		byte? PrintLineReleaseDescription = (byte)1,
		byte? PrintStandardOrderText = (byte)1,
		byte? PrintBillToNotes = (byte)1,
		byte? PrintDiscountAmt = (byte)0,
		decimal? UserId = null,
		byte? PrintLotNumbers = (byte)1,
		string CurrentCultureName = null,
		byte? UseProfile = (byte)0,
		byte? NonDraftCust = (byte)0,
		string pSite = null,
		string PBuilderInvoiceNum = null,
		string Infobar = null);
	}
	
	public class InvoiceBuilderProcess : IInvoiceBuilderProcess
	{
		readonly IApplicationDB appDB;
		
		public InvoiceBuilderProcess(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string PBuilderInvoiceNum, string Infobar) InvoiceBuilderProcessSp(Guid? PProcessID = null,
		string PCustNum = null,
		string InvCred = "I",
		DateTime? PInvoiceDate = null,
		string InvType = "R",
		string FormType = "L",
		string PrintItemCustomerItem = "CI",
		byte? TransToDomCurr = (byte)0,
		byte? PrintSerialNumbers = (byte)1,
		byte? PrintPlanItemMaterial = (byte)0,
		string PrintConfigurationDetail = "N",
		byte? PrintEuro = (byte)0,
		byte? PrintCustomerNotes = (byte)1,
		byte? PrintOrderNotes = (byte)1,
		byte? PrintOrderLineNotes = (byte)1,
		byte? PrintOrderBlanketLineNotes = (byte)1,
		byte? PrintProgressiveBillingNotes = (byte)0,
		byte? PrintInternalNotes = (byte)1,
		byte? PrintExternalNotes = (byte)1,
		byte? PrintItemOverview = (byte)0,
		byte? DisplayHeader = (byte)0,
		byte? PrintLineReleaseDescription = (byte)1,
		byte? PrintStandardOrderText = (byte)1,
		byte? PrintBillToNotes = (byte)1,
		byte? PrintDiscountAmt = (byte)0,
		decimal? UserId = null,
		byte? PrintLotNumbers = (byte)1,
		string CurrentCultureName = null,
		byte? UseProfile = (byte)0,
		byte? NonDraftCust = (byte)0,
		string pSite = null,
		string PBuilderInvoiceNum = null,
		string Infobar = null)
		{
			RowPointerType _PProcessID = PProcessID;
			CustNumType _PCustNum = PCustNum;
			InvoiceTypeType _InvCred = InvCred;
			DateType _PInvoiceDate = PInvoiceDate;
			StringType _InvType = InvType;
			StringType _FormType = FormType;
			StringType _PrintItemCustomerItem = PrintItemCustomerItem;
			ListYesNoType _TransToDomCurr = TransToDomCurr;
			ListYesNoType _PrintSerialNumbers = PrintSerialNumbers;
			ListYesNoType _PrintPlanItemMaterial = PrintPlanItemMaterial;
			StringType _PrintConfigurationDetail = PrintConfigurationDetail;
			ListYesNoType _PrintEuro = PrintEuro;
			ListYesNoType _PrintCustomerNotes = PrintCustomerNotes;
			ListYesNoType _PrintOrderNotes = PrintOrderNotes;
			ListYesNoType _PrintOrderLineNotes = PrintOrderLineNotes;
			ListYesNoType _PrintOrderBlanketLineNotes = PrintOrderBlanketLineNotes;
			ListYesNoType _PrintProgressiveBillingNotes = PrintProgressiveBillingNotes;
			ListYesNoType _PrintInternalNotes = PrintInternalNotes;
			ListYesNoType _PrintExternalNotes = PrintExternalNotes;
			ListYesNoType _PrintItemOverview = PrintItemOverview;
			ListYesNoType _DisplayHeader = DisplayHeader;
			ListYesNoType _PrintLineReleaseDescription = PrintLineReleaseDescription;
			ListYesNoType _PrintStandardOrderText = PrintStandardOrderText;
			ListYesNoType _PrintBillToNotes = PrintBillToNotes;
			ListYesNoType _PrintDiscountAmt = PrintDiscountAmt;
			TokenType _UserId = UserId;
			ListYesNoType _PrintLotNumbers = PrintLotNumbers;
			LanguageIDType _CurrentCultureName = CurrentCultureName;
			ListYesNoType _UseProfile = UseProfile;
			ListYesNoType _NonDraftCust = NonDraftCust;
			SiteType _pSite = pSite;
			BuilderInvNumType _PBuilderInvoiceNum = PBuilderInvoiceNum;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "InvoiceBuilderProcessSp";
				
				appDB.AddCommandParameter(cmd, "PProcessID", _PProcessID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCustNum", _PCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvCred", _InvCred, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PInvoiceDate", _PInvoiceDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvType", _InvType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FormType", _FormType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintItemCustomerItem", _PrintItemCustomerItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransToDomCurr", _TransToDomCurr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintSerialNumbers", _PrintSerialNumbers, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintPlanItemMaterial", _PrintPlanItemMaterial, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintConfigurationDetail", _PrintConfigurationDetail, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintEuro", _PrintEuro, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintCustomerNotes", _PrintCustomerNotes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintOrderNotes", _PrintOrderNotes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintOrderLineNotes", _PrintOrderLineNotes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintOrderBlanketLineNotes", _PrintOrderBlanketLineNotes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintProgressiveBillingNotes", _PrintProgressiveBillingNotes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintInternalNotes", _PrintInternalNotes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintExternalNotes", _PrintExternalNotes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintItemOverview", _PrintItemOverview, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayHeader", _DisplayHeader, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintLineReleaseDescription", _PrintLineReleaseDescription, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintStandardOrderText", _PrintStandardOrderText, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintBillToNotes", _PrintBillToNotes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintDiscountAmt", _PrintDiscountAmt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UserId", _UserId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintLotNumbers", _PrintLotNumbers, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CurrentCultureName", _CurrentCultureName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UseProfile", _UseProfile, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NonDraftCust", _NonDraftCust, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pSite", _pSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PBuilderInvoiceNum", _PBuilderInvoiceNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PBuilderInvoiceNum = _PBuilderInvoiceNum;
				Infobar = _Infobar;
				
				return (Severity, PBuilderInvoiceNum, Infobar);
			}
		}
	}
}
