//PROJECT NAME: CSIConfig
//CLASS NAME: CfgPurgeUtility.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Config
{
	public interface ICfgPurgeUtility
	{
		(ICollectionLoadResponse Data, int? ReturnCode, int? pRecCnt, string Infobar) CfgPurgeUtilitySp(byte? pDelSymcfg,
		DateTime? pBegDate,
		DateTime? pEndDate,
		int? pRecCnt,
		string Infobar,
		short? StartingDateOffset = null,
		short? EndingDateOffset = null,
		byte? ListConfigs = null);
	}
	
	public class CfgPurgeUtility : ICfgPurgeUtility
	{
		IApplicationDB appDB;
		IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public CfgPurgeUtility(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode, int? pRecCnt, string Infobar) CfgPurgeUtilitySp(byte? pDelSymcfg,
		DateTime? pBegDate,
		DateTime? pEndDate,
		int? pRecCnt,
		string Infobar,
		short? StartingDateOffset = null,
		short? EndingDateOffset = null,
		byte? ListConfigs = null)
		{
			FlagNyType _pDelSymcfg = pDelSymcfg;
			CurrentDateType _pBegDate = pBegDate;
			CurrentDateType _pEndDate = pEndDate;
			GenericNoType _pRecCnt = pRecCnt;
			InfobarType _Infobar = Infobar;
			DateOffsetType _StartingDateOffset = StartingDateOffset;
			DateOffsetType _EndingDateOffset = EndingDateOffset;
			FlagNyType _ListConfigs = ListConfigs;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CfgPurgeUtilitySp";
				
				appDB.AddCommandParameter(cmd, "pDelSymcfg", _pDelSymcfg, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pBegDate", _pBegDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pEndDate", _pEndDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pRecCnt", _pRecCnt, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "StartingDateOffset", _StartingDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingDateOffset", _EndingDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ListConfigs", _ListConfigs, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;

                dtReturn = appDB.ExecuteQuery(cmd);

                pRecCnt = _pRecCnt;
				Infobar = _Infobar;
				
				return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value, pRecCnt, Infobar);
			}
		}
	}
}
