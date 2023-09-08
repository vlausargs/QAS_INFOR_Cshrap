//PROJECT NAME: Logistics
//CLASS NAME: SSSFSProfileSROPackSlip.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService.Requests
{
	public interface ISSSFSProfileSROPackSlip
	{
		(ICollectionLoadResponse Data, int? ReturnCode) SSSFSProfileSROPackSlipSp(int? BegPackNum = null,
		int? EndPackNum = null,
		int? BegPackSeq = null,
		int? EndPackSeq = null,
		string StartCustNum = null,
		string EndCustNum = null,
		DateTime? StartOpenDate = null,
		DateTime? EndOpenDate = null,
		DateTime? StartTransDate = null,
		DateTime? EndTransDate = null);
	}
	
	public class SSSFSProfileSROPackSlip : ISSSFSProfileSROPackSlip
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public SSSFSProfileSROPackSlip(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) SSSFSProfileSROPackSlipSp(int? BegPackNum = null,
		int? EndPackNum = null,
		int? BegPackSeq = null,
		int? EndPackSeq = null,
		string StartCustNum = null,
		string EndCustNum = null,
		DateTime? StartOpenDate = null,
		DateTime? EndOpenDate = null,
		DateTime? StartTransDate = null,
		DateTime? EndTransDate = null)
		{
			PackNumType _BegPackNum = BegPackNum;
			PackNumType _EndPackNum = EndPackNum;
			FSSeqType _BegPackSeq = BegPackSeq;
			FSSeqType _EndPackSeq = EndPackSeq;
			CustNumType _StartCustNum = StartCustNum;
			CustNumType _EndCustNum = EndCustNum;
			DateType _StartOpenDate = StartOpenDate;
			DateType _EndOpenDate = EndOpenDate;
			DateType _StartTransDate = StartTransDate;
			DateType _EndTransDate = EndTransDate;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSProfileSROPackSlipSp";
				
				appDB.AddCommandParameter(cmd, "BegPackNum", _BegPackNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndPackNum", _EndPackNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BegPackSeq", _BegPackSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndPackSeq", _EndPackSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartCustNum", _StartCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndCustNum", _EndCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartOpenDate", _StartOpenDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndOpenDate", _EndOpenDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartTransDate", _StartTransDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndTransDate", _EndTransDate, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;

                dtReturn = appDB.ExecuteQuery(cmd);

                return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
