//PROJECT NAME: Codes
//CLASS NAME: IVchProceduralMarkingsUpd.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Codes
{
	public interface IVchProceduralMarkingsUpd
	{
		(int? ReturnCode, string Infobar) VchProceduralMarkingsUpdSp(int? VchNum,
		int? VchSeq,
		int? Selected,
		string VATProceduralMarkingId,
		string Infobar);
	}
}

