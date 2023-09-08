//PROJECT NAME: Data
//CLASS NAME: IEdiOutObDriverPoC.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IEdiOutObDriverPoC
	{
		(int? ReturnCode,
			string Infobar) EdiOutObDriverPoCSp(
			string PPoNum,
			string PPoItemStat,
			string Infobar);
	}
}

