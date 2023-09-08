//PROJECT NAME: BusInterfaceExt
//CLASS NAME: ESBShipmentScheduleLinesViews.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.BusInterface;
using CSI.MG;
using System.Runtime.InteropServices;

namespace CSI.MG.BusInterface
{
	[IDOExtensionClass("ESBShipmentScheduleLinesViews")]
	public class ESBShipmentScheduleLinesViews : ExtensionClassBase
	{
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int LoadESBShipmentSchLineSp(string ActionExpression,
		                                    string CoNum,
		                                    string CustNum,
		                                    short? CoLine,
		                                    string ShipmentLineID,
		                                    string DocumentReference,
		                                    DateTime? CobEffDate,
		                                    DateTime? CobExpDate,
		                                    decimal? CoItemQuantity,
		                                    string CoItemISOUM,
		                                    string CoItemStatus,
		                                    DateTime? CoItemStartDate,
		                                    DateTime? CoItemEndDate,
		                                    string CoItemShipToParty,
		                                    string CoItemUsageType,
		                                    string CoItemExternalPickupSheet,
		                                    string ShipmentRevisionID,
		                                    ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iLoadESBShipmentSchLineExt = new LoadESBShipmentSchLineFactory().Create(appDb);
				
				int Severity = iLoadESBShipmentSchLineExt.LoadESBShipmentSchLineSp(ActionExpression,
				                                                                   CoNum,
				                                                                   CustNum,
				                                                                   CoLine,
				                                                                   ShipmentLineID,
				                                                                   DocumentReference,
				                                                                   CobEffDate,
				                                                                   CobExpDate,
				                                                                   CoItemQuantity,
				                                                                   CoItemISOUM,
				                                                                   CoItemStatus,
				                                                                   CoItemStartDate,
				                                                                   CoItemEndDate,
				                                                                   CoItemShipToParty,
				                                                                   CoItemUsageType,
				                                                                   CoItemExternalPickupSheet,
				                                                                   ShipmentRevisionID,
				                                                                   ref Infobar);
				
				return Severity;
			}
		}
	}
}
