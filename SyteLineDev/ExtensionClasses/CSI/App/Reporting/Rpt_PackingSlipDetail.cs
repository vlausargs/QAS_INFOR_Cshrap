//PROJECT NAME: Reporting
//CLASS NAME: Rpt_PackingSlipDetail.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_PackingSlipDetail : IRpt_PackingSlipDetail
	{
		IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
        readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_PackingSlipDetail(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_PackingSlipDetailSp(string OrderStarting = null,
		string OrderEnding = null,
		int? OrderLineStarting = null,
		int? OrderLineEnding = null,
		int? OrderReleaseStarting = null,
		int? OrderReleaseEnding = null,
		string CustomerStarting = null,
		string CustomerEnding = null,
		int? PackSlipStarting = null,
		int? PackSlipEnding = null,
		DateTime? PackDateStarting = null,
		DateTime? PackDateEnding = null,
		int? PackDateStartingOffset = null,
		int? PackDateEndingOffset = null,
		int? DisplayHeader = null,
		string pSite = null)
		{
			CoNumType _OrderStarting = OrderStarting;
			CoNumType _OrderEnding = OrderEnding;
			CoLineType _OrderLineStarting = OrderLineStarting;
			CoLineType _OrderLineEnding = OrderLineEnding;
			CoReleaseType _OrderReleaseStarting = OrderReleaseStarting;
			CoReleaseType _OrderReleaseEnding = OrderReleaseEnding;
			CustNumType _CustomerStarting = CustomerStarting;
			CustNumType _CustomerEnding = CustomerEnding;
			PackNumType _PackSlipStarting = PackSlipStarting;
			PackNumType _PackSlipEnding = PackSlipEnding;
			DateType _PackDateStarting = PackDateStarting;
			DateType _PackDateEnding = PackDateEnding;
			DateOffsetType _PackDateStartingOffset = PackDateStartingOffset;
			DateOffsetType _PackDateEndingOffset = PackDateEndingOffset;
			ListYesNoType _DisplayHeader = DisplayHeader;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_PackingSlipDetailSp";
				
				appDB.AddCommandParameter(cmd, "OrderStarting", _OrderStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrderEnding", _OrderEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrderLineStarting", _OrderLineStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrderLineEnding", _OrderLineEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrderReleaseStarting", _OrderReleaseStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrderReleaseEnding", _OrderReleaseEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustomerStarting", _CustomerStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustomerEnding", _CustomerEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PackSlipStarting", _PackSlipStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PackSlipEnding", _PackSlipEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PackDateStarting", _PackDateStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PackDateEnding", _PackDateEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PackDateStartingOffset", _PackDateStartingOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PackDateEndingOffset", _PackDateEndingOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayHeader", _DisplayHeader, ParameterDirection.Input);
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
