//PROJECT NAME: Production
//CLASS NAME: IProjcostdetailDel.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Projects
{
	public interface IProjcostdetailDel
	{
		(int? ReturnCode, string Infobar) ProjcostdetailDelSp(string ProjNum,
		int? TaskNum,
		int? Seq,
		string CostCode,
		string CostCodeType,
		int? Year,
		int? Month,
		decimal? FcstCost,
		decimal? FcstCostAcc,
		string Infobar);
	}
}

