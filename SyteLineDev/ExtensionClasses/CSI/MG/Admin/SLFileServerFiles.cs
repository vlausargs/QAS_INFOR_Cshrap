//PROJECT NAME: AdminExt
//CLASS NAME: SLFileServerFiles.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Admin;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;
using CSI.Logistics.Vendor;



namespace CSI.MG.Admin
{
    [IDOExtensionClass("SLFileServerFiles")]
    public class SLFileServerFiles : ExtensionClassBase
    {
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int GetFileServerInfoByLogicalFolderNameSp(string LogicalFolderName,
                                                          ref string ServerName,
                                                          ref string FolderTemplate,
                                                          ref byte? FolderAccessDepth)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iGetFileServerInfoByLogicalFolderNameExt = new GetFileServerInfoByLogicalFolderNameFactory().Create(appDb);

                OSMachineNameType oServerName = ServerName;
                FolderTemplateType oFolderTemplate = FolderTemplate;
                PopulationDepthType oFolderAccessDepth = FolderAccessDepth;

                int Severity = iGetFileServerInfoByLogicalFolderNameExt.GetFileServerInfoByLogicalFolderNameSp(LogicalFolderName,
                                                                                                               ref oServerName,
                                                                                                               ref oFolderTemplate,
                                                                                                               ref oFolderAccessDepth);

                ServerName = oServerName;
                FolderTemplate = oFolderTemplate;
                FolderAccessDepth = oFolderAccessDepth;


                return Severity;
            }
        }

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
        public DataTable GetLogicalFoldersByPermissionSp([Optional] string UserName,
        [Optional] string PermissionGroupName,
        [Optional, DefaultParameterValue(0)] int? ShowAllFolders)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
                var mgInvoker = new MGInvoker(this.Context);
                var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
                var iGetLogicalFoldersByPermissionExt = new GetLogicalFoldersByPermissionFactory().Create(appDb,
                bunchedLoadCollection,
                mgInvoker,
                new CSI.Data.SQL.SQLParameterProvider(),
                true);

                var result = iGetLogicalFoldersByPermissionExt.GetLogicalFoldersByPermissionSp(UserName,
                PermissionGroupName,
                ShowAllFolders);

                IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();

                DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
                return dt;
            }
        }
    }
}
