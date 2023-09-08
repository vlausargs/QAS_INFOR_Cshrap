//PROJECT NAME: Logistics
//CLASS NAME: RmaReplCoLine.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class RmaReplCoLine : IRmaReplCoLine
	{
		readonly IApplicationDB appDB;
		
		
		public RmaReplCoLine(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, decimal? RUnitPrice,
		string Infobar) RmaReplCoLineSp(string PRmaNum,
		int? PRmaLine,
		string PCoNum,
		int? PCoLine,
		string PItem,
		decimal? RUnitPrice,
		string Infobar)
		{
			RmaNumType _PRmaNum = PRmaNum;
			RmaLineType _PRmaLine = PRmaLine;
			CoNumType _PCoNum = PCoNum;
			CoLineType _PCoLine = PCoLine;
			ItemType _PItem = PItem;
			CostPrcNoNegType _RUnitPrice = RUnitPrice;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "RmaReplCoLineSp";
				
				appDB.AddCommandParameter(cmd, "PRmaNum", _PRmaNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PRmaLine", _PRmaLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCoNum", _PCoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCoLine", _PCoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PItem", _PItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RUnitPrice", _RUnitPrice, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				RUnitPrice = _RUnitPrice;
				Infobar = _Infobar;
				
				return (Severity, RUnitPrice, Infobar);
			}
		}
	}
}
