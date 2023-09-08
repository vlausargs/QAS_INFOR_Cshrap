//PROJECT NAME: Codes
//CLASS NAME: ISaveInvProceduralMarkingsUpd.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Codes
{
	public interface ISaveInvProceduralMarkingsUpd
	{
		(int? ReturnCode, string Infobar) SaveInvProceduralMarkingsUpdSp(string SiteRef,
		string InvNum,
		int? InvSeq,
		int? Selected,
		string VATProceduralMarkingId,
		string Infobar);
	}
}

