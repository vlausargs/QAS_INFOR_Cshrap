//PROJECT NAME: RSQCSExt
//CLASS NAME: RS_QCSelectCOCShipmentMasters.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Production.Quality;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.RSQCS
{
	[IDOExtensionClass("RS_QCSelectCOCShipmentMasters")]
	public class RS_QCSelectCOCShipmentMasters : ExtensionClassBase
	{
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int GeneratePackageSp(Guid? ProcessId,
		                             decimal? QtyPerPackage,
		                             ref string InfoBar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iGeneratePackageExt = new GeneratePackageFactory().Create(appDb);
				
				int Severity = iGeneratePackageExt.GeneratePackageSp(ProcessId,
				                                                     QtyPerPackage,
				                                                     ref InfoBar);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int PackConfirmationCompleteSp(decimal? ShipmentID,
		                                      string ShipLoc,
		                                      short? QtyPackages,
		                                      decimal? Weight,
		                                      string WeightUM,
		                                      string Packer,
		                                      ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iPackConfirmationCompleteExt = new PackConfirmationCompleteFactory().Create(appDb);
				
				var result = iPackConfirmationCompleteExt.PackConfirmationCompleteSp(ShipmentID,
				                                                                     ShipLoc,
				                                                                     QtyPackages,
				                                                                     Weight,
				                                                                     WeightUM,
				                                                                     Packer,
				                                                                     Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}



		[IDOMethod(MethodFlags.None, "Infobar")]
		public int RSQC_CheckCustomerShipmentMasterSp(string CoNum,
		int? CoLine,
		int? CoRelease,
		string Item,
		string CoitemUM,
		decimal? ShipmentId,
		int? ShipmentLine,
		decimal? QtyToShip,
		ref int? NeedsQC,
		ref int? HoldCertificateRequired,
		ref string Messages,
		ref int? Status,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iRSQC_CheckCustomerShipmentMasterExt = new RSQC_CheckCustomerShipmentMasterFactory().Create(appDb);
				
				var result = iRSQC_CheckCustomerShipmentMasterExt.RSQC_CheckCustomerShipmentMasterSp(CoNum,
				CoLine,
				CoRelease,
				Item,
				CoitemUM,
				ShipmentId,
				ShipmentLine,
				QtyToShip,
				NeedsQC,
				HoldCertificateRequired,
				Messages,
				Status,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				NeedsQC = result.NeedsQC;
				HoldCertificateRequired = result.HoldCertificateRequired;
				Messages = result.Messages;
				Status = result.Status;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int RSQC_UpdateShipmentCOCSp(decimal? ShipmentId,
		int? ShipmentLine,
		decimal? Qty,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iRSQC_UpdateShipmentCOCExt = new RSQC_UpdateShipmentCOCFactory().Create(appDb);
				
				var result = iRSQC_UpdateShipmentCOCExt.RSQC_UpdateShipmentCOCSp(ShipmentId,
				ShipmentLine,
				Qty,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int GeneratePackageSerialSp(Guid? ProcessId,
		int? PackageId,
		string PackageType,
		string RateCode,
		string NMFC,
		decimal? Weight,
		int? Hazard,
		string MarksExcept,
		string Description,
		ref string InfoBar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iGeneratePackageSerialExt = new GeneratePackageSerialFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iGeneratePackageSerialExt.GeneratePackageSerialSp(ProcessId,
				PackageId,
				PackageType,
				RateCode,
				NMFC,
				Weight,
				Hazard,
				MarksExcept,
				Description,
				InfoBar);
				
				int Severity = result.ReturnCode.Value;
				InfoBar = result.InfoBar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int GenerateTmpShipSeqSp(Guid? ProcessId,
		int? Select,
		decimal? ShipmentId,
		int? ShipmentLine,
		int? ShipmentSeq,
		decimal? QtyPackages,
		decimal? QtyPerPackage,
		string Loc,
		string Lot,
		decimal? QtyPicked,
		decimal? QtyShipped,
		int? PackageId,
		ref string InfoBar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iGenerateTmpShipSeqExt = new GenerateTmpShipSeqFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iGenerateTmpShipSeqExt.GenerateTmpShipSeqSp(ProcessId,
				Select,
				ShipmentId,
				ShipmentLine,
				ShipmentSeq,
				QtyPackages,
				QtyPerPackage,
				Loc,
				Lot,
				QtyPicked,
				QtyShipped,
				PackageId,
				InfoBar);
				
				int Severity = result.ReturnCode.Value;
				InfoBar = result.InfoBar;
				return Severity;
			}
		}
	}
}
