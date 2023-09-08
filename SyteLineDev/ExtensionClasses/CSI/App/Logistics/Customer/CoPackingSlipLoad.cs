//PROJECT NAME: Logistics
//CLASS NAME: CoPackingSlipLoad.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class CoPackingSlipLoad : ICoPackingSlipLoad
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public CoPackingSlipLoad(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) CoPackingSlipLoadSp(string TPckCall,
		string CoNum,
		string CustNum,
		string CoitemCustNum,
		int? CoitemCustSeq,
		string Whse,
		int? FromCoLine,
		int? ToCoLine,
		int? FromCoRelease,
		int? ToCoRelease,
		DateTime? FromDate,
		DateTime? ToDate,
		string Stat,
		int? BatchId = null,
		string FilterString = null)
		{
			if(bunchedLoadCollection != null)
			bunchedLoadCollection.StartBunching();
			
			try
			{
				StringType _TPckCall = TPckCall;
				CoNumType _CoNum = CoNum;
				CustNumType _CustNum = CustNum;
				CustNumType _CoitemCustNum = CoitemCustNum;
				CustSeqType _CoitemCustSeq = CoitemCustSeq;
				WhseType _Whse = Whse;
				CoLineType _FromCoLine = FromCoLine;
				CoLineType _ToCoLine = ToCoLine;
				CoReleaseType _FromCoRelease = FromCoRelease;
				CoReleaseType _ToCoRelease = ToCoRelease;
				DateType _FromDate = FromDate;
				DateType _ToDate = ToDate;
				StringType _Stat = Stat;
				BatchIdType _BatchId = BatchId;
				LongListType _FilterString = FilterString;
				
				using (IDbCommand cmd = appDB.CreateCommand())
				{
					DataTable dtReturn = new DataTable();
					
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.CommandText = "CoPackingSlipLoadSp";
					
					appDB.AddCommandParameter(cmd, "TPckCall", _TPckCall, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "CoNum", _CoNum, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "CoitemCustNum", _CoitemCustNum, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "CoitemCustSeq", _CoitemCustSeq, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "FromCoLine", _FromCoLine, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "ToCoLine", _ToCoLine, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "FromCoRelease", _FromCoRelease, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "ToCoRelease", _ToCoRelease, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "FromDate", _FromDate, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "ToDate", _ToDate, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "Stat", _Stat, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "BatchId", _BatchId, ParameterDirection.Input);
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
