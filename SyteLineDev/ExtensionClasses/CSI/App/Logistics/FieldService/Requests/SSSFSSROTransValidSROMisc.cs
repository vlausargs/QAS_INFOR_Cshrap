//PROJECT NAME: Logistics
//CLASS NAME: SSSFSSROTransValidSROMisc.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService.Requests
{
	public class SSSFSSROTransValidSROMisc : ISSSFSSROTransValidSROMisc
	{
		readonly IApplicationDB appDB;
		
		
		public SSSFSSROTransValidSROMisc(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? SROLine,
		int? SROOper,
		DateTime? TransDate,
		DateTime? PostDate,
		string PartnerID,
		string PartnerCurrCode,
		string Dept,
		string Whse,
		string BillCode,
		string MiscCode,
		string MiscCodeDesc,
		decimal? UnitCost,
		decimal? UnitPrice,
		string TaxCode1,
		string TaxCode2,
		string VatLabel,
		string PriceCurrCode,
		string Prompt,
		string PromptButtons,
		decimal? Disc,
		string Infobar,
		string CurAmtFormat,
		string CurCstPrcFormat,
		string ReimbTaxCode1,
		string ReimbTaxCode2,
		string ReimbMethod) SSSFSSROTransValidSROMiscSp(string Table,
		string Level,
		string SRONum,
		int? SROLine,
		int? SROOper,
		DateTime? TransDate,
		DateTime? PostDate,
		string PartnerID,
		string PartnerCurrCode,
		string Dept,
		string Whse,
		string BillCode,
		string MiscCode,
		string MiscCodeDesc,
		decimal? UnitCost,
		decimal? UnitPrice,
		string TaxCode1,
		string TaxCode2,
		string VatLabel,
		string PriceCurrCode,
		string Prompt,
		string PromptButtons,
		decimal? Disc,
		string Infobar,
		string CurAmtFormat,
		string CurCstPrcFormat,
		string Type = "A",
		string ReimbTaxCode1 = null,
		string ReimbTaxCode2 = null,
		string ReimbMethod = null)
		{
			StringType _Table = Table;
			StringType _Level = Level;
			FSSRONumType _SRONum = SRONum;
			FSSROLineType _SROLine = SROLine;
			FSSROOperType _SROOper = SROOper;
			DateType _TransDate = TransDate;
			DateType _PostDate = PostDate;
			FSPartnerType _PartnerID = PartnerID;
			CurrCodeType _PartnerCurrCode = PartnerCurrCode;
			DeptType _Dept = Dept;
			WhseType _Whse = Whse;
			FSSROBillCodeType _BillCode = BillCode;
			FSMiscCodeType _MiscCode = MiscCode;
			DescriptionType _MiscCodeDesc = MiscCodeDesc;
			CostPrcType _UnitCost = UnitCost;
			CostPrcType _UnitPrice = UnitPrice;
			TaxCodeType _TaxCode1 = TaxCode1;
			TaxCodeType _TaxCode2 = TaxCode2;
			StringType _VatLabel = VatLabel;
			CurrCodeType _PriceCurrCode = PriceCurrCode;
			InfobarType _Prompt = Prompt;
			InfobarType _PromptButtons = PromptButtons;
			FSPctType _Disc = Disc;
			InfobarType _Infobar = Infobar;
			InputMaskType _CurAmtFormat = CurAmtFormat;
			InputMaskType _CurCstPrcFormat = CurCstPrcFormat;
			StringType _Type = Type;
			TaxCodeType _ReimbTaxCode1 = ReimbTaxCode1;
			TaxCodeType _ReimbTaxCode2 = ReimbTaxCode2;
			FSReimbMethodType _ReimbMethod = ReimbMethod;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSSROTransValidSROMiscSp";
				
				appDB.AddCommandParameter(cmd, "Table", _Table, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Level", _Level, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SRONum", _SRONum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SROLine", _SROLine, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "SROOper", _SROOper, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TransDate", _TransDate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PostDate", _PostDate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PartnerID", _PartnerID, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PartnerCurrCode", _PartnerCurrCode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Dept", _Dept, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "BillCode", _BillCode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "MiscCode", _MiscCode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "MiscCodeDesc", _MiscCodeDesc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UnitCost", _UnitCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UnitPrice", _UnitPrice, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TaxCode1", _TaxCode1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TaxCode2", _TaxCode2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "VatLabel", _VatLabel, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PriceCurrCode", _PriceCurrCode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Prompt", _Prompt, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptButtons", _PromptButtons, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Disc", _Disc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CurAmtFormat", _CurAmtFormat, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CurCstPrcFormat", _CurCstPrcFormat, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Type", _Type, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ReimbTaxCode1", _ReimbTaxCode1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ReimbTaxCode2", _ReimbTaxCode2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ReimbMethod", _ReimbMethod, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				SROLine = _SROLine;
				SROOper = _SROOper;
				TransDate = _TransDate;
				PostDate = _PostDate;
				PartnerID = _PartnerID;
				PartnerCurrCode = _PartnerCurrCode;
				Dept = _Dept;
				Whse = _Whse;
				BillCode = _BillCode;
				MiscCode = _MiscCode;
				MiscCodeDesc = _MiscCodeDesc;
				UnitCost = _UnitCost;
				UnitPrice = _UnitPrice;
				TaxCode1 = _TaxCode1;
				TaxCode2 = _TaxCode2;
				VatLabel = _VatLabel;
				PriceCurrCode = _PriceCurrCode;
				Prompt = _Prompt;
				PromptButtons = _PromptButtons;
				Disc = _Disc;
				Infobar = _Infobar;
				CurAmtFormat = _CurAmtFormat;
				CurCstPrcFormat = _CurCstPrcFormat;
				ReimbTaxCode1 = _ReimbTaxCode1;
				ReimbTaxCode2 = _ReimbTaxCode2;
				ReimbMethod = _ReimbMethod;
				
				return (Severity, SROLine, SROOper, TransDate, PostDate, PartnerID, PartnerCurrCode, Dept, Whse, BillCode, MiscCode, MiscCodeDesc, UnitCost, UnitPrice, TaxCode1, TaxCode2, VatLabel, PriceCurrCode, Prompt, PromptButtons, Disc, Infobar, CurAmtFormat, CurCstPrcFormat, ReimbTaxCode1, ReimbTaxCode2, ReimbMethod);
			}
		}
	}
}
