//PROJECT NAME: Data
//CLASS NAME: IProdMixIrtCreate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IProdMixIrtCreate
	{
		(int? ReturnCode,
			string Infobar) ProdMixIrtCreateSp(
			string Item,
			string ProdMix,
			string ChildItem,
			string Infobar);
	}
}

