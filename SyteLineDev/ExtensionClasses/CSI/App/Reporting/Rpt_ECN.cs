//PROJECT NAME: Reporting
//CLASS NAME: Rpt_ECN.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public interface IRpt_ECN
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_ECNSp(int? ExOptBegECN_num = null,
		int? ExOptENDECN_num = null,
		string ExOptgoJobType = null,
		string ExOpthBegjob = null,
		string ExOpTHENDjob = null,
		short? ExOpthBegsuffix = null,
		short? ExOpTHENDsuffix = null,
		string ExOpthBegitem = null,
		string ExOpTHENDitem = null,
		string ExOpthBegrevision = null,
		string ExOpTHENDrevision = null,
		string ExOpthBegorig = null,
		string ExOpTHENDorig = null,
		DateTime? ExOpthBegreqdate = null,
		DateTime? ExOpTHENDreqdate = null,
		DateTime? ExOpthBegappdate = null,
		DateTime? ExOpTHENDappdate = null,
		DateTime? ExOpthBegcompdate = null,
		DateTime? ExOpTHENDcompdate = null,
		short? DateStartingOffSET = null,
		short? DateENDingOffSET = null,
		short? DateStartingappdateOffSET = null,
		short? DateENDingappdateOffSET = null,
		short? DateStartingcompdateOffSET = null,
		short? DateENDingcompdateOffSET = null,
		byte? PrintTableECN = null,
		byte? PrintTableEcnItem = null,
		byte? PrintTableEcndist = null,
		byte? ShowInternal = null,
		byte? ShowExternal = null,
		byte? DisplayHeader = null,
		string pSite = null);
	}
	
	public class Rpt_ECN : IRpt_ECN
	{
		IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_ECN(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_ECNSp(int? ExOptBegECN_num = null,
		int? ExOptENDECN_num = null,
		string ExOptgoJobType = null,
		string ExOpthBegjob = null,
		string ExOpTHENDjob = null,
		short? ExOpthBegsuffix = null,
		short? ExOpTHENDsuffix = null,
		string ExOpthBegitem = null,
		string ExOpTHENDitem = null,
		string ExOpthBegrevision = null,
		string ExOpTHENDrevision = null,
		string ExOpthBegorig = null,
		string ExOpTHENDorig = null,
		DateTime? ExOpthBegreqdate = null,
		DateTime? ExOpTHENDreqdate = null,
		DateTime? ExOpthBegappdate = null,
		DateTime? ExOpTHENDappdate = null,
		DateTime? ExOpthBegcompdate = null,
		DateTime? ExOpTHENDcompdate = null,
		short? DateStartingOffSET = null,
		short? DateENDingOffSET = null,
		short? DateStartingappdateOffSET = null,
		short? DateENDingappdateOffSET = null,
		short? DateStartingcompdateOffSET = null,
		short? DateENDingcompdateOffSET = null,
		byte? PrintTableECN = null,
		byte? PrintTableEcnItem = null,
		byte? PrintTableEcndist = null,
		byte? ShowInternal = null,
		byte? ShowExternal = null,
		byte? DisplayHeader = null,
		string pSite = null)
		{
			EcnNumType _ExOptBegECN_num = ExOptBegECN_num;
			EcnNumType _ExOptENDECN_num = ExOptENDECN_num;
			InfobarType _ExOptgoJobType = ExOptgoJobType;
			JobType _ExOpthBegjob = ExOpthBegjob;
			JobType _ExOpTHENDjob = ExOpTHENDjob;
			SuffixType _ExOpthBegsuffix = ExOpthBegsuffix;
			SuffixType _ExOpTHENDsuffix = ExOpTHENDsuffix;
			ItemType _ExOpthBegitem = ExOpthBegitem;
			ItemType _ExOpTHENDitem = ExOpTHENDitem;
			RevisionType _ExOpthBegrevision = ExOpthBegrevision;
			RevisionType _ExOpTHENDrevision = ExOpTHENDrevision;
			NameType _ExOpthBegorig = ExOpthBegorig;
			NameType _ExOpTHENDorig = ExOpTHENDorig;
			DateType _ExOpthBegreqdate = ExOpthBegreqdate;
			DateType _ExOpTHENDreqdate = ExOpTHENDreqdate;
			DateType _ExOpthBegappdate = ExOpthBegappdate;
			DateType _ExOpTHENDappdate = ExOpTHENDappdate;
			DateType _ExOpthBegcompdate = ExOpthBegcompdate;
			DateType _ExOpTHENDcompdate = ExOpTHENDcompdate;
			DateOffsetType _DateStartingOffSET = DateStartingOffSET;
			DateOffsetType _DateENDingOffSET = DateENDingOffSET;
			DateOffsetType _DateStartingappdateOffSET = DateStartingappdateOffSET;
			DateOffsetType _DateENDingappdateOffSET = DateENDingappdateOffSET;
			DateOffsetType _DateStartingcompdateOffSET = DateStartingcompdateOffSET;
			DateOffsetType _DateENDingcompdateOffSET = DateENDingcompdateOffSET;
			ListYesNoType _PrintTableECN = PrintTableECN;
			ListYesNoType _PrintTableEcnItem = PrintTableEcnItem;
			ListYesNoType _PrintTableEcndist = PrintTableEcndist;
			FlagNyType _ShowInternal = ShowInternal;
			FlagNyType _ShowExternal = ShowExternal;
			ListYesNoType _DisplayHeader = DisplayHeader;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_ECNSp";
				
				appDB.AddCommandParameter(cmd, "ExOptBegECN_num", _ExOptBegECN_num, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptENDECN_num", _ExOptENDECN_num, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptgoJobType", _ExOptgoJobType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOpthBegjob", _ExOpthBegjob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOpTHENDjob", _ExOpTHENDjob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOpthBegsuffix", _ExOpthBegsuffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOpTHENDsuffix", _ExOpTHENDsuffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOpthBegitem", _ExOpthBegitem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOpTHENDitem", _ExOpTHENDitem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOpthBegrevision", _ExOpthBegrevision, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOpTHENDrevision", _ExOpTHENDrevision, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOpthBegorig", _ExOpthBegorig, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOpTHENDorig", _ExOpTHENDorig, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOpthBegreqdate", _ExOpthBegreqdate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOpTHENDreqdate", _ExOpTHENDreqdate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOpthBegappdate", _ExOpthBegappdate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOpTHENDappdate", _ExOpTHENDappdate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOpthBegcompdate", _ExOpthBegcompdate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOpTHENDcompdate", _ExOpTHENDcompdate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DateStartingOffSET", _DateStartingOffSET, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DateENDingOffSET", _DateENDingOffSET, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DateStartingappdateOffSET", _DateStartingappdateOffSET, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DateENDingappdateOffSET", _DateENDingappdateOffSET, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DateStartingcompdateOffSET", _DateStartingcompdateOffSET, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DateENDingcompdateOffSET", _DateENDingcompdateOffSET, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintTableECN", _PrintTableECN, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintTableEcnItem", _PrintTableEcnItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintTableEcndist", _PrintTableEcndist, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShowInternal", _ShowInternal, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShowExternal", _ShowExternal, ParameterDirection.Input);
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
