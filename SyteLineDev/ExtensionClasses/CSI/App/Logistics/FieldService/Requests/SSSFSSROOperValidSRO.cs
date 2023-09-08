//PROJECT NAME: Logistics
//CLASS NAME: SSSFSSROOperValidSRO.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService.Requests
{
	public interface ISSSFSSROOperValidSRO
	{
		(int? ReturnCode, string SRODesc, string SROCustNum, int? SROCustSeq, string SROCustName, byte? SROAllowPartial, string SROStat, int? SROLine, string LineUnit, string LineStat, string LineItem, decimal? LineQtyConv, string LineUM, string ProductCode, string Whse, string BillCode, string BillType, string Stat, string CGSLabor, string CGSMatl, string CGSMisc, byte? AccumWIP, byte? PlanTransReq, byte? UsePlanPricing, string PartnerId, string Pricecode, byte? ExtendMatl, byte? ExtendLbr, byte? ExtendMisc, string TaxCode1, string TaxCode2, string Dept, string Infobar, string SROBillCustName) SSSFSSROOperValidSROSp(string SRONum,
		int? Level,
		string SRODesc,
		string SROCustNum,
		int? SROCustSeq,
		string SROCustName,
		byte? SROAllowPartial,
		string SROStat,
		int? SROLine,
		string LineUnit,
		string LineStat,
		string LineItem,
		decimal? LineQtyConv,
		string LineUM,
		string ProductCode,
		string Whse,
		string BillCode,
		string BillType,
		string Stat,
		string CGSLabor,
		string CGSMatl,
		string CGSMisc,
		byte? AccumWIP,
		byte? PlanTransReq,
		byte? UsePlanPricing,
		string PartnerId,
		string Pricecode,
		byte? ExtendMatl,
		byte? ExtendLbr,
		byte? ExtendMisc,
		string TaxCode1,
		string TaxCode2,
		string Dept,
		string Infobar,
		string SROBillCustName = null);
	}
	
	public class SSSFSSROOperValidSRO : ISSSFSSROOperValidSRO
	{
		readonly IApplicationDB appDB;
		
		public SSSFSSROOperValidSRO(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string SRODesc, string SROCustNum, int? SROCustSeq, string SROCustName, byte? SROAllowPartial, string SROStat, int? SROLine, string LineUnit, string LineStat, string LineItem, decimal? LineQtyConv, string LineUM, string ProductCode, string Whse, string BillCode, string BillType, string Stat, string CGSLabor, string CGSMatl, string CGSMisc, byte? AccumWIP, byte? PlanTransReq, byte? UsePlanPricing, string PartnerId, string Pricecode, byte? ExtendMatl, byte? ExtendLbr, byte? ExtendMisc, string TaxCode1, string TaxCode2, string Dept, string Infobar, string SROBillCustName) SSSFSSROOperValidSROSp(string SRONum,
		int? Level,
		string SRODesc,
		string SROCustNum,
		int? SROCustSeq,
		string SROCustName,
		byte? SROAllowPartial,
		string SROStat,
		int? SROLine,
		string LineUnit,
		string LineStat,
		string LineItem,
		decimal? LineQtyConv,
		string LineUM,
		string ProductCode,
		string Whse,
		string BillCode,
		string BillType,
		string Stat,
		string CGSLabor,
		string CGSMatl,
		string CGSMisc,
		byte? AccumWIP,
		byte? PlanTransReq,
		byte? UsePlanPricing,
		string PartnerId,
		string Pricecode,
		byte? ExtendMatl,
		byte? ExtendLbr,
		byte? ExtendMisc,
		string TaxCode1,
		string TaxCode2,
		string Dept,
		string Infobar,
		string SROBillCustName = null)
		{
			FSSRONumType _SRONum = SRONum;
			IntType _Level = Level;
			DescriptionType _SRODesc = SRODesc;
			CustNumType _SROCustNum = SROCustNum;
			CustSeqType _SROCustSeq = SROCustSeq;
			NameType _SROCustName = SROCustName;
			ListYesNoType _SROAllowPartial = SROAllowPartial;
			FSSROStatType _SROStat = SROStat;
			FSSROLineType _SROLine = SROLine;
			SerNumType _LineUnit = LineUnit;
			FSSROStatType _LineStat = LineStat;
			ItemType _LineItem = LineItem;
			QtyUnitType _LineQtyConv = LineQtyConv;
			UMType _LineUM = LineUM;
			ProductCodeType _ProductCode = ProductCode;
			WhseType _Whse = Whse;
			FSSROBillCodeType _BillCode = BillCode;
			FSSROBillTypeType _BillType = BillType;
			FSSROStatType _Stat = Stat;
			FSCgsRevLocType _CGSLabor = CGSLabor;
			FSCgsRevLocType _CGSMatl = CGSMatl;
			FSCgsRevLocType _CGSMisc = CGSMisc;
			ListYesNoType _AccumWIP = AccumWIP;
			ListYesNoType _PlanTransReq = PlanTransReq;
			ListYesNoType _UsePlanPricing = UsePlanPricing;
			FSPartnerType _PartnerId = PartnerId;
			PriceCodeType _Pricecode = Pricecode;
			ListYesNoType _ExtendMatl = ExtendMatl;
			ListYesNoType _ExtendLbr = ExtendLbr;
			ListYesNoType _ExtendMisc = ExtendMisc;
			TaxCodeType _TaxCode1 = TaxCode1;
			TaxCodeType _TaxCode2 = TaxCode2;
			DeptType _Dept = Dept;
			Infobar _Infobar = Infobar;
			NameType _SROBillCustName = SROBillCustName;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSSROOperValidSROSp";
				
				appDB.AddCommandParameter(cmd, "SRONum", _SRONum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Level", _Level, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SRODesc", _SRODesc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "SROCustNum", _SROCustNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "SROCustSeq", _SROCustSeq, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "SROCustName", _SROCustName, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "SROAllowPartial", _SROAllowPartial, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "SROStat", _SROStat, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "SROLine", _SROLine, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "LineUnit", _LineUnit, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "LineStat", _LineStat, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "LineItem", _LineItem, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "LineQtyConv", _LineQtyConv, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "LineUM", _LineUM, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ProductCode", _ProductCode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "BillCode", _BillCode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "BillType", _BillType, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Stat", _Stat, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CGSLabor", _CGSLabor, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CGSMatl", _CGSMatl, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CGSMisc", _CGSMisc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "AccumWIP", _AccumWIP, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PlanTransReq", _PlanTransReq, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UsePlanPricing", _UsePlanPricing, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PartnerId", _PartnerId, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Pricecode", _Pricecode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ExtendMatl", _ExtendMatl, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ExtendLbr", _ExtendLbr, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ExtendMisc", _ExtendMisc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TaxCode1", _TaxCode1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TaxCode2", _TaxCode2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Dept", _Dept, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "SROBillCustName", _SROBillCustName, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				SRODesc = _SRODesc;
				SROCustNum = _SROCustNum;
				SROCustSeq = _SROCustSeq;
				SROCustName = _SROCustName;
				SROAllowPartial = _SROAllowPartial;
				SROStat = _SROStat;
				SROLine = _SROLine;
				LineUnit = _LineUnit;
				LineStat = _LineStat;
				LineItem = _LineItem;
				LineQtyConv = _LineQtyConv;
				LineUM = _LineUM;
				ProductCode = _ProductCode;
				Whse = _Whse;
				BillCode = _BillCode;
				BillType = _BillType;
				Stat = _Stat;
				CGSLabor = _CGSLabor;
				CGSMatl = _CGSMatl;
				CGSMisc = _CGSMisc;
				AccumWIP = _AccumWIP;
				PlanTransReq = _PlanTransReq;
				UsePlanPricing = _UsePlanPricing;
				PartnerId = _PartnerId;
				Pricecode = _Pricecode;
				ExtendMatl = _ExtendMatl;
				ExtendLbr = _ExtendLbr;
				ExtendMisc = _ExtendMisc;
				TaxCode1 = _TaxCode1;
				TaxCode2 = _TaxCode2;
				Dept = _Dept;
				Infobar = _Infobar;
				SROBillCustName = _SROBillCustName;
				
				return (Severity, SRODesc, SROCustNum, SROCustSeq, SROCustName, SROAllowPartial, SROStat, SROLine, LineUnit, LineStat, LineItem, LineQtyConv, LineUM, ProductCode, Whse, BillCode, BillType, Stat, CGSLabor, CGSMatl, CGSMisc, AccumWIP, PlanTransReq, UsePlanPricing, PartnerId, Pricecode, ExtendMatl, ExtendLbr, ExtendMisc, TaxCode1, TaxCode2, Dept, Infobar, SROBillCustName);
			}
		}
	}
}
