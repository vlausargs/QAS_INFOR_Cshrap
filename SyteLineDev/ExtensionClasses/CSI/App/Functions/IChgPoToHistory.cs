//PROJECT NAME: Data
//CLASS NAME: IChgPoToHistory.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IChgPoToHistory
	{
		(int? ReturnCode,
			string Infobar) ChgPoToHistorySp(
			string PoNum,
			string Infobar);
	}
}

