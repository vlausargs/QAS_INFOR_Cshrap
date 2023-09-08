//PROJECT NAME: RFQ
//CLASS NAME: SSSRFQSplitQtysToPrice.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.RFQ
{
	public class SSSRFQSplitQtysToPrice : ISSSRFQSplitQtysToPrice
	{
		readonly IApplicationDB appDB;
		
		public SSSRFQSplitQtysToPrice(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			decimal? BrkQtyConv1,
			decimal? BrkQtyConv2,
			decimal? BrkQtyConv3,
			decimal? BrkQtyConv4,
			decimal? BrkQtyConv5,
			decimal? BrkQtyConv6,
			decimal? BrkQtyConv7,
			decimal? BrkQtyConv8,
			decimal? BrkQtyConv9,
			decimal? BrkQtyConv10,
			string Infobar) SSSRFQSplitQtysToPriceSp(
			decimal? SingleQty,
			string QtysToPrice,
			decimal? BrkQtyConv1,
			decimal? BrkQtyConv2,
			decimal? BrkQtyConv3,
			decimal? BrkQtyConv4,
			decimal? BrkQtyConv5,
			decimal? BrkQtyConv6,
			decimal? BrkQtyConv7,
			decimal? BrkQtyConv8,
			decimal? BrkQtyConv9,
			decimal? BrkQtyConv10,
			string Infobar)
		{
			QtyUnitType _SingleQty = SingleQty;
			LongListType _QtysToPrice = QtysToPrice;
			QtyUnitType _BrkQtyConv1 = BrkQtyConv1;
			QtyUnitType _BrkQtyConv2 = BrkQtyConv2;
			QtyUnitType _BrkQtyConv3 = BrkQtyConv3;
			QtyUnitType _BrkQtyConv4 = BrkQtyConv4;
			QtyUnitType _BrkQtyConv5 = BrkQtyConv5;
			QtyUnitType _BrkQtyConv6 = BrkQtyConv6;
			QtyUnitType _BrkQtyConv7 = BrkQtyConv7;
			QtyUnitType _BrkQtyConv8 = BrkQtyConv8;
			QtyUnitType _BrkQtyConv9 = BrkQtyConv9;
			QtyUnitType _BrkQtyConv10 = BrkQtyConv10;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSRFQSplitQtysToPriceSp";
				
				appDB.AddCommandParameter(cmd, "SingleQty", _SingleQty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QtysToPrice", _QtysToPrice, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BrkQtyConv1", _BrkQtyConv1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "BrkQtyConv2", _BrkQtyConv2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "BrkQtyConv3", _BrkQtyConv3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "BrkQtyConv4", _BrkQtyConv4, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "BrkQtyConv5", _BrkQtyConv5, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "BrkQtyConv6", _BrkQtyConv6, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "BrkQtyConv7", _BrkQtyConv7, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "BrkQtyConv8", _BrkQtyConv8, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "BrkQtyConv9", _BrkQtyConv9, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "BrkQtyConv10", _BrkQtyConv10, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				BrkQtyConv1 = _BrkQtyConv1;
				BrkQtyConv2 = _BrkQtyConv2;
				BrkQtyConv3 = _BrkQtyConv3;
				BrkQtyConv4 = _BrkQtyConv4;
				BrkQtyConv5 = _BrkQtyConv5;
				BrkQtyConv6 = _BrkQtyConv6;
				BrkQtyConv7 = _BrkQtyConv7;
				BrkQtyConv8 = _BrkQtyConv8;
				BrkQtyConv9 = _BrkQtyConv9;
				BrkQtyConv10 = _BrkQtyConv10;
				Infobar = _Infobar;
				
				return (Severity, BrkQtyConv1, BrkQtyConv2, BrkQtyConv3, BrkQtyConv4, BrkQtyConv5, BrkQtyConv6, BrkQtyConv7, BrkQtyConv8, BrkQtyConv9, BrkQtyConv10, Infobar);
			}
		}
	}
}
