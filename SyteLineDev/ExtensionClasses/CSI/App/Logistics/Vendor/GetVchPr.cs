//PROJECT NAME: CSIVendor
//CLASS NAME: GetVchPr.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public interface IGetVchPr
	{
		int GetVchPrSp(int? PPreRegister,
		               string PVendNum,
		               ref decimal? RPurchAmt,
		               ref decimal? RFreight,
		               ref decimal? RMiscCharges,
		               ref decimal? RSalesTax,
		               ref decimal? RSalesTax2,
		               ref string RInvNum,
		               ref DateTime? RInvDate,
		               ref string Infobar);
	}
	
	public class GetVchPr : IGetVchPr
	{
		readonly IApplicationDB appDB;
		
		public GetVchPr(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int GetVchPrSp(int? PPreRegister,
		                      string PVendNum,
		                      ref decimal? RPurchAmt,
		                      ref decimal? RFreight,
		                      ref decimal? RMiscCharges,
		                      ref decimal? RSalesTax,
		                      ref decimal? RSalesTax2,
		                      ref string RInvNum,
		                      ref DateTime? RInvDate,
		                      ref string Infobar)
		{
			PreRegisterType _PPreRegister = PPreRegister;
			VendNumType _PVendNum = PVendNum;
			AmountType _RPurchAmt = RPurchAmt;
			AmountType _RFreight = RFreight;
			AmountType _RMiscCharges = RMiscCharges;
			AmountType _RSalesTax = RSalesTax;
			AmountType _RSalesTax2 = RSalesTax2;
			VendInvoiceType _RInvNum = RInvNum;
			DateType _RInvDate = RInvDate;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetVchPrSp";
				
				appDB.AddCommandParameter(cmd, "PPreRegister", _PPreRegister, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PVendNum", _PVendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RPurchAmt", _RPurchAmt, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "RFreight", _RFreight, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "RMiscCharges", _RMiscCharges, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "RSalesTax", _RSalesTax, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "RSalesTax2", _RSalesTax2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "RInvNum", _RInvNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "RInvDate", _RInvDate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				RPurchAmt = _RPurchAmt;
				RFreight = _RFreight;
				RMiscCharges = _RMiscCharges;
				RSalesTax = _RSalesTax;
				RSalesTax2 = _RSalesTax2;
				RInvNum = _RInvNum;
				RInvDate = _RInvDate;
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
