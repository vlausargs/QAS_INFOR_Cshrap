//PROJECT NAME: Logistics
//CLASS NAME: IValidateShipCoA.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IValidateShipCoA
	{
		(int? ReturnCode, int? PShipCoActive,
		int? PShipCoLines,
		int? PShipCoReadyToProcess,
		int? PShipCoPicked,
		int? PShipCoShipped,
		int? PShipCoPacked,
		int? PShipCoInvoiced,
		decimal? PLcrAmt,
		string PromptMsg,
		string PromptButtons,
		string Infobar) ValidateShipCoASp(string PShipCoCoNum,
		decimal? PSubColLcrAmt,
		int? PShipCoActive,
		int? PShipCoLines,
		int? PShipCoReadyToProcess,
		int? PShipCoPicked,
		int? PShipCoShipped,
		int? PShipCoPacked,
		int? PShipCoInvoiced,
		decimal? PLcrAmt,
		string PromptMsg,
		string PromptButtons,
		string Infobar,
		int? RecalcOnly = 0);
	}
}

