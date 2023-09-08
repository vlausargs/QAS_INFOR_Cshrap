//PROJECT NAME: Reporting
//CLASS NAME: Rpt_UnitCodeWhereUsed.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_UnitCodeWhereUsed : IRpt_UnitCodeWhereUsed
	{
		readonly IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
        readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_UnitCodeWhereUsed(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_UnitCodeWhereUsedSp(string UnitCode1Starting = null,
		string UnitCode1Ending = null,
		string UnitCode2Starting = null,
		string UnitCode2Ending = null,
		string UnitCode3Starting = null,
		string UnitCode3Ending = null,
		string UnitCode4Starting = null,
		string UnitCode4Ending = null,
		int? DisplayHeader = null,
		string MessageLanguage = null,
		string pSite = null,
		string BGUser = null)
		{
			UnitCode1Type _UnitCode1Starting = UnitCode1Starting;
			UnitCode1Type _UnitCode1Ending = UnitCode1Ending;
			UnitCode2Type _UnitCode2Starting = UnitCode2Starting;
			UnitCode2Type _UnitCode2Ending = UnitCode2Ending;
			UnitCode3Type _UnitCode3Starting = UnitCode3Starting;
			UnitCode3Type _UnitCode3Ending = UnitCode3Ending;
			UnitCode1Type _UnitCode4Starting = UnitCode4Starting;
			UnitCode1Type _UnitCode4Ending = UnitCode4Ending;
			ListYesNoType _DisplayHeader = DisplayHeader;
			MessageLanguageType _MessageLanguage = MessageLanguage;
			SiteType _pSite = pSite;
			UsernameType _BGUser = BGUser;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_UnitCodeWhereUsedSp";
				
				appDB.AddCommandParameter(cmd, "UnitCode1Starting", _UnitCode1Starting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UnitCode1Ending", _UnitCode1Ending, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UnitCode2Starting", _UnitCode2Starting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UnitCode2Ending", _UnitCode2Ending, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UnitCode3Starting", _UnitCode3Starting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UnitCode3Ending", _UnitCode3Ending, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UnitCode4Starting", _UnitCode4Starting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UnitCode4Ending", _UnitCode4Ending, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayHeader", _DisplayHeader, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MessageLanguage", _MessageLanguage, ParameterDirection.Input);
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
