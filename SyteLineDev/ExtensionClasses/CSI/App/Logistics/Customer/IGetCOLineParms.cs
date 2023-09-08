//PROJECT NAME: Logistics
//CLASS NAME: IGetCOLineParms.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IGetCOLineParms
	{
		(int? ReturnCode, string ApsParmApsmode,
		string MrpParmReqSrc,
		int? CanDueNEProjected,
		int? CanDueLTProjected,
		int? SharedCustEnabled) GetCOLineParmsSp(string Type,
		string Type1,
		string Object,
		string ParamSite,
		string ApsParmApsmode,
		string MrpParmReqSrc,
		int? CanDueNEProjected,
		int? CanDueLTProjected,
		int? SharedCustEnabled);
	}
}

