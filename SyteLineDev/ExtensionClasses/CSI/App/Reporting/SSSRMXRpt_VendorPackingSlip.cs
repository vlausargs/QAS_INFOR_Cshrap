//PROJECT NAME: Reporting
//CLASS NAME: SSSRMXRpt_VendorPackingSlip.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class SSSRMXRpt_VendorPackingSlip : ISSSRMXRpt_VendorPackingSlip
	{
        readonly IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
        readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public SSSRMXRpt_VendorPackingSlip(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) SSSRMXRpt_VendorPackingSlipSp(string CalledType,
		int? BegPackNum,
		int? EndPackNum,
		int? PrintDisp,
		int? PrintLineReleaseText,
		int? PrintExternalNotes,
		int? PrintInternalNotes,
		int? DisplayHeader,
		int? PrintItemOverview = 0,
		string Whse = null,
		int? RefTypeM = null,
		int? RefTypeP = null,
		string BegVendNum = null,
		string EndBendNum = null,
		string BegRefNum = null,
		string EndRefNum = null,
		string pSite = null)
		{
			StringType _CalledType = CalledType;
			PackNumType _BegPackNum = BegPackNum;
			PackNumType _EndPackNum = EndPackNum;
			ListYesNoType _PrintDisp = PrintDisp;
			ListYesNoType _PrintLineReleaseText = PrintLineReleaseText;
			ListYesNoType _PrintExternalNotes = PrintExternalNotes;
			ListYesNoType _PrintInternalNotes = PrintInternalNotes;
			ListYesNoType _DisplayHeader = DisplayHeader;
			ListYesNoType _PrintItemOverview = PrintItemOverview;
			WhseType _Whse = Whse;
			ListYesNoType _RefTypeM = RefTypeM;
			ListYesNoType _RefTypeP = RefTypeP;
			VendNumType _BegVendNum = BegVendNum;
			VendNumType _EndBendNum = EndBendNum;
			RMXRefNumType _BegRefNum = BegRefNum;
			RMXRefNumType _EndRefNum = EndRefNum;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSRMXRpt_VendorPackingSlipSp";
				
				appDB.AddCommandParameter(cmd, "CalledType", _CalledType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BegPackNum", _BegPackNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndPackNum", _EndPackNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintDisp", _PrintDisp, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintLineReleaseText", _PrintLineReleaseText, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintExternalNotes", _PrintExternalNotes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintInternalNotes", _PrintInternalNotes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayHeader", _DisplayHeader, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintItemOverview", _PrintItemOverview, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefTypeM", _RefTypeM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefTypeP", _RefTypeP, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BegVendNum", _BegVendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndBendNum", _EndBendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BegRefNum", _BegRefNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndRefNum", _EndRefNum, ParameterDirection.Input);
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
