//PROJECT NAME: ProductExt
//CLASS NAME: SLBomBulkImportMappings.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Production;
using CSI.MG;
using System.Runtime.InteropServices;

namespace CSI.MG.Product
{
    [IDOExtensionClass("SLBomBulkImportMappings")]
    public class SLBomBulkImportMappings : ExtensionClassBase
    {
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int BOMBulkImport_ExcludeListSp(string TableName,
                                               ref string ExcludeList)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iBOMBulkImport_ExcludeListExt = new BOMBulkImport_ExcludeListFactory().Create(appDb);

                InfobarType oExcludeList = ExcludeList;

                int Severity = iBOMBulkImport_ExcludeListExt.BOMBulkImport_ExcludeListSp(TableName,
                                                                                         ref oExcludeList);

                ExcludeList = oExcludeList;


                return Severity;
            }
        }
    }
}
