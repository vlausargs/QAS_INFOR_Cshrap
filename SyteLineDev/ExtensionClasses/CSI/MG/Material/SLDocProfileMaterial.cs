//PROJECT NAME: MaterialExt
//CLASS NAME: SLDocProfileMaterial.cs

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
    [IDOExtensionClass("SLDocProfileMaterial")]
    public class SLDocProfileMaterial : ExtensionClassBase
    {
		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable ProfileProFormaInvoiceSp([Optional] int? pStartPackNum,
		                                          [Optional] int? pEndPackNum)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iProfileProFormaInvoiceExt = new ProfileProFormaInvoiceFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iProfileProFormaInvoiceExt.ProfileProFormaInvoiceSp(pStartPackNum,
				                                                                 pEndPackNum);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
