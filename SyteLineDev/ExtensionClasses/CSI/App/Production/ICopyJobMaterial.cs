//PROJECT NAME: Production
//CLASS NAME: ICopyJobMaterial.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface ICopyJobMaterial
	{
		(int? ReturnCode, string Infobar) CopyJobMaterialSp(string FromCardType,
		string FromJobType,
		string FromJob,
		int? FromSuffix,
		int? FromOperNum,
		int? FromSequence,
		string ToCardType,
		string ToJobType,
		string ToJob,
		int? ToSuffix,
		int? ToOperNum,
		int? ToSequence,
		int? CutFlag,
		string Infobar);
	}
}

