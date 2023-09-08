//PROJECT NAME: CSIVendor
//CLASS NAME: UpdatePOLineItemCost.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public interface IUpdatePOLineItemCost
	{
		int UpdatePOLineItemCostSp(string pPoNum,
		                           ref string Infobar);
	}
	
	public class UpdatePOLineItemCost : IUpdatePOLineItemCost
	{
		readonly IApplicationDB appDB;
		
		public UpdatePOLineItemCost(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int UpdatePOLineItemCostSp(string pPoNum,
		                                  ref string Infobar)
		{
			PoNumType _pPoNum = pPoNum;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "UpdatePOLineItemCostSp";
				
				appDB.AddCommandParameter(cmd, "pPoNum", _pPoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
