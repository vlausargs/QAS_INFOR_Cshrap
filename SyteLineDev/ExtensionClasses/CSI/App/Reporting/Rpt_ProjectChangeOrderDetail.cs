//PROJECT NAME: Reporting
//CLASS NAME: Rpt_ProjectChangeOrderDetail.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_ProjectChangeOrderDetail : IRpt_ProjectChangeOrderDetail
	{
		IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_ProjectChangeOrderDetail(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_ProjectChangeOrderDetailSp(string pChgStat = null,
		string pPrChgTxtDet = null,
		string pStartProjNum = null,
		string pEndProjNum = null,
		int? pStartChgNum = null,
		int? pEndChgNum = null,
		int? pStartTaskNum = null,
		int? pEndTaskNum = null,
		int? pStartSeq = null,
		int? pEndSeq = null,
		DateTime? pStartChgDate = null,
		DateTime? pEndChgDate = null,
		int? pStartChgDateOffset = null,
		int? pEndChgDateOffset = null,
		int? Showinternal = 1,
		int? ShowExternal = 1,
		int? DisplayHeader = null,
		string PMessageLanguage = null,
		string pSite = null)
		{
			StringType _pChgStat = pChgStat;
			StringType _pPrChgTxtDet = pPrChgTxtDet;
			HighLowCharType _pStartProjNum = pStartProjNum;
			HighLowCharType _pEndProjNum = pEndProjNum;
			GenericIntType _pStartChgNum = pStartChgNum;
			GenericIntType _pEndChgNum = pEndChgNum;
			GenericIntType _pStartTaskNum = pStartTaskNum;
			GenericIntType _pEndTaskNum = pEndTaskNum;
			GenericIntType _pStartSeq = pStartSeq;
			GenericIntType _pEndSeq = pEndSeq;
			GenericDateType _pStartChgDate = pStartChgDate;
			GenericDateType _pEndChgDate = pEndChgDate;
			DateOffsetType _pStartChgDateOffset = pStartChgDateOffset;
			DateOffsetType _pEndChgDateOffset = pEndChgDateOffset;
			FlagNyType _Showinternal = Showinternal;
			FlagNyType _ShowExternal = ShowExternal;
			ListYesNoType _DisplayHeader = DisplayHeader;
			MessageLanguageType _PMessageLanguage = PMessageLanguage;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_ProjectChangeOrderDetailSp";
				
				appDB.AddCommandParameter(cmd, "pChgStat", _pChgStat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pPrChgTxtDet", _pPrChgTxtDet, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pStartProjNum", _pStartProjNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pEndProjNum", _pEndProjNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pStartChgNum", _pStartChgNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pEndChgNum", _pEndChgNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pStartTaskNum", _pStartTaskNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pEndTaskNum", _pEndTaskNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pStartSeq", _pStartSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pEndSeq", _pEndSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pStartChgDate", _pStartChgDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pEndChgDate", _pEndChgDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pStartChgDateOffset", _pStartChgDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pEndChgDateOffset", _pEndChgDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Showinternal", _Showinternal, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShowExternal", _ShowExternal, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayHeader", _DisplayHeader, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PMessageLanguage", _PMessageLanguage, ParameterDirection.Input);
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
