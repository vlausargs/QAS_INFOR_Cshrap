//PROJECT NAME: Reporting
//CLASS NAME: Rpt_ECNStatus.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public interface IRpt_ECNStatus
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_ECNStatusSp(int? ExOptBegECN_num = null,
		int? ExOptEndECN_num = null,
		string ExOptgoJobType = null,
		string ExOptdfEcnitemStat = null,
		string ExOptdfEcnStatH = null,
		string ExOpthBegitem = null,
		string ExOpthEnditem = null,
		byte? ExOptszSortEcnJob = null,
		DateTime? ExOptBegReqDate = null,
		DateTime? ExOptEndReqDate = null,
		short? DateStartingOffSET = null,
		short? DateEndingOffSET = null,
		byte? DisplayHeader = null,
		string pSite = null);
	}
	
	public class Rpt_ECNStatus : IRpt_ECNStatus
	{
		IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_ECNStatus(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_ECNStatusSp(int? ExOptBegECN_num = null,
		int? ExOptEndECN_num = null,
		string ExOptgoJobType = null,
		string ExOptdfEcnitemStat = null,
		string ExOptdfEcnStatH = null,
		string ExOpthBegitem = null,
		string ExOpthEnditem = null,
		byte? ExOptszSortEcnJob = null,
		DateTime? ExOptBegReqDate = null,
		DateTime? ExOptEndReqDate = null,
		short? DateStartingOffSET = null,
		short? DateEndingOffSET = null,
		byte? DisplayHeader = null,
		string pSite = null)
		{
			EcnNumType _ExOptBegECN_num = ExOptBegECN_num;
			EcnNumType _ExOptEndECN_num = ExOptEndECN_num;
			InfobarType _ExOptgoJobType = ExOptgoJobType;
			InfobarType _ExOptdfEcnitemStat = ExOptdfEcnitemStat;
			InfobarType _ExOptdfEcnStatH = ExOptdfEcnStatH;
			ItemType _ExOpthBegitem = ExOpthBegitem;
			ItemType _ExOpthEnditem = ExOpthEnditem;
			ListYesNoType _ExOptszSortEcnJob = ExOptszSortEcnJob;
			DateType _ExOptBegReqDate = ExOptBegReqDate;
			DateType _ExOptEndReqDate = ExOptEndReqDate;
			DateOffsetType _DateStartingOffSET = DateStartingOffSET;
			DateOffsetType _DateEndingOffSET = DateEndingOffSET;
			ListYesNoType _DisplayHeader = DisplayHeader;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_ECNStatusSp";
				
				appDB.AddCommandParameter(cmd, "ExOptBegECN_num", _ExOptBegECN_num, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptEndECN_num", _ExOptEndECN_num, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptgoJobType", _ExOptgoJobType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptdfEcnitemStat", _ExOptdfEcnitemStat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptdfEcnStatH", _ExOptdfEcnStatH, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOpthBegitem", _ExOpthBegitem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOpthEnditem", _ExOpthEnditem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptszSortEcnJob", _ExOptszSortEcnJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptBegReqDate", _ExOptBegReqDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptEndReqDate", _ExOptEndReqDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DateStartingOffSET", _DateStartingOffSET, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DateEndingOffSET", _DateEndingOffSET, ParameterDirection.Input);
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
