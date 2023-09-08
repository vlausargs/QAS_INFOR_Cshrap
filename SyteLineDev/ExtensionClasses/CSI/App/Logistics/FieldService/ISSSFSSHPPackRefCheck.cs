//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSSHPPackRefCheck.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSSHPPackRefCheck
	{
		(int? ReturnCode,
			string CustNum,
			int? CustSeq,
			string ShipCode,
			string Infobar) SSSFSSHPPackRefCheckSp(
			string SroNum,
			string CustNum,
			int? CustSeq,
			string ShipCode,
			string Infobar);
	}
}

