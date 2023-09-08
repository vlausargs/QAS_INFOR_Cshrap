//PROJECT NAME: Production
//CLASS NAME: IDropProdMixTT.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface IDropProdMixTT
	{
		(int? ReturnCode, string Infobar) DropProdMixTTSp(Guid? PSessionID,
		string Infobar);
	}
}

