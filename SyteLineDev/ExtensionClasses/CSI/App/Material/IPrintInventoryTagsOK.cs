//PROJECT NAME: Material
//CLASS NAME: IPrintInventoryTagsOK.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface IPrintInventoryTagsOK
	{
		(int? ReturnCode, string Infobar) PrintInventoryTagsOKSp(Guid? PSessionID,
		string PWhse,
		string Infobar);
	}
}

