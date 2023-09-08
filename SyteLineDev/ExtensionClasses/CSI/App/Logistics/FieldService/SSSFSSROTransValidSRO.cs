//PROJECT NAME: Logistics
//CLASS NAME: SSSFSSROTransValidSRO.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSSROTransValidSRO : ISSSFSSROTransValidSRO
	{
		readonly IApplicationDB appDB;
		
		public SSSFSSROTransValidSRO(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Item,
			int? SROLine,
			int? SROOper,
			DateTime? TransDate,
			DateTime? PostDate,
			string PartnerID,
			string Dept,
			string Whse,
			string BillCode,
			string TaxCode1,
			string TaxCode2,
			string VatLabel,
			string PriceCurrCode,
			string Prompt,
			string PromptButtons,
			string Infobar,
			string SROCustNum) SSSFSSROTransValidSROSp(
			string Table,
			string Level,
			string Item,
			string SRONum,
			int? SROLine,
			int? SROOper,
			DateTime? TransDate,
			DateTime? PostDate,
			string PartnerID,
			string Dept,
			string Whse,
			string BillCode,
			string TaxCode1,
			string TaxCode2,
			string VatLabel,
			string PriceCurrCode,
			string Prompt,
			string PromptButtons,
			string Infobar,
			string SROCustNum)
		{
			StringType _Table = Table;
			StringType _Level = Level;
			ItemType _Item = Item;
			FSSRONumType _SRONum = SRONum;
			FSSROLineType _SROLine = SROLine;
			FSSROOperType _SROOper = SROOper;
			DateType _TransDate = TransDate;
			DateType _PostDate = PostDate;
			FSPartnerType _PartnerID = PartnerID;
			DeptType _Dept = Dept;
			WhseType _Whse = Whse;
			FSSROBillCodeType _BillCode = BillCode;
			TaxCodeType _TaxCode1 = TaxCode1;
			TaxCodeType _TaxCode2 = TaxCode2;
			StringType _VatLabel = VatLabel;
			CurrCodeType _PriceCurrCode = PriceCurrCode;
			InfobarType _Prompt = Prompt;
			InfobarType _PromptButtons = PromptButtons;
			InfobarType _Infobar = Infobar;
			CustNumType _SROCustNum = SROCustNum;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSSROTransValidSROSp";
				
				appDB.AddCommandParameter(cmd, "Table", _Table, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Level", _Level, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "SRONum", _SRONum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SROLine", _SROLine, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "SROOper", _SROOper, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TransDate", _TransDate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PostDate", _PostDate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PartnerID", _PartnerID, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Dept", _Dept, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "BillCode", _BillCode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TaxCode1", _TaxCode1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TaxCode2", _TaxCode2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "VatLabel", _VatLabel, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PriceCurrCode", _PriceCurrCode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Prompt", _Prompt, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptButtons", _PromptButtons, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "SROCustNum", _SROCustNum, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Item = _Item;
				SROLine = _SROLine;
				SROOper = _SROOper;
				TransDate = _TransDate;
				PostDate = _PostDate;
				PartnerID = _PartnerID;
				Dept = _Dept;
				Whse = _Whse;
				BillCode = _BillCode;
				TaxCode1 = _TaxCode1;
				TaxCode2 = _TaxCode2;
				VatLabel = _VatLabel;
				PriceCurrCode = _PriceCurrCode;
				Prompt = _Prompt;
				PromptButtons = _PromptButtons;
				Infobar = _Infobar;
				SROCustNum = _SROCustNum;
				
				return (Severity, Item, SROLine, SROOper, TransDate, PostDate, PartnerID, Dept, Whse, BillCode, TaxCode1, TaxCode2, VatLabel, PriceCurrCode, Prompt, PromptButtons, Infobar, SROCustNum);
			}
		}
	}
}
