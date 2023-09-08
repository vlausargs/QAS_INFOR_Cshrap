//PROJECT NAME: Data
//CLASS NAME: InsertVchDistProceduralMarking.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class InsertVchDistProceduralMarking : IInsertVchDistProceduralMarking
	{
		readonly IApplicationDB appDB;
		
		public InsertVchDistProceduralMarking(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) InsertVchDistProceduralMarkingSp(
			int? Voucher,
			int? VoucherSeq,
			string VendNum,
			string Type,
			string TaxCode,
			string TaxCodeE,
			string Infobar)
		{
			VoucherType _Voucher = Voucher;
			VouchSeqType _VoucherSeq = VoucherSeq;
			VendNumType _VendNum = VendNum;
			AptrxTypeType _Type = Type;
			TaxCodeType _TaxCode = TaxCode;
			TaxCodeType _TaxCodeE = TaxCodeE;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "InsertVchDistProceduralMarkingSp";
				
				appDB.AddCommandParameter(cmd, "Voucher", _Voucher, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VoucherSeq", _VoucherSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VendNum", _VendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Type", _Type, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TaxCode", _TaxCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TaxCodeE", _TaxCodeE, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
