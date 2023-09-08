//PROJECT NAME: BusInterfaceExt
//CLASS NAME: ESBReceiveShipHdrViews.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.BusInterface;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;
using Microsoft.Extensions.DependencyInjection;

namespace CSI.MG.BusInterface
{
	[IDOExtensionClass("ESBReceiveShipHdrViews")]
	public class ESBReceiveShipHdrViews : CSIExtensionClassBase
	{


		[IDOMethod(MethodFlags.None, "Infobar")]
		public int LoadESBReceiveShippingPostSp(string DocumentIDName,
		                                        string BODNOUN,
		                                        string BODVERB,
		                                        string DocumentID,
		                                        string PurchaseOrderRef,
		                                        string SalesOrderRef,
		                                        string Status,
		                                        ref string InfoBar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iLoadESBReceiveShippingPostExt = new LoadESBReceiveShippingPostFactory().Create(appDb);
				
				int Severity = iLoadESBReceiveShippingPostExt.LoadESBReceiveShippingPostSp(DocumentIDName,
				                                                                           BODNOUN,
				                                                                           BODVERB,
				                                                                           DocumentID,
				                                                                           PurchaseOrderRef,
				                                                                           SalesOrderRef,
				                                                                           Status,
				                                                                           ref InfoBar);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_ESBReceiveHdrPLSp(string RefNum,
		DateTime? ReceivedDateTime,
		string RefType,
		[Optional] decimal? ShipmentID)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCLM_ESBReceiveHdrPLExt = new CLM_ESBReceiveHdrPLFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCLM_ESBReceiveHdrPLExt.CLM_ESBReceiveHdrPLSp(RefNum,
				ReceivedDateTime,
				RefType,
				ShipmentID);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_ESBReceiveShipHdrSp(decimal? DocumentID)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCLM_ESBReceiveShipHdrExt = new CLM_ESBReceiveShipHdrFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCLM_ESBReceiveShipHdrExt.CLM_ESBReceiveShipHdrSp(DocumentID);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_ESBShipHdrPLSp(string RefNum,
		DateTime? ShippedDateTime,
		string RefType,
		[Optional] decimal? ShipmentID,
		[Optional] string ShipmentStatus)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCLM_ESBShipHdrPLExt = new CLM_ESBShipHdrPLFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCLM_ESBShipHdrPLExt.CLM_ESBShipHdrPLSp(RefNum,
				ShippedDateTime,
				RefType,
				ShipmentID,
				ShipmentStatus);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}







		[IDOMethod(MethodFlags.None, "Infobar")]
		public int GenerateReceiveShipBODPLSp(string RefNum,
		string ReceivedDateTime,
		string RefType,
		[Optional] ref string Infobar,
		[Optional] decimal? ShipmentID,
		[Optional] string Action)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iGenerateReceiveShipBODPLExt = new GenerateReceiveShipBODPLFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iGenerateReceiveShipBODPLExt.GenerateReceiveShipBODPLSp(RefNum,
				ReceivedDateTime,
				RefType,
				Infobar,
				ShipmentID,
				Action);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}


		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_ESBSp()
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCLM_ESBExt = new CLM_ESBFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCLM_ESBExt.CLM_ESBSp();
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}		
	}
}
