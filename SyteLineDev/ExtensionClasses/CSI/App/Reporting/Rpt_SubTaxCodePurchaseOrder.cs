//PROJECT NAME: Reporting
//CLASS NAME: Rpt_SubTaxCodePurchaseOrder.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_SubTaxCodePurchaseOrder : IRpt_SubTaxCodePurchaseOrder
	{
        readonly IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
        readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_SubTaxCodePurchaseOrder(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_SubTaxCodePurchaseOrderSp(string pPoNumStart = null,
		string pPoNumEnd = null,
		int? pSummary = 0,
		string pSubTaxXMLData = null)
		{
			PoNumType _pPoNumStart = pPoNumStart;
			PoNumType _pPoNumEnd = pPoNumEnd;
			ListYesNoType _pSummary = pSummary;
			StringType _pSubTaxXMLData = pSubTaxXMLData;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_SubTaxCodePurchaseOrderSp";
				
				appDB.AddCommandParameter(cmd, "pPoNumStart", _pPoNumStart, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pPoNumEnd", _pPoNumEnd, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pSummary", _pSummary, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pSubTaxXMLData", _pSubTaxXMLData, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;
				
				dtReturn = appDB.ExecuteQuery(cmd);
				
				return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
