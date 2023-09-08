//PROJECT NAME: Logistics
//CLASS NAME: ICpSoCopyCpO.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface ICpSoCopyCpO
	{
		(int? ReturnCode,
			string Infobar) CpSoCopyCpOSp(
			string pCpFOrdType,
			string pCpTOrdType,
			string pCpFOrdRef,
			string pCpTOrdRef,
			int? pCpOrdStart,
			int? pCpOrdEnd,
			string pCopyChoice,
			string pFCurr,
			string pTCurr,
			int? HasCfg,
			string CurWhse,
			int? pRecalcDueDate,
			string Infobar,
			int? ShipmentApprovalRequired = 0);
	}
}

