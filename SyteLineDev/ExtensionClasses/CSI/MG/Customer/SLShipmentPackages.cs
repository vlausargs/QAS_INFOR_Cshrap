//PROJECT NAME: CustomerExt
//CLASS NAME: SLShipmentPackages.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Logistics.Customer;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;
using CSI.ExternalContracts.FactoryTrack;
using Microsoft.Extensions.DependencyInjection;

namespace CSI.MG.Customer
{
	[IDOExtensionClass("SLShipmentPackages")]
	public class SLShipmentPackages : CSIExtensionClassBase, IExtFTSLShipmentPackages
	{

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int GeneratePackagePackageSp(Guid? ProcessId,
		                                    int? PackageId,
		                                    ref string InfoBar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iGeneratePackagePackageExt = new GeneratePackagePackageFactory().Create(appDb);
				
				int Severity = iGeneratePackagePackageExt.GeneratePackagePackageSp(ProcessId,
				                                                                   PackageId,
				                                                                   ref InfoBar);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int LabelPathsExistSp(ref string UbTemplatePath,
		                             ref string UbOutputPath)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iLabelPathsExistExt = new LabelPathsExistFactory().Create(appDb);
				
				int Severity = iLabelPathsExistExt.LabelPathsExistSp(ref UbTemplatePath,
				                                                     ref UbOutputPath);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int PackagesExistSp(decimal? ShipmentID,
			ref int? UbPackagesExist)
		{
			var iPackagesExistExt = new PackagesExistFactory().Create(this, true);

			var result = iPackagesExistExt.PackagesExistSp(ShipmentID,
				UbPackagesExist);

			UbPackagesExist = result.UbPackagesExist;

			return result.ReturnCode ?? 0;
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int RemoveShipmentSequencePackageIDSp(Guid? ProcessId,
		                                             ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iRemoveShipmentSequencePackageIDExt = new RemoveShipmentSequencePackageIDFactory().Create(appDb);
				
				int Severity = iRemoveShipmentSequencePackageIDExt.RemoveShipmentSequencePackageIDSp(ProcessId,
				                                                                                     ref Infobar);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ValidateShipmentPackageSp(decimal? ShipmentID,
		                                     int? PackageId,
		                                     ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iValidateShipmentPackageExt = new ValidateShipmentPackageFactory().Create(appDb);
				
				int Severity = iValidateShipmentPackageExt.ValidateShipmentPackageSp(ShipmentID,
				                                                                     PackageId,
				                                                                     ref Infobar);
				
				return Severity;
			}
		}


		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_PackageLabelsSp(decimal? ShipmentID,
		                                     string UbLabelBy,
		                                     string UbSite,
		                                     [Optional] string FilterString)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iCLM_PackageLabelsExt = new CLM_PackageLabelsFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iCLM_PackageLabelsExt.CLM_PackageLabelsSp(ShipmentID,
				                                                       UbLabelBy,
				                                                       UbSite,
				                                                       FilterString);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}



		[IDOMethod(MethodFlags.None, "Infobar")]
		public int GenerateTmpShipSeqPackageSp(Guid? ProcessId,
		int? Select,
		decimal? ShipmentId,
		int? PackageId,
		string PackageType,
		string RateCode,
		string NMFC,
		decimal? Weight,
		int? Hazard,
		string Description,
		string Marksexcept,
		int? RefPackageId,
		string TH_CartonPrefix,
		decimal? TH_Measurement,
		string TH_CartonSize,
		ref string InfoBar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iGenerateTmpShipSeqPackageExt = new GenerateTmpShipSeqPackageFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iGenerateTmpShipSeqPackageExt.GenerateTmpShipSeqPackageSp(ProcessId,
				Select,
				ShipmentId,
				PackageId,
				PackageType,
				RateCode,
				NMFC,
				Weight,
				Hazard,
				Description,
				Marksexcept,
				RefPackageId,
				TH_CartonPrefix,
				TH_Measurement,
				TH_CartonSize,
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
		public int GenerateTmpShipSeqPackageWithFreightClassSp(Guid? ProcessId,
		int? Select,
		decimal? ShipmentId,
		int? PackageId,
		string PackageType,
		string RateCode,
		string NMFC,
		decimal? Weight,
		int? Hazard,
		string Description,
		string Marksexcept,
		int? RefPackageId,
		string TH_CartonPrefix,
		decimal? TH_Measurement,
		string TH_CartonSize,
		[Optional] string FreightClass,
		ref string InfoBar)
		{
			int Severity = 0;

			Severity = this.GenerateTmpShipSeqPackageSp(ProcessId,
			Select,
			ShipmentId,
			PackageId,
			PackageType,
			RateCode,
			NMFC,
			Weight,
			Hazard,
			Description,
			Marksexcept,
			RefPackageId,
			TH_CartonPrefix,
			TH_Measurement,
			TH_CartonSize,
			ref InfoBar);

			if (Severity != 0)
			{
				return Severity;
			}

			var shipmentPackageFreightClass = this.GetService<IShipmentPackageFreightClass>();

			(Severity, InfoBar) = shipmentPackageFreightClass.Process(ShipmentId, PackageId, FreightClass);


			return Severity;

		}
	}
}
