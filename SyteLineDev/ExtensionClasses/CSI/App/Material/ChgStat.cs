//PROJECT NAME: CSIMaterial
//CLASS NAME: ChgStat.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public interface IChgStat
	{
		(ICollectionLoadResponse Data, int? ReturnCode, string Infobar) ChgStatSp(string ProcSel,
		string EcnFStat,
		string EcnTStat,
		int? EcnFrom = null,
		int? EcnTo = null,
		string Infobar = null);
	}
	
	public class ChgStat : IChgStat
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public ChgStat(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode, string Infobar) ChgStatSp(string ProcSel,
		string EcnFStat,
		string EcnTStat,
		int? EcnFrom = null,
		int? EcnTo = null,
		string Infobar = null)
		{
			LongListType _ProcSel = ProcSel;
			LongListType _EcnFStat = EcnFStat;
			LongListType _EcnTStat = EcnTStat;
			EcnNumType _EcnFrom = EcnFrom;
			EcnNumType _EcnTo = EcnTo;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ChgStatSp";
				
				appDB.AddCommandParameter(cmd, "ProcSel", _ProcSel, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EcnFStat", _EcnFStat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EcnTStat", _EcnTStat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EcnFrom", _EcnFrom, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EcnTo", _EcnTo, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
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
