//PROJECT NAME: Reporting
//CLASS NAME: Rpt_VoucherPreregister.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_VoucherPreregister : IRpt_VoucherPreregister
	{
        readonly IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
        readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_VoucherPreregister(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_VoucherPreregisterSp(int? PreregisterStarting = null,
		int? PreregisterEnding = null,
		string VendorNumStarting = null,
		string VendorNumEnding = null,
		string NameStarting = null,
		string NameEnding = null,
		DateTime? VoucherDateStarting = null,
		DateTime? VoucherDateEnding = null,
		string ExOptszSortPreVend = null,
		string Status = null,
		int? ExOptszShowDetail = null,
		int? ExOptszTransDomCurr = null,
		int? VoucherDateStartingOffset = null,
		int? VoucherDateEndingOffset = null,
		int? DisplayHeader = null,
		string BGSessionId = null,
		int? TaskId = null,
		string pSite = null)
		{
			PreRegisterType _PreregisterStarting = PreregisterStarting;
			PreRegisterType _PreregisterEnding = PreregisterEnding;
			VendNumType _VendorNumStarting = VendorNumStarting;
			VendNumType _VendorNumEnding = VendorNumEnding;
			NameType _NameStarting = NameStarting;
			NameType _NameEnding = NameEnding;
			DateType _VoucherDateStarting = VoucherDateStarting;
			DateType _VoucherDateEnding = VoucherDateEnding;
			StringType _ExOptszSortPreVend = ExOptszSortPreVend;
			InfobarType _Status = Status;
			ListYesNoType _ExOptszShowDetail = ExOptszShowDetail;
			ListYesNoType _ExOptszTransDomCurr = ExOptszTransDomCurr;
			DateOffsetType _VoucherDateStartingOffset = VoucherDateStartingOffset;
			DateOffsetType _VoucherDateEndingOffset = VoucherDateEndingOffset;
			ListYesNoType _DisplayHeader = DisplayHeader;
			StringType _BGSessionId = BGSessionId;
			TaskNumType _TaskId = TaskId;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_VoucherPreregisterSp";
				
				appDB.AddCommandParameter(cmd, "PreregisterStarting", _PreregisterStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PreregisterEnding", _PreregisterEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VendorNumStarting", _VendorNumStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VendorNumEnding", _VendorNumEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NameStarting", _NameStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NameEnding", _NameEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VoucherDateStarting", _VoucherDateStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VoucherDateEnding", _VoucherDateEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptszSortPreVend", _ExOptszSortPreVend, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Status", _Status, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptszShowDetail", _ExOptszShowDetail, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptszTransDomCurr", _ExOptszTransDomCurr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VoucherDateStartingOffset", _VoucherDateStartingOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VoucherDateEndingOffset", _VoucherDateEndingOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayHeader", _DisplayHeader, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BGSessionId", _BGSessionId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TaskId", _TaskId, ParameterDirection.Input);
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
