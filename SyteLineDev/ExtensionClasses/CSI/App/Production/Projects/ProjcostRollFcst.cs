//PROJECT NAME: CSIProjects
//CLASS NAME: ProjcostRollFcst.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Production.Projects
{
	public interface IProjcostRollFcst
	{
		DataTable ProjcostRollFcstSp(string Process,
		                             string ProjNum,
		                             int? FromTaskNum,
		                             int? ToTaskNum,
		                             string FromCostCode,
		                             string ToCostCode);
	}
	
	public class ProjcostRollFcst : IProjcostRollFcst
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		
		public ProjcostRollFcst(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
		}
		
		public DataTable ProjcostRollFcstSp(string Process,
		                                    string ProjNum,
		                                    int? FromTaskNum,
		                                    int? ToTaskNum,
		                                    string FromCostCode,
		                                    string ToCostCode)
		{
			LongListType _Process = Process;
			ProjNumType _ProjNum = ProjNum;
			GenericIntType _FromTaskNum = FromTaskNum;
			GenericIntType _ToTaskNum = ToTaskNum;
			CostCodeType _FromCostCode = FromCostCode;
			CostCodeType _ToCostCode = ToCostCode;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ProjcostRollFcstSp";
				
				appDB.AddCommandParameter(cmd, "Process", _Process, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProjNum", _ProjNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromTaskNum", _FromTaskNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToTaskNum", _ToTaskNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromCostCode", _FromCostCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToCostCode", _ToCostCode, ParameterDirection.Input);

                dtReturn = appDB.ExecuteQuery(cmd);

                return dtReturn;
			}
		}
	}
}
