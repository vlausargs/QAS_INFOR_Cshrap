//PROJECT NAME: Logistics
//CLASS NAME: ISSSRMXCreateLine.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface ISSSRMXCreateLine
	{
		(int? ReturnCode,
			string Infobar) SSSRMXCreateLineSp(
			string RmaNum,
			int? RmaLine,
			string SerNum,
			string Item,
			string Infobar);
	}
}

