//PROJECT NAME: Data
//CLASS NAME: MatltranAmtCreate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class MatltranAmtCreate : IMatltranAmtCreate
	{
		readonly IApplicationDB appDB;
		
		public MatltranAmtCreate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			int? TransSeq,
			Guid? RowPointer) MatltranAmtCreateSp(
			Guid? BufferJournal = null,
			int? Adj = 0,
			decimal? TransNum = null,
			int? TransSeq = null,
			decimal? Amt = 0,
			string Acct = null,
			string AcctUnit1 = null,
			string AcctUnit2 = null,
			string AcctUnit3 = null,
			string AcctUnit4 = null,
			decimal? MatlAmt = 0,
			string MatlAcct = null,
			string MatlAcctUnit1 = null,
			string MatlAcctUnit2 = null,
			string MatlAcctUnit3 = null,
			string MatlAcctUnit4 = null,
			decimal? LbrAmt = 0,
			string LbrAcct = null,
			string LbrAcctUnit1 = null,
			string LbrAcctUnit2 = null,
			string LbrAcctUnit3 = null,
			string LbrAcctUnit4 = null,
			decimal? FovhdAmt = 0,
			string FovhdAcct = null,
			string FovhdAcctUnit1 = null,
			string FovhdAcctUnit2 = null,
			string FovhdAcctUnit3 = null,
			string FovhdAcctUnit4 = null,
			decimal? VovhdAmt = 0,
			string VovhdAcct = null,
			string VovhdAcctUnit1 = null,
			string VovhdAcctUnit2 = null,
			string VovhdAcctUnit3 = null,
			string VovhdAcctUnit4 = null,
			decimal? OutAmt = 0,
			string OutAcct = null,
			string OutAcctUnit1 = null,
			string OutAcctUnit2 = null,
			string OutAcctUnit3 = null,
			string OutAcctUnit4 = null,
			Guid? RowPointer = null,
			int? IncludeInInventoryBalCalc = 0)
		{
			RowPointerType _BufferJournal = BufferJournal;
			ListYesNoType _Adj = Adj;
			MatlTransNumType _TransNum = TransNum;
			DateSeqType _TransSeq = TransSeq;
			AmountType _Amt = Amt;
			AcctType _Acct = Acct;
			UnitCode1Type _AcctUnit1 = AcctUnit1;
			UnitCode2Type _AcctUnit2 = AcctUnit2;
			UnitCode3Type _AcctUnit3 = AcctUnit3;
			UnitCode4Type _AcctUnit4 = AcctUnit4;
			AmountType _MatlAmt = MatlAmt;
			AcctType _MatlAcct = MatlAcct;
			UnitCode1Type _MatlAcctUnit1 = MatlAcctUnit1;
			UnitCode2Type _MatlAcctUnit2 = MatlAcctUnit2;
			UnitCode3Type _MatlAcctUnit3 = MatlAcctUnit3;
			UnitCode4Type _MatlAcctUnit4 = MatlAcctUnit4;
			AmountType _LbrAmt = LbrAmt;
			AcctType _LbrAcct = LbrAcct;
			UnitCode1Type _LbrAcctUnit1 = LbrAcctUnit1;
			UnitCode2Type _LbrAcctUnit2 = LbrAcctUnit2;
			UnitCode3Type _LbrAcctUnit3 = LbrAcctUnit3;
			UnitCode4Type _LbrAcctUnit4 = LbrAcctUnit4;
			AmountType _FovhdAmt = FovhdAmt;
			AcctType _FovhdAcct = FovhdAcct;
			UnitCode1Type _FovhdAcctUnit1 = FovhdAcctUnit1;
			UnitCode2Type _FovhdAcctUnit2 = FovhdAcctUnit2;
			UnitCode3Type _FovhdAcctUnit3 = FovhdAcctUnit3;
			UnitCode4Type _FovhdAcctUnit4 = FovhdAcctUnit4;
			AmountType _VovhdAmt = VovhdAmt;
			AcctType _VovhdAcct = VovhdAcct;
			UnitCode1Type _VovhdAcctUnit1 = VovhdAcctUnit1;
			UnitCode2Type _VovhdAcctUnit2 = VovhdAcctUnit2;
			UnitCode3Type _VovhdAcctUnit3 = VovhdAcctUnit3;
			UnitCode4Type _VovhdAcctUnit4 = VovhdAcctUnit4;
			AmountType _OutAmt = OutAmt;
			AcctType _OutAcct = OutAcct;
			UnitCode1Type _OutAcctUnit1 = OutAcctUnit1;
			UnitCode2Type _OutAcctUnit2 = OutAcctUnit2;
			UnitCode3Type _OutAcctUnit3 = OutAcctUnit3;
			UnitCode4Type _OutAcctUnit4 = OutAcctUnit4;
			RowPointerType _RowPointer = RowPointer;
			ListYesNoType _IncludeInInventoryBalCalc = IncludeInInventoryBalCalc;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "MatltranAmtCreateSp";
				
				appDB.AddCommandParameter(cmd, "BufferJournal", _BufferJournal, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Adj", _Adj, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransNum", _TransNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransSeq", _TransSeq, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Amt", _Amt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Acct", _Acct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AcctUnit1", _AcctUnit1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AcctUnit2", _AcctUnit2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AcctUnit3", _AcctUnit3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AcctUnit4", _AcctUnit4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MatlAmt", _MatlAmt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MatlAcct", _MatlAcct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MatlAcctUnit1", _MatlAcctUnit1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MatlAcctUnit2", _MatlAcctUnit2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MatlAcctUnit3", _MatlAcctUnit3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MatlAcctUnit4", _MatlAcctUnit4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LbrAmt", _LbrAmt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LbrAcct", _LbrAcct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LbrAcctUnit1", _LbrAcctUnit1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LbrAcctUnit2", _LbrAcctUnit2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LbrAcctUnit3", _LbrAcctUnit3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LbrAcctUnit4", _LbrAcctUnit4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FovhdAmt", _FovhdAmt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FovhdAcct", _FovhdAcct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FovhdAcctUnit1", _FovhdAcctUnit1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FovhdAcctUnit2", _FovhdAcctUnit2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FovhdAcctUnit3", _FovhdAcctUnit3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FovhdAcctUnit4", _FovhdAcctUnit4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VovhdAmt", _VovhdAmt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VovhdAcct", _VovhdAcct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VovhdAcctUnit1", _VovhdAcctUnit1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VovhdAcctUnit2", _VovhdAcctUnit2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VovhdAcctUnit3", _VovhdAcctUnit3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VovhdAcctUnit4", _VovhdAcctUnit4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OutAmt", _OutAmt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OutAcct", _OutAcct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OutAcctUnit1", _OutAcctUnit1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OutAcctUnit2", _OutAcctUnit2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OutAcctUnit3", _OutAcctUnit3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OutAcctUnit4", _OutAcctUnit4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RowPointer", _RowPointer, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "IncludeInInventoryBalCalc", _IncludeInInventoryBalCalc, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				TransSeq = _TransSeq;
				RowPointer = _RowPointer;
				
				return (Severity, TransSeq, RowPointer);
			}
		}
	}
}
