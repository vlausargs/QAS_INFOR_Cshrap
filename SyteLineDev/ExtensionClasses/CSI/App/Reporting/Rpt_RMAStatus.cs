//PROJECT NAME: Reporting
//CLASS NAME: Rpt_RMAStatus.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_RMAStatus : IRpt_RMAStatus
	{
        readonly IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
        readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_RMAStatus(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_RMAStatusSp(string RMAStatus = "OSCHR",
		string RMALineStatus = "OFCH",
		int? PrintExternalNotes = 0,
		int? PrintInternalNotes = 0,
		int? TranslateToDomesticCurrency = 0,
		int? ToBeCredited = 0,
		string SortBy = "R",
		string RMAStarting = null,
		string RMAEnding = null,
		string CustomerStarting = null,
		string CustomerEnding = null,
		string WhseStarting = null,
		string WhseEnding = null,
		DateTime? RMADateStarting = null,
		DateTime? RMADateEnding = null,
		string ProblemCodeStarting = null,
		string ProblemCodeEnding = null,
		int? RMALineStarting = null,
		int? RMALineEnding = null,
		string RMAItemStarting = null,
		string RMAItemEnding = null,
		string EvaluationStarting = null,
		string EvaluationEnding = null,
		string DispositionStarting = null,
		string DispositionEnding = null,
		int? RMADateStartingOffset = null,
		int? RMADateEndingOffset = null,
		int? DisplayHeader = null,
		string pSite = null)
		{
			StringType _RMAStatus = RMAStatus;
			StringType _RMALineStatus = RMALineStatus;
			ListYesNoType _PrintExternalNotes = PrintExternalNotes;
			ListYesNoType _PrintInternalNotes = PrintInternalNotes;
			ListYesNoType _TranslateToDomesticCurrency = TranslateToDomesticCurrency;
			ListYesNoType _ToBeCredited = ToBeCredited;
			StringType _SortBy = SortBy;
			RmaNumType _RMAStarting = RMAStarting;
			RmaNumType _RMAEnding = RMAEnding;
			CustNumType _CustomerStarting = CustomerStarting;
			CustNumType _CustomerEnding = CustomerEnding;
			WhseType _WhseStarting = WhseStarting;
			WhseType _WhseEnding = WhseEnding;
			DateType _RMADateStarting = RMADateStarting;
			DateType _RMADateEnding = RMADateEnding;
			ProbCodeType _ProblemCodeStarting = ProblemCodeStarting;
			ProbCodeType _ProblemCodeEnding = ProblemCodeEnding;
			RmaLineType _RMALineStarting = RMALineStarting;
			RmaLineType _RMALineEnding = RMALineEnding;
			ItemType _RMAItemStarting = RMAItemStarting;
			ItemType _RMAItemEnding = RMAItemEnding;
			EvalCodeType _EvaluationStarting = EvaluationStarting;
			EvalCodeType _EvaluationEnding = EvaluationEnding;
			DispCodeType _DispositionStarting = DispositionStarting;
			DispCodeType _DispositionEnding = DispositionEnding;
			DateOffsetType _RMADateStartingOffset = RMADateStartingOffset;
			DateOffsetType _RMADateEndingOffset = RMADateEndingOffset;
			ListYesNoType _DisplayHeader = DisplayHeader;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_RMAStatusSp";
				
				appDB.AddCommandParameter(cmd, "RMAStatus", _RMAStatus, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RMALineStatus", _RMALineStatus, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintExternalNotes", _PrintExternalNotes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintInternalNotes", _PrintInternalNotes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TranslateToDomesticCurrency", _TranslateToDomesticCurrency, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToBeCredited", _ToBeCredited, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SortBy", _SortBy, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RMAStarting", _RMAStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RMAEnding", _RMAEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustomerStarting", _CustomerStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustomerEnding", _CustomerEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "WhseStarting", _WhseStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "WhseEnding", _WhseEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RMADateStarting", _RMADateStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RMADateEnding", _RMADateEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProblemCodeStarting", _ProblemCodeStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProblemCodeEnding", _ProblemCodeEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RMALineStarting", _RMALineStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RMALineEnding", _RMALineEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RMAItemStarting", _RMAItemStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RMAItemEnding", _RMAItemEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EvaluationStarting", _EvaluationStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EvaluationEnding", _EvaluationEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DispositionStarting", _DispositionStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DispositionEnding", _DispositionEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RMADateStartingOffset", _RMADateStartingOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RMADateEndingOffset", _RMADateEndingOffset, ParameterDirection.Input);
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
