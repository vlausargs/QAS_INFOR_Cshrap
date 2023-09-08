//PROJECT NAME: Production
//CLASS NAME: ApsIsDemandReady2.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class ApsIsDemandReady2 : IApsIsDemandReady2
	{
		readonly IApplicationDB appDB;
		
		public ApsIsDemandReady2(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? ApsIsDemandReady2Fn(
			string RefType,
			string RefNum)
		{
			RefTypeIJKMNOTType _RefType = RefType;
			RefType _RefNum = RefNum;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[ApsIsDemandReady2](@RefType, @RefNum)";
				
				appDB.AddCommandParameter(cmd, "RefType", _RefType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefNum", _RefNum, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<int?>(cmd);
				
				return Output;
			}
		}
	}
}
