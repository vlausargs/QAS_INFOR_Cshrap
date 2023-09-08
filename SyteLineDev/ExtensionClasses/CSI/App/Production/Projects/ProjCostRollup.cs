//PROJECT NAME: Production
//CLASS NAME: ProjCostRollup.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.Projects
{
	public class ProjCostRollup : IProjCostRollup
	{
		readonly IApplicationDB appDB;
		
		
		public ProjCostRollup(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) ProjCostRollupSp(string FromProjNum,
		string ToProjNum,
		string ProjStatList,
		string CostCodeOrMileStone,
		int? CalcRevenue,
		string Infobar,
		int? TaskNum = null,
		int? Seq = null)
		{
			HighLowCharType _FromProjNum = FromProjNum;
			HighLowCharType _ToProjNum = ToProjNum;
			StringType _ProjStatList = ProjStatList;
			StringType _CostCodeOrMileStone = CostCodeOrMileStone;
			ListYesNoType _CalcRevenue = CalcRevenue;
			InfobarType _Infobar = Infobar;
			TaskNumType _TaskNum = TaskNum;
			ProjmatlSeqType _Seq = Seq;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ProjCostRollupSp";
				
				appDB.AddCommandParameter(cmd, "FromProjNum", _FromProjNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToProjNum", _ToProjNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProjStatList", _ProjStatList, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CostCodeOrMileStone", _CostCodeOrMileStone, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CalcRevenue", _CalcRevenue, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TaskNum", _TaskNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Seq", _Seq, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
