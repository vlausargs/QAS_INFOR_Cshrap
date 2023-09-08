//PROJECT NAME: Material
//CLASS NAME: CopyCostingAnalysisAlternativeRouting.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public class CopyCostingAnalysisAlternativeRouting : ICopyCostingAnalysisAlternativeRouting
	{
		readonly IApplicationDB appDB;
		
		
		public CopyCostingAnalysisAlternativeRouting(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) CopyCostingAnalysisAlternativeRoutingSp(string CostingAlt,
		string Item,
		string CostingAltFrom = null,
		string Infobar = null)
		{
			CostingAlternativeType _CostingAlt = CostingAlt;
			ItemType _Item = Item;
			CostingAlternativeType _CostingAltFrom = CostingAltFrom;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CopyCostingAnalysisAlternativeRoutingSp";
				
				appDB.AddCommandParameter(cmd, "CostingAlt", _CostingAlt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CostingAltFrom", _CostingAltFrom, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
