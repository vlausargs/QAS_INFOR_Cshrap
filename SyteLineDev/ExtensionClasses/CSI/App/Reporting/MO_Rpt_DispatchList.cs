//PROJECT NAME: CSIReport
//CLASS NAME: MO_Rpt_DispatchList.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public interface IMO_Rpt_DispatchList
	{
		(ICollectionLoadResponse Data, int? ReturnCode) MO_Rpt_DispatchListSp(string MoldingReportType = null,
		string SecondaryResourceType = null,
		string ResourceStarting = null,
		string ResourceEnding = null,
		string ResourceGroupStarting = null,
		string ResourceGroupEnding = null,
		DateTime? ScheduleDateStarting = null,
		DateTime? ScheduleDateEnding = null,
		short? ScheduleDateStartingOffset = null,
		short? ScheduleDateEndingOffset = null,
		byte? ShowDateTime = (byte)1,
		byte? DisplayHeader = (byte)1,
		string pSite = null);
	}
	
	public class MO_Rpt_DispatchList : IMO_Rpt_DispatchList
	{
		IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public MO_Rpt_DispatchList(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) MO_Rpt_DispatchListSp(string MoldingReportType = null,
		string SecondaryResourceType = null,
		string ResourceStarting = null,
		string ResourceEnding = null,
		string ResourceGroupStarting = null,
		string ResourceGroupEnding = null,
		DateTime? ScheduleDateStarting = null,
		DateTime? ScheduleDateEnding = null,
		short? ScheduleDateStartingOffset = null,
		short? ScheduleDateEndingOffset = null,
		byte? ShowDateTime = (byte)1,
		byte? DisplayHeader = (byte)1,
		string pSite = null)
		{
			ApsRestypeType _MoldingReportType = MoldingReportType;
			ApsRestypeType _SecondaryResourceType = SecondaryResourceType;
			ApsResourceType _ResourceStarting = ResourceStarting;
			ApsResourceType _ResourceEnding = ResourceEnding;
			ApsResgroupType _ResourceGroupStarting = ResourceGroupStarting;
			ApsResgroupType _ResourceGroupEnding = ResourceGroupEnding;
			DateTimeType _ScheduleDateStarting = ScheduleDateStarting;
			DateTimeType _ScheduleDateEnding = ScheduleDateEnding;
			DateOffsetType _ScheduleDateStartingOffset = ScheduleDateStartingOffset;
			DateOffsetType _ScheduleDateEndingOffset = ScheduleDateEndingOffset;
			ListYesNoType _ShowDateTime = ShowDateTime;
			ListYesNoType _DisplayHeader = DisplayHeader;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "MO_Rpt_DispatchListSp";
				
				appDB.AddCommandParameter(cmd, "MoldingReportType", _MoldingReportType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SecondaryResourceType", _SecondaryResourceType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ResourceStarting", _ResourceStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ResourceEnding", _ResourceEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ResourceGroupStarting", _ResourceGroupStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ResourceGroupEnding", _ResourceGroupEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ScheduleDateStarting", _ScheduleDateStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ScheduleDateEnding", _ScheduleDateEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ScheduleDateStartingOffset", _ScheduleDateStartingOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ScheduleDateEndingOffset", _ScheduleDateEndingOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShowDateTime", _ShowDateTime, ParameterDirection.Input);
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
