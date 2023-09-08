//PROJECT NAME: BusInterface
//CLASS NAME: ILoadESBPersonnelCert.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.BusInterface
{
	public interface ILoadESBPersonnelCert
	{
		(int? ReturnCode, string Infobar) LoadESBPersonnelCertSp(string ActionExpression = null,
		string EmpNum = null,
		string Licert = null,
		DateTime? EffDate = null,
		string State = null,
		string Infobar = null);
	}
}

