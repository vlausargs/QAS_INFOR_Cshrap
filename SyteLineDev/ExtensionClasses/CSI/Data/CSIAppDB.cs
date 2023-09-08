using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL;
using CSI.Data.SQL.UDDT;
using CSI.MG;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace CSI.Data
{
    public class CSIAppDB : IApplicationDB
    {
        ICommandExecutor commandExecutor;
        IMessageProvider messageProvider;
        ICollectionLoad sqlLoadCollection;
        ICollectionLoadBuilder sqlLoadCollectionBuild;
        ICollectionLoadStatement sqlLoadStatementCollection;
        ICollectionInsert sqlInsertCollection;
        ICollectionUpdate sqlUpdateCollection;
        ICollectionDelete sqlDeleteCollection;
        ICommandProvider commandProvider;
        ICommandParameters commandParameters;
        ILiteralProvider literalProvider;
        IParameterProvider parameterProvider;
        ISQLCollectionNonTriggerUpdate sqlCollectionNonTriggerUpdate;
        ISQLCollectionNonTriggerDelete sqlCollectionNonTriggerDelete;
        ISQLCollectionNonTriggerInsert sqlCollectionNonTriggerInsert;

        public CSIAppDB(
            ICommandExecutor commandExecutor,
            IMessageProvider messageProvider,
            ICollectionLoad sqlCollectionLoader,
            ICollectionLoadBuilder sqlLoadCollectionBuildLoader,
            ICollectionLoadStatement sqlLoadStatementCollectionloader,
            ICollectionInsert sqlInsertCollection,
            ICollectionUpdate sqlUpdateCollection,
            ICollectionDelete sqlDeleteCollection,
            ICommandProvider commandProvider,
            ICommandParameters commandParameters,
            ILiteralProvider literalProvider,
            IParameterProvider parameterProvider,
            ISQLCollectionNonTriggerUpdate sqlCollectionNonTriggerUpdate,
            ISQLCollectionNonTriggerDelete sqlCollectionNonTriggerDelete,
            ISQLCollectionNonTriggerInsert sqlCollectionNonTriggerInsert)
        {
            this.commandExecutor = commandExecutor;
            this.messageProvider = messageProvider;
            this.sqlLoadCollection = sqlCollectionLoader;
            this.sqlLoadCollectionBuild = sqlLoadCollectionBuildLoader;
            this.sqlLoadStatementCollection = sqlLoadStatementCollectionloader;
            this.sqlInsertCollection = sqlInsertCollection;
            this.sqlUpdateCollection = sqlUpdateCollection;
            this.sqlDeleteCollection = sqlDeleteCollection;
            this.commandProvider = commandProvider;
            this.commandParameters = commandParameters;
            this.literalProvider = literalProvider;
            this.parameterProvider = parameterProvider;
            this.sqlCollectionNonTriggerUpdate = sqlCollectionNonTriggerUpdate;
            this.sqlCollectionNonTriggerDelete = sqlCollectionNonTriggerDelete;
            this.sqlCollectionNonTriggerInsert = sqlCollectionNonTriggerInsert;
        }

        public IDataParameter CreateParameter(string parameterName, object value)
        {
            return parameterProvider.CreateParameter(parameterName, value);
        }

        public IDbDataParameter AddCommandParameter(IDbCommand cmd, string parameterName, IUDDTType csiData, ParameterDirection direction = ParameterDirection.Input)
        {
            return commandParameters.AddCommandParameterWithValue(cmd, parameterName, csiData, direction);
        }

        public IDbCommand CreateCommand()
        {
            this.commandParameters.ClearOutputParameters();
            return this.commandProvider.CreateCommand();
        }

        public IDataReader ExecuteReader(IDbCommand cmd)
        {
            return this.commandExecutor.ExecuteReader(cmd);
        }

        public DataTable ExecuteQuery(IDbCommand cmd)
        {
            DataTable dt = new DataTable();
            using (IDataReader reader = this.ExecuteReader(cmd))
            {
                dt.Load(reader);
            }
            this.commandParameters.GetOutputParameters(cmd);
            return dt;
        }

        public int ExecuteNonQuery(IDbCommand cmd)
        {
            IntType returnVal = 0;
            IDbDataParameter dbParm = commandParameters.AddCommandParameterWithValue(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
            dbParm.DbType = DbType.Int32;

            this.commandExecutor.ExecuteNonQuery(cmd);

            return GetParameterValue((IDbDataParameter)cmd.Parameters["@ReturnVal"]);
        }

        public dynamic GetParameterValue(IDbDataParameter parm)
        {
            return commandParameters.GetParameterValue(parm);
        }

        public ICollectionLoadResponse Load(ICollectionLoadRequest loadRequest)
        {
            return sqlLoadCollection.Load(loadRequest);
        }

        public ICollectionLoadResponse Load(ICollectionLoadBuilderRequest loadRequest)
        {
            return sqlLoadCollectionBuild.Load(loadRequest);
        }

        public ICollectionLoadResponse Load(ICollectionLoadStatementRequest loadRequest)
        {
            return sqlLoadStatementCollection.Load(loadRequest);
        }

        public void Insert(ICollectionInsertRequest insertRequest)
        {
            sqlInsertCollection.Insert(insertRequest);
        }

        public void Update(ICollectionUpdateRequest updateRequest)
        {
            sqlUpdateCollection.Update(updateRequest);
        }

        public void UpdateWithoutTrigger(ICollectionNonTriggerUpdateRequest updateRequest)
        {
            sqlCollectionNonTriggerUpdate.UpdateWithoutTrigger(updateRequest);
        }

        public void Delete(ICollectionDeleteRequest deleteRequest)
        {
            sqlDeleteCollection.Delete(deleteRequest);
        }

        public void DeleteWithoutTrigger(ICollectionNonTriggerDeleteRequest deleteRequest)
        {
            sqlCollectionNonTriggerDelete.DeleteWithoutTrigger(deleteRequest);
        }

        public void InsertWithoutTrigger(ICollectionNonTriggerInsertRequest insertRequest)
        {
            sqlCollectionNonTriggerInsert.InsertWithoutTrigger(insertRequest);
        }

        public string FormatLiteral(object value)
        {
            return literalProvider.FormatLiteral(value);
        }

        public string GetMessage(string messageId)
        {
            return messageProvider.GetMessage(messageId);
        }

        public string GetMessage(string messageId, params object[] args)
        {

            return messageProvider.GetMessage(messageId, args);
        }

        public T ExecuteScalar<T>(IDbCommand cmd)
        {
            return this.commandExecutor.ExecuteScalar<T>(cmd);
        }

        public Exception GetDbException(Exception ex)
        {
            DbException dbException;
            if(ex is DbException dbExp)
            {
                dbException = dbExp;
            }
            else if (ex is SqlException sqlException)
            {
                dbException = new DbException(sqlException.Number, (int)sqlException.Class, sqlException.State, sqlException.Message, ex);
            }
            else if(ex.InnerException is SqlException sqlEx)
            {
                dbException = new DbException(sqlEx.Number, (int)sqlEx.Class, sqlEx.State, sqlEx.Message, ex);
            }
            else
            {
                dbException = new DbException(ex.Message, ex);
            }

            return dbException;
        }
    }
}
