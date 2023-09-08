//PROJECT NAME: Production
//CLASS NAME: IPSSingleReleaseJobCopy.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface IPSSingleReleaseJobCopy
	{
		(int? ReturnCode, string Infobar) PSSingleReleaseJobCopySp(string RJob,
		int? RSuffix,
		string Item,
		string Revision,
		int? FromMRP = 0,
		string PLN_Ref_Type = null,
		string PLN_Ref_Num = null,
		int? PLN_Ref_suf = null,
		string Infobar = null);
	}
}

