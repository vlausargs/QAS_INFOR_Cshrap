using CSI.Data.SQL;
using CSI.MG;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSI.Data.Functions
{
    public class ScalarFunctionFactory
    {
        public IScalarFunction Create(IApplicationDB appDB, IParameterProvider parameterProvider)
        {
            var sqlQueryLanguage = new SQLQueryLanguageFactory().Create(parameterProvider);
            return new ScalarFunction(appDB, sqlQueryLanguage);
        }
    }
}
