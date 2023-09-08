//PROJECT NAME: Finance
//CLASS NAME: FaDispDist.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance
{
	public class FaDispDist : IFaDispDist
	{
		readonly IApplicationDB appDB;
		
		
		public FaDispDist(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string rFaDescription,
		string rFaClassCode,
		string rDepartment,
		string rDepDescription,
		string rGLAssetAcct,
		string rGLAssetAcctUnit1,
		string rGLAssetAcctUnit2,
		string rGLAssetAcctUnit3,
		string rGLAssetAcctUnit4,
		string rGLAssetAcctDescription,
		string rGLAccumAcct,
		string rGLAccumAcctUnit1,
		string rGLAccumAcctUnit2,
		string rGLAccumAcctUnit3,
		string rGLAccumAcctUnit4,
		string rGLAccumAcctDescription,
		decimal? rFaPurchaseAmount,
		decimal? rFaEnhancementAmount,
		decimal? rAccumDeprec,
		decimal? rCurrentValue,
		DateTime? rDisposalDate,
		decimal? rDisposalAmount,
		decimal? rGainLoss,
		int? rFaDistSeq,
		string Infobar) FaDispDistSp(string pFaNum,
		string rFaDescription,
		string rFaClassCode,
		string rDepartment,
		string rDepDescription,
		string rGLAssetAcct,
		string rGLAssetAcctUnit1,
		string rGLAssetAcctUnit2,
		string rGLAssetAcctUnit3,
		string rGLAssetAcctUnit4,
		string rGLAssetAcctDescription,
		string rGLAccumAcct,
		string rGLAccumAcctUnit1,
		string rGLAccumAcctUnit2,
		string rGLAccumAcctUnit3,
		string rGLAccumAcctUnit4,
		string rGLAccumAcctDescription,
		decimal? rFaPurchaseAmount,
		decimal? rFaEnhancementAmount,
		decimal? rAccumDeprec,
		decimal? rCurrentValue,
		DateTime? rDisposalDate,
		decimal? rDisposalAmount,
		decimal? rGainLoss,
		int? rFaDistSeq,
		string Infobar)
		{
			FaNumType _pFaNum = pFaNum;
			DescriptionType _rFaDescription = rFaDescription;
			FaClassType _rFaClassCode = rFaClassCode;
			DeptType _rDepartment = rDepartment;
			DescriptionType _rDepDescription = rDepDescription;
			AcctType _rGLAssetAcct = rGLAssetAcct;
			UnitCode1Type _rGLAssetAcctUnit1 = rGLAssetAcctUnit1;
			UnitCode2Type _rGLAssetAcctUnit2 = rGLAssetAcctUnit2;
			UnitCode3Type _rGLAssetAcctUnit3 = rGLAssetAcctUnit3;
			UnitCode4Type _rGLAssetAcctUnit4 = rGLAssetAcctUnit4;
			DescriptionType _rGLAssetAcctDescription = rGLAssetAcctDescription;
			AcctType _rGLAccumAcct = rGLAccumAcct;
			UnitCode1Type _rGLAccumAcctUnit1 = rGLAccumAcctUnit1;
			UnitCode1Type _rGLAccumAcctUnit2 = rGLAccumAcctUnit2;
			UnitCode1Type _rGLAccumAcctUnit3 = rGLAccumAcctUnit3;
			UnitCode1Type _rGLAccumAcctUnit4 = rGLAccumAcctUnit4;
			DescriptionType _rGLAccumAcctDescription = rGLAccumAcctDescription;
			AmountType _rFaPurchaseAmount = rFaPurchaseAmount;
			AmountType _rFaEnhancementAmount = rFaEnhancementAmount;
			AmountType _rAccumDeprec = rAccumDeprec;
			AmountType _rCurrentValue = rCurrentValue;
			DateType _rDisposalDate = rDisposalDate;
			AmountType _rDisposalAmount = rDisposalAmount;
			AmountType _rGainLoss = rGainLoss;
			FaDistSeqType _rFaDistSeq = rFaDistSeq;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "FaDispDistSp";
				
				appDB.AddCommandParameter(cmd, "pFaNum", _pFaNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "rFaDescription", _rFaDescription, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "rFaClassCode", _rFaClassCode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "rDepartment", _rDepartment, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "rDepDescription", _rDepDescription, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "rGLAssetAcct", _rGLAssetAcct, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "rGLAssetAcctUnit1", _rGLAssetAcctUnit1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "rGLAssetAcctUnit2", _rGLAssetAcctUnit2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "rGLAssetAcctUnit3", _rGLAssetAcctUnit3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "rGLAssetAcctUnit4", _rGLAssetAcctUnit4, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "rGLAssetAcctDescription", _rGLAssetAcctDescription, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "rGLAccumAcct", _rGLAccumAcct, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "rGLAccumAcctUnit1", _rGLAccumAcctUnit1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "rGLAccumAcctUnit2", _rGLAccumAcctUnit2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "rGLAccumAcctUnit3", _rGLAccumAcctUnit3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "rGLAccumAcctUnit4", _rGLAccumAcctUnit4, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "rGLAccumAcctDescription", _rGLAccumAcctDescription, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "rFaPurchaseAmount", _rFaPurchaseAmount, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "rFaEnhancementAmount", _rFaEnhancementAmount, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "rAccumDeprec", _rAccumDeprec, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "rCurrentValue", _rCurrentValue, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "rDisposalDate", _rDisposalDate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "rDisposalAmount", _rDisposalAmount, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "rGainLoss", _rGainLoss, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "rFaDistSeq", _rFaDistSeq, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				rFaDescription = _rFaDescription;
				rFaClassCode = _rFaClassCode;
				rDepartment = _rDepartment;
				rDepDescription = _rDepDescription;
				rGLAssetAcct = _rGLAssetAcct;
				rGLAssetAcctUnit1 = _rGLAssetAcctUnit1;
				rGLAssetAcctUnit2 = _rGLAssetAcctUnit2;
				rGLAssetAcctUnit3 = _rGLAssetAcctUnit3;
				rGLAssetAcctUnit4 = _rGLAssetAcctUnit4;
				rGLAssetAcctDescription = _rGLAssetAcctDescription;
				rGLAccumAcct = _rGLAccumAcct;
				rGLAccumAcctUnit1 = _rGLAccumAcctUnit1;
				rGLAccumAcctUnit2 = _rGLAccumAcctUnit2;
				rGLAccumAcctUnit3 = _rGLAccumAcctUnit3;
				rGLAccumAcctUnit4 = _rGLAccumAcctUnit4;
				rGLAccumAcctDescription = _rGLAccumAcctDescription;
				rFaPurchaseAmount = _rFaPurchaseAmount;
				rFaEnhancementAmount = _rFaEnhancementAmount;
				rAccumDeprec = _rAccumDeprec;
				rCurrentValue = _rCurrentValue;
				rDisposalDate = _rDisposalDate;
				rDisposalAmount = _rDisposalAmount;
				rGainLoss = _rGainLoss;
				rFaDistSeq = _rFaDistSeq;
				Infobar = _Infobar;
				
				return (Severity, rFaDescription, rFaClassCode, rDepartment, rDepDescription, rGLAssetAcct, rGLAssetAcctUnit1, rGLAssetAcctUnit2, rGLAssetAcctUnit3, rGLAssetAcctUnit4, rGLAssetAcctDescription, rGLAccumAcct, rGLAccumAcctUnit1, rGLAccumAcctUnit2, rGLAccumAcctUnit3, rGLAccumAcctUnit4, rGLAccumAcctDescription, rFaPurchaseAmount, rFaEnhancementAmount, rAccumDeprec, rCurrentValue, rDisposalDate, rDisposalAmount, rGainLoss, rFaDistSeq, Infobar);
			}
		}
	}
}
