//PROJECT NAME: Production
//CLASS NAME: IGetJobmatlSeqList.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface IGetJobmatlSeqList
	{
		(ICollectionLoadResponse Data, int? ReturnCode, string Infobar) GetJobmatlSeqListSp(string Job = null,
		int? Suffix = null,
		int? OperNum = null,
		string UM = null,
		string Item = null,
		string Descr = null,
		int? ExtScrap = 1,
		decimal? MatlCost = null,
		decimal? LaborCost = null,
		decimal? FovhdCost = null,
		decimal? VovhdCost = null,
		decimal? OutCost = null,
		string CurWhse = null,
		string Site = null,
		string Infobar = null);
	}
}

