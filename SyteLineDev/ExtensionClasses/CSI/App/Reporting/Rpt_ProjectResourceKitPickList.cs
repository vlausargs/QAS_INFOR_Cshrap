//PROJECT NAME: Reporting
//CLASS NAME: Rpt_ProjectResourceKitPickList.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_ProjectResourceKitPickList : IRpt_ProjectResourceKitPickList
	{
		IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_ProjectResourceKitPickList(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_ProjectResourceKitPickListSp(string StartingProjNum = null,
		string EndingProjNum = null,
		int? StartingTaskNum = null,
		int? EndingTaskNum = null,
		string StartingKit = null,
		string EndingKit = null,
		int? SortByLoc = null,
		int? PrintSecondaryLocations = null,
		int? ExtendByScrapFactor = null,
		int? PrintBarCode = null,
		int? DisplayHeader = null,
		string pSite = null)
		{
			ProjNumType _StartingProjNum = StartingProjNum;
			ProjNumType _EndingProjNum = EndingProjNum;
			TaskNumType _StartingTaskNum = StartingTaskNum;
			TaskNumType _EndingTaskNum = EndingTaskNum;
			ItemType _StartingKit = StartingKit;
			ItemType _EndingKit = EndingKit;
			ListYesNoType _SortByLoc = SortByLoc;
			ListYesNoType _PrintSecondaryLocations = PrintSecondaryLocations;
			ListYesNoType _ExtendByScrapFactor = ExtendByScrapFactor;
			ListYesNoType _PrintBarCode = PrintBarCode;
			ListYesNoType _DisplayHeader = DisplayHeader;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_ProjectResourceKitPickListSp";
				
				appDB.AddCommandParameter(cmd, "StartingProjNum", _StartingProjNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingProjNum", _EndingProjNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartingTaskNum", _StartingTaskNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingTaskNum", _EndingTaskNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartingKit", _StartingKit, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingKit", _EndingKit, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SortByLoc", _SortByLoc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintSecondaryLocations", _PrintSecondaryLocations, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExtendByScrapFactor", _ExtendByScrapFactor, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintBarCode", _PrintBarCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayHeader", _DisplayHeader, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pSite", _pSite, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;
				
				dtReturn = appDB.ExecuteQuery(cmd);
				
				return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
