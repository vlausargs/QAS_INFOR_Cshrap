//PROJECT NAME: Reporting
//CLASS NAME: SSSRMXRpt_ReprintVendorPackingList.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class SSSRMXRpt_ReprintVendorPackingList : ISSSRMXRpt_ReprintVendorPackingList
	{
        readonly IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
        readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public SSSRMXRpt_ReprintVendorPackingList(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) SSSRMXRpt_ReprintVendorPackingListSp(int? BegPackNum,
		int? EndPackNum,
		DateTime? BegPackDate,
		DateTime? EndPackDate,
		string BegWhse,
		string EndWhse,
		string BegVendor,
		string EndVendor,
		int? DisplayHeaderVar,
		int? PrintDispVar,
		int? PrintLineReleaseTextVar,
		int? PrintInternalNotesVar,
		int? PrintExternalNotesVar,
		int? PrintItemOverviewVar = 0,
		string Infobar = null,
		string pSite = null)
		{
			PackNumType _BegPackNum = BegPackNum;
			PackNumType _EndPackNum = EndPackNum;
			DateType _BegPackDate = BegPackDate;
			DateType _EndPackDate = EndPackDate;
			WhseType _BegWhse = BegWhse;
			WhseType _EndWhse = EndWhse;
			VendNumType _BegVendor = BegVendor;
			VendNumType _EndVendor = EndVendor;
			ListYesNoType _DisplayHeaderVar = DisplayHeaderVar;
			ListYesNoType _PrintDispVar = PrintDispVar;
			ListYesNoType _PrintLineReleaseTextVar = PrintLineReleaseTextVar;
			ListYesNoType _PrintInternalNotesVar = PrintInternalNotesVar;
			ListYesNoType _PrintExternalNotesVar = PrintExternalNotesVar;
			ListYesNoType _PrintItemOverviewVar = PrintItemOverviewVar;
			InfobarType _Infobar = Infobar;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSRMXRpt_ReprintVendorPackingListSp";
				
				appDB.AddCommandParameter(cmd, "BegPackNum", _BegPackNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndPackNum", _EndPackNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BegPackDate", _BegPackDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndPackDate", _EndPackDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BegWhse", _BegWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndWhse", _EndWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BegVendor", _BegVendor, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndVendor", _EndVendor, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayHeaderVar", _DisplayHeaderVar, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintDispVar", _PrintDispVar, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintLineReleaseTextVar", _PrintLineReleaseTextVar, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintInternalNotesVar", _PrintInternalNotesVar, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintExternalNotesVar", _PrintExternalNotesVar, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintItemOverviewVar", _PrintItemOverviewVar, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.Input);
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
