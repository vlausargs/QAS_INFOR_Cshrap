//PROJECT NAME: Logistics
//CLASS NAME: SSSFSContSROGen.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSContSROGen : ISSSFSContSROGen
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public SSSFSContSROGen(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) SSSFSContSROGenSp(string StartContract,
		string EndContract,
		string StartCustNum,
		string EndCustNum,
		DateTime? ThroughDate,
		int? CreateSROs,
		int? ThroughDateOffset = null,
		string pSite = null)
		{
			FSContractType _StartContract = StartContract;
			FSContractType _EndContract = EndContract;
			CustNumType _StartCustNum = StartCustNum;
			CustNumType _EndCustNum = EndCustNum;
			DateType _ThroughDate = ThroughDate;
			ListYesNoType _CreateSROs = CreateSROs;
			DateOffsetType _ThroughDateOffset = ThroughDateOffset;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSContSROGenSp";
				
				appDB.AddCommandParameter(cmd, "StartContract", _StartContract, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndContract", _EndContract, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartCustNum", _StartCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndCustNum", _EndCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ThroughDate", _ThroughDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CreateSROs", _CreateSROs, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ThroughDateOffset", _ThroughDateOffset, ParameterDirection.Input);
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
