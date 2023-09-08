using CSI.Data.CRUD;
using CSI.Data.SQL;
using System;

namespace CSI.Reporting
{
    public class Rpt_JobTransactionsBuildClause : IRpt_JobTransactionsBuildClause
    {
        readonly ICollectionLoadRequestFactory collectionLoadRequestFactory;

        public Rpt_JobTransactionsBuildClause(ICollectionLoadRequestFactory collectionLoadRequestFactory)
        {
            this.collectionLoadRequestFactory = collectionLoadRequestFactory;
        }

        public IParameterizedCommand GetWhereClause(string TransactionType, string PayType, string Posted, string EmployeeStarting, string EmployeeEnding, string JobStarting, string JobEnding, int? SuffixStarting, int? SuffixEnding, DateTime? TransactionDateStarting, DateTime? TransactionDateEnding, decimal? TransactionNumberStarting, decimal? TransactionNumberEnding, string ShiftStarting, string ShiftEnding, string ReasonStarting, string ReasonEnding, string UserInitialStarting, string UserInitialEnding, string ResourceStarting, string ResourceEnding, string SortByTEJ, int? t_backflush)
        {
            return collectionLoadRequestFactory.Clause("jt.trans_class = 'J' AND ([jt].[job] >= {16} OR {16} IS NULL) AND ([jt].[job] <= {19} OR {19} IS NULL) AND ((ISNULL(jt.suffix, 0) >= CASE WHEN jt.job = {16} THEN {9} ELSE 0 END) OR {16} IS NULL) AND ((ISNULL(jt.suffix, 0) <= CASE WHEN jt.job = {19} THEN {14} ELSE 10000 END) OR {19} IS NULL) AND ([jt].[trans_num] >= {0} OR {0} IS NULL) AND ([jt].[trans_num] <= {1} OR {1} IS NULL) AND ([jt].[trans_date] >= {2} OR {2} IS NULL) AND ([jt].[trans_date] <= {3} OR {3} IS NULL) AND ([jt].[emp_num] >= {6} OR {6} IS NULL) AND ([jt].[emp_num] <= {10} OR {10} IS NULL) AND CHARINDEX(jt.trans_type, {8}) <> 0 AND (jt.backflush = {17} OR {17} IS NULL) AND (CHARINDEX(jt.pay_rate, {21}) <> 0 OR CHARINDEX(jt.trans_type, 'QMCEU') <> 0) AND ([jt].[shift] >= {13} OR {13} IS NULL) AND ([jt].[shift] <= {18} OR {18} IS NULL) AND ([jt].[reason_code] >= {11} OR {11} IS NULL) AND ([jt].[reason_code] <= {15} OR {15} IS NULL) AND ([jt].[user_code] >= {4} OR {4} IS NULL) AND ([jt].[user_code] <= {5} OR {5} IS NULL) AND ([jt].[RESID] >= {7} OR {7} IS NULL) AND ([jt].[RESID] <= {12} OR {12} IS NULL) AND ({22} = 'Y' AND jt.posted = 1 OR {22} = 'N' AND jt.posted = 0 OR {22} <> 'Y' AND {22} <> 'N') AND ((jt.emp_num IS NULL OR emp.RowPointer IS NOT NULL) OR {20} = 'E')",
                                TransactionNumberStarting, TransactionNumberEnding, TransactionDateStarting, TransactionDateEnding, UserInitialStarting, UserInitialEnding, EmployeeStarting, ResourceStarting, TransactionType, SuffixStarting, EmployeeEnding, ReasonStarting, ResourceEnding, ShiftStarting, SuffixEnding, ReasonEnding, JobStarting, t_backflush, ShiftEnding, JobEnding, SortByTEJ, PayType, Posted);
        }
    }
}
