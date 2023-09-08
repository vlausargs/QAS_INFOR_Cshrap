//PROJECT NAME: CSIAdmin
//CLASS NAME: CLM_UserStartFormSubForms.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Admin
{
	public interface ICLM_UserStartFormSubForms
	{
		(ICollectionLoadResponse Data, int? ReturnCode, string Infobar) CLM_UserStartFormSubFormsSp(string Username,
		string FilterString = null,
		string Infobar = null);
	}
	
	public class CLM_UserStartFormSubForms : ICLM_UserStartFormSubForms
	{
		IApplicationDB appDB;
		IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public CLM_UserStartFormSubForms(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode, string Infobar) CLM_UserStartFormSubFormsSp(string Username,
		string FilterString = null,
		string Infobar = null)
		{
			bunchedLoadCollection.StartBunching();
			
			try
			{
				UsernameType _Username = Username;
				LongListType _FilterString = FilterString;
				InfobarType _Infobar = Infobar;
				
				using (IDbCommand cmd = appDB.CreateCommand())
				{
					DataTable dtReturn = new DataTable();
					
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.CommandText = "CLM_UserStartFormSubFormsSp";
					
					appDB.AddCommandParameter(cmd, "Username", _Username, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "FilterString", _FilterString, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
					
					IntType returnVal = 0;
					IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
					dbParm.DbType = DbType.Int32;

                    dtReturn = appDB.ExecuteQuery(cmd);

                    Infobar = _Infobar;
					
					return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value, Infobar);
				}
			}
			finally
			{
				bunchedLoadCollection.EndBunching();
			}
		}
	}
}
