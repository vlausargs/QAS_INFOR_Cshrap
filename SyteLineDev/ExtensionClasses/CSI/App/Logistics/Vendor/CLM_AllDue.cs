//PROJECT NAME: Logistics
//CLASS NAME: CLM_AllDue.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class CLM_AllDue : ICLM_AllDue
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public CLM_AllDue(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) CLM_AllDueSp(string pBankCode,
		string pVendNum,
		int? pCheckSeq,
		DateTime? pCheckDate,
		int? pCheckNum,
		string FilterString = null)
		{
			if(bunchedLoadCollection != null)
			bunchedLoadCollection.StartBunching();
			
			try
			{
				BankCodeType _pBankCode = pBankCode;
				VendNumType _pVendNum = pVendNum;
				ApCheckSeqType _pCheckSeq = pCheckSeq;
				DateType _pCheckDate = pCheckDate;
				ApCheckNumType _pCheckNum = pCheckNum;
				LongListType _FilterString = FilterString;
				
				using (IDbCommand cmd = appDB.CreateCommand())
				{
					DataTable dtReturn = new DataTable();
					
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.CommandText = "CLM_AllDueSp";
					
					appDB.AddCommandParameter(cmd, "pBankCode", _pBankCode, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "pVendNum", _pVendNum, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "pCheckSeq", _pCheckSeq, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "pCheckDate", _pCheckDate, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "pCheckNum", _pCheckNum, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "FilterString", _FilterString, ParameterDirection.Input);
					
					IntType returnVal = 0;
					IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
					dbParm.DbType = DbType.Int32;
					
					dtReturn = appDB.ExecuteQuery(cmd);
					
					return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
				}
			}
			finally
			{
				if(bunchedLoadCollection != null)
				bunchedLoadCollection.EndBunching();
			}
		}
	}
}
