//PROJECT NAME: Production
//CLASS NAME: ICurrentMaterialsBomSeqV1.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface ICurrentMaterialsBomSeqV1
	{
		(int? ReturnCode, int? BomSeq,
		string Infobar) CurrentMaterialsBomSeqV1Sp(string Job,
		int? Suffix,
		int? OperNum,
		int? Sequence,
		string ItmItem,
		int? BomSeq,
		int? AltGroup,
		string Infobar);
	}
}

