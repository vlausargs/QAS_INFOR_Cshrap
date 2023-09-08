//PROJECT NAME: Production
//CLASS NAME: ProjBldPcst.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.Projects
{
	public class ProjBldPcst : IProjBldPcst
	{
		readonly IApplicationDB appDB;
		
		public ProjBldPcst(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? ProjBldPcstSp(
			string RefNum,
			string ProjType,
			string ProjNum,
			int? TaskNum,
			int? DeleteOld)
		{
			ProjNumType _RefNum = RefNum;
			ProjTypeType _ProjType = ProjType;
			ProjNumType _ProjNum = ProjNum;
			TaskNumType _TaskNum = TaskNum;
			FlagNyType _DeleteOld = DeleteOld;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ProjBldPcstSp";
				
				appDB.AddCommandParameter(cmd, "RefNum", _RefNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProjType", _ProjType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProjNum", _ProjNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TaskNum", _TaskNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DeleteOld", _DeleteOld, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
