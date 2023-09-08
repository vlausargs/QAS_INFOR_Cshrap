//PROJECT NAME: Codes
//CLASS NAME: IInvProceduralMarkingsUpd.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Codes
{
	public interface IInvProceduralMarkingsUpd
	{
		(int? ReturnCode, string Infobar) InvProceduralMarkingsUpdSp(int? IsSelected = 0,
		string InvNum = null,
		int? InvSeq = null,
		string VatProceduralMarking = null,
		string Infobar = null);
	}
}

