//PROJECT NAME: Production
//CLASS NAME: RevMsPost.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.Projects
{
	public class RevMsPost : IRevMsPost
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public RevMsPost(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) RevMsPostSp(string Process,
		string FromProjNum,
		string ToProjNum,
		string FromRevMsNum,
		string ToRevMsNum,
		int? MsPeriod,
		int? MsYear,
		DateTime? PostDate,
		string PrintLevel,
		string PostLevel)
		{
			StringType _Process = Process;
			HighLowCharType _FromProjNum = FromProjNum;
			HighLowCharType _ToProjNum = ToProjNum;
			HighLowCharType _FromRevMsNum = FromRevMsNum;
			HighLowCharType _ToRevMsNum = ToRevMsNum;
			FinPeriodType _MsPeriod = MsPeriod;
			FiscalYearType _MsYear = MsYear;
			DateType _PostDate = PostDate;
			StringType _PrintLevel = PrintLevel;
			StringType _PostLevel = PostLevel;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "RevMsPostSp";
				
				appDB.AddCommandParameter(cmd, "Process", _Process, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromProjNum", _FromProjNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToProjNum", _ToProjNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromRevMsNum", _FromRevMsNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToRevMsNum", _ToRevMsNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MsPeriod", _MsPeriod, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MsYear", _MsYear, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PostDate", _PostDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintLevel", _PrintLevel, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PostLevel", _PostLevel, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;
				
				dtReturn = appDB.ExecuteQuery(cmd);
				
				return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
