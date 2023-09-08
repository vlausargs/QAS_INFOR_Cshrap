//PROJECT NAME: MaterialExt
//CLASS NAME: SLItemManufacturerItems.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Material;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.Material
{
	[IDOExtensionClass("SLItemManufacturerItems")]
	public class SLItemManufacturerItems : ExtensionClassBase
	{





		[IDOMethod(MethodFlags.None, "Infobar")]
		public int GetManufacturerItemSp(ref string Item,
		                                 ref string Manufacturer,
		                                 ref string ManufacturerName,
		                                 string ManufacturerItem,
		                                 ref string ManufacturerItemDescription,
		                                 string RefType,
		                                 string RefNum,
		                                 ref string Infobar,
		                                 [Optional] string SiteRef)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iGetManufacturerItemExt = new GetManufacturerItemFactory().Create(appDb);
				
				var result = iGetManufacturerItemExt.GetManufacturerItemSp(Item,
				                                                           Manufacturer,
				                                                           ManufacturerName,
				                                                           ManufacturerItem,
				                                                           ManufacturerItemDescription,
				                                                           RefType,
				                                                           RefNum,
				                                                           Infobar,
				                                                           SiteRef);
				
				int Severity = result.ReturnCode.Value;
				Item = result.Item;
				Manufacturer = result.Manufacturer;
				ManufacturerName = result.ManufacturerName;
				ManufacturerItemDescription = result.ManufacturerItemDescription;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int GetManufacturerSp(string Item,
		                             string Manufacturer,
		                             ref string ManufacturerName,
		                             string RefType,
		                             string RefNum,
		                             ref string Infobar,
		                             [Optional] string SiteRef)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iGetManufacturerExt = new GetManufacturerFactory().Create(appDb);
				
				var result = iGetManufacturerExt.GetManufacturerSp(Item,
				                                                   Manufacturer,
				                                                   ManufacturerName,
				                                                   RefType,
				                                                   RefNum,
				                                                   Infobar,
				                                                   SiteRef);
				
				int Severity = result.ReturnCode.Value;
				ManufacturerName = result.ManufacturerName;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int RerankItemManufacturerSp(string PItem,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iRerankItemManufacturerExt = new RerankItemManufacturerFactory().Create(appDb);
				
				var result = iRerankItemManufacturerExt.RerankItemManufacturerSp(PItem,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_ManufacturerItemSp(string Item,
		string Manufacturer,
		string RefType,
		string RefNum,
		ref string Infobar,
		[Optional] string SiteRef,
		[Optional] string ManufacturerItem)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCLM_ManufacturerItemExt = new CLM_ManufacturerItemFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCLM_ManufacturerItemExt.CLM_ManufacturerItemSp(Item,
				Manufacturer,
				RefType,
				RefNum,
				Infobar,
				SiteRef,
				ManufacturerItem);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				Infobar = result.Infobar;
				return dt;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_ManufacturerSp(string Item,
		string RefType,
		string RefNum,
		ref string Infobar,
		[Optional] string SiteRef,
		[Optional] string Manufacturer)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCLM_ManufacturerExt = new CLM_ManufacturerFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCLM_ManufacturerExt.CLM_ManufacturerSp(Item,
				RefType,
				RefNum,
				Infobar,
				SiteRef,
				Manufacturer);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				Infobar = result.Infobar;
				return dt;
			}
		}
	}
}
