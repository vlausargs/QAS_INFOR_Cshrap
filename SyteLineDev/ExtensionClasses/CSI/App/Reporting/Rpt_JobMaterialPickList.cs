//PROJECT NAME: Reporting
//CLASS NAME: Rpt_JobMaterialPickList.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_JobMaterialPickList : IRpt_JobMaterialPickList
	{
		IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_JobMaterialPickList(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_JobMaterialPickListSp(string StartJob = null,
		string EndJob = null,
		int? StartSuffix = null,
		int? EndSuffix = null,
		string JobStat = null,
		string StartItem = null,
		string EndItem = null,
		string StartProdMix = null,
		string EndProdMix = null,
		DateTime? StartJobDate = null,
		DateTime? EndJobDate = null,
		int? StartOpera = null,
		int? EndOpera = null,
		int? MatlLst132 = null,
		int? MatlLstDate = null,
		int? PickByLoc = null,
		int? PrintSN = null,
		int? PrintBCFmt = null,
		int? PageOpera = null,
		int? PrintSecLoc = null,
		int? ExtScrapFact = null,
		string ReprintPick = null,
		int? DisplayRefFields = null,
		int? StartJobDateOffset = null,
		int? EndJobDateOffset = null,
		int? DisplayHeader = null,
		string BGSessionId = null,
		string pSite = null)
		{
			JobType _StartJob = StartJob;
			JobType _EndJob = EndJob;
			SuffixType _StartSuffix = StartSuffix;
			SuffixType _EndSuffix = EndSuffix;
			StringType _JobStat = JobStat;
			ItemType _StartItem = StartItem;
			ItemType _EndItem = EndItem;
			ProdMixType _StartProdMix = StartProdMix;
			ProdMixType _EndProdMix = EndProdMix;
			GenericDateType _StartJobDate = StartJobDate;
			GenericDateType _EndJobDate = EndJobDate;
			OperNumType _StartOpera = StartOpera;
			OperNumType _EndOpera = EndOpera;
			ListYesNoType _MatlLst132 = MatlLst132;
			ListYesNoType _MatlLstDate = MatlLstDate;
			ListYesNoType _PickByLoc = PickByLoc;
			ListYesNoType _PrintSN = PrintSN;
			ListYesNoType _PrintBCFmt = PrintBCFmt;
			ListYesNoType _PageOpera = PageOpera;
			ListYesNoType _PrintSecLoc = PrintSecLoc;
			ListYesNoType _ExtScrapFact = ExtScrapFact;
			StringType _ReprintPick = ReprintPick;
			ListYesNoType _DisplayRefFields = DisplayRefFields;
			DateOffsetType _StartJobDateOffset = StartJobDateOffset;
			DateOffsetType _EndJobDateOffset = EndJobDateOffset;
			ListYesNoType _DisplayHeader = DisplayHeader;
			StringType _BGSessionId = BGSessionId;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_JobMaterialPickListSp";
				
				appDB.AddCommandParameter(cmd, "StartJob", _StartJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndJob", _EndJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartSuffix", _StartSuffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndSuffix", _EndSuffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobStat", _JobStat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartItem", _StartItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndItem", _EndItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartProdMix", _StartProdMix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndProdMix", _EndProdMix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartJobDate", _StartJobDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndJobDate", _EndJobDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartOpera", _StartOpera, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndOpera", _EndOpera, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MatlLst132", _MatlLst132, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MatlLstDate", _MatlLstDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PickByLoc", _PickByLoc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintSN", _PrintSN, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintBCFmt", _PrintBCFmt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PageOpera", _PageOpera, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintSecLoc", _PrintSecLoc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExtScrapFact", _ExtScrapFact, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ReprintPick", _ReprintPick, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayRefFields", _DisplayRefFields, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartJobDateOffset", _StartJobDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndJobDateOffset", _EndJobDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayHeader", _DisplayHeader, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BGSessionId", _BGSessionId, ParameterDirection.Input);
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
