//PROJECT NAME: CSIMaterial
//CLASS NAME: PlanningDemandNegative.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public interface IPlanningDemandNegative
	{
		(ICollectionLoadResponse Data, int? ReturnCode) PlanningDemandNegativeSp(DateTime? CutOffDate,
		string PlanCode,
		string Buyer,
		string PMTCodes,
		string FilterString = null,
		string CustNum = null,
		byte? CSFlag = (byte)0,
		string ProjMgr = null,
		byte? PMFlag = (byte)0,
		string SiteGroup = null,
		byte? SortByDueDate = (byte)0);
	}
	
	public class PlanningDemandNegative : IPlanningDemandNegative
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public PlanningDemandNegative(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) PlanningDemandNegativeSp(DateTime? CutOffDate,
		string PlanCode,
		string Buyer,
		string PMTCodes,
		string FilterString = null,
		string CustNum = null,
		byte? CSFlag = (byte)0,
		string ProjMgr = null,
		byte? PMFlag = (byte)0,
		string SiteGroup = null,
		byte? SortByDueDate = (byte)0)
		{
			bunchedLoadCollection.StartBunching();
			
			try
			{
				DateType _CutOffDate = CutOffDate;
				UserCodeType _PlanCode = PlanCode;
				NameType _Buyer = Buyer;
				StringType _PMTCodes = PMTCodes;
				LongListType _FilterString = FilterString;
				CustNumType _CustNum = CustNum;
				ListYesNoType _CSFlag = CSFlag;
				NameType _ProjMgr = ProjMgr;
				ListYesNoType _PMFlag = PMFlag;
				SiteGroupType _SiteGroup = SiteGroup;
				ListYesNoType _SortByDueDate = SortByDueDate;
				
				using (IDbCommand cmd = appDB.CreateCommand())
				{
					DataTable dtReturn = new DataTable();
					
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.CommandText = "PlanningDemandNegativeSp";
					
					appDB.AddCommandParameter(cmd, "CutOffDate", _CutOffDate, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "PlanCode", _PlanCode, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "Buyer", _Buyer, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "PMTCodes", _PMTCodes, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "FilterString", _FilterString, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "CSFlag", _CSFlag, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "ProjMgr", _ProjMgr, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "PMFlag", _PMFlag, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "SiteGroup", _SiteGroup, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "SortByDueDate", _SortByDueDate, ParameterDirection.Input);
					
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
