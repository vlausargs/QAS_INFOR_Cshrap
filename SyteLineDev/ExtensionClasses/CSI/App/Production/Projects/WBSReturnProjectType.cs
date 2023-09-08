//PROJECT NAME: Production
//CLASS NAME: WBSReturnProjectType.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.Projects
{
	public class WBSReturnProjectType : IWBSReturnProjectType
	{
		readonly IApplicationDB appDB;
		
		public WBSReturnProjectType(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public string WBSReturnProjectTypeFn(
			string RefType,
			string RefNum)
		{
			LongListType _RefType = RefType;
			ProjWbsNumType _RefNum = RefNum;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[WBSReturnProjectType](@RefType, @RefNum)";
				
				appDB.AddCommandParameter(cmd, "RefType", _RefType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefNum", _RefNum, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<string>(cmd);
				
				return Output;
			}
		}
	}
}
