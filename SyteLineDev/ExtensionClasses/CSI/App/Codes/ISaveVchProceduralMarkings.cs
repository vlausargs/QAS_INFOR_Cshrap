//PROJECT NAME: Codes
//CLASS NAME: ISaveVchProceduralMarkings.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Codes
{
	public interface ISaveVchProceduralMarkings
	{
		(int? ReturnCode, string Infobar) SaveVchProceduralMarkingsSp(string SiteRef,
		int? VchNum,
		int? VchSeq,
		int? Selected,
		string VATProceduralMarkingId,
		string Infobar);
	}
}

