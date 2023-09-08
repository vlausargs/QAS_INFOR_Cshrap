//PROJECT NAME: Reporting
//CLASS NAME: SSSFSRpt_SROPackSlip.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class SSSFSRpt_SROPackSlip : ISSSFSRpt_SROPackSlip
	{
        readonly IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
        readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public SSSFSRpt_SROPackSlip(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) SSSFSRpt_SROPackSlipSp(int? BegPackNum = null,
		int? EndPackNum = null,
		int? BegPackSeq = null,
		int? EndPackSeq = null,
		string BegCustNum = null,
		string EndCustNum = null,
		int? PrintSerials = 0,
		int? PrintPckHdrNotes = 0,
		int? PrintPckLineNotes = 0,
		int? PrintInternalNotes = 1,
		int? PrintExternalNotes = 1,
		DateTime? BegPackDate = null,
		DateTime? EndPackDate = null,
		int? PrintSROOperNotes = 0,
		int? PrintSROLineNotes = 0,
		int? DisplayHeader = 0,
		int? PrintSRONotes = 0,
		string pSite = null)
		{
			PackNumType _BegPackNum = BegPackNum;
			PackNumType _EndPackNum = EndPackNum;
			FSSeqType _BegPackSeq = BegPackSeq;
			FSSeqType _EndPackSeq = EndPackSeq;
			CustNumType _BegCustNum = BegCustNum;
			CustNumType _EndCustNum = EndCustNum;
			ListYesNoType _PrintSerials = PrintSerials;
			ListYesNoType _PrintPckHdrNotes = PrintPckHdrNotes;
			ListYesNoType _PrintPckLineNotes = PrintPckLineNotes;
			ListYesNoType _PrintInternalNotes = PrintInternalNotes;
			ListYesNoType _PrintExternalNotes = PrintExternalNotes;
			DateType _BegPackDate = BegPackDate;
			DateType _EndPackDate = EndPackDate;
			ListYesNoType _PrintSROOperNotes = PrintSROOperNotes;
			ListYesNoType _PrintSROLineNotes = PrintSROLineNotes;
			ListYesNoType _DisplayHeader = DisplayHeader;
			ListYesNoType _PrintSRONotes = PrintSRONotes;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSRpt_SROPackSlipSp";
				
				appDB.AddCommandParameter(cmd, "BegPackNum", _BegPackNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndPackNum", _EndPackNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BegPackSeq", _BegPackSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndPackSeq", _EndPackSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BegCustNum", _BegCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndCustNum", _EndCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintSerials", _PrintSerials, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintPckHdrNotes", _PrintPckHdrNotes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintPckLineNotes", _PrintPckLineNotes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintInternalNotes", _PrintInternalNotes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintExternalNotes", _PrintExternalNotes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BegPackDate", _BegPackDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndPackDate", _EndPackDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintSROOperNotes", _PrintSROOperNotes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintSROLineNotes", _PrintSROLineNotes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayHeader", _DisplayHeader, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintSRONotes", _PrintSRONotes, ParameterDirection.Input);
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
