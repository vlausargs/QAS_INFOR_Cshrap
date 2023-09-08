//PROJECT NAME: CSIPmf
//CLASS NAME: PmfRecallGen.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.ProcessManufacturing
{
	public interface IPmfRecallGen
	{
		(int? ReturnCode, string InfoBar) PmfRecallGenSp(string InfoBar = null,
		Guid? RecallRp = null,
		int? MaxLevels = 10);
	}
	
	public class PmfRecallGen : IPmfRecallGen
	{
		readonly IApplicationDB appDB;
		
		public PmfRecallGen(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string InfoBar) PmfRecallGenSp(string InfoBar = null,
		Guid? RecallRp = null,
		int? MaxLevels = 10)
		{
			InfobarType _InfoBar = InfoBar;
			RowPointerType _RecallRp = RecallRp;
			IntType _MaxLevels = MaxLevels;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PmfRecallGenSp";
				
				appDB.AddCommandParameter(cmd, "InfoBar", _InfoBar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "RecallRp", _RecallRp, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MaxLevels", _MaxLevels, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				InfoBar = _InfoBar;
				
				return (Severity, InfoBar);
			}
		}
	}
}
