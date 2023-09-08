//PROJECT NAME: Logistics
//CLASS NAME: GenerateLCVouchersCustomUpd.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class GenerateLCVouchersCustomUpd : IGenerateLCVouchersCustomUpd
	{
		readonly IApplicationDB appDB;
		
		
		public GenerateLCVouchersCustomUpd(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? GenerateLCVouchersCustomUpdSp(Guid? ProcessId,
		string RefNum,
		int? RefLineSuf,
		int? RefRelease,
		string RefType,
		string LcType,
		DateTime? RcvdDate,
		string VendNum,
		decimal? DomAmtEstimate,
		decimal? AmtApplied,
		decimal? VchAmt,
		string GrnNum,
		int? RcptAmtOvrd,
		decimal? AmtFrnEst,
		int? DateSeq,
		decimal? UnitCost,
		decimal? DomUnitCost,
		decimal? QtyReceived)
		{
			RowPointerType _ProcessId = ProcessId;
			PoTrnNumType _RefNum = RefNum;
			PoLineType _RefLineSuf = RefLineSuf;
			PoReleaseType _RefRelease = RefRelease;
			RefTypePTType _RefType = RefType;
			LcTypeType _LcType = LcType;
			DateType _RcvdDate = RcvdDate;
			VendNumType _VendNum = VendNum;
			AmountType _DomAmtEstimate = DomAmtEstimate;
			AmountType _AmtApplied = AmtApplied;
			AmountType _VchAmt = VchAmt;
			GrnNumType _GrnNum = GrnNum;
			ListYesNoType _RcptAmtOvrd = RcptAmtOvrd;
			AmountType _AmtFrnEst = AmtFrnEst;
			DateSeqType _DateSeq = DateSeq;
			CostPrcType _UnitCost = UnitCost;
			CostPrcType _DomUnitCost = DomUnitCost;
			QtyUnitType _QtyReceived = QtyReceived;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GenerateLCVouchersCustomUpdSp";
				
				appDB.AddCommandParameter(cmd, "ProcessId", _ProcessId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefNum", _RefNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefLineSuf", _RefLineSuf, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefRelease", _RefRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefType", _RefType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LcType", _LcType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RcvdDate", _RcvdDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VendNum", _VendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DomAmtEstimate", _DomAmtEstimate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AmtApplied", _AmtApplied, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VchAmt", _VchAmt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "GrnNum", _GrnNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RcptAmtOvrd", _RcptAmtOvrd, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AmtFrnEst", _AmtFrnEst, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DateSeq", _DateSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UnitCost", _UnitCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DomUnitCost", _DomUnitCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QtyReceived", _QtyReceived, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
