//PROJECT NAME: Production
//CLASS NAME: WBSItemDeleteCheckMilestones.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.Projects
{
	public class WBSItemDeleteCheckMilestones : IWBSItemDeleteCheckMilestones
	{
		readonly IApplicationDB appDB;
		
		
		public WBSItemDeleteCheckMilestones(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) WBSItemDeleteCheckMilestonesSp(string ProjNum,
		string WbsNum,
		string WbsItemRefType,
		string Infobar)
		{
			ProjNumType _ProjNum = ProjNum;
			WbsNumType _WbsNum = WbsNum;
			WbsItemRefTypeType _WbsItemRefType = WbsItemRefType;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "WBSItemDeleteCheckMilestonesSp";
				
				appDB.AddCommandParameter(cmd, "ProjNum", _ProjNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "WbsNum", _WbsNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "WbsItemRefType", _WbsItemRefType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
