using System;
using System.Collections.Generic;
using System.Text;

namespace CSI.CSIInterfaces
{
    //public interface IViewDefinitionFactory
    //{
    //    /// <summary>
    //    /// Specifications needed to describe a record selection result set, whether connecting directly to SQL or via the Mongoose IDO layer.
    //    /// </summary>
    //    /// <param name="idoName">
    //    /// Optional when data handling through the Mongoose IDO layer isn't needed.
    //    /// </param>
    //    /// <param name="columnNames">
    //    /// Optional when direct connection to SQL is not needed.
    //    /// </param>
    //    /// <param name="columnExpressionsByColumnName">
    //    /// Mapping of column name to SQL column expression.
    //    /// Optional when direct connection to SQL is not needed.
    //    /// </param>
    //    /// <param name="fromClause">
    //    /// Optional when direct connection to SQL is not needed.
    //    /// </param>
    //    /// <returns></returns>
    //    IViewDefinition Create(
    //        string idoName = null,
    //        IEnumerable<string> columnNames = null,
    //        IReadOnlyDictionary<string, string> columnExpressionsByColumnName = null,
    //        string fromClause = null);

    //    /// <summary>
    //    /// SQL Only. Specifications needed to describe a record selection result set via a direct SQL connection.
    //    /// </summary>
    //    /// <param name="columnExpressionsByColumnName">
    //    /// Mapping of column name to SQL column expression.
    //    /// Optional when direct connection to SQL is not needed.
    //    /// </param>
    //    /// <param name="fromClause">
    //    /// Optional when direct connection to SQL is not needed.
    //    /// </param>
    //    /// <returns></returns>
    //    [Obsolete("This method doesn't support Mongoose")]
    //    IViewDefinition Create(
    //        IReadOnlyDictionary<string, string> columnExpressionsByColumnName,
    //        string fromClause);

    //    /// <summary>
    //    /// Mongoose Only. Specifications needed to describe a record selection result set via the Mongoose IDO layer.
    //    /// </summary>
    //    /// <param name="idoName">
    //    /// Optional when data handling through the Mongoose IDO layer isn't needed.
    //    /// </param>
    //    /// <param name="columnNames">
    //    /// Optional when direct connection to SQL is not needed.
    //    /// </param>
    //    /// <returns></returns>
    //    [Obsolete("This method doesn't support SQL")]
    //    IViewDefinition Create(
    //        string idoName,
    //        IEnumerable<string> columnNames);
    //}
}
