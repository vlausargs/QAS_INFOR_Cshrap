//PROJECT NAME: CSICustomer
//CLASS NAME: DisplayRMAWarningMsg.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public interface IDisplayRMAWarningMsg
	{
		int DisplayRMAWarningMsgSp(string PRmaNum,
		                           string PCoNum,
		                           byte? IncludeTaxInPrice,
		                           decimal? ItmQty,
		                           ref string Infobar);
	}
	
	public class DisplayRMAWarningMsg : IDisplayRMAWarningMsg
	{
		readonly IApplicationDB appDB;
		
		public DisplayRMAWarningMsg(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int DisplayRMAWarningMsgSp(string PRmaNum,
		                                  string PCoNum,
		                                  byte? IncludeTaxInPrice,
		                                  decimal? ItmQty,
		                                  ref string Infobar)
		{
			RmaNumType _PRmaNum = PRmaNum;
			CoNumType _PCoNum = PCoNum;
			ListYesNoType _IncludeTaxInPrice = IncludeTaxInPrice;
			QtyUnitType _ItmQty = ItmQty;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "DisplayRMAWarningMsgSp";
				
				appDB.AddCommandParameter(cmd, "PRmaNum", _PRmaNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCoNum", _PCoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IncludeTaxInPrice", _IncludeTaxInPrice, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItmQty", _ItmQty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
