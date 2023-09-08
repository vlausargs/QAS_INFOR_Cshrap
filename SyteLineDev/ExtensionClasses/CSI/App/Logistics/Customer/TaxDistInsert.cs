//PROJECT NAME: Logistics
//CLASS NAME: TaxDistInsert.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class TaxDistInsert : ITaxDistInsert
	{
		readonly IApplicationDB appDB;
		
		
		public TaxDistInsert(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) TaxDistInsertSp(string PCoNum,
		int? PSeq,
		int? PTaxSystem,
		string PTaxCode,
		string PTaxCodeE,
		string PAcct,
		string PAcctUnit1,
		string PAcctUnit2,
		string PAcctUnit3,
		string PAcctUnit4,
		string PTaxJur,
		decimal? PTaxRate,
		decimal? PTaxAmount,
		decimal? PTaxBasis,
		string Infobar)
		{
			CoNumType _PCoNum = PCoNum;
			ArDistSeqType _PSeq = PSeq;
			TaxSystemType _PTaxSystem = PTaxSystem;
			TaxCodeType _PTaxCode = PTaxCode;
			TaxCodeType _PTaxCodeE = PTaxCodeE;
			AcctType _PAcct = PAcct;
			UnitCode1Type _PAcctUnit1 = PAcctUnit1;
			UnitCode2Type _PAcctUnit2 = PAcctUnit2;
			UnitCode3Type _PAcctUnit3 = PAcctUnit3;
			UnitCode4Type _PAcctUnit4 = PAcctUnit4;
			TaxJurType _PTaxJur = PTaxJur;
			TaxRateType _PTaxRate = PTaxRate;
			AmountType _PTaxAmount = PTaxAmount;
			AmountType _PTaxBasis = PTaxBasis;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "TaxDistInsertSp";
				
				appDB.AddCommandParameter(cmd, "PCoNum", _PCoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSeq", _PSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTaxSystem", _PTaxSystem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTaxCode", _PTaxCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTaxCodeE", _PTaxCodeE, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PAcct", _PAcct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PAcctUnit1", _PAcctUnit1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PAcctUnit2", _PAcctUnit2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PAcctUnit3", _PAcctUnit3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PAcctUnit4", _PAcctUnit4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTaxJur", _PTaxJur, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTaxRate", _PTaxRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTaxAmount", _PTaxAmount, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTaxBasis", _PTaxBasis, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
