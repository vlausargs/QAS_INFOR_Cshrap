//PROJECT NAME: CSICustomer
//CLASS NAME: CoItemPriceBreak.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public interface ICoItemPriceBreak
	{
		(int? ReturnCode, string InfoBar) CoItemPriceBreakSp(string CoNum,
		short? CoLine,
		decimal? ItemQty,
		byte? VendorPriceBreaks,
		string InfoBar);
	}
	
	public class CoItemPriceBreak : ICoItemPriceBreak
	{
		readonly IApplicationDB appDB;
		
		public CoItemPriceBreak(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string InfoBar) CoItemPriceBreakSp(string CoNum,
		short? CoLine,
		decimal? ItemQty,
		byte? VendorPriceBreaks,
		string InfoBar)
		{
			CoNumType _CoNum = CoNum;
			CoLineType _CoLine = CoLine;
			QtyUnitType _ItemQty = ItemQty;
			ListYesNoType _VendorPriceBreaks = VendorPriceBreaks;
			InfobarType _InfoBar = InfoBar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CoItemPriceBreakSp";
				
				appDB.AddCommandParameter(cmd, "CoNum", _CoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoLine", _CoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemQty", _ItemQty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VendorPriceBreaks", _VendorPriceBreaks, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InfoBar", _InfoBar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				InfoBar = _InfoBar;
				
				return (Severity, InfoBar);
			}
		}
	}
}
