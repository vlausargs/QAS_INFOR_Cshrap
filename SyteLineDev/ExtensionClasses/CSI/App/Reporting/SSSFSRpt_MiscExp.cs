//PROJECT NAME: Reporting
//CLASS NAME: SSSFSRpt_MiscExp.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class SSSFSRpt_MiscExp : ISSSFSRpt_MiscExp
	{
        readonly IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
        readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public SSSFSRpt_MiscExp(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) SSSFSRpt_MiscExpSp(string _iPartnerStart,
		string _iPartnerEnd,
		DateTime? _iTransDateStart,
		DateTime? _iTransDateEnd,
		int? _iTransDateStart_OffSET = null,
		int? _iTransDateEnd_OffSET = null,
		string _iSroNumStart = null,
		string _iSroNumEnd = null,
		int? _iSROLineStart = null,
		int? _iSROLineEnd = null,
		int? _iSroOperStart = null,
		int? _iSroOperEnd = null,
		string _iPayTypeStart = null,
		string _iPayTypeEnd = null,
		string _iMiscCodeStart = null,
		string _iMiscCodeEnd = null,
		string _iShowStat = null,
		string pSite = null)
		{
			FSPartnerType __iPartnerStart = _iPartnerStart;
			FSPartnerType __iPartnerEnd = _iPartnerEnd;
			DateType __iTransDateStart = _iTransDateStart;
			DateType __iTransDateEnd = _iTransDateEnd;
			DateOffsetType __iTransDateStart_OffSET = _iTransDateStart_OffSET;
			DateOffsetType __iTransDateEnd_OffSET = _iTransDateEnd_OffSET;
			FSSRONumType __iSroNumStart = _iSroNumStart;
			FSSRONumType __iSroNumEnd = _iSroNumEnd;
			FSSROLineType __iSROLineStart = _iSROLineStart;
			FSSROLineType __iSROLineEnd = _iSROLineEnd;
			FSSROOperType __iSroOperStart = _iSroOperStart;
			FSSROOperType __iSroOperEnd = _iSroOperEnd;
			FSPayTypeType __iPayTypeStart = _iPayTypeStart;
			FSPayTypeType __iPayTypeEnd = _iPayTypeEnd;
			FSMiscCodeType __iMiscCodeStart = _iMiscCodeStart;
			FSMiscCodeType __iMiscCodeEnd = _iMiscCodeEnd;
			StringType __iShowStat = _iShowStat;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSRpt_MiscExpSp";
				
				appDB.AddCommandParameter(cmd, "_iPartnerStart", __iPartnerStart, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "_iPartnerEnd", __iPartnerEnd, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "_iTransDateStart", __iTransDateStart, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "_iTransDateEnd", __iTransDateEnd, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "_iTransDateStart_OffSET", __iTransDateStart_OffSET, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "_iTransDateEnd_OffSET", __iTransDateEnd_OffSET, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "_iSroNumStart", __iSroNumStart, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "_iSroNumEnd", __iSroNumEnd, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "_iSROLineStart", __iSROLineStart, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "_iSROLineEnd", __iSROLineEnd, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "_iSroOperStart", __iSroOperStart, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "_iSroOperEnd", __iSroOperEnd, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "_iPayTypeStart", __iPayTypeStart, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "_iPayTypeEnd", __iPayTypeEnd, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "_iMiscCodeStart", __iMiscCodeStart, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "_iMiscCodeEnd", __iMiscCodeEnd, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "_iShowStat", __iShowStat, ParameterDirection.Input);
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
