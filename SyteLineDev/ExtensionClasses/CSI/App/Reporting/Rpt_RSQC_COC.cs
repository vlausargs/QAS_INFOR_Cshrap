//PROJECT NAME: Reporting
//CLASS NAME: Rpt_RSQC_COC.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_RSQC_COC : IRpt_RSQC_COC
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_RSQC_COC(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_RSQC_COCSp(
			string BegCoc = null,
			string EndCoc = null,
			int? BegRcvr = null,
			int? EndRcvr = null,
			string BegCoNum = null,
			string EndCoNum = null,
			int? BegLine = null,
			int? EndLine = null,
			int? BegRel = null,
			int? EndRel = null,
			string BegCust = null,
			string EndCust = null,
			int? PrintCustNotes = null,
			int? PrintOrderNotes = null,
			int? PrintQCCustNotes = null,
			int? PrintRcvrNotes = null,
			int? PrintCocNotes = null,
			int? ShowTests = null,
			int? PrintInternal = null,
			int? PrintExternal = null,
			string ref_type = null)
		{
			QCDocNumType _BegCoc = BegCoc;
			QCDocNumType _EndCoc = EndCoc;
			QCRcvrNumType _BegRcvr = BegRcvr;
			QCRcvrNumType _EndRcvr = EndRcvr;
			CoNumType _BegCoNum = BegCoNum;
			CoNumType _EndCoNum = EndCoNum;
			CoLineType _BegLine = BegLine;
			CoLineType _EndLine = EndLine;
			CoReleaseType _BegRel = BegRel;
			CoReleaseType _EndRel = EndRel;
			CustNumType _BegCust = BegCust;
			CustNumType _EndCust = EndCust;
			ListYesNoType _PrintCustNotes = PrintCustNotes;
			ListYesNoType _PrintOrderNotes = PrintOrderNotes;
			ListYesNoType _PrintQCCustNotes = PrintQCCustNotes;
			ListYesNoType _PrintRcvrNotes = PrintRcvrNotes;
			ListYesNoType _PrintCocNotes = PrintCocNotes;
			ListYesNoType _ShowTests = ShowTests;
			FlagNyType _PrintInternal = PrintInternal;
			FlagNyType _PrintExternal = PrintExternal;
			StringType _ref_type = ref_type;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_RSQC_COCSp";
				
				appDB.AddCommandParameter(cmd, "BegCoc", _BegCoc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndCoc", _EndCoc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BegRcvr", _BegRcvr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndRcvr", _EndRcvr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BegCoNum", _BegCoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndCoNum", _EndCoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BegLine", _BegLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndLine", _EndLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BegRel", _BegRel, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndRel", _EndRel, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BegCust", _BegCust, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndCust", _EndCust, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintCustNotes", _PrintCustNotes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintOrderNotes", _PrintOrderNotes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintQCCustNotes", _PrintQCCustNotes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintRcvrNotes", _PrintRcvrNotes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintCocNotes", _PrintCocNotes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShowTests", _ShowTests, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintInternal", _PrintInternal, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintExternal", _PrintExternal, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ref_type", _ref_type, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;
				
				dtReturn = appDB.ExecuteQuery(cmd);
				
				return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
