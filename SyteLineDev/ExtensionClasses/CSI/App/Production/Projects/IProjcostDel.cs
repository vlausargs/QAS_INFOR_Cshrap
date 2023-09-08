//PROJECT NAME: Production
//CLASS NAME: IProjcostDel.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Projects
{
	public interface IProjcostDel
	{
		(int? ReturnCode, string Infobar) ProjcostDelSp(string ProjNum,
		int? TaskNum,
		int? Seq,
		string CostCode,
		decimal? Units,
		decimal? FcstCost,
		string CostCodeType,
		decimal? FcstCostAcc,
		string Infobar);
	}
}

