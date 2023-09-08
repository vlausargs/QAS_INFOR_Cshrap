//PROJECT NAME: Data
//CLASS NAME: SumCoitem.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class SumCoitem : ISumCoitem
	{
		readonly IApplicationDB appDB;
		
		public SumCoitem(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? SumCoitemSp(
			string ParmCoNum,
			decimal? ParmOldQtyOrdered,
			decimal? ParmOldDisc,
			decimal? ParmOldPrice,
			decimal? ParmOldLbrCost,
			decimal? ParmOldMatlCost,
			decimal? ParmOldFovhdCost,
			decimal? ParmOldVovhdCost,
			decimal? ParmOldOutCost,
			decimal? ParmNewDisc,
			decimal? ParmNewQtyOrdered,
			decimal? ParmNewPrice)
		{
			CoNumType _ParmCoNum = ParmCoNum;
			AmountType _ParmOldQtyOrdered = ParmOldQtyOrdered;
			AmountType _ParmOldDisc = ParmOldDisc;
			AmountType _ParmOldPrice = ParmOldPrice;
			AmountType _ParmOldLbrCost = ParmOldLbrCost;
			AmountType _ParmOldMatlCost = ParmOldMatlCost;
			AmountType _ParmOldFovhdCost = ParmOldFovhdCost;
			AmountType _ParmOldVovhdCost = ParmOldVovhdCost;
			AmountType _ParmOldOutCost = ParmOldOutCost;
			AmountType _ParmNewDisc = ParmNewDisc;
			AmountType _ParmNewQtyOrdered = ParmNewQtyOrdered;
			AmountType _ParmNewPrice = ParmNewPrice;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SumCoitemSp";
				
				appDB.AddCommandParameter(cmd, "ParmCoNum", _ParmCoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ParmOldQtyOrdered", _ParmOldQtyOrdered, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ParmOldDisc", _ParmOldDisc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ParmOldPrice", _ParmOldPrice, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ParmOldLbrCost", _ParmOldLbrCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ParmOldMatlCost", _ParmOldMatlCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ParmOldFovhdCost", _ParmOldFovhdCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ParmOldVovhdCost", _ParmOldVovhdCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ParmOldOutCost", _ParmOldOutCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ParmNewDisc", _ParmNewDisc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ParmNewQtyOrdered", _ParmNewQtyOrdered, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ParmNewPrice", _ParmNewPrice, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
