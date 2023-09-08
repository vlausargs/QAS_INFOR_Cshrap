//PROJECT NAME: Logistics
//CLASS NAME: ICpSoCopyCpB.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface ICpSoCopyCpB
	{
		(int? ReturnCode,
			string Infobar) CpSoCopyCpBSp(
			string pCpFOrdType,
			string pCpTOrdType,
			string pCpFOrdRef,
			string pCpTOrdRef,
			int? pCpOrdStart,
			int? pCpOrdEnd,
			string pCopyChoice,
			string pFCurr,
			string pTCurr,
			string CurWhse,
			string Infobar,
			int? ShipmentApprovalRequired = 0);
	}
}

