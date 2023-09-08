using System;
using System.Collections.Generic;
using System.Text;

namespace CSI.Data.SQL
{
    public interface ITransactionFactory
    {
        void BeginTransaction(string transactionName = null);

        void CommitTransaction(string transactionName = null);

        void RollbackTransaction(string transactionName = null);

        void SaveTransaction(string transactionName = null);

        void SetIsolationLevel(string isolationLevel);
    }
}
