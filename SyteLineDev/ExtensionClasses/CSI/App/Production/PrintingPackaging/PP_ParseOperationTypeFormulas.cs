//PROJECT NAME: Production
//CLASS NAME: PP_ParseOperationTypeFormulas.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.PrintingPackaging
{
	public class PP_ParseOperationTypeFormulas : IPP_ParseOperationTypeFormulas
	{
		readonly IApplicationDB appDB;
		
		public PP_ParseOperationTypeFormulas(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			decimal? PrintQuotePrice,
			decimal? QuoteLineAmount,
			decimal? PaperConsumption,
			decimal? SetupHrs,
			decimal? FinishHrs,
			decimal? PcsPerHr,
			string Infobar) PP_ParseOperationTypeFormulasSp(
			string Job,
			int? Suffix,
			int? OperNum,
			string CoNum,
			int? CoLine,
			int? CoRelease,
			int? SectionNum,
			int? PriceQuoteLine,
			string OperType = null,
			string OperTypeCode = null,
			decimal? PrintQuotePrice = null,
			decimal? QuoteLineAmount = null,
			decimal? PaperConsumption = null,
			decimal? SetupHrs = null,
			decimal? FinishHrs = null,
			decimal? PcsPerHr = null,
			string Infobar = null)
		{
			JobType _Job = Job;
			SuffixType _Suffix = Suffix;
			OperNumType _OperNum = OperNum;
			CoNumType _CoNum = CoNum;
			CoLineType _CoLine = CoLine;
			CoReleaseType _CoRelease = CoRelease;
			PP_QuoteSectionType _SectionNum = SectionNum;
			PP_QuoteLineType _PriceQuoteLine = PriceQuoteLine;
			PP_OperationType2Type _OperType = OperType;
			PP_OperationTypeCodeType _OperTypeCode = OperTypeCode;
			CostPrcType _PrintQuotePrice = PrintQuotePrice;
			AmountType _QuoteLineAmount = QuoteLineAmount;
			QtyUnitNoNegType _PaperConsumption = PaperConsumption;
			SchedHoursType _SetupHrs = SetupHrs;
			SchedHoursType _FinishHrs = FinishHrs;
			QtyUnitNoNegType _PcsPerHr = PcsPerHr;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PP_ParseOperationTypeFormulasSp";
				
				appDB.AddCommandParameter(cmd, "Job", _Job, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Suffix", _Suffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OperNum", _OperNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoNum", _CoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoLine", _CoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoRelease", _CoRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SectionNum", _SectionNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PriceQuoteLine", _PriceQuoteLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OperType", _OperType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OperTypeCode", _OperTypeCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintQuotePrice", _PrintQuotePrice, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "QuoteLineAmount", _QuoteLineAmount, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PaperConsumption", _PaperConsumption, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "SetupHrs", _SetupHrs, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "FinishHrs", _FinishHrs, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PcsPerHr", _PcsPerHr, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PrintQuotePrice = _PrintQuotePrice;
				QuoteLineAmount = _QuoteLineAmount;
				PaperConsumption = _PaperConsumption;
				SetupHrs = _SetupHrs;
				FinishHrs = _FinishHrs;
				PcsPerHr = _PcsPerHr;
				Infobar = _Infobar;
				
				return (Severity, PrintQuotePrice, QuoteLineAmount, PaperConsumption, SetupHrs, FinishHrs, PcsPerHr, Infobar);
			}
		}
	}
}
