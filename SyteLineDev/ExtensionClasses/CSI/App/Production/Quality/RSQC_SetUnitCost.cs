//PROJECT NAME: Production
//CLASS NAME: RSQC_SetUnitCost.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.Quality
{
	public class RSQC_SetUnitCost : IRSQC_SetUnitCost
	{
		readonly IApplicationDB appDB;
		
		
		public RSQC_SetUnitCost(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, decimal? o_unit_cost,
		string Infobar) RSQC_SetUnitCostSp(int? i_vrma,
		decimal? o_unit_cost,
		string Infobar)
		{
			QCRcvrNumType _i_vrma = i_vrma;
			CostPrcType _o_unit_cost = o_unit_cost;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "RSQC_SetUnitCostSp";
				
				appDB.AddCommandParameter(cmd, "i_vrma", _i_vrma, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "o_unit_cost", _o_unit_cost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				o_unit_cost = _o_unit_cost;
				Infobar = _Infobar;
				
				return (Severity, o_unit_cost, Infobar);
			}
		}
	}
}
