//PROJECT NAME: Material
//CLASS NAME: EcnCpEcn.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public class EcnCpEcn : IEcnCpEcn
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public EcnCpEcn(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode, string Infobar) EcnCpEcnSp(string FromEcnType,
		int? FromEcnNum,
		string FromEcnStat,
		string FromEcnJobType,
		int? FromBeginEcnLine,
		int? FromEndEcnLine,
		int? ToEcnNum,
		string EcnLineOption,
		int? RunMode,
		string Infobar)
		{
			StringType _FromEcnType = FromEcnType;
			EcnNumType _FromEcnNum = FromEcnNum;
			StringType _FromEcnStat = FromEcnStat;
			StringType _FromEcnJobType = FromEcnJobType;
			EcnLineType _FromBeginEcnLine = FromBeginEcnLine;
			EcnLineType _FromEndEcnLine = FromEndEcnLine;
			EcnNumType _ToEcnNum = ToEcnNum;
			StringType _EcnLineOption = EcnLineOption;
			ByteType _RunMode = RunMode;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "EcnCpEcnSp";
				
				appDB.AddCommandParameter(cmd, "FromEcnType", _FromEcnType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromEcnNum", _FromEcnNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromEcnStat", _FromEcnStat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromEcnJobType", _FromEcnJobType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromBeginEcnLine", _FromBeginEcnLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromEndEcnLine", _FromEndEcnLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToEcnNum", _ToEcnNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EcnLineOption", _EcnLineOption, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RunMode", _RunMode, ParameterDirection.Input);
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
