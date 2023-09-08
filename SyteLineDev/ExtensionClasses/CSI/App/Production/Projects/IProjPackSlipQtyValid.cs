//PROJECT NAME: Production
//CLASS NAME: IProjPackSlipQtyValid.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Projects
{
	public interface IProjPackSlipQtyValid
	{
		(int? ReturnCode, string Warning,
		string Infobar) ProjPackSlipQtyValidSp(decimal? QtyRequired,
		decimal? QtyToPack,
		string TPckCall,
		string Warning,
		string Infobar);
	}
}

