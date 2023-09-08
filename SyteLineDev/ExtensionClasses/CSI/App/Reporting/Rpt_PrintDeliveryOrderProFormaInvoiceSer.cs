//PROJECT NAME: Reporting
//CLASS NAME: Rpt_PrintDeliveryOrderProFormaInvoiceSer.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_PrintDeliveryOrderProFormaInvoiceSer : IRpt_PrintDeliveryOrderProFormaInvoiceSer
	{
		IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_PrintDeliveryOrderProFormaInvoiceSer(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_PrintDeliveryOrderProFormaInvoiceSerSp(string DoNum,
		int? DoLine,
		int? DoSeq,
		string pSite = null)
		{
			DoNumType _DoNum = DoNum;
			DoLineType _DoLine = DoLine;
			DoSeqType _DoSeq = DoSeq;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_PrintDeliveryOrderProFormaInvoiceSerSp";
				
				appDB.AddCommandParameter(cmd, "DoNum", _DoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DoLine", _DoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DoSeq", _DoSeq, ParameterDirection.Input);
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
