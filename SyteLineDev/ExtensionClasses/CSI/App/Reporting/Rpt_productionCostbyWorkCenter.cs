//PROJECT NAME: Reporting
//CLASS NAME: Rpt_productionCostbyWorkCenter.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_productionCostbyWorkCenter : IRpt_productionCostbyWorkCenter
	{
		IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_productionCostbyWorkCenter(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_productionCostbyWorkCenterSp(string StartingWorkCenter = null,
		string EndingWorkCenter = null,
		DateTime? StartingTransDate = null,
		DateTime? EndingTransDate = null,
		int? StartingTransDateOffset = null,
		int? EndingTransDateOffset = null,
		int? DisplayHeader = null,
		string pSite = null)
		{
			WcType _StartingWorkCenter = StartingWorkCenter;
			WcType _EndingWorkCenter = EndingWorkCenter;
			DateType _StartingTransDate = StartingTransDate;
			DateType _EndingTransDate = EndingTransDate;
			DateOffsetType _StartingTransDateOffset = StartingTransDateOffset;
			DateOffsetType _EndingTransDateOffset = EndingTransDateOffset;
			ListYesNoType _DisplayHeader = DisplayHeader;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_productionCostbyWorkCenterSp";
				
				appDB.AddCommandParameter(cmd, "StartingWorkCenter", _StartingWorkCenter, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingWorkCenter", _EndingWorkCenter, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartingTransDate", _StartingTransDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingTransDate", _EndingTransDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartingTransDateOffset", _StartingTransDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingTransDateOffset", _EndingTransDateOffset, ParameterDirection.Input);
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
