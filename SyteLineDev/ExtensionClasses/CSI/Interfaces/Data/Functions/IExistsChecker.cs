using CSI.Data.SQL;
using System;
using System.Collections.Generic;

namespace CSI.Data.Functions
{
    public interface IExistsChecker
    {
        /// <summary>
        /// Perform a load request and return false if no records are found and return true any records are found.  
        /// This API cannot be used with an IDO.
        /// </summary>
        /// <param name="tableName">The name of the table to load data from.</param>
        /// <param name="fromClause">Optional.  The parameterized from clause, including any joins, to use.</param>
        /// <param name="whereClause">Optional.  The parameterized where clause to use.</param>
        /// <returns>true if load collection finds any records</returns>
        bool Exists(string tableName, IParameterizedCommand fromClause = null, IParameterizedCommand whereClause = null);
        bool Exists(IParameterizedCommand selectStatement);
    }
}