//PROJECT NAME: POSExt
//CLASS NAME: POSMParms.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.POS;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.POS
{
    [IDOExtensionClass("POSMParms")]
    public class POSMParms : CSIExtensionClassBase
    {
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SSSPOSCheckModuleInstalledSp(string ModuleInstalled, ref int? InstalledYN)
		{
			var iSSSPOSCheckModuleInstalledExt = new SSSPOSCheckModuleInstalledFactory().Create(this, true);
			
			var result = iSSSPOSCheckModuleInstalledExt.SSSPOSCheckModuleInstalledSp(ModuleInstalled, InstalledYN);
			
			InstalledYN = result.InstalledYN;
			
			return result.ReturnCode??0;
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable SSSPOSGetUserGroupNamesCLSp()
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iSSSPOSGetUserGroupNamesCLExt = new SSSPOSGetUserGroupNamesCLFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iSSSPOSGetUserGroupNamesCLExt.SSSPOSGetUserGroupNamesCLSp();
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
