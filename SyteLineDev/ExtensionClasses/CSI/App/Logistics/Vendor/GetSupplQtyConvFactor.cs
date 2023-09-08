//PROJECT NAME: CSIVendor
//CLASS NAME: GetSupplQtyConvFactor.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public interface IGetSupplQtyConvFactor
	{
		int GetSupplQtyConvFactorSp(string comm_code,
		                            ref double? suppl_qty_conv_factor,
		                            ref byte? suppl_qty_req,
		                            ref string Infobar);
	}
	
	public class GetSupplQtyConvFactor : IGetSupplQtyConvFactor
	{
		readonly IApplicationDB appDB;
		
		public GetSupplQtyConvFactor(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int GetSupplQtyConvFactorSp(string comm_code,
		                                   ref double? suppl_qty_conv_factor,
		                                   ref byte? suppl_qty_req,
		                                   ref string Infobar)
		{
			CommodityCodeType _comm_code = comm_code;
			UMConvFactorType _suppl_qty_conv_factor = suppl_qty_conv_factor;
			ListYesNoType _suppl_qty_req = suppl_qty_req;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetSupplQtyConvFactorSp";
				
				appDB.AddCommandParameter(cmd, "comm_code", _comm_code, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "suppl_qty_conv_factor", _suppl_qty_conv_factor, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "suppl_qty_req", _suppl_qty_req, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				suppl_qty_conv_factor = _suppl_qty_conv_factor;
				suppl_qty_req = _suppl_qty_req;
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
