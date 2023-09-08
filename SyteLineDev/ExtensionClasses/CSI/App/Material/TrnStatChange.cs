//PROJECT NAME: Material
//CLASS NAME: TrnStatChange.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public interface ITrnStatChange
	{
		(ICollectionLoadResponse Data, int? ReturnCode, string Infobar) TrnStatChangeSp(string BegTrnNum,
		string EndTrnNum,
		short? BegTrnLine,
		short? EndTrnLine,
		DateTime? BegDateRec,
		DateTime? EndDateRec,
		byte? PProcess,
		string Infobar,
		short? StartingReceivedDateOffset = null,
		short? EndingReceivedDateOffset = null);
	}
	
	public class TrnStatChange : ITrnStatChange
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public TrnStatChange(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode, string Infobar) TrnStatChangeSp(string BegTrnNum,
		string EndTrnNum,
		short? BegTrnLine,
		short? EndTrnLine,
		DateTime? BegDateRec,
		DateTime? EndDateRec,
		byte? PProcess,
		string Infobar,
		short? StartingReceivedDateOffset = null,
		short? EndingReceivedDateOffset = null)
		{
			TrnNumType _BegTrnNum = BegTrnNum;
			TrnNumType _EndTrnNum = EndTrnNum;
			TrnLineType _BegTrnLine = BegTrnLine;
			TrnLineType _EndTrnLine = EndTrnLine;
			DateType _BegDateRec = BegDateRec;
			DateType _EndDateRec = EndDateRec;
			FlagNyType _PProcess = PProcess;
			InfobarType _Infobar = Infobar;
			DateOffsetType _StartingReceivedDateOffset = StartingReceivedDateOffset;
			DateOffsetType _EndingReceivedDateOffset = EndingReceivedDateOffset;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "TrnStatChangeSp";
				
				appDB.AddCommandParameter(cmd, "BegTrnNum", _BegTrnNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndTrnNum", _EndTrnNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BegTrnLine", _BegTrnLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndTrnLine", _EndTrnLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BegDateRec", _BegDateRec, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndDateRec", _EndDateRec, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PProcess", _PProcess, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "StartingReceivedDateOffset", _StartingReceivedDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingReceivedDateOffset", _EndingReceivedDateOffset, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;

                dtReturn = appDB.ExecuteQuery(cmd);

                Infobar = _Infobar;
				
				return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value, Infobar);
			}
		}
	}
}
