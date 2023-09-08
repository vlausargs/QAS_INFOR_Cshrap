//PROJECT NAME: Data
//CLASS NAME: UpdWhse.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class UpdWhse : IUpdWhse
	{
		readonly IApplicationDB appDB;
		
		public UpdWhse(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) UpdWhseSp(
			decimal? PDeltaQty,
			string PItem,
			string PWhse,
			string PTrnNum,
			int? PTrnLine,
			string Infobar = null)
		{
			QtyTotlType _PDeltaQty = PDeltaQty;
			ItemType _PItem = PItem;
			WhseType _PWhse = PWhse;
			TrnNumType _PTrnNum = PTrnNum;
			TrnLineType _PTrnLine = PTrnLine;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "UpdWhseSp";
				
				appDB.AddCommandParameter(cmd, "PDeltaQty", _PDeltaQty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PItem", _PItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PWhse", _PWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTrnNum", _PTrnNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTrnLine", _PTrnLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
