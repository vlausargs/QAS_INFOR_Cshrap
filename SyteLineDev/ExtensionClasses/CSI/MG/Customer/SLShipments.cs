//PROJECT NAME: CustomerExt
//CLASS NAME: SLShipments.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Logistics.Customer;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;
using Microsoft.Extensions.DependencyInjection;
using CSI.App.Reporting.Rpt_ShipmentProFormaInvoice;

namespace CSI.MG.Customer
{
	[IDOExtensionClass("SLShipments")]
	public class SLShipments : CSIExtensionClassBase
	{
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int GetShipmentInfoSp(decimal? ShipmentId,
		                             ref string Status,
		                             ref string CustNum,
		                             ref int? CustSeq,
		                             ref string Whse,
		                             ref string ShipCode,
		                             ref string CurrCode,
		                             ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iGetShipmentInfoExt = new GetShipmentInfoFactory().Create(appDb);
				
				int Severity = iGetShipmentInfoExt.GetShipmentInfoSp(ShipmentId,
				                                                     ref Status,
				                                                     ref CustNum,
				                                                     ref CustSeq,
				                                                     ref Whse,
				                                                     ref ShipCode,
				                                                     ref CurrCode,
				                                                     ref Infobar);
				
				return Severity;
			}
		}



		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_ShipmentASNSp([Optional] string StartCustNum,
			[Optional] string EndCustNum,
			[Optional] int? StartCustSeq,
			[Optional] int? EndCustSeq,
			[Optional] decimal? StartShipmentID,
			[Optional] decimal? EndShipmentID)
		{
			var iCLM_ShipmentASNExt = this.GetService<ICLM_ShipmentASN>();

			var result = iCLM_ShipmentASNExt.CLM_ShipmentASNSp(StartCustNum,
				EndCustNum,
				StartCustSeq,
				EndCustSeq,
				StartShipmentID,
				EndShipmentID);

			if (result.Data is null)
				return new DataTable();
			else
			{
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				return recordCollectionToDataTable.ToDataTable(result.Data.Items);
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int DelShipmentSp(decimal? StartingShipment,
		                         decimal? EndingShipment,
		                         DateTime? StartingDate,
		                         DateTime? EndingDate,
		                         string StartingCustNum,
		                         string EndingCustNum,
		                         [Optional] short? StartingDateOffset,
		                         [Optional] short? EndingDateOffset,
		                         ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iDelShipmentExt = new DelShipmentFactory().Create(appDb);
				
				var result = iDelShipmentExt.DelShipmentSp(StartingShipment,
				                                           EndingShipment,
				                                           StartingDate,
				                                           EndingDate,
				                                           StartingCustNum,
				                                           EndingCustNum,
				                                           StartingDateOffset,
				                                           EndingDateOffset,
				                                           Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}



		[IDOMethod(MethodFlags.None, "Infobar")]
		public int PickListValidateSp(decimal? PickListId,
		                              ref string CustNum,
		                              ref int? CustSeq,
		                              ref string Whse,
		                              ref string ShipLoc,
		                              ref string Infobar,
		                              [Optional] ref string Prompt,
		                              [Optional] ref string PromptButtons,
		                              ref decimal? ShipmentId)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iPickListValidateExt = new PickListValidateFactory().Create(appDb);
				
				var result = iPickListValidateExt.PickListValidateSp(PickListId,
				                                                     CustNum,
				                                                     CustSeq,
				                                                     Whse,
				                                                     ShipLoc,
				                                                     Infobar,
				                                                     Prompt,
				                                                     PromptButtons,
				                                                     ShipmentId);
				
				int Severity = result.ReturnCode.Value;
				CustNum = result.CustNum;
				CustSeq = result.CustSeq;
				Whse = result.Whse;
				ShipLoc = result.ShipLoc;
				Infobar = result.Infobar;
				Prompt = result.Prompt;
				PromptButtons = result.PromptButtons;
				ShipmentId = result.ShipmentId;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable ProfileShipmentBillofLadingSp([Optional] decimal? ShipmentStarting,
		                                               [Optional] decimal? ShipmentEnding,
		                                               [Optional] string CustomerStarting,
		                                               [Optional] string CustomerEnding,
		                                               [Optional] int? CustSeqStarting,
		                                               [Optional] int? CustSeqEnding,
		                                               [Optional] DateTime? PickupDateStarting,
		                                               [Optional] DateTime? PickupDateEnding,
		                                               [Optional] short? PickupDateStartingOffset,
		                                               [Optional] short? PickupDateEndingOffset,
		                                               [Optional] byte? DisplayHeader)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iProfileShipmentBillofLadingExt = new ProfileShipmentBillofLadingFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iProfileShipmentBillofLadingExt.ProfileShipmentBillofLadingSp(ShipmentStarting,
				                                                                           ShipmentEnding,
				                                                                           CustomerStarting,
				                                                                           CustomerEnding,
				                                                                           CustSeqStarting,
				                                                                           CustSeqEnding,
				                                                                           PickupDateStarting,
				                                                                           PickupDateEnding,
				                                                                           PickupDateStartingOffset,
				                                                                           PickupDateEndingOffset,
				                                                                           DisplayHeader);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable ProfileShipmentPackingSlipSp([Optional] decimal? ShipmentStarting,
		                                              [Optional] decimal? ShipmentEnding,
		                                              [Optional] string CustomerStarting,
		                                              [Optional] string CustomerEnding,
		                                              [Optional] int? CustSeqStarting,
		                                              [Optional] int? CustSeqEnding,
		                                              [Optional] DateTime? PickupDateStarting,
		                                              [Optional] DateTime? PickupDateEnding,
		                                              [Optional] short? PickupDateStartingOffset,
		                                              [Optional] short? PickupDateEndingOffset,
		                                              [Optional] byte? DisplayHeader)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iProfileShipmentPackingSlipExt = new ProfileShipmentPackingSlipFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iProfileShipmentPackingSlipExt.ProfileShipmentPackingSlipSp(ShipmentStarting,
				                                                                         ShipmentEnding,
				                                                                         CustomerStarting,
				                                                                         CustomerEnding,
				                                                                         CustSeqStarting,
				                                                                         CustSeqEnding,
				                                                                         PickupDateStarting,
				                                                                         PickupDateEnding,
				                                                                         PickupDateStartingOffset,
				                                                                         PickupDateEndingOffset,
				                                                                         DisplayHeader);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable ProfileShipmentProFormaInvoiceSp([Optional] decimal? ShipmentStarting,
			[Optional] decimal? ShipmentEnding,
			[Optional] string CustomerStarting,
			[Optional] string CustomerEnding,
			[Optional] int? CustSeqStarting,
			[Optional] int? CustSeqEnding,
			[Optional] DateTime? PickupDateStarting,
			[Optional] DateTime? PickupDateEnding)
		{
			using (var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);

				var iProfileShipmentProFormaInvoiceExt = this.GetService<IProfileShipmentProFormaInvoice>();

				var result = iProfileShipmentProFormaInvoiceExt.ProfileShipmentProFormaInvoiceSp(ShipmentStarting,
					ShipmentEnding,
					CustomerStarting,
					CustomerEnding,
					CustSeqStarting,
					CustSeqEnding,
					PickupDateStarting,
					PickupDateEnding);

				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();

				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}



		[IDOMethod(MethodFlags.None, "Infobar")]
		public int RSQC_CustomerLicenseSp(ref int? IsQCLicensed)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iRSQC_CustomerLicenseExt = new RSQC_CustomerLicenseFactory().Create(appDb);
				
				var result = iRSQC_CustomerLicenseExt.RSQC_CustomerLicenseSp(IsQCLicensed);
				
				int Severity = result.ReturnCode.Value;
				IsQCLicensed = result.IsQCLicensed;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int RSQC_CustomerNeedsQCSp(decimal? ShipmentID,
		ref int? NeedsQC)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iRSQC_CustomerNeedsQCExt = new RSQC_CustomerNeedsQCFactory().Create(appDb);
				
				var result = iRSQC_CustomerNeedsQCExt.RSQC_CustomerNeedsQCSp(ShipmentID,
				NeedsQC);
				
				int Severity = result.ReturnCode.Value;
				NeedsQC = result.NeedsQC;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int RSQC_RollBackShipmentCOCSp(decimal? ShipmentId,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iRSQC_RollBackShipmentCOCExt = new RSQC_RollBackShipmentCOCFactory().Create(appDb);
				
				var result = iRSQC_RollBackShipmentCOCExt.RSQC_RollBackShipmentCOCSp(ShipmentId,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ShipConfirmationSp(decimal? ShipmentId,
		DateTime? Curdate,
		int? IgnoreLCR,
		int? IgnoreCount,
		ref string InfoBar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iShipConfirmationExt = new ShipConfirmationFactory().Create(appDb);
				
				var result = iShipConfirmationExt.ShipConfirmationSp(ShipmentId,
				Curdate,
				IgnoreLCR,
				IgnoreCount,
				InfoBar);
				
				int Severity = result.ReturnCode.Value;
				InfoBar = result.InfoBar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ShipmentMergeSp(decimal? OldShipment,
		decimal? NewShipment,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iShipmentMergeExt = new ShipmentMergeFactory().Create(appDb);
				
				var result = iShipmentMergeExt.ShipmentMergeSp(OldShipment,
				NewShipment,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ShipmentSplittingSp([Optional] int? Package,
		[Optional] decimal? OldShipment,
		[Optional] int? OldLine,
		[Optional] int? OldSeq,
		[Optional] int? CreateNewLine,
		ref decimal? NewShipment,
		ref int? NewLine,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iShipmentSplittingExt = new ShipmentSplittingFactory().Create(appDb);
				
				var result = iShipmentSplittingExt.ShipmentSplittingSp(Package,
				OldShipment,
				OldLine,
				OldSeq,
				CreateNewLine,
				NewShipment,
				NewLine,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				NewShipment = result.NewShipment;
				NewLine = result.NewLine;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int UpdateShipmentValueSp(decimal? Shipment,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iUpdateShipmentValueExt = new UpdateShipmentValueFactory().Create(appDb);
				
				var result = iUpdateShipmentValueExt.UpdateShipmentValueSp(Shipment,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int CalculateShipmentWeightAndPackagesSp(decimal? Shipment,
		int? Recalcflag,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCalculateShipmentWeightAndPackagesExt = new CalculateShipmentWeightAndPackagesFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCalculateShipmentWeightAndPackagesExt.CalculateShipmentWeightAndPackagesSp(Shipment,
				Recalcflag,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
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
		public int GeneratePickListTmpSp(Guid? ProcessId,
		int? Select,
		decimal? PickListId,
		string CustNum,
		int? CustSeq,
		string Whse,
		int? Group,
		string Packer,
		string ParentContainerNum,
		ref string InfoBar,
		[Optional] string RefNum,
		[Optional] int? RefLine,
		[Optional] int? RefRelease,
		[Optional] string RefType,
		[Optional, DefaultParameterValue(0)] decimal? Qty,
		[Optional] string Loc,
		[Optional] string Lot)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iGeneratePickListTmpExt = new GeneratePickListTmpFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iGeneratePickListTmpExt.GeneratePickListTmpSp(ProcessId,
				Select,
				PickListId,
				CustNum,
				CustSeq,
				Whse,
				Group,
				Packer,
				ParentContainerNum,
				InfoBar,
				RefNum,
				RefLine,
				RefRelease,
				RefType,
				Qty,
				Loc,
				Lot);
				
				int Severity = result.ReturnCode.Value;
				InfoBar = result.InfoBar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int GenerateShipmentSP(Guid? ProcessId,
		string ShipLoc,
		int? Packages,
		decimal? Weight,
		string WeightUm,
		ref string InfoBar,
		[Optional] string ShipmentStatus)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iGenerateShipmentExt = new GenerateShipmentFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iGenerateShipmentExt.GenerateShipmentSP(ProcessId,
				ShipLoc,
				Packages,
				Weight,
				WeightUm,
				InfoBar,
				ShipmentStatus);
				
				int Severity = result.ReturnCode.Value;
				InfoBar = result.InfoBar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable GetShipmentListSp(decimal? PickListId,
		ref string InfoBar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iGetShipmentListExt = new GetShipmentListFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iGetShipmentListExt.GetShipmentListSp(PickListId,
				InfoBar);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				InfoBar = result.InfoBar;
				return dt;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable PackageLoadTreeLevelSp(decimal? ShipmentId,
		string Type,
		int? PackageID,
		string Item,
		string Lot,
		string Process)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iPackageLoadTreeLevelExt = new PackageLoadTreeLevelFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iPackageLoadTreeLevelExt.PackageLoadTreeLevelSp(ShipmentId,
				Type,
				PackageID,
				Item,
				Lot,
				Process);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		public int UpdateShipmentWithTMInfo(string TMShipmentInfo, [Optional] ref string Infobar)
		{
			int severity = 0;
			var updateShipmentWithTMInfo = this.GetService<IUpdateShipmentWithTMInfo>();

			var process = updateShipmentWithTMInfo.Process(TMShipmentInfo);

			severity = process.returnCode??0;
			 Infobar = process.infobar;

			return severity;
		}
	}
}
