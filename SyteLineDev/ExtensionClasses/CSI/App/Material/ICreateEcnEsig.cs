//PROJECT NAME: Material
//CLASS NAME: ICreateEcnEsig.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface ICreateEcnEsig
	{
		(int? ReturnCode, Guid? EsigRowpointer) CreateEcnEsigSp(string UserName,
		string ReasonCode,
		string ECNNum,
		Guid? EsigRowpointer);
	}
}

