//PROJECT NAME: Data
//CLASS NAME: IPR01prpPostChecks.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IPR01prpPostChecks
	{
		(int? ReturnCode,
			string Infobar) PR01prpPostChecksSp(
			Guid? pSessionID,
			int? pAddToExisting = 1,
			string pStartDept = null,
			string pEndDept = null,
			string pStartEmpNum = null,
			string pEndEmpNum = null,
			string pBankCode = null,
			string pEmpType = null,
			string Infobar = null,
			string PStartEmpCate = null,
			string PEndEmpCate = null);
	}
}

