//PROJECT NAME: Production
//CLASS NAME: IValidateResource.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface IValidateResource
	{
		(int? ReturnCode, string RESID,
		string DESCR,
		string Infobar) ValidateResourceSp(string RESID,
		int? AltNo,
		string DESCR,
		string Infobar);
	}
}

