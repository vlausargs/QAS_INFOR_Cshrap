//PROJECT NAME: Data
//CLASS NAME: ICo10R.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ICo10R
	{
		(int? ReturnCode,
			string StartInvNum,
			string EndInvNum,
			string Infobar,
			Guid? ProcessID) Co10RSp(
			string InvType = "R",
			string InvCred = "I",
			DateTime? InvDate = null,
			string StartCustomer = null,
			string EndCustomer = null,
			string StartOrderNum = null,
			string EndOrderNum = null,
			int? StartLine = null,
			int? EndLine = null,
			int? StartRelease = null,
			int? EndRelease = null,
			DateTime? StartLastShipDate = null,
			DateTime? EndLastShipDate = null,
			int? StartPackNum = null,
			int? EndPackNum = null,
			int? CreateFromPackSlip = 0,
			string pMooreForms = "N",
			int? pNonDraftCust = 0,
			string SelectedStartInvNum = null,
			int? CheckShipItemActiveFlag = 0,
			string StartInvNum = null,
			string EndInvNum = null,
			string Infobar = null,
			int? BatchId = null,
			Guid? ProcessID = null,
			string CalledFrom = null,
			Guid? InvoicBuilderProcessID = null,
			decimal? StartShipmentId = null,
			decimal? EndShipmentId = null,
			int? CreateFromShipment = 0);
	}
}

