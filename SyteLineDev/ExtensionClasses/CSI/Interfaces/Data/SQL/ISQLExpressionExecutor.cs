using CSI.Data.CRUD;
using System.Data;

namespace CSI.Data.SQL
{
    public interface ISQLExpressionExecutor
    {
        void Execute(string expression, params object[] expressionParameters);
    }
}
