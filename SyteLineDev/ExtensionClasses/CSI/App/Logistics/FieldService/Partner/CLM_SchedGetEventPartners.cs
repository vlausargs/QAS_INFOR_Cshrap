//PROJECT NAME: Logistics
//CLASS NAME: CLM_SchedGetEventPartners.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService.Partner
{
	public class CLM_SchedGetEventPartners : ICLM_SchedGetEventPartners
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public CLM_SchedGetEventPartners(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) CLM_SchedGetEventPartnersSp(string Username,
		string FilterUsername,
		string FilterName,
		int? FilterType,
		string SelectedPartnerList)
		{
			StringType _Username = Username;
			StringType _FilterUsername = FilterUsername;
			StringType _FilterName = FilterName;
			IntType _FilterType = FilterType;
			LongListType _SelectedPartnerList = SelectedPartnerList;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CLM_SchedGetEventPartnersSp";
				
				appDB.AddCommandParameter(cmd, "Username", _Username, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FilterUsername", _FilterUsername, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FilterName", _FilterName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FilterType", _FilterType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SelectedPartnerList", _SelectedPartnerList, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;
				
				dtReturn = appDB.ExecuteQuery(cmd);
				
				return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
