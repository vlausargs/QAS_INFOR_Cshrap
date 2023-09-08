using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.Data.SQL;
using CSI.Data.SQL.UDDT;
using CSI.MG;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;

namespace CSI.Data.Functions
{
    public class SQLExpressionExecutor : ISQLExpressionExecutor, ISQLCollectionLoad
    {
        readonly IApplicationDB appDB;
        readonly IDataTypeUtil dataTypeUtil;
        readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
        readonly IQueryLanguage queryLanguage;

        public SQLExpressionExecutor(IApplicationDB appDB, IDataTypeUtil dataTypeUtil, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse, IQueryLanguage queryLanguage)
        {
            this.appDB = appDB;
            this.dataTypeUtil = dataTypeUtil;
            this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
            this.queryLanguage = queryLanguage;
        }

        public void Execute(string expression, params object[] expressionParameters)
        {
            var parameterized = queryLanguage.WhereClause(expression, expressionParameters);

            try
            {
                using (IDbCommand cmd = appDB.CreateCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = parameterized.Statement;

                    foreach (var parameter in parameterized.Parameters)
                    {
                        cmd.Parameters.Add(parameter);
                    }

                    cmd.ExecuteNonQuery();
                }
            }
            catch
            {
                throw;
            }
        }

        public (int? Severity, ICollectionLoadResponse Data) ExecuteDynamicQuery(string expression, string paramDefinition, params object[] paramValues)
        {
            try
            {
                using (IDbCommand cmd = appDB.CreateCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = expression;

                    var parmNames = new List<string>();
                    var parmData = new List<IUDDTType>();
                    var parmDir = new List<ParameterDirection>();

                    if (!string.IsNullOrEmpty(paramDefinition))
                    {
                        var parsedParms = ParseParameterDefinition(paramDefinition, paramValues);

                        parmNames = parsedParms.parmNames;
                        parmData = parsedParms.parmData;
                        parmDir = parsedParms.parmDirs;

                        for (int i = 0; i < parmNames.Count; i++)
                            appDB.AddCommandParameter(cmd, parmNames[i], parmData[i], parmDir[i]);
                    }

                    // add return value parameter
                    IntType returnVal = 0;
                    IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);

                    DataTable retTable = new DataTable();
                    using (IDataReader reader = appDB.ExecuteReader(cmd))
                    {
                        if (reader != null)
                            retTable.Load(reader);

                        for (int i = 0; i < parmNames.Count; i++)
                        {
                            if (parmDir[i] == ParameterDirection.Output)
                            {
                                if (paramValues[i] is IUDDTType)
                                    paramValues[i] = parmData[i];
                                else
                                    paramValues[i] = parmData[i].Value;
                            }
                        }
                    }
                    return (returnVal.Value, dataTableToCollectionLoadResponse.Process(retTable));
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private (List<string> parmNames, List<IUDDTType> parmData, List<ParameterDirection> parmDirs) ParseParameterDefinition(string parmDef, params object[] paramValues)
        {
            var parmNames = new List<string>();
            var parmTypes = new List<string>();
            var parmData = new List<IUDDTType>();
            var parmDir = new List<ParameterDirection>();

            string[] parms = parmDef.Split(',').Where(x => !string.IsNullOrEmpty(x)).ToArray();
            foreach (string parm in parms)
            {
                string[] parmArr = parm.Split(' ').Where(x => !string.IsNullOrEmpty(x)).ToArray();
                parmNames.Add(parmArr[0].Replace("@", ""));
                parmTypes.Add(parmArr[1]);
                parmDir.Add(parmArr.Length > 2 && parmArr[2].Contains("OUT") ? ParameterDirection.Output : ParameterDirection.Input);
            }

            for (int i = 0; i < parmNames.Count; i++)
            {
                var uddtType = dataTypeUtil.GetUDDTFromSQLType(parmTypes[i]);
                Type type = dataTypeUtil.GetType($"CSI.Data.SQL.UDDT.{uddtType}");
                Type getCSType = null;

                IUDDTType objParm = null;
                Exception exception = null;
                bool bCreated = false;
                if (paramValues[i] is IUDDTType uDDTParm)
                {
                    objParm = uDDTParm;
                    bCreated = true;
                }
                else
                {
                    var constructorInfos = type.GetTypeInfo().DeclaredConstructors;
                    foreach (var constructorInfo in constructorInfos)
                    {
                        string _type = constructorInfo.ToString();
                        if (_type.Contains("String"))
                        {
                            int trimStart = _type.IndexOf("op_Implicit") + 12;
                            int trimEnd = _type.Length - trimStart - 1;
                            _type = _type.Substring(trimStart, trimEnd);
                            getCSType =  Type.GetType(_type);
                        }
                        else
                        {
                            var startIndex = _type.IndexOf("[System.") + 1;
                            var firstSubstring = _type.Substring(startIndex, _type.Length - startIndex);
                            var endIndex = firstSubstring.IndexOf("]");
                            var typeString = firstSubstring.Substring(0, endIndex);
                            getCSType = Type.GetType(typeString);
                        }

                        try
                        {
                            var cotr = type.GetTypeInfo().GetConstructor(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Public, null, new[] { getCSType }, null);
                            if (cotr != null)
                            {
                                object[] parms1 = new object[] { paramValues[i] };
                                objParm = cotr.Invoke(parms1) as IUDDTType;
                                bCreated = true;
                            }
                        }
                        catch(Exception ex)
                        {
                            exception = ex;
                        }

                    }

                }

                if (!bCreated)
                {
                    throw exception;
                }

                parmData.Add(objParm);
            }

            return (parmNames, parmData, parmDir);
        }
    }
}
