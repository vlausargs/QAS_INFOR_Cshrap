//PROJECT NAME: Data
//CLASS NAME: ESF_MapCoStat.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class ESF_MapCoStat : IESF_MapCoStat
	{
		readonly IApplicationDB appDB;
		
		public ESF_MapCoStat(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public string ESF_MapCoStatFn(
			string CoStat)
		{
			CoStatusType _CoStat = CoStat;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[ESF_MapCoStat](@CoStat)";
				
				appDB.AddCommandParameter(cmd, "CoStat", _CoStat, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<string>(cmd);
				
				return Output;
			}
		}
	}
}
