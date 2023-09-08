//PROJECT NAME: Logistics
//CLASS NAME: IHomepage_MyPipelineValue.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IHomepage_MyPipelineValue
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Homepage_MyPipelineValueSp(string Salesperson = null, int? IncludeDirectReports = 0);
	}
}

