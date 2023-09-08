//PROJECT NAME: Reporting
//CLASS NAME: Rpt_CanadaCustomsInvoice.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public interface IRpt_CanadaCustomsInvoice
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_CanadaCustomsInvoiceSp(decimal? ShipmentStarting = null,
		decimal? ShipmentEnding = null,
		string CustomerStarting = null,
		string CustomerEnding = null,
		int? ShipToStarting = null,
		int? ShipToEnding = null,
		byte? DisplayHeader = null,
		string PrintItemCustItem = null,
		string pSite = null);
	}
	
	public class Rpt_CanadaCustomsInvoice : IRpt_CanadaCustomsInvoice
	{
		IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_CanadaCustomsInvoice(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_CanadaCustomsInvoiceSp(decimal? ShipmentStarting = null,
		decimal? ShipmentEnding = null,
		string CustomerStarting = null,
		string CustomerEnding = null,
		int? ShipToStarting = null,
		int? ShipToEnding = null,
		byte? DisplayHeader = null,
		string PrintItemCustItem = null,
		string pSite = null)
		{
			ShipmentIDType _ShipmentStarting = ShipmentStarting;
			ShipmentIDType _ShipmentEnding = ShipmentEnding;
			CustNumType _CustomerStarting = CustomerStarting;
			CustNumType _CustomerEnding = CustomerEnding;
			CustSeqType _ShipToStarting = ShipToStarting;
			CustSeqType _ShipToEnding = ShipToEnding;
			ListYesNoType _DisplayHeader = DisplayHeader;
			StringType _PrintItemCustItem = PrintItemCustItem;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_CanadaCustomsInvoiceSp";
				
				appDB.AddCommandParameter(cmd, "ShipmentStarting", _ShipmentStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShipmentEnding", _ShipmentEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustomerStarting", _CustomerStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustomerEnding", _CustomerEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShipToStarting", _ShipToStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShipToEnding", _ShipToEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayHeader", _DisplayHeader, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintItemCustItem", _PrintItemCustItem, ParameterDirection.Input);
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
