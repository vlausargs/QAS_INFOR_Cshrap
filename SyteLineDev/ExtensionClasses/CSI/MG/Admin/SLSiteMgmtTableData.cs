using CSI.Admin;
using CSI.Admin.SiteOnBoarding;
using Microsoft.Extensions.DependencyInjection;
using Mongoose.IDO;
using System.Runtime.InteropServices;
using CSI.Interfaces.Data;

namespace CSI.MG.Admin
{
    [IDOExtensionClass("SLSiteMgmtTableData")]
    public class SLSiteMgmtTableData : CSIExtensionClassBase
    {
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int GetSiteTableToPurgeSp(
            string DeleteSite,
            ref string TableName,
            ref int? OriginRowAmount,
            ref int? PendingTableRemaining)
        {
            var iGetSiteTableToPurgeExt = new GetSiteTableToPurgeFactory().Create(this, true);

            var result = iGetSiteTableToPurgeExt.GetSiteTableToPurgeSp(
                DeleteSite,
                TableName,
                OriginRowAmount,
                PendingTableRemaining);

            TableName = result.TableName;
            OriginRowAmount = result.OriginRowAmount;
            PendingTableRemaining = result.PendingTableRemaining;

            return result.ReturnCode ?? 0;
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int PreSitePurgeSp(
            string DeleteSite,
            [Optional, DefaultParameterValue(0)] int? IsRetry,
            string NotificationEmail,
            ref string Infobar)
        {
            var iPreSitePurgeExt = new PreSitePurgeFactory().Create(this, true);

            var result = iPreSitePurgeExt.PreSitePurgeSp(
                DeleteSite,
                IsRetry,
                NotificationEmail,
                Infobar);

            Infobar = result.Infobar;

            return result.ReturnCode ?? 0;
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int PurgeTableSp(
            string TableName,
            string DeleteSite,
            [Optional, DefaultParameterValue(0)] int? ForcePurge,
            ref int? RowAmount,
            ref int? CanRetry,
            ref string Infobar)
        {
            var iPurgeTableExt = new PurgeTableFactory().Create(this, true);

            var result = iPurgeTableExt.PurgeTableSp(
                TableName,
                DeleteSite,
                ForcePurge,
                RowAmount,
                CanRetry,
                Infobar);

            RowAmount = result.RowAmount;
            CanRetry = result.CanRetry;
            Infobar = result.Infobar;

            return result.ReturnCode ?? 0;
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int GetAvailableTask(
            string site,
            ref string TaskRowPointer,
            ref string Infobar)
        {
            var taskNavigator = this.GetService<ITaskNavigator>();

            var taskRowPointer = taskNavigator.GetAvailableTask(
                site);

            TaskRowPointer = taskRowPointer;
            Infobar = string.Empty;

            return 0;
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int ProcessImportTask(
            string site,
            string logicalFolder,
            string taskRowPointer,
            ref bool IsSuccess,
            ref string Infobar)
        {
            var importSiteTaskProcessor = this.GetService<IImportSiteTaskProcessor>();

            (IsSuccess, Infobar) = importSiteTaskProcessor.Process(
                site,
                logicalFolder,
                taskRowPointer);

            return IsSuccess ? 0 : 16;
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int ProcessExportTask(
            string site,
            int taskSize,
            string targetFileType,
            string logicalFolder,
            string taskRowPointer,
            ref string Infobar,
            ref bool IsSuccess)
        {
            var exportSiteTaskProcessor = this.GetService<IExportSiteTaskProcessor>();

            (IsSuccess, Infobar) = exportSiteTaskProcessor.Process(
                site,
                taskSize,
                targetFileType,
                logicalFolder,
                taskRowPointer);

            return IsSuccess ? 0 : 16;
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public void ExportHeaderInfo(
            string site,
            ref string export_logical_folder,
            ref string email,
            ref string file_type)
        {
            var iExportHeader = this.GetService<IExportHeaderInfo>();
            var result = iExportHeader.GetExportHeaderInfo(site);
            export_logical_folder = result.export_logical_folder;
            email = result.email;
            file_type = result.file_type;
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public void ImportHeaderInfo(
            string site,
            ref string import_logical_folder,
            ref string archive_logical_folder,
            ref int use_files_to_import,
            ref int display_row_data,
            ref string remote_server,
            ref string configuration,
            ref string user_name,
            ref string import_action,
            ref string email)
        {
            var iImportHeader = this.GetService<IImportHeaderInfo>();
            var result = iImportHeader.GetImportHeaderInfo(site);
            import_logical_folder = result.import_logical_folder;
            archive_logical_folder = result.archive_logical_folder;
            use_files_to_import = result.use_files_to_import;
            display_row_data = result.display_row_data;
            remote_server = result.remote_server;
            configuration = result.configuration;
            user_name = result.user_name;
            import_action = result.import_action;
            email = result.email;
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public void InsertExportHeaderInfo(
            string site,
            string export_logical_folder,
            string email,
            string file_type)
        {
            var iExportHeaderInfoCRUD = this.GetService<IExportHeaderInfoCRUD>();
            iExportHeaderInfoCRUD.InsertExportHeaderInfo(
                site,
                export_logical_folder,
                email,
                file_type);
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public void InsertImportHeaderInfo(
            string site,
            string import_logical_folder,
            string archive_logical_folder,
            int use_files_to_import,
            int display_row_data,
            string remote_server,
            string configuration,
            string user_name,
            string import_action,
            string email,
            string password)
        {
            var iImportHeaderInfoCRUD = this.GetService<IImportHeaderInfoCRUD>();
            iImportHeaderInfoCRUD.InsertImportHeaderInfo(
                site,
                import_logical_folder,
                archive_logical_folder,
                use_files_to_import,
                display_row_data,
                remote_server,
                configuration,
                user_name,
                import_action,
                email,
                password);
        }
    }
}