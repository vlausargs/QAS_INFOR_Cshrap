//PROJECT NAME: Production
//CLASS NAME: IPP_PrintingEstWB_CreateSectionMatl.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface IPP_PrintingEstWB_CreateSectionMatl
	{
		(int? ReturnCode, string Infobar) PP_PrintingEstWB_CreateSectionMatlSp(string Job,
		int? Suffix,
		string Item,
		decimal? Quantity,
		string Infobar);
	}
}

