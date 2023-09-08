//PROJECT NAME: Data
//CLASS NAME: IGetInteractionUserCompany.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IGetInteractionUserCompany
	{
		string GetInteractionUserCompanyFn(
			string EnteredBy,
			string Portal);
	}
}

