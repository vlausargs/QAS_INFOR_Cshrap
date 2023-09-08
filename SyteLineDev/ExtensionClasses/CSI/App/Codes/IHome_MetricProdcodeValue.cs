//PROJECT NAME: Codes
//CLASS NAME: IHome_MetricProdcodeValue.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Codes
{
	public interface IHome_MetricProdcodeValue
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Home_MetricProdcodeValueSp();
	}
}

