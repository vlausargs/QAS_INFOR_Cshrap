using CSI.Data.CRUD;
using CSI.Data.SQL;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSI.CRUD.Production.APS
{
    public class CLM_ApsGetSupplyUsageCRUD : ICLM_ApsGetSupplyUsageCRUD
    {
        readonly ISQLCollectionLoad sQLCollectionLoad;
        readonly ISQLExpressionExecutor sQLExpressionExecutor;

        public CLM_ApsGetSupplyUsageCRUD(ISQLCollectionLoad sQLCollectionLoad, ISQLExpressionExecutor sQLExpressionExecutor)
        {
            this.sQLCollectionLoad = sQLCollectionLoad ?? throw new ArgumentNullException(nameof(sQLCollectionLoad));
            this.sQLExpressionExecutor = sQLExpressionExecutor ?? throw new ArgumentNullException(nameof(sQLExpressionExecutor));
        }

        (int? Severity, ICollectionLoadResponse Data) ICLM_ApsGetSupplyUsageCRUD.LoadTempSupplyUsage(string SupplyID, int? SupplyMatltag, Guid? SupplyRowPtr, string Item, DateTime? DueDate, string SQLStr)
        {
            return sQLCollectionLoad.ExecuteDynamicQuery(SQLStr
            , "@pItem ItemType,                               @pSupplyID OrderRefStrType,                               @pDueDate DateType,                               @pSupplyRowPtr RowPointerType,                               @pSupplyMatltag int"
            , Item
            , SupplyID
            , DueDate
            , SupplyRowPtr
            , SupplyMatltag);
        }

        void ICLM_ApsGetSupplyUsageCRUD.CreateTempSupplyUsageTable()
        {
            this.sQLExpressionExecutor.Execute(@"CREATE TABLE #tempdbl (
                        SupplyType        NVARCHAR (14)    COLLATE DATABASE_DEFAULT,
                        SupplyID          NVARCHAR (65)    COLLATE DATABASE_DEFAULT,
                        SupplyMatltag     INT             ,
                        Item              NVARCHAR (30)    COLLATE DATABASE_DEFAULT,
                        SupplyQuantity    FLOAT           ,
                        DueDate           DATETIME        ,
                        ApsSupplyID       NVARCHAR (63)    COLLATE DATABASE_DEFAULT,
                        RowPointer        UNIQUEIDENTIFIER,
                        IsConsolidatedPLN TINYINT
                    )");
        }
    }
}
