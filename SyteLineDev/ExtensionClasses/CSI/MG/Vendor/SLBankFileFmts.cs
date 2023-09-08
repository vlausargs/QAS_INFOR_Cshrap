//PROJECT NAME: MG
//CLASS NAME: SLBankFileFmts.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Logistics.Vendor;
using CSI.MG;
using CSI.Data.RecordSets;
using System.Runtime.InteropServices;

namespace CSI.MG.Vendor
{
	[IDOExtensionClass("SLBankFileFmts")]
	public class SLBankFileFmts : ExtensionClassBase
	{
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int GetLogicalFoldersByPermissionSp([Optional] string UserName,
		[Optional] string PermissionGroupName,
		[Optional, DefaultParameterValue(0)] int? ShowAllFolders)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
                var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
                var mgInvoker = new MGInvoker(this.Context);
				
				var iGetLogicalFoldersByPermissionExt = new GetLogicalFoldersByPermissionFactory().Create(appDb,
                bunchedLoadCollection,
                mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iGetLogicalFoldersByPermissionExt.GetLogicalFoldersByPermissionSp(UserName,
				PermissionGroupName,
				ShowAllFolders);
				
				int Severity = (int)result.ReturnCode;
				return Severity;
			}
		}
	}
}
