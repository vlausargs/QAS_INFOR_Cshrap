using CSI.Data.Functions;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSI.Data.SQL
{
    public class TransactionFactory : ITransactionFactory
    {
        ISQLExpressionExecutor sQLExpressionExecutor;

        public TransactionFactory(ISQLExpressionExecutor sQLExpressionExecutor)
        {
            this.sQLExpressionExecutor = sQLExpressionExecutor;
        }

        public void BeginTransaction(string transactionName = null)
        {
            this.sQLExpressionExecutor.Execute($"BEGIN TRANSACTION {transactionName}");
        }

        public void CommitTransaction(string transactionName = null)
        {
            this.sQLExpressionExecutor.Execute($"COMMIT TRANSACTION {transactionName}");
        }

        public void RollbackTransaction(string transactionName = null)
        {
            this.sQLExpressionExecutor.Execute($"ROLLBACK TRANSACTION {transactionName}");
        }

        public void SaveTransaction(string transactionName = null)
        {
            this.sQLExpressionExecutor.Execute($"SAVE TRANSACTION {transactionName}");
        }

        public void SetIsolationLevel(string isolationLevel)
        {
            //this.sQLExpressionExecutor.Execute($"SET TRANSACTION ISOLATION LEVEL {isolationLevel}");
            this.sQLExpressionExecutor.Execute($"{isolationLevel}");
        }
    }
}
