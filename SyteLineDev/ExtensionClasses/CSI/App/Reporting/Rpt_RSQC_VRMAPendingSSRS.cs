//PROJECT NAME: Reporting
//CLASS NAME: Rpt_RSQC_VRMAPendingSSRS.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_RSQC_VRMAPendingSSRS : IRpt_RSQC_VRMAPendingSSRS
	{
        readonly IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
        readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_RSQC_VRMAPendingSSRS(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_RSQC_VRMAPendingSSRSSp(string BegItem = null,
		string EndItem = null,
		string BegVendor = null,
		string EndVendor = null,
		int? BegVrma = null,
		int? EndVrma = null,
		DateTime? BegDate = null,
		DateTime? EndDate = null,
		int? _internal = null,
		int? external = null,
		string orderby = null,
		string psite = null)
		{
			ItemType _BegItem = BegItem;
			ItemType _EndItem = EndItem;
			VendNumType _BegVendor = BegVendor;
			VendNumType _EndVendor = EndVendor;
			QCRcvrNumType _BegVrma = BegVrma;
			QCRcvrNumType _EndVrma = EndVrma;
			DateType _BegDate = BegDate;
			DateType _EndDate = EndDate;
			IntType __internal = _internal;
			IntType _external = external;
			StringType _orderby = orderby;
			SiteType _psite = psite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_RSQC_VRMAPendingSSRSSp";
				
				appDB.AddCommandParameter(cmd, "BegItem", _BegItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndItem", _EndItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BegVendor", _BegVendor, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndVendor", _EndVendor, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BegVrma", _BegVrma, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndVrma", _EndVrma, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BegDate", _BegDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndDate", _EndDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "internal", __internal, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "external", _external, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "orderby", _orderby, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "psite", _psite, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;
				
				dtReturn = appDB.ExecuteQuery(cmd);
				
				return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
