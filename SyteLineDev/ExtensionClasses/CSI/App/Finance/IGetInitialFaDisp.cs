//PROJECT NAME: Finance
//CLASS NAME: IGetInitialFaDisp.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
	public interface IGetInitialFaDisp
	{
		(int? ReturnCode, string rGLAsstAcct,
		string rGLAsstUnit1,
		string rGLAsstUnit2,
		string rGLAsstUnit3,
		string rGLAsstUnit4,
		string rGLResAcct,
		string rGLResUnit1,
		string rGLResUnit2,
		string rGLResUnit3,
		string rGLResUnit4,
		decimal? rFadeprBonusDepr,
		decimal? rFadeprAccumDepr,
		string Infobar) GetInitialFaDispSp(string pFaNum,
		string pClass,
		string pDept,
		string rGLAsstAcct,
		string rGLAsstUnit1,
		string rGLAsstUnit2,
		string rGLAsstUnit3,
		string rGLAsstUnit4,
		string rGLResAcct,
		string rGLResUnit1,
		string rGLResUnit2,
		string rGLResUnit3,
		string rGLResUnit4,
		decimal? rFadeprBonusDepr,
		decimal? rFadeprAccumDepr,
		string Infobar);
	}
}

