//PROJECT NAME: Logistics
//CLASS NAME: ManualVoucherBuilderProcess.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class ManualVoucherBuilderProcess : IManualVoucherBuilderProcess
	{
		readonly IApplicationDB appDB;
		
		
		public ManualVoucherBuilderProcess(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? ManualVoucherBuilderProcessSp(string PToSite,
		string PVendNum,
		string PInvNum,
		DateTime? PInvDate,
		DateTime? PDistDate,
		string PTxt,
		int? PGenerateDistributions,
		int? PFixedRate,
		decimal? PExchRate,
		decimal? PPurchAmt,
		decimal? PFreight,
		decimal? PDuty,
		decimal? PBrokerage,
		decimal? PInsurance,
		decimal? PLocFrt,
		decimal? PMiscCharges,
		decimal? PSalesTax,
		decimal? PSalesTax2,
		string PBuilderVoucherOrigSite,
		string PBuilderVoucher,
		DateTime? PTaxDate)
		{
			SiteType _PToSite = PToSite;
			VendNumType _PVendNum = PVendNum;
			VendInvNumType _PInvNum = PInvNum;
			DateType _PInvDate = PInvDate;
			DateType _PDistDate = PDistDate;
			DescriptionType _PTxt = PTxt;
			ListYesNoType _PGenerateDistributions = PGenerateDistributions;
			ListYesNoType _PFixedRate = PFixedRate;
			ExchRateType _PExchRate = PExchRate;
			AmountType _PPurchAmt = PPurchAmt;
			AmountType _PFreight = PFreight;
			AmountType _PDuty = PDuty;
			AmountType _PBrokerage = PBrokerage;
			AmountType _PInsurance = PInsurance;
			AmountType _PLocFrt = PLocFrt;
			AmountType _PMiscCharges = PMiscCharges;
			AmountType _PSalesTax = PSalesTax;
			AmountType _PSalesTax2 = PSalesTax2;
			SiteType _PBuilderVoucherOrigSite = PBuilderVoucherOrigSite;
			BuilderVoucherType _PBuilderVoucher = PBuilderVoucher;
			DateType _PTaxDate = PTaxDate;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ManualVoucherBuilderProcessSp";
				
				appDB.AddCommandParameter(cmd, "PToSite", _PToSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PVendNum", _PVendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PInvNum", _PInvNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PInvDate", _PInvDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PDistDate", _PDistDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTxt", _PTxt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PGenerateDistributions", _PGenerateDistributions, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PFixedRate", _PFixedRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PExchRate", _PExchRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPurchAmt", _PPurchAmt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PFreight", _PFreight, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PDuty", _PDuty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PBrokerage", _PBrokerage, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PInsurance", _PInsurance, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PLocFrt", _PLocFrt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PMiscCharges", _PMiscCharges, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSalesTax", _PSalesTax, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSalesTax2", _PSalesTax2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PBuilderVoucherOrigSite", _PBuilderVoucherOrigSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PBuilderVoucher", _PBuilderVoucher, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTaxDate", _PTaxDate, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
