//PROJECT NAME: CSIVendor
//CLASS NAME: GrnLineGetQtyShipped.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public interface IGrnLineGetQtyShipped
	{
		int GrnLineGetQtyShippedSp(string PPoNum,
		                           short? PPoLine,
		                           short? PPoRelease,
		                           ref decimal? PShippedQty,
		                           ref string PUM,
		                           ref string PPoType,
		                           ref string PItem,
		                           ref string PItemDesc,
		                           ref string Infobar);
	}
	
	public class GrnLineGetQtyShipped : IGrnLineGetQtyShipped
	{
		readonly IApplicationDB appDB;
		
		public GrnLineGetQtyShipped(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int GrnLineGetQtyShippedSp(string PPoNum,
		                                  short? PPoLine,
		                                  short? PPoRelease,
		                                  ref decimal? PShippedQty,
		                                  ref string PUM,
		                                  ref string PPoType,
		                                  ref string PItem,
		                                  ref string PItemDesc,
		                                  ref string Infobar)
		{
			PoNumType _PPoNum = PPoNum;
			PoLineType _PPoLine = PPoLine;
			PoReleaseType _PPoRelease = PPoRelease;
			QtyUnitType _PShippedQty = PShippedQty;
			UMType _PUM = PUM;
			PoTypeType _PPoType = PPoType;
			ItemType _PItem = PItem;
			DescriptionType _PItemDesc = PItemDesc;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GrnLineGetQtyShippedSp";
				
				appDB.AddCommandParameter(cmd, "PPoNum", _PPoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPoLine", _PPoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPoRelease", _PPoRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PShippedQty", _PShippedQty, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PUM", _PUM, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PPoType", _PPoType, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PItem", _PItem, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PItemDesc", _PItemDesc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PShippedQty = _PShippedQty;
				PUM = _PUM;
				PPoType = _PPoType;
				PItem = _PItem;
				PItemDesc = _PItemDesc;
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
