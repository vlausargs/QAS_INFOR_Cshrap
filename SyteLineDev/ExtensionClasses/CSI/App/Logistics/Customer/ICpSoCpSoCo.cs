//PROJECT NAME: Logistics
//CLASS NAME: ICpSoCpSoCo.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface ICpSoCpSoCo
	{
		int? CpSoCpSoCoSp(
			string PFromCoType,
			string PFromCoNum,
			string PToCoType,
			string PToCoNum,
			string PToCoOrigSite,
			string PToCurr,
			string Infobar);
	}
}

