using System.Transactions;

namespace CSI.Data.SQL
{
    public interface ITransactionScopeBuilder
    {
        TransactionScope Scope { get; }
        IsolationLevel Level { get;}
        void CommitTransaction();
        void RollbackTransaction();
        TransactionScope CreateTransactionScope();
    }
}
