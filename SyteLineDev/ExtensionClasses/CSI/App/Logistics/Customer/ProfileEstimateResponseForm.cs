//PROJECT NAME: CSICustomer
//CLASS NAME: ProfileEstimateResponseForm.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public interface IProfileEstimateResponseForm
	{
		(ICollectionLoadResponse Data, int? ReturnCode) ProfileEstimateResponseFormSp(string EstimateStarting = null,
		string EstimateEnding = null);
	}
	
	public class ProfileEstimateResponseForm : IProfileEstimateResponseForm
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public ProfileEstimateResponseForm(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) ProfileEstimateResponseFormSp(string EstimateStarting = null,
		string EstimateEnding = null)
		{
			CoNumType _EstimateStarting = EstimateStarting;
			CoNumType _EstimateEnding = EstimateEnding;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ProfileEstimateResponseFormSp";
				
				appDB.AddCommandParameter(cmd, "EstimateStarting", _EstimateStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EstimateEnding", _EstimateEnding, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;

                dtReturn = appDB.ExecuteQuery(cmd);

                return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
