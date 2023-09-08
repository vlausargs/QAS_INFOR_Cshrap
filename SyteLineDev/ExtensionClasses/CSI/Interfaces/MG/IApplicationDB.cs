using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;
using System;
using System.Data;

namespace CSI.MG
{
    public interface IApplicationDB
    {
        IDbCommand CreateCommand();

        IDataParameter CreateParameter(string parameterName, object value);

        IDbDataParameter AddCommandParameter(IDbCommand cmd, string parameterName, IUDDTType csiData, ParameterDirection direction = ParameterDirection.Input);

        IDataReader ExecuteReader(IDbCommand cmd);

        int ExecuteNonQuery(IDbCommand cmd);

        dynamic GetParameterValue(IDbDataParameter parm);

        ICollectionLoadResponse Load(ICollectionLoadRequest loadRequest);

        ICollectionLoadResponse Load(ICollectionLoadBuilderRequest loadRequest);

        ICollectionLoadResponse Load(ICollectionLoadStatementRequest loadRequest);

        void Insert(ICollectionInsertRequest insertRequest);
        void Update(ICollectionUpdateRequest updateRequest);
        void Delete(ICollectionDeleteRequest deleteRequest);

        void UpdateWithoutTrigger(ICollectionNonTriggerUpdateRequest updateRequest);

        void DeleteWithoutTrigger(ICollectionNonTriggerDeleteRequest deleteRequest);

        void InsertWithoutTrigger(ICollectionNonTriggerInsertRequest insertRequest);

        string FormatLiteral(object value);

        string GetMessage(string messageId);

        string GetMessage(string messageId, params object[] args);
        T ExecuteScalar<T>(IDbCommand cmd);

        Exception GetDbException(Exception ex);

        DataTable ExecuteQuery(IDbCommand cmd);
    }
}
