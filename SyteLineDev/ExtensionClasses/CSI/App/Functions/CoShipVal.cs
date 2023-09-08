//PROJECT NAME: Data
//CLASS NAME: COShipVal.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class COShipVal : ICOShipVal
	{
		readonly IApplicationDB appDB;
		
		public COShipVal(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
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
			int? PeriodValidated = 0)
		{
			CoNumType _PCoNum = PCoNum;
			CoLineType _PCoLine = PCoLine;
			CoReleaseType _PCoRelease = PCoRelease;
			QtyUnitNoNegType _PQtyToShipConv = PQtyToShipConv;
			QtyUnitNoNegType _PQtyToShip = PQtyToShip;
			LocType _PLoc = PLoc;
			LotType _PLot = PLot;
			FlagNyType _PCrReturn = PCrReturn;
			ReasonCodeType _PReasonCode = PReasonCode;
			CurrentDateType _PTransDate = PTransDate;
			IntType _PSequence = PSequence;
			IntType _FirstSequenceWithError = FirstSequenceWithError;
			ListYesNoType _WhseFreeze = WhseFreeze;
			InfobarType _Infobar = Infobar;
			ImportDocIdType _PImportDocId = PImportDocId;
			ListYesNoType _PRsvdExced = PRsvdExced;
			IntType _POnHandNegative = POnHandNegative;
			ListYesNoType _SkipCycleCountCheck = SkipCycleCountCheck;
			InfobarType _PromptButtons = PromptButtons;
			Flag _ByContainer = ByContainer;
			ListYesNoType _MsgFlag = MsgFlag;
			ListYesNoType _PeriodValidated = PeriodValidated;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "COShipValSp";
				
				appDB.AddCommandParameter(cmd, "PCoNum", _PCoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCoLine", _PCoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCoRelease", _PCoRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PQtyToShipConv", _PQtyToShipConv, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PQtyToShip", _PQtyToShip, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PLoc", _PLoc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PLot", _PLot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCrReturn", _PCrReturn, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PReasonCode", _PReasonCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTransDate", _PTransDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSequence", _PSequence, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FirstSequenceWithError", _FirstSequenceWithError, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "WhseFreeze", _WhseFreeze, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PImportDocId", _PImportDocId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PRsvdExced", _PRsvdExced, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "POnHandNegative", _POnHandNegative, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "SkipCycleCountCheck", _SkipCycleCountCheck, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PromptButtons", _PromptButtons, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ByContainer", _ByContainer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MsgFlag", _MsgFlag, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PeriodValidated", _PeriodValidated, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				FirstSequenceWithError = _FirstSequenceWithError;
				WhseFreeze = _WhseFreeze;
				Infobar = _Infobar;
				PRsvdExced = _PRsvdExced;
				POnHandNegative = _POnHandNegative;
				PromptButtons = _PromptButtons;
				PeriodValidated = _PeriodValidated;
				
				return (Severity, FirstSequenceWithError, WhseFreeze, Infobar, PRsvdExced, POnHandNegative, PromptButtons, PeriodValidated);
			}
		}
	}
}
