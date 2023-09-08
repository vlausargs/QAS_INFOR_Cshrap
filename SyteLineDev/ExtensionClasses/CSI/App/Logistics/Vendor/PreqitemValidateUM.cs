//PROJECT NAME: CSIVendor
//CLASS NAME: PreqitemValidateUM.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public interface IPreqitemValidateUM
	{
		int PreqitemValidateUMSp(string PUM,
		                         string PItem,
		                         decimal? PQtyOrdered,
		                         decimal? PPlanCost,
		                         ref string PVendNum,
		                         ref decimal? PPlanCostConv,
		                         ref decimal? TcAmtExtCost,
		                         ref string Infobar);
	}
	
	public class PreqitemValidateUM : IPreqitemValidateUM
	{
		readonly IApplicationDB appDB;
		
		public PreqitemValidateUM(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int PreqitemValidateUMSp(string PUM,
		                                string PItem,
		                                decimal? PQtyOrdered,
		                                decimal? PPlanCost,
		                                ref string PVendNum,
		                                ref decimal? PPlanCostConv,
		                                ref decimal? TcAmtExtCost,
		                                ref string Infobar)
		{
			UMType _PUM = PUM;
			ItemType _PItem = PItem;
			QtyUnitNoNegType _PQtyOrdered = PQtyOrdered;
			CostPrcType _PPlanCost = PPlanCost;
			VendNumType _PVendNum = PVendNum;
			CostPrcType _PPlanCostConv = PPlanCostConv;
			CostPrcType _TcAmtExtCost = TcAmtExtCost;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PreqitemValidateUMSp";
				
				appDB.AddCommandParameter(cmd, "PUM", _PUM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PItem", _PItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PQtyOrdered", _PQtyOrdered, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPlanCost", _PPlanCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PVendNum", _PVendNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PPlanCostConv", _PPlanCostConv, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TcAmtExtCost", _TcAmtExtCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PVendNum = _PVendNum;
				PPlanCostConv = _PPlanCostConv;
				TcAmtExtCost = _TcAmtExtCost;
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
