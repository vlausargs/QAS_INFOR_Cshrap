//PROJECT NAME: Reporting
//CLASS NAME: Rpt_ShipmentProFormaInvoiceSer.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_ShipmentProFormaInvoiceSer : IRpt_ShipmentProFormaInvoiceSer
	{
        readonly IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
        readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_ShipmentProFormaInvoiceSer(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_ShipmentProFormaInvoiceSerSp(decimal? ShipmentID,
		int? ShipmentLine,
		int? ShipmentSeq,
		string pSite = null)
		{
			ShipmentIDType _ShipmentID = ShipmentID;
			ShipmentLineType _ShipmentLine = ShipmentLine;
			ShipmentSequenceType _ShipmentSeq = ShipmentSeq;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_ShipmentProFormaInvoiceSerSp";
				
				appDB.AddCommandParameter(cmd, "ShipmentID", _ShipmentID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShipmentLine", _ShipmentLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShipmentSeq", _ShipmentSeq, ParameterDirection.Input);
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
