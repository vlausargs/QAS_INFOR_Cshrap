//PROJECT NAME: BusInterface
//CLASS NAME: CLM_ESBEUSalesLineDetail.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.BusInterface
{
	public class CLM_ESBEUSalesLineDetail : ICLM_ESBEUSalesLineDetail
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public CLM_ESBEUSalesLineDetail(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) CLM_ESBEUSalesLineDetailSp(string SiteGroup,
		string DeclarationID,
		DateTime? StartTaxPeriod,
		DateTime? EndTaxPeriod,
		string StartCust,
		string EndCust,
		string StartEcCode,
		string EndEcCode,
		string StartProcessInd,
		string EndProcessInd)
		{
			SiteGroupType _SiteGroup = SiteGroup;
			StringType _DeclarationID = DeclarationID;
			DateType _StartTaxPeriod = StartTaxPeriod;
			DateType _EndTaxPeriod = EndTaxPeriod;
			CustNumType _StartCust = StartCust;
			CustNumType _EndCust = EndCust;
			EcCodeType _StartEcCode = StartEcCode;
			EcCodeType _EndEcCode = EndEcCode;
			ProcessIndType _StartProcessInd = StartProcessInd;
			ProcessIndType _EndProcessInd = EndProcessInd;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CLM_ESBEUSalesLineDetailSp";
				
				appDB.AddCommandParameter(cmd, "SiteGroup", _SiteGroup, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DeclarationID", _DeclarationID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartTaxPeriod", _StartTaxPeriod, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndTaxPeriod", _EndTaxPeriod, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartCust", _StartCust, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndCust", _EndCust, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartEcCode", _StartEcCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndEcCode", _EndEcCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartProcessInd", _StartProcessInd, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndProcessInd", _EndProcessInd, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;
				
				dtReturn = appDB.ExecuteQuery(cmd);
				
				return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
