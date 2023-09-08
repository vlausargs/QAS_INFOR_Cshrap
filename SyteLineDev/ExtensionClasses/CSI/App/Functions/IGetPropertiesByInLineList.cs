//PROJECT NAME: Data
//CLASS NAME: IGetPropertiesByInLineList.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IGetPropertiesByInLineList
	{
		(int? ReturnCode,
			string DynamicSQL) GetPropertiesByInLineListSp(
			string InLineList,
			string KeyValue = null,
			string DynamicSQL = null);
	}
}

