using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSI.CRUD.Production.APS
{
    public class CLM_ApsGetShortagesCRUD : ICLM_ApsGetShortagesCRUD
    {
        readonly ISQLCollectionLoad sQLCollectionLoad;
        readonly IStringUtil stringUtil;

        public CLM_ApsGetShortagesCRUD(ISQLCollectionLoad sQLCollectionLoad, IStringUtil stringUtil)
        {
            this.sQLCollectionLoad = sQLCollectionLoad ?? throw new ArgumentNullException(nameof(sQLCollectionLoad));
            this.stringUtil = stringUtil ?? throw new ArgumentNullException(nameof(stringUtil));
        }

        (int? Severity, ICollectionLoadResponse Data) ICLM_ApsGetShortagesCRUD.LoadShortageExtraData(string DemandType, string DemandRef, string Item, string PlannerCode, DateTime? StartDate, DateTime? DueDate, string ProductCode, string ORDER, string MATLPLAN, string MATL, string ORDPLAN, int? DemandRefNumber)
        {
            string SQLStr = stringUtil.Concat(@"
               SELECT
                  dem.DemandType,
                  dem.DemandRef,
                  dem.DemandId,
                  mp.MATLTAG as Matltag,
                  CASE WHEN ISNULL(@DT, '') <> 'PLN' THEN o.MATERIALID ELSE plnmp.materialid END AS Item,
                  CASE WHEN ISNULL(@DT, '') <> 'PLN' THEN matl.DESCR ELSE plnmatl.DESCR END AS ItemDescr,
                  CASE WHEN ISNULL(@DT, '') <> 'PLN' THEN matl.LOWLEVEL ELSE plnmatl.LOWLEVEL END AS LowLevel,
                  CASE WHEN ISNULL(@DT, '') <> 'PLN' THEN item.plan_code ELSE plnitem.plan_code END AS PlannerCode,
                  CASE WHEN ISNULL(@DT, '') <> 'PLN' THEN item.product_code ELSE plnitem.product_code END AS ProductCode,
                  CASE WHEN ISNULL(@DT, '') <> 'PLN' THEN mp.ADJQTY ELSE plnmp.adjqty END AS Quantity,
                  CASE WHEN o.OrderTable = 'job' THEN CAST(o.RELDATE as date) ELSE CAST(mp.STARTDATE as date) END,
                  CASE WHEN ISNULL(@DT, '') <> 'PLN' THEN CAST(op.DUEDATE as date) ELSE CAST(plnmp.enddate as date) END AS DueDate,
                  CASE WHEN (op.DUEDATE <= '19700101') OR (op.CALCDATE <= '19700101') THEN
                     null
                  ELSE
                     CONVERT(float, DATEDIFF(hh, op.DUEDATE, op.CALCDATE)) / CONVERT(float, 24)
                  END as DaysLate,
                  o.RowPointer
               FROM
                  #Demands dem
                  JOIN ", MATLPLAN, @" mp ON mp.MATLTAG = dem.DemandTag
                  JOIN ", ORDER, @" o ON o.ORDERID = mp.ORDERID
                  JOIN ", ORDPLAN, @" op ON op.ORDERID = o.ORDERID
                  LEFT JOIN item (nolock) ON item.item = o.MATERIALID
                  LEFT JOIN ", MATL, @" matl ON matl.materialid = o.MATERIALID
                  LEFT JOIN ", MATLPLAN, @" plnmp ON plnmp.matltag = dem.DemandTag
                  LEFT JOIN ", MATL, @" plnmatl ON plnmatl.materialid = plnmp.materialid
                  LEFT JOIN item plnitem (nolock) ON plnitem.item = plnmp.materialid
               ");
            string ParmList = @"@IT ItemType, @PC UserCodeType, @SD DateType, @DD DateType, @DR OrderRefStrType, @ProductCode ProductCodeType, @DT RefType, @DRN int";

            return sQLCollectionLoad.ExecuteDynamicQuery(SQLStr
                    , ParmList
                    , Item
                    , PlannerCode
                    , StartDate
                    , DueDate
                    , DemandRef
                    , ProductCode
                    , DemandType
                    , DemandRefNumber);
        }
    }
}
