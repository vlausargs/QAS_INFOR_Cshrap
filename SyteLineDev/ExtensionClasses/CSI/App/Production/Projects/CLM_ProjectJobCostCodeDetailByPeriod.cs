//PROJECT NAME: CSIProjects
//CLASS NAME: CLM_ProjectJobCostCodeDetailByPeriod.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.Projects
{
	public interface ICLM_ProjectJobCostCodeDetailByPeriod
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_ProjectJobCostCodeDetailByPeriodSp(string StartProjNum,
		string EndProjNum,
		int? StartTaskNum,
		int? EndTaskNum,
		string StartProdCode,
		string EndProdCode,
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
		string ActiveProjStat,
		string InactiveProjStat,
		string CompleteProjStat,
		string HistoryProjStat,
		string ProjMgr = null,
		string SiteGroup = null);
	}
	
	public class CLM_ProjectJobCostCodeDetailByPeriod : ICLM_ProjectJobCostCodeDetailByPeriod
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public CLM_ProjectJobCostCodeDetailByPeriod(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) CLM_ProjectJobCostCodeDetailByPeriodSp(string StartProjNum,
		string EndProjNum,
		int? StartTaskNum,
		int? EndTaskNum,
		string StartProdCode,
		string EndProdCode,
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
		string ActiveProjStat,
		string InactiveProjStat,
		string CompleteProjStat,
		string HistoryProjStat,
		string ProjMgr = null,
		string SiteGroup = null)
		{
			bunchedLoadCollection.StartBunching();
			
			try
			{
				ProjNumType _StartProjNum = StartProjNum;
				ProjNumType _EndProjNum = EndProjNum;
				TaskNumType _StartTaskNum = StartTaskNum;
				TaskNumType _EndTaskNum = EndTaskNum;
				ProductCodeType _StartProdCode = StartProdCode;
				ProductCodeType _EndProdCode = EndProdCode;
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
				ProjStatusType _ActiveProjStat = ActiveProjStat;
				ProjStatusType _InactiveProjStat = InactiveProjStat;
				ProjStatusType _CompleteProjStat = CompleteProjStat;
				ProjStatusType _HistoryProjStat = HistoryProjStat;
				NameType _ProjMgr = ProjMgr;
				SiteGroupType _SiteGroup = SiteGroup;
				
				using (IDbCommand cmd = appDB.CreateCommand())
				{
					DataTable dtReturn = new DataTable();
					
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.CommandText = "CLM_ProjectJobCostCodeDetailByPeriodSp";
					
					appDB.AddCommandParameter(cmd, "StartProjNum", _StartProjNum, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "EndProjNum", _EndProjNum, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "StartTaskNum", _StartTaskNum, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "EndTaskNum", _EndTaskNum, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "StartProdCode", _StartProdCode, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "EndProdCode", _EndProdCode, ParameterDirection.Input);
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
					appDB.AddCommandParameter(cmd, "ActiveProjStat", _ActiveProjStat, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "InactiveProjStat", _InactiveProjStat, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "CompleteProjStat", _CompleteProjStat, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "HistoryProjStat", _HistoryProjStat, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "ProjMgr", _ProjMgr, ParameterDirection.Input);
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
