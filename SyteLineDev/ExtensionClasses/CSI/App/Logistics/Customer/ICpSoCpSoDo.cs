//PROJECT NAME: Logistics
//CLASS NAME: ICpSoCpSoDo.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface ICpSoCpSoDo
	{
		(int? ReturnCode,
			string Infobar) CpSoCpSoDoSp(
			string PCoNum,
			string Infobar);
	}
}

