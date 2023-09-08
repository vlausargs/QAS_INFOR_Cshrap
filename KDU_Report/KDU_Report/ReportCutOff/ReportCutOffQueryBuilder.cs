using System;
using System.Collections.Generic;
using System.Text;
using KDU_Report;



namespace KDU_Report
{
    public class ReportCutOffQueryBuilder
    {

        string pSource;
        string pSite;
        DateTime? pEndingDate;
        int? pRemaining;
        DateTime? pStartingDate;
        public ReportCutOffQueryBuilder(string pSource,
            string pSite,
            DateTime? pEndingDate,
            int? pRemaining,
           DateTime? pStartingDate)
        {
            this.pSource = pSource;
            this.pSite = pSite;
            this.pEndingDate = pEndingDate;
            this.pRemaining = pRemaining;
            this.pStartingDate = pStartingDate;
        }

        public string query1()
        {
            return String.Format("SELECT x.*, " +
"(CASE WHEN x.type in ('C') AND  apply_to_inv_num  = '0' THEN  " +
"x.CN " +
"WHEN x.type in ('D') AND  apply_to_inv_num  = '0' THEN  " +
"x.invh_price " +
"WHEN x.type in ('P') AND  apply_to_inv_num  = '0' THEN  " +
"(x.payment) " +
"ELSE " +
"(x.invh_price+x.payment+x.CN+x.debit_memo )  " +
"END) as remaining , " +
" " +
"(CASE WHEN x.type in ('C') AND  apply_to_inv_num  = '0' THEN  " +
"x.CN " +
"ELSE " +
"(x.invh_price)  " +
"END)as total_invoice ,  " +
"1 as query " +
"FROM (SELECT  " +
"art.acct as account,  " +
"art.amount,  " +
"art.apply_to_inv_num,  " +
"art.co_num,  " +
"art.corp_cust as cust_id,  " +
"art.CreateDate,  " +
"art.CreatedBy,  " +
"art.curr_code,  " +
" " +
"(CASE WHEN art.type='P' THEN  " +
"    ((ISNULL(art.amount,0) + ISNULL(art.sales_tax,0))*-1)  " +
"WHEN art.type in ('D','C') THEN  0 " +
"ELSE  " +
"ISNULL( (select sum(ISNULL(a.amount,0) + ISNULL(a.sales_tax,0))*-1 from artran as a where a.apply_to_inv_num = art.inv_num and a.type = 'P' and ('{0}' is null or a.inv_date <= '{0}')  ) ,0)  " +
"END) as payment,  " +
" " +
"(CASE WHEN art.type in ('P','C','D')  THEN ((ISNULL(art.amount,0) + ISNULL(art.sales_tax,0)))  " +
"ELSE ISNULL( (select sum(ISNULL(a.amount,0) + ISNULL(a.sales_tax,0)) from artran as a where a.apply_to_inv_num = art.inv_num and a.type in ('P','C','D') and ('{0}' is null or a.inv_date <= '{0}') ) ,0) " +
"END) as all_payment,  " +
" " +
"(CASE WHEN art.type='D' THEN ((ISNULL(art.amount,0) + ISNULL(art.sales_tax,0)))  " +
"    WHEN art.type in ('P','C') THEN  0 " +
"ELSE " +
"ISNULL((SELECT SUM((ISNULL(x.amount,0) + ISNULL(x.sales_tax,0))) FROM artran as x  where x.apply_to_inv_num = art.apply_to_inv_num  and x.type='D' and ('{0}' is null or x.inv_date <= '{0}')),0)  " +
"END) as debit_memo,  " +
" " +
"ISNULL(invh.price,0) as invh_price,  " +
" " +
"(CASE WHEN art.type='C' THEN ((ISNULL(art.amount,0) + ISNULL(art.sales_tax,0))*-1)  " +
"    WHEN art.type in ('P','D') THEN  0 " +
"ELSE ISNULL( (select sum(ISNULL(a.amount,0) + ISNULL(a.sales_tax,0))*-1 from artran as a where a.apply_to_inv_num = art.inv_num and a.type = 'C' and ('{0}' is null or a.inv_date <= '{0}') ) ,0)  " +
"END) as CN,  " +
" " +
"art.description,  " +
"art.due_date,  " +
"art.inv_date,  " +
"art.Uf_ClearingDate,  " +
"art.cust_num,  " +
"cadr.name as cust_name,  " +
"invh.slsman as invh_slsman,  " +
"art.shipment_id as ship_num,  " +
"art.sales_tax as ppn, " +
"art.inv_num,  " +
"art.type, " +
"art.inv_seq " +
"FROM artran as art " +
"LEFT JOIN inv_hdr as invh on [invh].[inv_num] = [art].[inv_num] AND [invh].[inv_seq] = [art].[inv_seq]  " +
"LEFT JOIN custaddr as cadr on cadr.[cust_num] = art.[cust_num] AND cadr.[cust_seq] = 0 " +
"WHERE ((art.type='I' and ('{0}' IS NULL or art.Uf_ClearingDate IS NULL or  art.Uf_ClearingDate > '{0}' )) or (art.type='C' and art.apply_to_inv_num = '0' ) or (art.type='D' and art.apply_to_inv_num = '0' and art.inv_seq = '0') or (art.type='P' and art.apply_to_inv_num = '0') or (art.type='P' and art.apply_to_inv_num = '0' and art.inv_num ='0')) and  " +
"('{0}' IS NULL OR art.inv_date <='{0}') " +
" " +
") x " , this.pEndingDate);
        }
        public string query2()
        {
            return String.Format("SELECT x.*," +
            "(x.payment+x.CN+x.debit_memo) as remaining ," +
            "(0) as total_invoice, -- 25" +
            "2 as query" +
            "FROM (SELECT " +
            "    art.acct as account," +
            "    0 as amount," +
            "    -- art.amount," +
            "    art.apply_to_inv_num," +
            "    art.co_num," +
            "    art.corp_cust as cust_id," +
            "    art.CreateDate," +
            "    art.CreatedBy," +
            "    art.curr_code," +
            "" +
            "    ( ISNULL( (select sum(ISNULL(a.amount,0) + ISNULL(a.sales_tax,0))*-1 from artran as a where a.apply_to_inv_num = art.inv_num and a.type = 'P' and ({0} is null or a.inv_date <= {0})  ) ,0) " +
            "    ) as payment," +
            "" +
            "    ( ISNULL( (select sum(ISNULL(a.amount,0) + ISNULL(a.sales_tax,0)) from artran as a where a.apply_to_inv_num = art.inv_num and a.type in ('P','C','D') and ({0} is null or a.inv_date <= {0}) ) ,0)" +
            "    ) as all_payment," +
            "" +
            "    (" +
            "    ISNULL((SELECT SUM((ISNULL(x.amount,0) + ISNULL(x.sales_tax,0))) FROM artran as x  where x.apply_to_inv_num = art.apply_to_inv_num  and x.type='D' and ({0} is null or x.inv_date <= {0})),0) " +
            "    ) as debit_memo," +
            "    0 as invh_price," +
            "    -- ISNULL(invh.price,0) as invh_price," +
            "" +
            "    (ISNULL( (select sum(ISNULL(a.amount,0) + ISNULL(a.sales_tax,0))*-1 from artran as a where a.apply_to_inv_num = art.inv_num and a.type = 'C' and ({0} is null or a.inv_date <= {0}) ) ,0) " +
            "    ) as CN," +
            "" +
            "    art.description," +
            "    art.due_date," +
            "    art.inv_date," +
            "    art.Uf_ClearingDate," +
            "    art.cust_num," +
            "    cadr.name as cust_name," +
            "    invh.slsman as invh_slsman," +
            "    art.shipment_id as ship_num," +
            "    0 as ppn," +
            "    -- art.sales_tax as ppn," +
            "    art.inv_num," +
            "    art.type," +
            "    art.inv_seq" +
            "    FROM artran as art" +
            "    -- INNER JOIN #temp_cutoff as tmp on tmp.type = 'I' and art.type='I' and art.inv_num != tmp.inv_num " +
            "    INNER JOIN artran as art2 on (art2.type='P' and ({0} IS NULL or art2.inv_date >{0}) ) and art.inv_num = art2.apply_to_inv_num" +
            "    LEFT JOIN inv_hdr as invh on [invh].[inv_num] = [art].[inv_num] AND [invh].[inv_seq] = [art].[inv_seq] " +
            "    LEFT JOIN custaddr as cadr on cadr.[cust_num] = art.[cust_num] AND cadr.[cust_seq] = 0" +
            "    WHERE (art.type='I' and ({0} IS NULL or art.Uf_ClearingDate IS NULL or  art.Uf_ClearingDate > {0} )) and ({0} is NOT null AND art.inv_date > {0} )" +
            "" +
            "    ) x ", this.pEndingDate);
        }
        public string query3()
        {
            return String.Format("SELECT x.*," +
                "(x.payment+x.CN+x.debit_memo) as remaining ," +
                "(0) as total_invoice, -- 25" +
                "3 as query" +
                "FROM (SELECT " +
                "    art2.acct as account," +
                "    0 as amount," +
                "    -- art.amount," +
                "    art2.apply_to_inv_num," +
                "    art2.co_num," +
                "    art2.corp_cust as cust_id," +
                "    art2.CreateDate," +
                "    art2.CreatedBy," +
                "    art2.curr_code," +
                "" +
                "    ( ISNULL( (select sum(ISNULL(a.amount,0) + ISNULL(a.sales_tax,0))*-1 from artran as a where a.apply_to_inv_num = art.inv_num and a.type = 'P' and ({0} is null or a.inv_date <= {0})  ) ,0) " +
                "    ) as payment," +
                "" +
                "    ( ISNULL( (select sum(ISNULL(a.amount,0) + ISNULL(a.sales_tax,0)) from artran as a where a.apply_to_inv_num = art.inv_num and a.type in ('P','C','D') and ({0} is null or a.inv_date <= {0}) ) ,0)" +
                "    ) as all_payment," +
                "" +
                "    (" +
                "    ISNULL((SELECT SUM((ISNULL(x.amount,0) + ISNULL(x.sales_tax,0))) FROM artran as x  where x.apply_to_inv_num = art.apply_to_inv_num  and x.type='D' and ({0} is null or x.inv_date <= {0})),0) " +
                "    ) as debit_memo," +
                "    0 as invh_price," +
                "    -- ISNULL(invh.price,0) as invh_price," +
                "" +
                "    (ISNULL( ((ISNULL(art2.amount,0) + ISNULL(art2.sales_tax,0))*-1) ,0) " +
                "    ) as CN," +
                "" +
                "    art2.description," +
                "    art2.due_date," +
                "    art2.inv_date," +
                "    art.Uf_ClearingDate," +
                "    art2.cust_num," +
                "    cadr.name as cust_name," +
                "    invh.slsman as invh_slsman," +
                "    art2.shipment_id as ship_num," +
                "    0 as ppn," +
                "    -- art.sales_tax as ppn," +
                "    art2.inv_num," +
                "    art2.type," +
                "    art2.inv_seq" +
                "    FROM artran as art" +
                "    -- INNER JOIN #temp_cutoff as tmp on tmp.type = 'I' and art.type='I' and art.inv_num != tmp.inv_num " +
                "    INNER JOIN artran as art2 on (art2.type='C'  and ({0} IS NULL or  art2.inv_date < {0} )  ) and art.inv_num = art2.apply_to_inv_num" +
                "    LEFT JOIN inv_hdr as invh on [invh].[inv_num] = [art].[inv_num] AND [invh].[inv_seq] = [art].[inv_seq] " +
                "    LEFT JOIN custaddr as cadr on cadr.[cust_num] = art.[cust_num] AND cadr.[cust_seq] = 0" +
                "    WHERE (art.type='I' and ({0} IS NULL or art.Uf_ClearingDate IS NULL or  art.Uf_ClearingDate > {0} )) and ({0} is NOT null AND art.inv_date <= {0} )" +
                "" +
                "    ) x  ", this.pEndingDate);
        }
        public string query4()
        {
            return String.Format("SELECT x.*," +
                "(x.payment+x.CN+x.debit_memo) as remaining ," +
                "(0) as total_invoice, -- 25" +
                "4 as query" +
                "FROM (SELECT " +
                "    art2.acct as account," +
                "    0 as amount," +
                "    -- art.amount," +
                "    art2.apply_to_inv_num," +
                "    art2.co_num," +
                "    art2.corp_cust as cust_id," +
                "    art2.CreateDate," +
                "    art2.CreatedBy," +
                "    art2.curr_code," +
                "" +
                "    ( ISNULL( (select sum(ISNULL(a.amount,0) + ISNULL(a.sales_tax,0))*-1 from artran as a where a.apply_to_inv_num = art.inv_num and a.type = 'P' and ({0} is null or a.inv_date <= {0})  ) ,0) " +
                "    ) as payment," +
                "" +
                "    ( ISNULL( (select sum(ISNULL(a.amount,0) + ISNULL(a.sales_tax,0)) from artran as a where a.apply_to_inv_num = art.inv_num and a.type in ('P','C','D') and ({0} is null or a.inv_date <= {0}) ) ,0)" +
                "    ) as all_payment," +
                "" +
                "    (" +
                "    ISNULL((SELECT SUM((ISNULL(x.amount,0) + ISNULL(x.sales_tax,0))) FROM artran as x  where x.apply_to_inv_num = art.apply_to_inv_num  and x.type='D' and ({0} is null or x.inv_date <= {0})),0) " +
                "    ) as debit_memo," +
                "    0 as invh_price," +
                "    -- ISNULL(invh.price,0) as invh_price," +
                "" +
                "    (ISNULL( ((ISNULL(art2.amount,0) + ISNULL(art2.sales_tax,0))*-1) ,0) " +
                "    ) as CN," +
                "" +
                "    art2.description," +
                "    art2.due_date," +
                "    art2.inv_date," +
                "    art.Uf_ClearingDate," +
                "    art2.cust_num," +
                "    cadr.name as cust_name," +
                "    invh.slsman as invh_slsman," +
                "    art2.shipment_id as ship_num," +
                "    0 as ppn," +
                "    -- art.sales_tax as ppn," +
                "    art2.inv_num," +
                "    art2.type," +
                "    art2.inv_seq" +
                "    FROM artran as art" +
                "    -- INNER JOIN #temp_cutoff as tmp on tmp.type = 'I' and art.type='I' and art.inv_num != tmp.inv_num " +
                "    INNER JOIN artran as art2 on (art2.type IN ('C','P')  and ({0} IS NULL or art2.Uf_ClearingDate IS NULL or  art2.Uf_ClearingDate > {0} ) and ({0} IS NULL or  art2.inv_date < {0} ) ) and art.inv_num = art2.apply_to_inv_num" +
                "    LEFT JOIN inv_hdr as invh on [invh].[inv_num] = [art].[inv_num] AND [invh].[inv_seq] = [art].[inv_seq] " +
                "    LEFT JOIN custaddr as cadr on cadr.[cust_num] = art.[cust_num] AND cadr.[cust_seq] = 0" +
                "    WHERE (art.type='I' and  ({0} is NOT null AND art.inv_date > {0} ))" +
                "" +
                "    ) x  ", this.pEndingDate);
        }


    }
}
