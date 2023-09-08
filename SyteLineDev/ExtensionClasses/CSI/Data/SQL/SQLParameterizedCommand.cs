using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CSI.Data.SQL
{
    public class SQLParameterizedCommand : IParameterizedCommand
    {
        public SQLParameterizedCommand(string statement, IEnumerable<IDataParameter> parameters = null)
        {
            this.Statement = statement;
            if (parameters != null)
                this.Parameters = parameters;
            else
                this.Parameters = new List<IDataParameter>();
        }

        public string Statement { get; }
        public IEnumerable<IDataParameter> Parameters { get; }
    }
}