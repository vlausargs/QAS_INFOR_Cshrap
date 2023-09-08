//PROJECT NAME: DataCollection
//CLASS NAME: IWcLbrDcValidate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.DataCollection
{
	public interface IWcLbrDcValidate
	{
		(int? ReturnCode, string Infobar) WcLbrDcValidateSp(string Wc,
		decimal? AHrs,
		decimal? JobRate,
		string Infobar);
	}
}

