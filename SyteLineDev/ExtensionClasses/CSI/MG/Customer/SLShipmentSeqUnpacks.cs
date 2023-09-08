//PROJECT NAME: CustomerExt
//CLASS NAME: SLShipmentSeqUnpacks.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Logistics.Customer;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.Customer
{
	[IDOExtensionClass("SLShipmentSeqUnpacks")]
	public class SLShipmentSeqUnpacks : ExtensionClassBase
	{
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int CheckNeedDeletedShipmentSp(Guid? ProcessId,
		                                      [Optional, DefaultParameterValue((byte)0)] ref byte? DeleteEmptyShipment,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iCheckNeedDeletedShipmentExt = new CheckNeedDeletedShipmentFactory().Create(appDb);
				
				var result = iCheckNeedDeletedShipmentExt.CheckNeedDeletedShipmentSp(ProcessId,
				                                                                     DeleteEmptyShipment,
				                                                                     Infobar);
				
				int Severity = result.ReturnCode.Value;
				DeleteEmptyShipment = result.DeleteEmptyShipment;
				Infobar = result.Infobar;
				return Severity;
			}
		}


		[IDOMethod(MethodFlags.None, "Infobar")]
		public int UnpackInventorySp(Guid? ProcessId,
		int? ReturnToPickList,
		int? ReduceQuantityOnly,
		ref string Infobar,
		[Optional, DefaultParameterValue(0)] int? DeleteEmptyShipment)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iUnpackInventoryExt = new UnpackInventoryFactory().Create(appDb);
				
				var result = iUnpackInventoryExt.UnpackInventorySp(ProcessId,
				ReturnToPickList,
				ReduceQuantityOnly,
				Infobar,
				DeleteEmptyShipment);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int GenerateUnpackInventoryTmpShipSeqSp(Guid? ProcessId,
		int? Select,
		decimal? ShipmentId,
		int? ShipmentLine,
		int? ShipmentSeq,
		decimal? QtyPackages,
		decimal? QtyPerPackage,
		string ToLoc,
		string Lot,
		decimal? QtyPicked,
		decimal? QtyShipped,
		int? PackageId,
		string Loc,
		int? ReturnToPickList,
		int? ReduceQtyOnly,
		ref string InfoBar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iGenerateUnpackInventoryTmpShipSeqExt = new GenerateUnpackInventoryTmpShipSeqFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iGenerateUnpackInventoryTmpShipSeqExt.GenerateUnpackInventoryTmpShipSeqSp(ProcessId,
				Select,
				ShipmentId,
				ShipmentLine,
				ShipmentSeq,
				QtyPackages,
				QtyPerPackage,
				ToLoc,
				Lot,
				QtyPicked,
				QtyShipped,
				PackageId,
				Loc,
				ReturnToPickList,
				ReduceQtyOnly,
				InfoBar);
				
				int Severity = result.ReturnCode.Value;
				InfoBar = result.InfoBar;
				return Severity;
			}
		}
	}
}
