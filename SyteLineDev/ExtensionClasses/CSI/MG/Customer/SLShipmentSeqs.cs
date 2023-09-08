//PROJECT NAME: CustomerExt
//CLASS NAME: SLShipmentSeqs.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Logistics.Customer;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Production.Quality;
using CSI.Data.RecordSets;

namespace CSI.MG.Customer
{
	[IDOExtensionClass("SLShipmentSeqs")]
	public class SLShipmentSeqs : ExtensionClassBase
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






		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_UnshipShipmentSp(decimal? ShipmentId,
		                                      byte? Return2Stock,
		                                      [Optional] string Filter)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iCLM_UnshipShipmentExt = new CLM_UnshipShipmentFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iCLM_UnshipShipmentExt.CLM_UnshipShipmentSp(ShipmentId,
				                                                         Return2Stock,
				                                                         Filter);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
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
		public int ShipmentPackageUnMergeSp(Guid? ProcessId,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iShipmentPackageUnMergeExt = new ShipmentPackageUnMergeFactory().Create(appDb);
				
				var result = iShipmentPackageUnMergeExt.ShipmentPackageUnMergeSp(ProcessId,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int UnshipShipmentSp(decimal? ShipmentId,
		string Whse,
		int? IgnoreLCR,
		int? IgnoreCount,
		int? ChangeStatus,
		int? Return2Stock,
		DateTime? TransDate,
		ref int? FirstSequenceWithError,
		ref int? RecordsPosted,
		[Optional] ref string PromptMsg,
		[Optional] ref string PromptButtons,
		ref string InfoBar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iUnshipShipmentExt = new UnshipShipmentFactory().Create(appDb);
				
				var result = iUnshipShipmentExt.UnshipShipmentSp(ShipmentId,
				Whse,
				IgnoreLCR,
				IgnoreCount,
				ChangeStatus,
				Return2Stock,
				TransDate,
				FirstSequenceWithError,
				RecordsPosted,
				PromptMsg,
				PromptButtons,
				InfoBar);
				
				int Severity = result.ReturnCode.Value;
				FirstSequenceWithError = result.FirstSequenceWithError;
				RecordsPosted = result.RecordsPosted;
				PromptMsg = result.PromptMsg;
				PromptButtons = result.PromptButtons;
				InfoBar = result.InfoBar;
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


		[IDOMethod(MethodFlags.None, "Infobar")]
		public int GetShipmentTrackingURLSp(decimal? ShipmentID,
		[Optional] string TrackingNumber,
		ref string TrackingURL)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iGetShipmentTrackingURLExt = new GetShipmentTrackingURLFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iGetShipmentTrackingURLExt.GetShipmentTrackingURLSp(ShipmentID,
				TrackingNumber,
				TrackingURL);
				
				int Severity = result.ReturnCode.Value;
				TrackingURL = result.TrackingURL;
				return Severity;
			}
		}


		[IDOMethod(MethodFlags.None, "Infobar")]
		public int COShippingPopulateTmpShpSP(string CoNum,
		int? CoLine,
		int? CoRelease,
		string UbDoNum,
		int? UbDoLine,
		decimal? UbQtyToShipConv,
		decimal? UbQtyToShip,
		string UbLoc,
		string UbLot,
		int? UbCrReturn,
		int? UbRtnToStk,
		int? UbByCons,
		string UbReasonCode,
		string UbWorkkey,
		DateTime? UbTransDate,
		Guid? RowPointer,
		int? UbSequence,
		string UbOrigInvoice,
		string UbReasonText,
		string UbImportdocId,
		string UbExportDocId,
		int? PackNum,
		string ContainerNum,
		string UM,
		string UbUserName,
		string UbEsigReason,
		Guid? UbEsigRowPointer,
		string UbEsigEncryptedPassword,
		DateTime? RecordDate,
		[Optional] decimal? ShipmentId,
		[Optional] int? ShipmentLine,
		[Optional] int? ShipmentSeq)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCOShippingPopulateTmpShpExt = new COShippingPopulateTmpShpFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCOShippingPopulateTmpShpExt.COShippingPopulateTmpShpSP(CoNum,
				CoLine,
				CoRelease,
				UbDoNum,
				UbDoLine,
				UbQtyToShipConv,
				UbQtyToShip,
				UbLoc,
				UbLot,
				UbCrReturn,
				UbRtnToStk,
				UbByCons,
				UbReasonCode,
				UbWorkkey,
				UbTransDate,
				RowPointer,
				UbSequence,
				UbOrigInvoice,
				UbReasonText,
				UbImportdocId,
				UbExportDocId,
				PackNum,
				ContainerNum,
				UM,
				UbUserName,
				UbEsigReason,
				UbEsigRowPointer,
				UbEsigEncryptedPassword,
				RecordDate,
				ShipmentId,
				ShipmentLine,
				ShipmentSeq);
				
				int Severity = result.Value;
				return Severity;
			}
		}
	}
}
