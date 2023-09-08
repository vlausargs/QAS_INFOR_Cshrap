//PROJECT NAME: Production
//CLASS NAME: IPP_CalcSetupAndRunTimes_Lookup.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface IPP_CalcSetupAndRunTimes_Lookup
	{
		(int? ReturnCode, decimal? SetupHrs,
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
		string Infobar);
	}
}

