//PROJECT NAME: Reporting
//CLASS NAME: Rpt_InboundVendorInvoice.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public interface IRpt_InboundVendorInvoice
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_InboundVendorInvoiceSP(string Begvendnum = null,
		string Endvendnum = null,
		string Begponum = null,
		string Endponum = null,
		DateTime? Begorderdate = null,
		DateTime? Endorderdate = null,
		short? BegorderdateOffset = null,
		short? EndorderdateOffset = null,
		string BegVendOrder = null,
		string EndVendOrder = null,
		string ExOptprPostedEmp = null,
		byte? ExOptszShowDetail = null,
		byte? ExOptszShowOnlyErrors = null,
		byte? DisplayHeader = null,
		string pSite = null);
	}
	
	public class Rpt_InboundVendorInvoice : IRpt_InboundVendorInvoice
	{
		IApplicationDB appDB;
		IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_InboundVendorInvoice(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_InboundVendorInvoiceSP(string Begvendnum = null,
		string Endvendnum = null,
		string Begponum = null,
		string Endponum = null,
		DateTime? Begorderdate = null,
		DateTime? Endorderdate = null,
		short? BegorderdateOffset = null,
		short? EndorderdateOffset = null,
		string BegVendOrder = null,
		string EndVendOrder = null,
		string ExOptprPostedEmp = null,
		byte? ExOptszShowDetail = null,
		byte? ExOptszShowOnlyErrors = null,
		byte? DisplayHeader = null,
		string pSite = null)
		{
			VendNumType _Begvendnum = Begvendnum;
			VendNumType _Endvendnum = Endvendnum;
			PoNumType _Begponum = Begponum;
			PoNumType _Endponum = Endponum;
			DateTimeType _Begorderdate = Begorderdate;
			DateTimeType _Endorderdate = Endorderdate;
			DateOffsetType _BegorderdateOffset = BegorderdateOffset;
			DateOffsetType _EndorderdateOffset = EndorderdateOffset;
			VendOrderType _BegVendOrder = BegVendOrder;
			VendOrderType _EndVendOrder = EndVendOrder;
			StringType _ExOptprPostedEmp = ExOptprPostedEmp;
			ListYesNoType _ExOptszShowDetail = ExOptszShowDetail;
			ListYesNoType _ExOptszShowOnlyErrors = ExOptszShowOnlyErrors;
			ListYesNoType _DisplayHeader = DisplayHeader;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_InboundVendorInvoiceSP";
				
				appDB.AddCommandParameter(cmd, "Begvendnum", _Begvendnum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Endvendnum", _Endvendnum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Begponum", _Begponum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Endponum", _Endponum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Begorderdate", _Begorderdate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Endorderdate", _Endorderdate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BegorderdateOffset", _BegorderdateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndorderdateOffset", _EndorderdateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BegVendOrder", _BegVendOrder, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndVendOrder", _EndVendOrder, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptprPostedEmp", _ExOptprPostedEmp, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptszShowDetail", _ExOptszShowDetail, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptszShowOnlyErrors", _ExOptszShowOnlyErrors, ParameterDirection.Input);
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
