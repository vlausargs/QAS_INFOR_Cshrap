//PROJECT NAME: Production
//CLASS NAME: ICreateJobCompEsig.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface ICreateJobCompEsig
	{
		(int? ReturnCode, Guid? EsigRowpointer) CreateJobCompEsigSp(string UserName,
		string ReasonCode,
		string Job,
		string Suffix,
		string Item,
		string OperNum,
		string Qty,
		string Loc,
		string ContainerNum = null,
		string Lot = null,
		string Project = null,
		Guid? EsigRowpointer = null);
	}
}

