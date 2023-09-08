//PROJECT NAME: Reporting
//CLASS NAME: SSSFSRpt_SROPrePackSlip.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class SSSFSRpt_SROPrePackSlip : ISSSFSRpt_SROPrePackSlip
	{
        readonly IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
        readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public SSSFSRpt_SROPrePackSlip(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) SSSFSRpt_SROPrePackSlipSp(string BegSroNum = null,
		string EndSroNum = null,
		int? BegSroLine = null,
		int? EndSroLine = null,
		int? BegSroOper = null,
		int? EndSroOper = null,
		string BegCustNum = null,
		string EndCustNum = null,
		DateTime? BegOpenDate = null,
		DateTime? EndOpenDate = null,
		DateTime? BegTransDate = null,
		DateTime? EndTransDate = null,
		DateTime? PackDate = null,
		int? InclOpen = 1,
		int? InclInvoice = 1,
		int? InclClosed = 1,
		int? PrintSerials = 0,
		int? PrintSroNotes = 0,
		int? PrintLineNotes = 0,
		int? PrintOperNotes = 0,
		int? PrintTransNotes = 0,
		int? PrintInternalNotes = 1,
		int? PrintExternalNotes = 1,
		string ShipToAddress = "C",
		string pSite = null)
		{
			FSSRONumType _BegSroNum = BegSroNum;
			FSSRONumType _EndSroNum = EndSroNum;
			FSSROLineType _BegSroLine = BegSroLine;
			FSSROLineType _EndSroLine = EndSroLine;
			FSSROOperType _BegSroOper = BegSroOper;
			FSSROOperType _EndSroOper = EndSroOper;
			CustNumType _BegCustNum = BegCustNum;
			CustNumType _EndCustNum = EndCustNum;
			DateType _BegOpenDate = BegOpenDate;
			DateType _EndOpenDate = EndOpenDate;
			DateType _BegTransDate = BegTransDate;
			DateType _EndTransDate = EndTransDate;
			DateType _PackDate = PackDate;
			ListYesNoType _InclOpen = InclOpen;
			ListYesNoType _InclInvoice = InclInvoice;
			ListYesNoType _InclClosed = InclClosed;
			ListYesNoType _PrintSerials = PrintSerials;
			ListYesNoType _PrintSroNotes = PrintSroNotes;
			ListYesNoType _PrintLineNotes = PrintLineNotes;
			ListYesNoType _PrintOperNotes = PrintOperNotes;
			ListYesNoType _PrintTransNotes = PrintTransNotes;
			ListYesNoType _PrintInternalNotes = PrintInternalNotes;
			ListYesNoType _PrintExternalNotes = PrintExternalNotes;
			StringType _ShipToAddress = ShipToAddress;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSRpt_SROPrePackSlipSp";
				
				appDB.AddCommandParameter(cmd, "BegSroNum", _BegSroNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndSroNum", _EndSroNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BegSroLine", _BegSroLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndSroLine", _EndSroLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BegSroOper", _BegSroOper, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndSroOper", _EndSroOper, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BegCustNum", _BegCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndCustNum", _EndCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BegOpenDate", _BegOpenDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndOpenDate", _EndOpenDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BegTransDate", _BegTransDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndTransDate", _EndTransDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PackDate", _PackDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InclOpen", _InclOpen, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InclInvoice", _InclInvoice, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InclClosed", _InclClosed, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintSerials", _PrintSerials, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintSroNotes", _PrintSroNotes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintLineNotes", _PrintLineNotes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintOperNotes", _PrintOperNotes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintTransNotes", _PrintTransNotes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintInternalNotes", _PrintInternalNotes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintExternalNotes", _PrintExternalNotes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShipToAddress", _ShipToAddress, ParameterDirection.Input);
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
