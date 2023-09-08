//PROJECT NAME: Production
//CLASS NAME: PmfSpecUpdWipCostBom.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.ProcessManufacturing
{
	public interface IPmfSpecUpdWipCostBom
	{
		(int? ReturnCode, string InfoBar) PmfSpecUpdWipCostBomSp(string InfoBar = null,
		                                                         Guid? SpecRp = null,
		                                                         int? AddWipIfMissing = 0);
	}
	
	public class PmfSpecUpdWipCostBom : IPmfSpecUpdWipCostBom
	{
		readonly IApplicationDB appDB;
		
		public PmfSpecUpdWipCostBom(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string InfoBar) PmfSpecUpdWipCostBomSp(string InfoBar = null,
		                                                                Guid? SpecRp = null,
		                                                                int? AddWipIfMissing = 0)
		{
			InfobarType _InfoBar = InfoBar;
			RowPointerType _SpecRp = SpecRp;
			IntType _AddWipIfMissing = AddWipIfMissing;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PmfSpecUpdWipCostBomSp";
				
				appDB.AddCommandParameter(cmd, "InfoBar", _InfoBar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "SpecRp", _SpecRp, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AddWipIfMissing", _AddWipIfMissing, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				InfoBar = _InfoBar;
				
				return (Severity, InfoBar);
			}
		}
	}
}
