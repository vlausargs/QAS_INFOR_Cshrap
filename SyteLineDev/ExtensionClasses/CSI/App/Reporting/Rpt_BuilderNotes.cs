//PROJECT NAME: Reporting
//CLASS NAME: Rpt_BuilderNotes.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public interface IRpt_BuilderNotes
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_BuilderNotesSp(Guid? pProcessId = null,
		string pSiteRef = null,
		Guid? pRefRowPointer = null,
		byte? pShowInternal = null,
		byte? pShowExternal = null,
		string pSite = null);
	}
	
	public class Rpt_BuilderNotes : IRpt_BuilderNotes
	{
		IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_BuilderNotes(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_BuilderNotesSp(Guid? pProcessId = null,
		string pSiteRef = null,
		Guid? pRefRowPointer = null,
		byte? pShowInternal = null,
		byte? pShowExternal = null,
		string pSite = null)
		{
			RowPointerType _pProcessId = pProcessId;
			SiteType _pSiteRef = pSiteRef;
			RowPointerType _pRefRowPointer = pRefRowPointer;
			ListYesNoType _pShowInternal = pShowInternal;
			ListYesNoType _pShowExternal = pShowExternal;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_BuilderNotesSp";
				
				appDB.AddCommandParameter(cmd, "pProcessId", _pProcessId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pSiteRef", _pSiteRef, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pRefRowPointer", _pRefRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pShowInternal", _pShowInternal, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pShowExternal", _pShowExternal, ParameterDirection.Input);
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
