//PROJECT NAME: Data
//CLASS NAME: InvPrt2.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class InvPrt2 : IInvPrt2
	{
		readonly IApplicationDB appDB;
		
		public InvPrt2(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			decimal? TSubPrice,
			decimal? TDiscCiPrice,
			string TPrintInvNum,
			decimal? TEuroTotal,
			string Infobar,
			int? PrintEuro) InvPrt2Sp(
			int? Progressive = 0,
			string Mode = "REPRINT",
			decimal? TSubPrice = 0,
			decimal? TDiscCiPrice = 0,
			string TPrintInvNum = "0",
			decimal? TEuroTotal = 0,
			int? TransToDomCurr = 1,
			string PrintItemCustomerItem = "IC",
			int? PrintSerialNumbers = 0,
			string InvCred = "I",
			int? PrintPlanItemMaterial = 0,
			string PrintConfigurationDetail = "N",
			int? TEuroExists = 0,
			int? PrintOrderLineNotes = 0,
			int? PrintOrderBlanketLineNotes = 0,
			int? PrintProgressiveBillingNotes = 0,
			int? PrintInternalNotes = 0,
			int? PrintExternalNotes = 0,
			int? PrintItemOverview = 0,
			int? PrintLineReleaseDescription = 0,
			string Infobar = null,
			int? PrintEuro = 0,
			int? PrintLotNumbers = 0)
		{
			ListYesNoType _Progressive = Progressive;
			StringType _Mode = Mode;
			AmountType _TSubPrice = TSubPrice;
			AmountType _TDiscCiPrice = TDiscCiPrice;
			InvNumType _TPrintInvNum = TPrintInvNum;
			AmountType _TEuroTotal = TEuroTotal;
			ListYesNoType _TransToDomCurr = TransToDomCurr;
			StringType _PrintItemCustomerItem = PrintItemCustomerItem;
			ListYesNoType _PrintSerialNumbers = PrintSerialNumbers;
			StringType _InvCred = InvCred;
			ListYesNoType _PrintPlanItemMaterial = PrintPlanItemMaterial;
			StringType _PrintConfigurationDetail = PrintConfigurationDetail;
			ListYesNoType _TEuroExists = TEuroExists;
			ListYesNoType _PrintOrderLineNotes = PrintOrderLineNotes;
			ListYesNoType _PrintOrderBlanketLineNotes = PrintOrderBlanketLineNotes;
			ListYesNoType _PrintProgressiveBillingNotes = PrintProgressiveBillingNotes;
			ListYesNoType _PrintInternalNotes = PrintInternalNotes;
			ListYesNoType _PrintExternalNotes = PrintExternalNotes;
			ListYesNoType _PrintItemOverview = PrintItemOverview;
			ListYesNoType _PrintLineReleaseDescription = PrintLineReleaseDescription;
			InfobarType _Infobar = Infobar;
			ListYesNoType _PrintEuro = PrintEuro;
			ListYesNoType _PrintLotNumbers = PrintLotNumbers;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "InvPrt2Sp";
				
				appDB.AddCommandParameter(cmd, "Progressive", _Progressive, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Mode", _Mode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TSubPrice", _TSubPrice, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TDiscCiPrice", _TDiscCiPrice, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TPrintInvNum", _TPrintInvNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TEuroTotal", _TEuroTotal, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TransToDomCurr", _TransToDomCurr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintItemCustomerItem", _PrintItemCustomerItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintSerialNumbers", _PrintSerialNumbers, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvCred", _InvCred, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintPlanItemMaterial", _PrintPlanItemMaterial, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintConfigurationDetail", _PrintConfigurationDetail, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TEuroExists", _TEuroExists, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintOrderLineNotes", _PrintOrderLineNotes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintOrderBlanketLineNotes", _PrintOrderBlanketLineNotes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintProgressiveBillingNotes", _PrintProgressiveBillingNotes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintInternalNotes", _PrintInternalNotes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintExternalNotes", _PrintExternalNotes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintItemOverview", _PrintItemOverview, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintLineReleaseDescription", _PrintLineReleaseDescription, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PrintEuro", _PrintEuro, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PrintLotNumbers", _PrintLotNumbers, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				TSubPrice = _TSubPrice;
				TDiscCiPrice = _TDiscCiPrice;
				TPrintInvNum = _TPrintInvNum;
				TEuroTotal = _TEuroTotal;
				Infobar = _Infobar;
				PrintEuro = _PrintEuro;
				
				return (Severity, TSubPrice, TDiscCiPrice, TPrintInvNum, TEuroTotal, Infobar, PrintEuro);
			}
		}
	}
}
