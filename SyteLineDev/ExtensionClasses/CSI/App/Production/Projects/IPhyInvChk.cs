//PROJECT NAME: Production
//CLASS NAME: IPhyInvChk.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Projects
{
	public interface IPhyInvChk
	{
		(int? ReturnCode, string Infobar) PhyInvChkSp(string Whse,
		string Infobar);
	}
}

