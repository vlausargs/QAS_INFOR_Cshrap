//PROJECT NAME: CSICustomer
//CLASS NAME: PortalOrderTotalsCalculation.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public interface IPortalOrderTotalsCalculation
	{
		int PortalOrderTotalsCalculationSp(Guid? CoRowPointer,
		                                   byte? ResellerPortalFlag,
		                                   string ResellerCustNum,
		                                   ref decimal? SubTotal,
		                                   ref decimal? SalesTax,
		                                   ref decimal? ShippingCost,
		                                   ref int? ItemCnt,
		                                   ref decimal? CommissionAmountTotal,
		                                   ref string CoNum,
		                                   ref string Infobar);
	}
	
	public class PortalOrderTotalsCalculation : IPortalOrderTotalsCalculation
	{
		readonly IApplicationDB appDB;
		
		public PortalOrderTotalsCalculation(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int PortalOrderTotalsCalculationSp(Guid? CoRowPointer,
		                                          byte? ResellerPortalFlag,
		                                          string ResellerCustNum,
		                                          ref decimal? SubTotal,
		                                          ref decimal? SalesTax,
		                                          ref decimal? ShippingCost,
		                                          ref int? ItemCnt,
		                                          ref decimal? CommissionAmountTotal,
		                                          ref string CoNum,
		                                          ref string Infobar)
		{
			RowPointerType _CoRowPointer = CoRowPointer;
			ListYesNoType _ResellerPortalFlag = ResellerPortalFlag;
			CustNumType _ResellerCustNum = ResellerCustNum;
			AmountType _SubTotal = SubTotal;
			AmountType _SalesTax = SalesTax;
			AmountType _ShippingCost = ShippingCost;
			IntType _ItemCnt = ItemCnt;
			AmountType _CommissionAmountTotal = CommissionAmountTotal;
			CoNumType _CoNum = CoNum;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PortalOrderTotalsCalculationSp";
				
				appDB.AddCommandParameter(cmd, "CoRowPointer", _CoRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ResellerPortalFlag", _ResellerPortalFlag, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ResellerCustNum", _ResellerCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SubTotal", _SubTotal, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "SalesTax", _SalesTax, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ShippingCost", _ShippingCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ItemCnt", _ItemCnt, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CommissionAmountTotal", _CommissionAmountTotal, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CoNum", _CoNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				SubTotal = _SubTotal;
				SalesTax = _SalesTax;
				ShippingCost = _ShippingCost;
				ItemCnt = _ItemCnt;
				CommissionAmountTotal = _CommissionAmountTotal;
				CoNum = _CoNum;
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
