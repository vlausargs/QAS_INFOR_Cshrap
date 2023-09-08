using System.Transactions;

namespace CSI.Data.SQL
{
    public class TransactionScopeBuilder : ITransactionScopeBuilder
    {

        public TransactionScope Scope { get; private set; }

        public IsolationLevel Level { get; private set; }

        public void CommitTransaction() => Scope.Complete();

        public void RollbackTransaction() => Scope.Dispose();

        public TransactionScopeBuilder(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted)
        {
            // Serializable is the default Isolation level for TransactionScope
            // However, ReadCommitted  is the default SQL isolation Level, so we use this instead
            // https://docs.microsoft.com/en-us/previous-versions/sql/sql-server-2008-r2/ms175909(v=sql.105)?redirectedfrom=MSDN

            this.Level = isolationLevel;
        }

        public TransactionScope CreateTransactionScope()
        {
            var options = new TransactionOptions
            {
                IsolationLevel = Level,
                Timeout = TransactionManager.DefaultTimeout    // TODO: get MG default
            };

            Scope = new TransactionScope(TransactionScopeOption.Required, options);

            return Scope;

        }

        //TransactionScopeBuilder(TransactionScopeOption scopeOption)
        //{
        //    Scope = new TransactionScope(scopeOption);
        //}

        //TransactionScopeBuilder(TransactionScopeOption scopeOption, TransactionOptions transactionOptions)
        //{
        //    Scope = new TransactionScope(scopeOption, transactionOptions);
        //}

        /// <summary>
        /// Creates a transactionscope with ReadCommitted Isolation, the same level as sql server
        /// </summary>
        /// <returns>A transaction scope</returns>
        //public static ITransactionScopeBuilder CreateReadCommitted()
        //{
        //    var options = new TransactionOptions
        //    {
        //        IsolationLevel = IsolationLevel.ReadCommitted,
        //        Timeout = TransactionManager.DefaultTimeout
        //    };

        //    return new TransactionScopeBuilder(TransactionScopeOption.Required, options);
        //}

        /// <summary>
        /// Creates a transactionscope with ReadUnCommitted Isolation, the same level as sql server
        /// </summary>
        /// <returns>A transaction scope</returns>
        //public static ITransactionScopeBuilder CreateReadUnCommitted()
        //{
        //    var options = new TransactionOptions
        //    {
        //        IsolationLevel = IsolationLevel.ReadUncommitted,
        //        Timeout = TransactionManager.DefaultTimeout
        //    };

        //    return new TransactionScopeBuilder(TransactionScopeOption.Required, options);
        //}

        /// <summary>
        /// Creates a transactionscope with default implementation (Isolation Level = Serializable)
        /// </summary>
        /// <returns>A transaction scope</returns>
        //public static ITransactionScopeBuilder CreateDefault()
        //{
        //    return new TransactionScopeBuilder();
        //}

        /// <summary>
        /// Creates a non-transactional scope that can be used within a transactionscope
        /// </summary>
        /// <returns>A transaction scope</returns>
        //public static ITransactionScopeBuilder CreateNonTransactionalScope()
        //{
        //    return new TransactionScopeBuilder(TransactionScopeOption.Suppress);
        //}

        public void SetIsolationLevelReadCommitted()
        {
            this.Level = IsolationLevel.ReadCommitted;
        }
        public void SetIsolationLevelReadUnCommitted()
        {
            this.Level = IsolationLevel.ReadUncommitted;
        }
    }
}
