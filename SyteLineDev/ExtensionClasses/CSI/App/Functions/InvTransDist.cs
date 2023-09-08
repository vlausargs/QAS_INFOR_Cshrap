//PROJECT NAME: Data
//CLASS NAME: InvTransDist.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class InvTransDist : IInvTransDist
	{
		readonly IApplicationDB appDB;
		
		public InvTransDist(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar,
			decimal? PTcAmtTAmount,
			decimal? PTcAmtFtotDr,
			decimal? PTcAmtFTotCr,
			decimal? PDomTcAmtAmount,
			decimal? PDomTcAmtDr,
			decimal? PDomTcAmtCr) InvTransDistSp(
			string Infobar,
			int? PSysGen,
			int? PGainLoss,
			decimal? PExchRate,
			string PCurrCode,
			string PAcct,
			string PAcctUnit1,
			string PAcctUnit2,
			string PAcctUnit3,
			string PAcctUnit4,
			string PAcctDesc,
			decimal? PTcAmtTAmount,
			decimal? PTcAmtFtotDr,
			decimal? PTcAmtFTotCr,
			decimal? PDomTcAmtAmount,
			decimal? PDomTcAmtDr,
			decimal? PDomTcAmtCr)
		{
			InfobarType _Infobar = Infobar;
			ListYesNoType _PSysGen = PSysGen;
			ListYesNoType _PGainLoss = PGainLoss;
			ExchRateType _PExchRate = PExchRate;
			CurrCodeType _PCurrCode = PCurrCode;
			AcctType _PAcct = PAcct;
			UnitCode1Type _PAcctUnit1 = PAcctUnit1;
			UnitCode2Type _PAcctUnit2 = PAcctUnit2;
			UnitCode3Type _PAcctUnit3 = PAcctUnit3;
			UnitCode4Type _PAcctUnit4 = PAcctUnit4;
			DescriptionType _PAcctDesc = PAcctDesc;
			AmountType _PTcAmtTAmount = PTcAmtTAmount;
			AmountType _PTcAmtFtotDr = PTcAmtFtotDr;
			AmountType _PTcAmtFTotCr = PTcAmtFTotCr;
			AmountType _PDomTcAmtAmount = PDomTcAmtAmount;
			AmountType _PDomTcAmtDr = PDomTcAmtDr;
			AmountType _PDomTcAmtCr = PDomTcAmtCr;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "InvTransDistSp";
				
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PSysGen", _PSysGen, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PGainLoss", _PGainLoss, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PExchRate", _PExchRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCurrCode", _PCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PAcct", _PAcct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PAcctUnit1", _PAcctUnit1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PAcctUnit2", _PAcctUnit2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PAcctUnit3", _PAcctUnit3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PAcctUnit4", _PAcctUnit4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PAcctDesc", _PAcctDesc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTcAmtTAmount", _PTcAmtTAmount, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PTcAmtFtotDr", _PTcAmtFtotDr, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PTcAmtFTotCr", _PTcAmtFTotCr, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PDomTcAmtAmount", _PDomTcAmtAmount, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PDomTcAmtDr", _PDomTcAmtDr, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PDomTcAmtCr", _PDomTcAmtCr, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				PTcAmtTAmount = _PTcAmtTAmount;
				PTcAmtFtotDr = _PTcAmtFtotDr;
				PTcAmtFTotCr = _PTcAmtFTotCr;
				PDomTcAmtAmount = _PDomTcAmtAmount;
				PDomTcAmtDr = _PDomTcAmtDr;
				PDomTcAmtCr = _PDomTcAmtCr;
				
				return (Severity, Infobar, PTcAmtTAmount, PTcAmtFtotDr, PTcAmtFTotCr, PDomTcAmtAmount, PDomTcAmtDr, PDomTcAmtCr);
			}
		}
	}
}
