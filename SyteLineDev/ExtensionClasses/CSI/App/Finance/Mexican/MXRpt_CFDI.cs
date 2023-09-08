//PROJECT NAME: Finance
//CLASS NAME: MXRpt_CFDI.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance.Mexican
{
	public class MXRpt_CFDI : IMXRpt_CFDI
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public MXRpt_CFDI(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode,
			string Infobar) MXRpt_CFDISp(
			string pProFormaInvNumStarting = null,
			string pProFormaInvNumEnding = null,
			DateTime? pProFormaInvDateStarting = null,
			DateTime? pProFormaInvDateEnding = null,
			string Infobar = null)
		{
			InvNumType _pProFormaInvNumStarting = pProFormaInvNumStarting;
			InvNumType _pProFormaInvNumEnding = pProFormaInvNumEnding;
			DateType _pProFormaInvDateStarting = pProFormaInvDateStarting;
			DateType _pProFormaInvDateEnding = pProFormaInvDateEnding;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "MXRpt_CFDISp";
				
				appDB.AddCommandParameter(cmd, "pProFormaInvNumStarting", _pProFormaInvNumStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pProFormaInvNumEnding", _pProFormaInvNumEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pProFormaInvDateStarting", _pProFormaInvDateStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pProFormaInvDateEnding", _pProFormaInvDateEnding, ParameterDirection.Input);
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
