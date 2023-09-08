//PROJECT NAME: Logistics
//CLASS NAME: AppmtGetNextSeq.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class AppmtGetNextSeq : IAppmtGetNextSeq
	{
		readonly IApplicationDB appDB;
		
		
		public AppmtGetNextSeq(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? PCheckSeq,
		string Infobar) AppmtGetNextSeqSp(string PVendNum,
		string PBankCode,
		int? PCheckSeq,
		string Infobar)
		{
			VendNumType _PVendNum = PVendNum;
			BankCodeType _PBankCode = PBankCode;
			ApCheckSeqType _PCheckSeq = PCheckSeq;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "AppmtGetNextSeqSp";
				
				appDB.AddCommandParameter(cmd, "PVendNum", _PVendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PBankCode", _PBankCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCheckSeq", _PCheckSeq, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PCheckSeq = _PCheckSeq;
				Infobar = _Infobar;
				
				return (Severity, PCheckSeq, Infobar);
			}
		}
	}
}
