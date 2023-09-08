//PROJECT NAME: Production
//CLASS NAME: PmfFmUpdWipCostBom.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.ProcessManufacturing
{
	public interface IPmfFmUpdWipCostBom
	{
		(int? ReturnCode, string InfoBar) PmfFmUpdWipCostBomSp(string InfoBar = null,
		                                                       Guid? FmRp = null);
	}
	
	public class PmfFmUpdWipCostBom : IPmfFmUpdWipCostBom
	{
		readonly IApplicationDB appDB;
		
		public PmfFmUpdWipCostBom(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string InfoBar) PmfFmUpdWipCostBomSp(string InfoBar = null,
		                                                              Guid? FmRp = null)
		{
			InfobarType _InfoBar = InfoBar;
			RowPointerType _FmRp = FmRp;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PmfFmUpdWipCostBomSp";
				
				appDB.AddCommandParameter(cmd, "InfoBar", _InfoBar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "FmRp", _FmRp, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				InfoBar = _InfoBar;
				
				return (Severity, InfoBar);
			}
		}
	}
}
