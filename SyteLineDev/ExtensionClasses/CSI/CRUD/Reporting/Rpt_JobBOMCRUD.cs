using System;
using System.Data;
using CSI.MG;
using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;
using System.Collections.Generic;
using CSI.Data.RecordSets;
using CSI.Data.Functions;

namespace CSI.CRUD.Reporting
{
    public class Rpt_JobBOMCRUD: IRpt_JobBOMCRUD
    {
        readonly IApplicationDB appDB;
        readonly ICollectionLoadRequestFactory collectionLoadRequestFactory;
        readonly IVariableUtil variableUtil;

        public Rpt_JobBOMCRUD(IApplicationDB appDB, ICollectionLoadRequestFactory collectionLoadRequestFactory, IVariableUtil variableUtil)
        {
            this.appDB = appDB;
            this.collectionLoadRequestFactory = collectionLoadRequestFactory;
            this.variableUtil = variableUtil;
        }

        public ICollectionLoadResponse LoadCollection(int? MOAddonAvailable)
        {
            var tv_tempOutputLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                {
                    {"col0lev","lev"},
                    {"col1item","item"},
                    {"col2job","job"},
                    {"col3jobtype","jobtype"},
                    {"col4qty_rel","qty_rel"},
                    {"col5qty_per","qty_per"},
                    {"col6u_m","u_m"},
                    {"col7type","type"},
                    {"col8ref","ref"},
                    {"col9oper","oper"},
                    {"col10sequence","sequence"},
                    {"col11BOM_seq","BOM_seq"},
                    {"col12backflush","backflush"},
                    {"col13revision","revision"},
                    {"col14description","description"},
                    {"col15unit_cost","unit_cost"},
                    {"col16ref_des","ref_des"},
                    {"col17bubble","bubble"},
                    {"col18assy_seq","assy_seq"},
                    {"col19alternate","alternate"},
                    {"col20qty_unit_format","qty_unit_format"},
                    {"col21places_qty_unit","places_qty_unit"},
                    {"col22qty_per_format","qty_per_format"},
                    {"col23places_qty_per","places_qty_per"},
                    {"col24cst_prc_format","cst_prc_format"},
                    {"col25places_cp","places_cp"},
                    {"col26co_job","co_job"},
                    {"col27co_prod","co_prod"},
                    {"col28co_prod_qty_released","co_prod_qty_released"},
                    {"col29co_job_item","co_job_item"},
                    {"col30co_job_qty_received","co_job_qty_received"},
                    {"col31co_job_qty_complete","co_job_qty_complete"},
                    {"col32co_job_qty_scrapped","co_job_qty_scrapped"},
                    {"col33suffix","suffix"},
                    {"col34job_id","job_id"},
                    {"col35oper_num_for_link","oper_num_for_link"},
                    {"MOAddonAvailable",$"{variableUtil.GetValue<int?>(MOAddonAvailable)}"},
                    {"UbVisible","0"},
                    {"UbFlag","0"},
                },
                loadForChange: false,
                lockingType: LockingType.None,
                tableName: "#tv_tempOutput",
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause(""),
                orderByClause: collectionLoadRequestFactory.Clause(""));
            var tv_tempOutputLoadResponse = this.appDB.Load(tv_tempOutputLoadRequest);
            return tv_tempOutputLoadResponse;
        }
    }
}
