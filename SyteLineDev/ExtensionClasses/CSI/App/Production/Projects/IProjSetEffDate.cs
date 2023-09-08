//PROJECT NAME: Production
//CLASS NAME: IProjSetEffDate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Projects
{
	public interface IProjSetEffDate
	{
		(int? ReturnCode, string Infobar) ProjSetEffDateSp(string ProjNum,
		int? ProjTaskNum,
		DateTime? NewEffDate,
		string Infobar);
	}
}

