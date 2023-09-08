//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSSROPackSlipLineCLM.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService.Requests
{
	public interface ISSSFSSROPackSlipLineCLM
	{
		(ICollectionLoadResponse Data, int? ReturnCode) SSSFSSROPackSlipLineCLMSp(int? PackNum);
	}
}

