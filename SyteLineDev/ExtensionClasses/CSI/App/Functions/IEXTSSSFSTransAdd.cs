//PROJECT NAME: Data
//CLASS NAME: IEXTSSSFSTransAdd.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IEXTSSSFSTransAdd
	{
		(int? ReturnCode,
			string Infobar) EXTSSSFSTransAddSp(
			DateTime? ShipDate,
			DateTime? RcvDate,
			string Item,
			string Infobar);
	}
}

