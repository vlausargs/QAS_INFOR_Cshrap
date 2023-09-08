using System;
using CSI.Data.SQL;

namespace CSI.Reporting
{
    public interface IRpt_JobTransactionsBuildClause
    {
        IParameterizedCommand GetWhereClause(string TransactionType, string PayType, string Posted, string EmployeeStarting, string EmployeeEnding, string JobStarting, string JobEnding, int? SuffixStarting, int? SuffixEnding, DateTime? TransactionDateStarting, DateTime? TransactionDateEnding, decimal? TransactionNumberStarting, decimal? TransactionNumberEnding, string ShiftStarting, string ShiftEnding, string ReasonStarting, string ReasonEnding, string UserInitialStarting, string UserInitialEnding, string ResourceStarting, string ResourceEnding, string SortByTEJ, int? t_backflush);
    }
}
