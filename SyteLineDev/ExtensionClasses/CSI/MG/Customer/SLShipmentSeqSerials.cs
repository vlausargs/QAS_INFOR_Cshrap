//PROJECT NAME: CustomerExt
//CLASS NAME: SLShipmentSeqSerials.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Logistics.Customer;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Material;
using CSI.BusInterface;
using CSI.Data.RecordSets;

namespace CSI.MG.Customer
{
    [IDOExtensionClass("SLShipmentSeqSerials")]
    public class SLShipmentSeqSerials : ExtensionClassBase
    {



		[IDOMethod(MethodFlags.None, "Infobar")]
		public int GenerateTmpShipSeqSerialSp(Guid? ProcessId,
		int? Select,
		decimal? ShipmentId,
		int? ShipmentLine,
		int? ShipmentSeq,
		string SerNum,
		ref string InfoBar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iGenerateTmpShipSeqSerialExt = new GenerateTmpShipSeqSerialFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iGenerateTmpShipSeqSerialExt.GenerateTmpShipSeqSerialSp(ProcessId,
				Select,
				ShipmentId,
				ShipmentLine,
				ShipmentSeq,
				SerNum,
				InfoBar);
				
				int Severity = result.ReturnCode.Value;
				InfoBar = result.InfoBar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SerialSaveSp(string SerNum,
		[Optional] Guid? TmpSerId,
		[Optional] string RefStr,
		ref string Infobar,
		[Optional] DateTime? ManufacturedDate,
		[Optional] DateTime? ExpirationDate,
		[Optional] string TrxRestrictCode)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iSerialSaveExt = new SerialSaveFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iSerialSaveExt.SerialSaveSp(SerNum,
				TmpSerId,
				RefStr,
				Infobar,
				ManufacturedDate,
				ExpirationDate,
				TrxRestrictCode);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}
    }
}
