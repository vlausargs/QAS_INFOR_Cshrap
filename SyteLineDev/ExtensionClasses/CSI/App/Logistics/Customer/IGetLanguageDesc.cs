//PROJECT NAME: Logistics
//CLASS NAME: IGetLanguageDesc.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IGetLanguageDesc
	{
			(int? ReturnCode,
			string Description,
			string Infobar) 
		GetLanguageDescSp(
			string LanguageCode,
			string Description,
			string Infobar = null);
	}
}

