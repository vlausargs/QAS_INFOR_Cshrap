//PROJECT NAME: Data
//CLASS NAME: Event_CustomerOrderAmountUpdate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class Event_CustomerOrderAmountUpdate : IEvent_CustomerOrderAmountUpdate
	{
		readonly IApplicationDB appDB;
		
		public Event_CustomerOrderAmountUpdate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) Event_CustomerOrderAmountUpdateSp(
			string CoNum,
			int? CoLine,
			decimal? QtyOrderedConv,
			decimal? Disc,
			decimal? PriceConv,
			string Infobar)
		{
			CoNumType _CoNum = CoNum;
			CoLineType _CoLine = CoLine;
			QtyUnitNoNegType _QtyOrderedConv = QtyOrderedConv;
			LineDiscType _Disc = Disc;
			CostPrcType _PriceConv = PriceConv;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Event_CustomerOrderAmountUpdateSp";
				
				appDB.AddCommandParameter(cmd, "CoNum", _CoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoLine", _CoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QtyOrderedConv", _QtyOrderedConv, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Disc", _Disc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PriceConv", _PriceConv, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
