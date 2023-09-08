//PROJECT NAME: Logistics
//CLASS NAME: ICpSoCpSoVi.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface ICpSoCpSoVi
	{
		(int? ReturnCode,
			int? PFoundItem,
			string Infobar) CpSoCpSoViSp(
			string pSite,
			string PItem,
			int? PFoundItem,
			string Infobar);
	}
}

