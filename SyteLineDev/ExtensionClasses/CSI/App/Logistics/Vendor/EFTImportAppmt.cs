//PROJECT NAME: Logistics
//CLASS NAME: EFTImportAppmt.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class EFTImportAppmt : IEFTImportAppmt
	{
		readonly IApplicationDB appDB;
		
		
		public EFTImportAppmt(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, Guid? RefRowPointer,
		string Infobar) EFTImportAppmtSp(string VendNum,
		int? CheckNum,
		DateTime? CheckDate,
		decimal? DomCheckAmt,
		string Ref,
		string txt,
		string InvNum,
		string BankCode,
		string PayType,
		int? CheckSeq,
		decimal? ExchRate,
		decimal? ForCheckAmt,
		DateTime? DueDate,
		int? Factor,
		int? OffSet,
		Guid? RefRowPointer,
		string Infobar)
		{
			VendNumType _VendNum = VendNum;
			ApCheckNumType _CheckNum = CheckNum;
			DateType _CheckDate = CheckDate;
			AmountType _DomCheckAmt = DomCheckAmt;
			ReferenceType _Ref = Ref;
			DescriptionType _txt = txt;
			InvNumType _InvNum = InvNum;
			BankCodeType _BankCode = BankCode;
			AppmtPayTypeType _PayType = PayType;
			ApCheckSeqType _CheckSeq = CheckSeq;
			ExchRateType _ExchRate = ExchRate;
			AmountType _ForCheckAmt = ForCheckAmt;
			DateType _DueDate = DueDate;
			ListYesNoType _Factor = Factor;
			ListYesNoType _OffSet = OffSet;
			RowPointerType _RefRowPointer = RefRowPointer;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "EFTImportAppmtSp";
				
				appDB.AddCommandParameter(cmd, "VendNum", _VendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CheckNum", _CheckNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CheckDate", _CheckDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DomCheckAmt", _DomCheckAmt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Ref", _Ref, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "txt", _txt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvNum", _InvNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BankCode", _BankCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PayType", _PayType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CheckSeq", _CheckSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExchRate", _ExchRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ForCheckAmt", _ForCheckAmt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DueDate", _DueDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Factor", _Factor, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OffSet", _OffSet, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefRowPointer", _RefRowPointer, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				RefRowPointer = _RefRowPointer;
				Infobar = _Infobar;
				
				return (Severity, RefRowPointer, Infobar);
			}
		}
	}
}
