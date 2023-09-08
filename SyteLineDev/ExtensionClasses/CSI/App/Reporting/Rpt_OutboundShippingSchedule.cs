//PROJECT NAME: Reporting
//CLASS NAME: Rpt_OutboundShippingSchedule.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_OutboundShippingSchedule : IRpt_OutboundShippingSchedule
	{
		IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_OutboundShippingSchedule(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_OutboundShippingScheduleSp(string Begvendnum = null,
		string Endvendnum = null,
		string Begponum = null,
		string Endponum = null,
		DateTime? Begorderdate = null,
		DateTime? Endorderdate = null,
		int? BegorderdateOffset = null,
		int? EndorderdateOffset = null,
		string Begplancode = null,
		string Endplancode = null,
		string BegItem = null,
		string Enditem = null,
		string ExOptprPostedEmp = null,
		int? ExOptszShowDetail = null,
		int? ShowInternal = 1,
		int? ShowExternal = 1,
		int? PrintNoteEdiPo = 1,
		int? PrintNoteEdiPoItem = 1,
		int? PrintNoteEdiPoBln = 1,
		int? DisplayHeader = null,
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
			UserCodeType _Begplancode = Begplancode;
			UserCodeType _Endplancode = Endplancode;
			ItemType _BegItem = BegItem;
			ItemType _Enditem = Enditem;
			StringType _ExOptprPostedEmp = ExOptprPostedEmp;
			ListYesNoType _ExOptszShowDetail = ExOptszShowDetail;
			ListYesNoType _ShowInternal = ShowInternal;
			ListYesNoType _ShowExternal = ShowExternal;
			ListYesNoType _PrintNoteEdiPo = PrintNoteEdiPo;
			ListYesNoType _PrintNoteEdiPoItem = PrintNoteEdiPoItem;
			ListYesNoType _PrintNoteEdiPoBln = PrintNoteEdiPoBln;
			ListYesNoType _DisplayHeader = DisplayHeader;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_OutboundShippingScheduleSp";
				
				appDB.AddCommandParameter(cmd, "Begvendnum", _Begvendnum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Endvendnum", _Endvendnum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Begponum", _Begponum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Endponum", _Endponum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Begorderdate", _Begorderdate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Endorderdate", _Endorderdate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BegorderdateOffset", _BegorderdateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndorderdateOffset", _EndorderdateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Begplancode", _Begplancode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Endplancode", _Endplancode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BegItem", _BegItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Enditem", _Enditem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptprPostedEmp", _ExOptprPostedEmp, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptszShowDetail", _ExOptszShowDetail, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShowInternal", _ShowInternal, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShowExternal", _ShowExternal, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintNoteEdiPo", _PrintNoteEdiPo, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintNoteEdiPoItem", _PrintNoteEdiPoItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintNoteEdiPoBln", _PrintNoteEdiPoBln, ParameterDirection.Input);
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
