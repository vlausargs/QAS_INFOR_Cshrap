//PROJECT NAME: Material
//CLASS NAME: IMcalDate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface IMcalDate
	{
		(int? ReturnCode, DateTime? McalFirst,
		DateTime? McalLast,
		string Infobar) McalDateSp(DateTime? McalFirst,
		DateTime? McalLast,
		string Infobar);
	}
}

