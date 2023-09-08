//PROJECT NAME: Reporting
//CLASS NAME: Rpt_Ap01FRI.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public interface IRpt_Ap01FRI
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_Ap01FRISp(string PSessionIDChar = null,
		string PPayType = null,
		byte? PDistDetail = null,
		DateTime? PPayDateStarting = null,
		DateTime? PPayDateEnding = null,
		int? TaskId = null,
		byte? PrintAPCheckStubs = null,
		string PFormType = null,
		string pSite = null,
		string BGUser = null);
	}
	
	public class Rpt_Ap01FRI : IRpt_Ap01FRI
	{
		IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_Ap01FRI(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_Ap01FRISp(string PSessionIDChar = null,
		string PPayType = null,
		byte? PDistDetail = null,
		DateTime? PPayDateStarting = null,
		DateTime? PPayDateEnding = null,
		int? TaskId = null,
		byte? PrintAPCheckStubs = null,
		string PFormType = null,
		string pSite = null,
		string BGUser = null)
		{
			StringType _PSessionIDChar = PSessionIDChar;
			NameType _PPayType = PPayType;
			ListYesNoType _PDistDetail = PDistDetail;
			DateType _PPayDateStarting = PPayDateStarting;
			DateType _PPayDateEnding = PPayDateEnding;
			TaskNumType _TaskId = TaskId;
			ListYesNoType _PrintAPCheckStubs = PrintAPCheckStubs;
			NameType _PFormType = PFormType;
			SiteType _pSite = pSite;
			UsernameType _BGUser = BGUser;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_Ap01FRISp";
				
				appDB.AddCommandParameter(cmd, "PSessionIDChar", _PSessionIDChar, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPayType", _PPayType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PDistDetail", _PDistDetail, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPayDateStarting", _PPayDateStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPayDateEnding", _PPayDateEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TaskId", _TaskId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintAPCheckStubs", _PrintAPCheckStubs, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PFormType", _PFormType, ParameterDirection.Input);
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
