//PROJECT NAME: Production
//CLASS NAME: ISeqProjBolVal.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Projects
{
	public interface ISeqProjBolVal
	{
		(int? ReturnCode, string Item,
		string Description,
		decimal? Qty,
		string UM,
		decimal? Weight,
		string Infobar) SeqProjBolValSp(string ProjNum,
		string BolNum,
		int? TaskNum,
		int? Seq,
		string Item,
		string Description,
		decimal? Qty,
		string UM,
		decimal? Weight,
		string Infobar);
	}
}

