//PROJECT NAME: Logistics
//CLASS NAME: IInsertDoLine.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IInsertDoLine
	{
		(int? ReturnCode, int? DoLine,
		string ErrorMsg) InsertDoLineSp(string DoNum,
		int? DoLine,
		string ErrorMsg);
	}
}

