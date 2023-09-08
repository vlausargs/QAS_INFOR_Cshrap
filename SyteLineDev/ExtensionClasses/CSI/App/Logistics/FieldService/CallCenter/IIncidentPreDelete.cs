//PROJECT NAME: Logistics
//CLASS NAME: IIncidentPreDelete.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService.CallCenter
{
	public interface IIncidentPreDelete
	{
		(int? ReturnCode,
		string Infobar) IncidentPreDeleteSp(
			string IncNum,
			string Infobar);
	}
}

