//PROJECT NAME: CSIProjects
//CLASS NAME: CLM_ProjectJobAccumulatedByPeriod.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.Projects
{
	public interface ICLM_ProjectJobAccumulatedByPeriod
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_ProjectJobAccumulatedByPeriodSp(string ProjNum,
		int? StartTaskNum,
		int? EndTaskNum,
		string StartCostCode,
		string EndCostCode,
		string StartYear,
		string StartMonth,
		int? NumberMonths,
		string CostCodeType,
		string ProjLevel,
		string MatlCostClass,
		string LaborCostClass,
		string OtherCostClass,
		string SiteGroup = null);
	}
	
	public class CLM_ProjectJobAccumulatedByPeriod : ICLM_ProjectJobAccumulatedByPeriod
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public CLM_ProjectJobAccumulatedByPeriod(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) CLM_ProjectJobAccumulatedByPeriodSp(string ProjNum,
		int? StartTaskNum,
		int? EndTaskNum,
		string StartCostCode,
		string EndCostCode,
		string StartYear,
		string StartMonth,
		int? NumberMonths,
		string CostCodeType,
		string ProjLevel,
		string MatlCostClass,
		string LaborCostClass,
		string OtherCostClass,
		string SiteGroup = null)
		{
			bunchedLoadCollection.StartBunching();
			
			try
			{
				ProjNumType _ProjNum = ProjNum;
				TaskNumType _StartTaskNum = StartTaskNum;
				TaskNumType _EndTaskNum = EndTaskNum;
				CostCodeType _StartCostCode = StartCostCode;
				CostCodeType _EndCostCode = EndCostCode;
				StringType _StartYear = StartYear;
				StringType _StartMonth = StartMonth;
				IntType _NumberMonths = NumberMonths;
				CostCodeType _CostCodeType = CostCodeType;
				StringType _ProjLevel = ProjLevel;
				CostCodeClassType _MatlCostClass = MatlCostClass;
				CostCodeClassType _LaborCostClass = LaborCostClass;
				CostCodeClassType _OtherCostClass = OtherCostClass;
				SiteGroupType _SiteGroup = SiteGroup;
				
				using (IDbCommand cmd = appDB.CreateCommand())
				{
					DataTable dtReturn = new DataTable();
					
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.CommandText = "CLM_ProjectJobAccumulatedByPeriodSp";
					
					appDB.AddCommandParameter(cmd, "ProjNum", _ProjNum, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "StartTaskNum", _StartTaskNum, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "EndTaskNum", _EndTaskNum, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "StartCostCode", _StartCostCode, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "EndCostCode", _EndCostCode, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "StartYear", _StartYear, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "StartMonth", _StartMonth, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "NumberMonths", _NumberMonths, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "CostCodeType", _CostCodeType, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "ProjLevel", _ProjLevel, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "MatlCostClass", _MatlCostClass, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "LaborCostClass", _LaborCostClass, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "OtherCostClass", _OtherCostClass, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "SiteGroup", _SiteGroup, ParameterDirection.Input);
					
					IntType returnVal = 0;
					IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
					dbParm.DbType = DbType.Int32;

                    dtReturn = appDB.ExecuteQuery(cmd);

                    return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
				}
			}
			finally
			{
				bunchedLoadCollection.EndBunching();
			}
		}
	}
}
