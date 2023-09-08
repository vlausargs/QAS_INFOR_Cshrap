//PROJECT NAME: Material
//CLASS NAME: IInvparmsFbomBlank.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface IInvparmsFbomBlank
	{
		(int? ReturnCode, string InvparmsFbomBlank) InvparmsFbomBlankSp(string InvparmsFbomBlank);
	}
}

