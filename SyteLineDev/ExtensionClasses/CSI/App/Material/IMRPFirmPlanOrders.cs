//PROJECT NAME: Material
//CLASS NAME: IMRPFirmPlanOrders.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface IMRPFirmPlanOrders
	{
		(int? ReturnCode, string Infobar) MRPFirmPlanOrdersSp(Guid? SessionID,
		string RefType,
		string VendNum = null,
		string PoNum = null,
		string PoChange = null,
		int? BlanketQtyOver = null,
		string ReqNum = null,
		string SfcparmsWoPrefix = null,
		int? CopyBom = null,
		int? CopyIndentedBom = null,
		string SfcparmsPsPrefix = null,
		int? SingleOrder = null,
		string TrnNum = null,
		string FromSite = null,
		string FromWhse = null,
		string ToSite = null,
		string ToWhse = null,
		int? DeleteMpw = 0,
		string Infobar = null);
	}
}

