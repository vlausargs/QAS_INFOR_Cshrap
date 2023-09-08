//PROJECT NAME: Finance
//CLASS NAME: IFaDispDist.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
	public interface IFaDispDist
	{
		(int? ReturnCode, string rFaDescription,
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
		string Infobar);
	}
}

