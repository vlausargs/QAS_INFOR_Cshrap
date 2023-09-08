//PROJECT NAME: Production
//CLASS NAME: PP_CalcSetupAndRunTimes_Lookup.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production
{
	public class PP_CalcSetupAndRunTimes_Lookup : IPP_CalcSetupAndRunTimes_Lookup
	{
		readonly IApplicationDB appDB;
		
		
		public PP_CalcSetupAndRunTimes_Lookup(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, decimal? SetupHrs,
		decimal? FinishHrs,
		decimal? PcsPerLbrHr,
		string RunBasisLbr,
		decimal? PcsPerMchHr,
		string RunBasisMch,
		int? OperTimesFound,
		string Infobar) PP_CalcSetupAndRunTimes_LookupSp(string Job,
		int? Suffix,
		int? OperNum,
		decimal? JobQuantity,
		string PpjrOperationType,
		string PpjrOperationTypeCode,
		string PpjrItem,
		string PpjrResourceGroupID,
		decimal? PpjrSheetCount,
		decimal? PpjrOperDifficultFactor,
		string PpjrPaperMassBasis,
		int? PpjrNumberOfOrigColors,
		int? PpjrNumberOfSpclColors,
		decimal? SetupHrs,
		decimal? FinishHrs,
		decimal? PcsPerLbrHr,
		string RunBasisLbr,
		decimal? PcsPerMchHr,
		string RunBasisMch,
		int? OperTimesFound,
		string Infobar)
		{
			JobType _Job = Job;
			SuffixType _Suffix = Suffix;
			OperNumType _OperNum = OperNum;
			QtyUnitType _JobQuantity = JobQuantity;
			PP_OperationType2Type _PpjrOperationType = PpjrOperationType;
			PP_OperationTypeCodeType _PpjrOperationTypeCode = PpjrOperationTypeCode;
			ItemType _PpjrItem = PpjrItem;
			ApsResgroupType _PpjrResourceGroupID = PpjrResourceGroupID;
			PP_SheetCountType _PpjrSheetCount = PpjrSheetCount;
			PP_FactorType _PpjrOperDifficultFactor = PpjrOperDifficultFactor;
			PP_PaperMassBasisType _PpjrPaperMassBasis = PpjrPaperMassBasis;
			PP_NumberOfColorsType _PpjrNumberOfOrigColors = PpjrNumberOfOrigColors;
			PP_NumberOfColorsType _PpjrNumberOfSpclColors = PpjrNumberOfSpclColors;
			SchedHoursType _SetupHrs = SetupHrs;
			SchedHoursType _FinishHrs = FinishHrs;
			QtyUnitNoNegType _PcsPerLbrHr = PcsPerLbrHr;
			RunBasisLbrType _RunBasisLbr = RunBasisLbr;
			QtyUnitNoNegType _PcsPerMchHr = PcsPerMchHr;
			RunBasisMchType _RunBasisMch = RunBasisMch;
			ListYesNoType _OperTimesFound = OperTimesFound;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PP_CalcSetupAndRunTimes_LookupSp";
				
				appDB.AddCommandParameter(cmd, "Job", _Job, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Suffix", _Suffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OperNum", _OperNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobQuantity", _JobQuantity, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PpjrOperationType", _PpjrOperationType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PpjrOperationTypeCode", _PpjrOperationTypeCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PpjrItem", _PpjrItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PpjrResourceGroupID", _PpjrResourceGroupID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PpjrSheetCount", _PpjrSheetCount, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PpjrOperDifficultFactor", _PpjrOperDifficultFactor, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PpjrPaperMassBasis", _PpjrPaperMassBasis, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PpjrNumberOfOrigColors", _PpjrNumberOfOrigColors, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PpjrNumberOfSpclColors", _PpjrNumberOfSpclColors, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SetupHrs", _SetupHrs, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "FinishHrs", _FinishHrs, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PcsPerLbrHr", _PcsPerLbrHr, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "RunBasisLbr", _RunBasisLbr, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PcsPerMchHr", _PcsPerMchHr, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "RunBasisMch", _RunBasisMch, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "OperTimesFound", _OperTimesFound, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				SetupHrs = _SetupHrs;
				FinishHrs = _FinishHrs;
				PcsPerLbrHr = _PcsPerLbrHr;
				RunBasisLbr = _RunBasisLbr;
				PcsPerMchHr = _PcsPerMchHr;
				RunBasisMch = _RunBasisMch;
				OperTimesFound = _OperTimesFound;
				Infobar = _Infobar;
				
				return (Severity, SetupHrs, FinishHrs, PcsPerLbrHr, RunBasisLbr, PcsPerMchHr, RunBasisMch, OperTimesFound, Infobar);
			}
		}
	}
}
