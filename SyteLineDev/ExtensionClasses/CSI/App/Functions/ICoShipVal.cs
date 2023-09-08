//PROJECT NAME: Data
//CLASS NAME: ICOShipVal.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ICOShipVal
	{
		(int? ReturnCode,
			int? FirstSequenceWithError,
			int? WhseFreeze,
			string Infobar,
			int? PRsvdExced,
			int? POnHandNegative,
			string PromptButtons,
			int? PeriodValidated) COShipValSp(
			string PCoNum,
			int? PCoLine,
			int? PCoRelease,
			decimal? PQtyToShipConv,
			decimal? PQtyToShip,
			string PLoc,
			string PLot,
			int? PCrReturn,
			string PReasonCode,
			DateTime? PTransDate,
			int? PSequence,
			int? FirstSequenceWithError,
			int? WhseFreeze,
			string Infobar,
			string PImportDocId,
			int? PRsvdExced,
			int? POnHandNegative,
			int? SkipCycleCountCheck = 0,
			string PromptButtons = null,
			int? ByContainer = 0,
			int? MsgFlag = 1,
			int? PeriodValidated = 0);
	}
}

