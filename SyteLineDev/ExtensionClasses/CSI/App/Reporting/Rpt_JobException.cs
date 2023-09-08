//PROJECT NAME: Reporting
//CLASS NAME: Rpt_JobException.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_JobException : IRpt_JobException
	{
		IApplicationDB appDB;
		IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_JobException(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_JobExceptionSp(string StartJob = null,
		string EndJob = null,
		int? SSuffix = null,
		int? ESuffix = null,
		string Status = null,
		decimal? TolFactor = null,
		int? ShowDetail = null,
		string DispJobTol = null,
		string StartItem = null,
		string EndItem = null,
		string SCustNum = null,
		string ECustNum = null,
		string StartProdMix = null,
		string EndProdMix = null,
		string OrdType = null,
		string SOrdNum = null,
		string EOrdNum = null,
		DateTime? SLstTrxDate = null,
		DateTime? ELstTrxDate = null,
		DateTime? StartJobDate = null,
		DateTime? EndJobDate = null,
		int? SLstTrxDateOffSET = null,
		int? ELstTrxDateOffSET = null,
		int? SJobDateOffSET = null,
		int? EJobDateOffSET = null,
		int? DisplayHeader = null,
		string pSite = null,
		string BGUser = null)
		{
			JobType _StartJob = StartJob;
			JobType _EndJob = EndJob;
			SuffixType _SSuffix = SSuffix;
			SuffixType _ESuffix = ESuffix;
			StringType _Status = Status;
			DecimalType _TolFactor = TolFactor;
			FlagNyType _ShowDetail = ShowDetail;
			StringType _DispJobTol = DispJobTol;
			ItemType _StartItem = StartItem;
			ItemType _EndItem = EndItem;
			CustNumType _SCustNum = SCustNum;
			CustNumType _ECustNum = ECustNum;
			ProdMixType _StartProdMix = StartProdMix;
			ProdMixType _EndProdMix = EndProdMix;
			RefTypeIKOTType _OrdType = OrdType;
			CoProjTrnNumType _SOrdNum = SOrdNum;
			CoProjTrnNumType _EOrdNum = EOrdNum;
			DateType _SLstTrxDate = SLstTrxDate;
			DateType _ELstTrxDate = ELstTrxDate;
			DateType _StartJobDate = StartJobDate;
			DateType _EndJobDate = EndJobDate;
			DateOffsetType _SLstTrxDateOffSET = SLstTrxDateOffSET;
			DateOffsetType _ELstTrxDateOffSET = ELstTrxDateOffSET;
			DateOffsetType _SJobDateOffSET = SJobDateOffSET;
			DateOffsetType _EJobDateOffSET = EJobDateOffSET;
			ListYesNoType _DisplayHeader = DisplayHeader;
			SiteType _pSite = pSite;
			UsernameType _BGUser = BGUser;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_JobExceptionSp";
				
				appDB.AddCommandParameter(cmd, "StartJob", _StartJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndJob", _EndJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SSuffix", _SSuffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ESuffix", _ESuffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Status", _Status, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TolFactor", _TolFactor, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShowDetail", _ShowDetail, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DispJobTol", _DispJobTol, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartItem", _StartItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndItem", _EndItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SCustNum", _SCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ECustNum", _ECustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartProdMix", _StartProdMix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndProdMix", _EndProdMix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrdType", _OrdType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SOrdNum", _SOrdNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EOrdNum", _EOrdNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SLstTrxDate", _SLstTrxDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ELstTrxDate", _ELstTrxDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartJobDate", _StartJobDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndJobDate", _EndJobDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SLstTrxDateOffSET", _SLstTrxDateOffSET, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ELstTrxDateOffSET", _ELstTrxDateOffSET, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SJobDateOffSET", _SJobDateOffSET, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EJobDateOffSET", _EJobDateOffSET, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayHeader", _DisplayHeader, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pSite", _pSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BGUser", _BGUser, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;
				
				dtReturn = appDB.ExecuteQuery(cmd);
				
				return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
