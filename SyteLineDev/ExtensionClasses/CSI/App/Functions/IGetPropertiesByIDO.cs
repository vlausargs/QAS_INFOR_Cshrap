//PROJECT NAME: Data
//CLASS NAME: IGetPropertiesByIDO.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IGetPropertiesByIDO
	{
		(int? ReturnCode,
			string DynamicSQL) GetPropertiesByIDOSp(
			string DomainIDOName,
			string DomainProperty,
			string DomainListProperty,
			string SiteRef,
			string KeyValue = null,
			string DynamicSQL = null);
	}
}

