using System;
using System.Collections.Generic;
using System.Text;

namespace CSI.Data.SQL
{
    public class SQLQueryLanguageFactory
    {
        public IQueryLanguage Create(IParameterProvider parameterProvider)
        {
            var parameterizedCommandFactory = new SQLParameterizedCommandFactory();

            return new SQLQueryLanguage(parameterProvider, parameterizedCommandFactory);

        }
    }
}
