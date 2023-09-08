//PROJECT NAME: CSIVendor
//CLASS NAME: GetAptrx.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public interface IGetAptrx
	{
		int GetAptrxSp(string PVendNum,
		               int? PVoucher,
		               ref string RVendName,
		               ref byte? RPostFromPo,
		               ref string RType,
		               ref string RGrnNum,
		               ref string RInvNum,
		               ref string RTaxCode1,
		               ref string RTaxCode2,
		               ref DateTime? RDistDate,
		               ref string RPoNum,
		               ref int? RPreRegister,
		               ref DateTime? RInvDate,
		               ref decimal? RExchRate,
		               ref string RCurrCode,
		               ref decimal? RPurchAmt,
		               ref decimal? RFreight,
		               ref decimal? RDutyAmt,
		               ref decimal? RBrokerageAmt,
		               ref decimal? RInsuranceAmt,
		               ref decimal? RLocFrtAmt,
		               ref decimal? RMiscCharges,
		               ref decimal? RSalesTax,
		               ref decimal? RSalesTax2,
		               ref decimal? RInvAmt,
		               ref string Infobar);
	}
	
	public class GetAptrx : IGetAptrx
	{
		readonly IApplicationDB appDB;
		
		public GetAptrx(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int GetAptrxSp(string PVendNum,
		                      int? PVoucher,
		                      ref string RVendName,
		                      ref byte? RPostFromPo,
		                      ref string RType,
		                      ref string RGrnNum,
		                      ref string RInvNum,
		                      ref string RTaxCode1,
		                      ref string RTaxCode2,
		                      ref DateTime? RDistDate,
		                      ref string RPoNum,
		                      ref int? RPreRegister,
		                      ref DateTime? RInvDate,
		                      ref decimal? RExchRate,
		                      ref string RCurrCode,
		                      ref decimal? RPurchAmt,
		                      ref decimal? RFreight,
		                      ref decimal? RDutyAmt,
		                      ref decimal? RBrokerageAmt,
		                      ref decimal? RInsuranceAmt,
		                      ref decimal? RLocFrtAmt,
		                      ref decimal? RMiscCharges,
		                      ref decimal? RSalesTax,
		                      ref decimal? RSalesTax2,
		                      ref decimal? RInvAmt,
		                      ref string Infobar)
		{
			VendNumType _PVendNum = PVendNum;
			VoucherType _PVoucher = PVoucher;
			NameType _RVendName = RVendName;
			ListYesNoType _RPostFromPo = RPostFromPo;
			AptrxTypeType _RType = RType;
			GrnNumType _RGrnNum = RGrnNum;
			VendInvNumType _RInvNum = RInvNum;
			TaxCodeType _RTaxCode1 = RTaxCode1;
			TaxCodeType _RTaxCode2 = RTaxCode2;
			DateType _RDistDate = RDistDate;
			PoNumType _RPoNum = RPoNum;
			PreRegisterType _RPreRegister = RPreRegister;
			DateType _RInvDate = RInvDate;
			ExchRateType _RExchRate = RExchRate;
			CurrCodeType _RCurrCode = RCurrCode;
			AmountType _RPurchAmt = RPurchAmt;
			AmountType _RFreight = RFreight;
			AmountType _RDutyAmt = RDutyAmt;
			AmountType _RBrokerageAmt = RBrokerageAmt;
			AmountType _RInsuranceAmt = RInsuranceAmt;
			AmountType _RLocFrtAmt = RLocFrtAmt;
			AmountType _RMiscCharges = RMiscCharges;
			AmountType _RSalesTax = RSalesTax;
			AmountType _RSalesTax2 = RSalesTax2;
			AmountType _RInvAmt = RInvAmt;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetAptrxSp";
				
				appDB.AddCommandParameter(cmd, "PVendNum", _PVendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PVoucher", _PVoucher, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RVendName", _RVendName, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "RPostFromPo", _RPostFromPo, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "RType", _RType, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "RGrnNum", _RGrnNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "RInvNum", _RInvNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "RTaxCode1", _RTaxCode1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "RTaxCode2", _RTaxCode2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "RDistDate", _RDistDate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "RPoNum", _RPoNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "RPreRegister", _RPreRegister, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "RInvDate", _RInvDate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "RExchRate", _RExchRate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "RCurrCode", _RCurrCode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "RPurchAmt", _RPurchAmt, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "RFreight", _RFreight, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "RDutyAmt", _RDutyAmt, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "RBrokerageAmt", _RBrokerageAmt, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "RInsuranceAmt", _RInsuranceAmt, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "RLocFrtAmt", _RLocFrtAmt, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "RMiscCharges", _RMiscCharges, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "RSalesTax", _RSalesTax, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "RSalesTax2", _RSalesTax2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "RInvAmt", _RInvAmt, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				RVendName = _RVendName;
				RPostFromPo = _RPostFromPo;
				RType = _RType;
				RGrnNum = _RGrnNum;
				RInvNum = _RInvNum;
				RTaxCode1 = _RTaxCode1;
				RTaxCode2 = _RTaxCode2;
				RDistDate = _RDistDate;
				RPoNum = _RPoNum;
				RPreRegister = _RPreRegister;
				RInvDate = _RInvDate;
				RExchRate = _RExchRate;
				RCurrCode = _RCurrCode;
				RPurchAmt = _RPurchAmt;
				RFreight = _RFreight;
				RDutyAmt = _RDutyAmt;
				RBrokerageAmt = _RBrokerageAmt;
				RInsuranceAmt = _RInsuranceAmt;
				RLocFrtAmt = _RLocFrtAmt;
				RMiscCharges = _RMiscCharges;
				RSalesTax = _RSalesTax;
				RSalesTax2 = _RSalesTax2;
				RInvAmt = _RInvAmt;
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
