//PROJECT NAME: CSIProduct
//CLASS NAME: EstimateJobRoll.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Production
{
	public interface IEstimateJobRoll
	{
		DataTable EstimateJobRollSp(string StartingJob,
		                            short? StartingSuffix,
		                            string EndingJob,
		                            short? EndingSuffix,
		                            byte? ResetByProductCost,
		                            byte? ResetItemCost,
		                            byte? ResetPOCost,
		                            byte? ResetRecCost,
		                            byte? ResetJobCost,
		                            byte? ShowList);
	}
	
	public class EstimateJobRoll : IEstimateJobRoll
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		
		public EstimateJobRoll(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
		}
		
		public DataTable EstimateJobRollSp(string StartingJob,
		                                   short? StartingSuffix,
		                                   string EndingJob,
		                                   short? EndingSuffix,
		                                   byte? ResetByProductCost,
		                                   byte? ResetItemCost,
		                                   byte? ResetPOCost,
		                                   byte? ResetRecCost,
		                                   byte? ResetJobCost,
		                                   byte? ShowList)
		{
			JobType _StartingJob = StartingJob;
			SuffixType _StartingSuffix = StartingSuffix;
			JobType _EndingJob = EndingJob;
			SuffixType _EndingSuffix = EndingSuffix;
			ListYesNoType _ResetByProductCost = ResetByProductCost;
			ListYesNoType _ResetItemCost = ResetItemCost;
			ListYesNoType _ResetPOCost = ResetPOCost;
			ListYesNoType _ResetRecCost = ResetRecCost;
			ListYesNoType _ResetJobCost = ResetJobCost;
			ListYesNoType _ShowList = ShowList;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "EstimateJobRollSp";
				
				appDB.AddCommandParameter(cmd, "StartingJob", _StartingJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartingSuffix", _StartingSuffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingJob", _EndingJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingSuffix", _EndingSuffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ResetByProductCost", _ResetByProductCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ResetItemCost", _ResetItemCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ResetPOCost", _ResetPOCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ResetRecCost", _ResetRecCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ResetJobCost", _ResetJobCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShowList", _ShowList, ParameterDirection.Input);

                dtReturn = appDB.ExecuteQuery(cmd);

                return dtReturn;
			}
		}
	}
}
