//PROJECT NAME: CSIFSPlusSRO
//CLASS NAME: SSSFSSROOperDefaults.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.FieldService.Requests
{
	public interface ISSSFSSROOperDefaults
	{
		int SSSFSSROOperDefaultsSp(string SRONum,
		                           int? SROLine,
		                           ref string ProductCode,
		                           ref string Whse,
		                           ref string BillCode,
		                           ref string BillType,
		                           ref string Stat,
		                           ref string CGSLabor,
		                           ref string CGSMatl,
		                           ref string CGSMisc,
		                           ref byte? AccumWIP,
		                           ref byte? PlanTransReq,
		                           ref byte? UsePlanPricing,
		                           ref string PartnerId,
		                           ref string Pricecode,
		                           ref byte? ExtendMatl,
		                           ref byte? ExtendLbr,
		                           ref byte? ExtendMisc,
		                           ref string TaxCode1,
		                           ref string TaxCode2,
		                           ref string Dept,
		                           ref string Infobar);
	}
	
	public class SSSFSSROOperDefaults : ISSSFSSROOperDefaults
	{
		readonly IApplicationDB appDB;
		
		public SSSFSSROOperDefaults(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int SSSFSSROOperDefaultsSp(string SRONum,
		                                  int? SROLine,
		                                  ref string ProductCode,
		                                  ref string Whse,
		                                  ref string BillCode,
		                                  ref string BillType,
		                                  ref string Stat,
		                                  ref string CGSLabor,
		                                  ref string CGSMatl,
		                                  ref string CGSMisc,
		                                  ref byte? AccumWIP,
		                                  ref byte? PlanTransReq,
		                                  ref byte? UsePlanPricing,
		                                  ref string PartnerId,
		                                  ref string Pricecode,
		                                  ref byte? ExtendMatl,
		                                  ref byte? ExtendLbr,
		                                  ref byte? ExtendMisc,
		                                  ref string TaxCode1,
		                                  ref string TaxCode2,
		                                  ref string Dept,
		                                  ref string Infobar)
		{
			FSSRONumType _SRONum = SRONum;
			FSSROLineType _SROLine = SROLine;
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
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSSROOperDefaultsSp";
				
				appDB.AddCommandParameter(cmd, "SRONum", _SRONum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SROLine", _SROLine, ParameterDirection.Input);
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
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
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
				
				return Severity;
			}
		}
	}
}
