//PROJECT NAME: Production
//CLASS NAME: IRSQC_Parmcu.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Quality
{
	public interface IRSQC_Parmcu
	{
		(int? ReturnCode,
		string o_prompt_item_order,
		string Infobar) RSQC_ParmcuSp(
			string o_prompt_item_order,
			string Infobar);
	}
}

