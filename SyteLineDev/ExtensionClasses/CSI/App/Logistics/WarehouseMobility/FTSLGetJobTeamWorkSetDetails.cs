//PROJECT NAME: CSIWarehouseMobility
//CLASS NAME: FTSLGetJobTeamWorkSetDetails.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.WarehouseMobility
{
	public interface IFTSLGetJobTeamWorkSetDetails
	{
		int FTSLGetJobTeamWorkSetDetailsSp(int? TaskCode,
		                                   string OrderNumber,
		                                   short? Suffix,
		                                   int? Operation,
		                                   string OrderType,
		                                   ref int? TaskCodeName,
		                                   ref string JobName,
		                                   ref short? SuffixName,
		                                   ref int? OperationName);
	}
	
	public class FTSLGetJobTeamWorkSetDetails : IFTSLGetJobTeamWorkSetDetails
	{
		readonly IApplicationDB appDB;
		
		public FTSLGetJobTeamWorkSetDetails(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int FTSLGetJobTeamWorkSetDetailsSp(int? TaskCode,
		                                          string OrderNumber,
		                                          short? Suffix,
		                                          int? Operation,
		                                          string OrderType,
		                                          ref int? TaskCodeName,
		                                          ref string JobName,
		                                          ref short? SuffixName,
		                                          ref int? OperationName)
		{
			TaskNumType _TaskCode = TaskCode;
			JobType _OrderNumber = OrderNumber;
			SuffixType _Suffix = Suffix;
			OperNumType _Operation = Operation;
			StateType _OrderType = OrderType;
			TaskNumType _TaskCodeName = TaskCodeName;
			JobType _JobName = JobName;
			SuffixType _SuffixName = SuffixName;
			OperNumType _OperationName = OperationName;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "FTSLGetJobTeamWorkSetDetailsSp";
				
				appDB.AddCommandParameter(cmd, "TaskCode", _TaskCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrderNumber", _OrderNumber, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Suffix", _Suffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Operation", _Operation, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrderType", _OrderType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TaskCodeName", _TaskCodeName, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "JobName", _JobName, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "SuffixName", _SuffixName, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "OperationName", _OperationName, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				TaskCodeName = _TaskCodeName;
				JobName = _JobName;
				SuffixName = _SuffixName;
				OperationName = _OperationName;
				
				return Severity;
			}
		}
	}
}
