using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.Data.SQL;
using CSI.Data.Utilities;
using Infor.IPF.Metrics.Metric;

namespace CSI.Data.Metric
{
    public interface IRunningSQLCatcher
    {
        string Process(string methodName, IParameterizedCommand parameterizedCommand);
    }
    public class RunningSQLCatcher: IRunningSQLCatcher
    {
        public string Process(string methodName, IParameterizedCommand parameterizedCommand)
        {
            if (parameterizedCommand == null) return string.Empty;
            IList<string> methods = new List<string>() { "UpdateStatementFromValues", "UpdateStatementFromRecord", "UpdateStatementWithFromWhereClause",
            "DeleteStatementFromKeyValues", "DeleteStatementFromRecord", "DeleteStatementWithFromWhereClause",
            "InsertStatementFromValues", "InsertStatementFromRecord", "InsertStatementFromExpressionValues",
            "SelectStatement", "SQLStatement"};
            if (!methods.Contains(methodName)) return string.Empty;
            StringBuilder parms = new StringBuilder();
            parms.Append($"Statement: [{parameterizedCommand.Statement}]");
            parms.Append($" Parameters: [");
            int index = 0; string spilteSymbol = string.Empty;
            foreach (var parm in parameterizedCommand.Parameters)
            {
                parms.Append($"{spilteSymbol}@p{index++}={parm.Value ?? "null"}");
                spilteSymbol = ",";
            }
            parms.Append($"]");
            return parms.ToString();
        }
    }
    class MetricBuilder: IMetricBuilder
    {
        readonly IMetricFactory metricFactory;
        readonly IMetricConfiguration metricConfiguration;
        readonly ITupleUtil tupleUtil;
        readonly IRunningSQLCatcher runningSQLCatcher;
        public MetricBuilder(IMetricFactory metricFactory, IMetricConfiguration metricConfiguration, ITupleUtil tupleUtil, IRunningSQLCatcher runningSQLCatcher)
        {
            this.metricFactory = metricFactory;
            this.metricConfiguration = metricConfiguration;
            this.tupleUtil = tupleUtil;
            this.runningSQLCatcher = runningSQLCatcher;
        }

        public IMetric CreateMetric(string className, MethodInfo targetMethod, object[] requestParms, object responseParm)
        {
            if (!this.metricConfiguration.StatisticEnabled(string.Empty)) return null;
            var metricAttributes = new Dictionary<string, string>() { { "Class", className }, { "Timestamp", DateTime.UtcNow.ToString("o") } };
            var request = BuildRequestInformation(requestParms);
            foreach (var item in request)
                metricAttributes.Add(item.Key, item.Value);
            var response = BuildResponseInformation(targetMethod.Name, responseParm);
            foreach (var item in response)
                metricAttributes.Add(item.Key, item.Value);
            return metricFactory.CreateMetricWithAttributes(targetMethod.Name, metricAttributes);
        }
        private IDictionary<string, string> BuildRequestInformation(object[] requestParms)
        {
            IDictionary<string, string> attributes = new Dictionary<string, string>();
            if (requestParms == null || requestParms.Length == 0) return attributes;
            StringBuilder parms = new StringBuilder();
            parms.Append("[Request]");
            foreach (var item in requestParms)
            {
                parms.Append($",{item ?? string.Empty}");
                if (item is ICollectionLoadRequest loadRequest) attributes = BuildRequestInformation(loadRequest, attributes);
                else if (item is ICollectionInsertRequest insertRequest) attributes = BuildRequestInformation(insertRequest, attributes);
                else if (item is ICollectionUpdateRequest updateRequest) attributes = BuildRequestInformation(updateRequest, attributes);
                else if (item is ICollectionDeleteRequest deleteRequest) attributes = BuildRequestInformation(deleteRequest, attributes);
                else if (item is ICollectionLoadStatementRequest loadStatementRequest) attributes = BuildRequestInformation(loadStatementRequest, attributes);
                else if (item is ICollectionNonTriggerDeleteRequest nonTriggerDeleteRequest) attributes = BuildRequestInformation(nonTriggerDeleteRequest, attributes);
                else if (item is ICollectionNonTriggerUpdateRequest nonTriggerUpdateRequest) attributes = BuildRequestInformation(nonTriggerUpdateRequest, attributes);
                else if (item is ICollectionNonTriggerInsertRequest nonTriggerInsertRequest) attributes = BuildRequestInformation(nonTriggerInsertRequest, attributes);    
                else if (item is ICollectionLoadBuilderRequest collectionLoadBuilderRequest) attributes = BuildRequestInformation(collectionLoadBuilderRequest, attributes);            
            }
            attributes.Add("ParmsList", parms.ToString());
            return attributes;
        }
         
        private IDictionary<string, string> BuildRequestInformation(ICollectionLoadRequest loadRequest, IDictionary<string, string> attributes)
        {
            if(!string.IsNullOrEmpty(loadRequest.TargetTableName)) attributes.Add("TargetTableName", loadRequest.TargetTableName);
            string requestedColumns = string.Join(",", loadRequest.RequestedColumns?.Select(x => $"{x}"));
            if (!string.IsNullOrEmpty(requestedColumns)) attributes.Add("RequestedColumns", requestedColumns);
            if (!string.IsNullOrEmpty(loadRequest.TableName)) attributes.Add("TableName", loadRequest.TableName);
            if (!string.IsNullOrEmpty(loadRequest.IDOName)) attributes.Add("IDOName", loadRequest.IDOName);
            if (loadRequest.MaximumRows != 0) attributes.Add("MaximumRows", Convert.ToString(loadRequest.MaximumRows));
            string selectColumns = loadRequest.ColumnExpressionByColumnName == null?"":
                string.Join(",", loadRequest.ColumnExpressionByColumnName?.Select(x => $"{x.Value}"));
            if (!string.IsNullOrEmpty(selectColumns)) attributes.Add("SelectColumns", selectColumns);
            string fromClause = loadRequest.FromClause?.Statement;
            if(loadRequest?.FromClause?.Parameters?.Count() > 0)
                fromClause += $"--{string.Join(",", loadRequest.FromClause?.Parameters?.Select(x => $"{x.ParameterName}={x.Value}"))}";
            if (!string.IsNullOrEmpty(fromClause)) attributes.Add("FromClause", fromClause);
            
            string whereClause = loadRequest.WhereClause?.Statement;
            if(loadRequest.WhereClause?.Parameters?.Count() > 0)
                whereClause += $"--{string.Join(",", loadRequest.WhereClause?.Parameters?.Select(x => $"{x.ParameterName}={x.Value}"))}";
            if (!string.IsNullOrEmpty(whereClause)) attributes.Add("WhereClause", whereClause);
            
            string orderByClause = loadRequest.OrderByClause?.Statement;
            if(loadRequest.OrderByClause?.Parameters?.Count() > 0)
                orderByClause += $"--{string.Join(",", loadRequest.OrderByClause?.Parameters?.Select(x => $"{x.ParameterName}={x.Value}"))}";
            if (!string.IsNullOrEmpty(orderByClause)) attributes.Add("OrderByClause", orderByClause);
                        
            return attributes;
        }
        private IDictionary<string, string> BuildRequestInformation(ICollectionLoadStatementRequest request, IDictionary<string, string> attributes)
        {
            string tableName = request.TargetTableName;
            string selectStatement = request.SelectStatement?.Statement;
            string selectParameters = string.Empty;
            if(request.SelectStatement?.Parameters != null)
                selectParameters = string.Join(",", request.SelectStatement?.Parameters?.Select(x => $"{x.ParameterName}={x.Value}"));
            if (!string.IsNullOrEmpty(selectStatement)) attributes.Add("SelectStatement", selectStatement);
            if (!string.IsNullOrEmpty(tableName)) attributes.Add("TableName", tableName);
            if (!string.IsNullOrEmpty(selectParameters)) attributes.Add("SelectParameters", selectParameters);
            return attributes;
        }
        private IDictionary<string, string> BuildRequestInformation(ICollectionInsertRequest request, IDictionary<string, string> attributes)
        {
            int? recordCount = request.Items?.Count;
            string tableName = request.TableName;
            string IDOName = request.IDOName;
            if (recordCount != null) attributes.Add("RecordCount", Convert.ToString(recordCount));
            if (!string.IsNullOrEmpty(tableName)) attributes.Add("TargetTableName", tableName);
            if (!string.IsNullOrEmpty(IDOName)) attributes.Add("IDOName", IDOName);
            return attributes;
        }
        private IDictionary<string, string> BuildRequestInformation(ICollectionUpdateRequest request, IDictionary<string, string> attributes)
        {
            int? recordCount = request.Items?.Count;
            string tableName = request.TableName;
            string IDOName = request.IDOName;
            if (recordCount != null) attributes.Add("RecordCount", Convert.ToString(recordCount));
            if (!string.IsNullOrEmpty(tableName)) attributes.Add("TargetTableName", tableName);
            if (!string.IsNullOrEmpty(IDOName)) attributes.Add("IDOName", IDOName);
            return attributes;
        }
        private IDictionary<string, string> BuildRequestInformation(ICollectionDeleteRequest request, IDictionary<string, string> attributes)
        {
            int? recordCount = request.Items?.Count;
            string tableName = request.TableName;
            string IDOName = request.IDOName;
            if (recordCount != null) attributes.Add("RecordCount", Convert.ToString(recordCount));
            if (!string.IsNullOrEmpty(tableName)) attributes.Add("TargetTableName", tableName);
            if (!string.IsNullOrEmpty(IDOName)) attributes.Add("IDOName", IDOName);
            return attributes;
        }
        private IDictionary<string, string> BuildRequestInformation(ICollectionNonTriggerDeleteRequest request, IDictionary<string, string> attributes)
        {
            if (request.MaximumRows != 0) attributes.Add("MaximumRows", Convert.ToString(request.MaximumRows));
            if (!string.IsNullOrEmpty(request.TableName)) attributes.Add("TargetTableName", request.TableName);
            string fromClause = request.FromClause?.Statement;
            if(request.FromClause?.Parameters?.Count() > 0)
                fromClause += $"--{string.Join(",", request.FromClause?.Parameters?.Select(x => $"{x.ParameterName}={x.Value}"))}";
            if (!string.IsNullOrEmpty(fromClause)) attributes.Add("FromClause", fromClause);
            string whereClause = request.WhereClause?.Statement;
            if(request.WhereClause?.Parameters?.Count() > 0)
                whereClause += $"--{string.Join(",", request.WhereClause?.Parameters?.Select(x => $"{x.ParameterName}={x.Value}"))}";
            if (!string.IsNullOrEmpty(whereClause)) attributes.Add("WhereClause", whereClause);
            return attributes;
        }
        private IDictionary<string, string> BuildRequestInformation(ICollectionNonTriggerUpdateRequest request, IDictionary<string, string> attributes)
        {
            string selectColumns = string.Empty;
            foreach (var column in request.ExpressionByColumnToAssign)
                selectColumns += $"{column.Value?.Statement}--{string.Join(",", column.Value?.Parameters?.Select(x => $"{x.ParameterName}={x.Value}"))}";
            if (!string.IsNullOrEmpty(selectColumns)) attributes.Add("SelectColumns", selectColumns);
            string fromClause = request.FromClause?.Statement;
            if (request.FromClause?.Parameters?.Count() > 0)
                fromClause += $"--{string.Join(",", request.FromClause?.Parameters?.Select(x => $"{x.ParameterName}={x.Value}"))}";
            if (!string.IsNullOrEmpty(fromClause)) attributes.Add("FromClause", fromClause);            
            string whereClause = request.WhereClause?.Statement;
            if(request.WhereClause?.Parameters?.Count() > 0)
                whereClause += $"--{string.Join(",", request.WhereClause?.Parameters?.Select(x => $"{x.ParameterName}={x.Value}"))}";
            if (!string.IsNullOrEmpty(whereClause)) attributes.Add("WhereClause", whereClause);            
            if (!string.IsNullOrEmpty(request.TableName)) attributes.Add("TargetTableName", request.TableName);
            if (request.MaximumRows != 0) attributes.Add("MaximumRows", Convert.ToString(request.MaximumRows));
            return attributes;
        }
        private IDictionary<string, string> BuildRequestInformation(ICollectionNonTriggerInsertRequest request, IDictionary<string, string> attributes)
        {
            if (request.MaximumRows != 0) attributes.Add("MaximumRows", Convert.ToString(request.MaximumRows));
            if (!string.IsNullOrEmpty(request.TargetTableName)) attributes.Add("TargetTableName", request.TargetTableName);
            string selectColumns = string.Empty;
            if (request.ValuesByExpressionToAssign?.Count > 0)
            {
                foreach (var column in request.ValuesByExpressionToAssign)
                    selectColumns += $"{column.Value?.Statement}--{string.Join(",", column.Value?.Parameters?.Select(x => $"{x.ParameterName}={x.Value}"))};";
            }
            if (!string.IsNullOrEmpty(selectColumns)) attributes.Add("SelectColumns", selectColumns);
            string targetColumns = string.Empty;
            if (request.TargetColumns?.Count > 0) targetColumns = string.Join(",", request.TargetColumns);
            if (!string.IsNullOrEmpty(targetColumns)) attributes.Add("TargetColumns", targetColumns);
            string fromClause = request.FromClause?.Statement;
            if(request.FromClause?.Parameters?.Count() > 0)
                fromClause += $"--{string.Join(",", request.FromClause?.Parameters?.Select(x => $"{x.ParameterName}={x.Value}"))}";
            if (!string.IsNullOrEmpty(fromClause)) attributes.Add("FromClause", fromClause);
            string whereClause = request.WhereClause?.Statement;
            if(request.WhereClause?.Parameters?.Count() > 0)
                whereClause += $"--{string.Join(",", request.WhereClause?.Parameters?.Select(x => $"{x.ParameterName}={x.Value}"))}";
            if (!string.IsNullOrEmpty(whereClause)) attributes.Add("WhereClause", whereClause);
            return attributes;
        }
        private IDictionary<string, string> BuildRequestInformation(ICollectionLoadBuilderRequest request, IDictionary<string, string> attributes)
        {
            string requestedColumns = string.Empty;
            if (request.RequestedColumns?.Count() > 0) requestedColumns = string.Join(",", request.RequestedColumns);
            if (!string.IsNullOrEmpty(requestedColumns)) attributes.Add("RequestedColumns", requestedColumns);
            string selectColumns = request.ColumnExpressionByColumnName == null ? "" :
                string.Join(",", request.ColumnExpressionByColumnName?.Select(x => $"{x.Value}"));
            if (!string.IsNullOrEmpty(selectColumns)) attributes.Add("SelectColumns", selectColumns);
            string varaibleColumns = request.ColumnNameByVariableToAssign == null ? "" :
                string.Join(",", request.ColumnNameByVariableToAssign?.Select(x => $"{x.Value}"));
            if (!string.IsNullOrEmpty(varaibleColumns)) attributes.Add("VaraibleColumns", varaibleColumns);
            return attributes;
        }
        private IDictionary<string, string> BuildResponseInformation(string methodName, object responseParm)
        {
            IDictionary<string, string> attributes = new Dictionary<string, string>();
            if (responseParm == null) return attributes;
            IList<object> args = null;
            if (this.tupleUtil.IsTuple(responseParm))
            {
                attributes.Add("ResultType", "Tuple");
                args = tupleUtil.EnumerateValueTuple(responseParm);
            }
            else args = new List<object>() { responseParm };

            StringBuilder parms = new StringBuilder();
            IRecordCollection records = null;
            foreach (var item in args)
            {
                if (item is IParameterizedCommand dataParamers)
                {
                    var runningSQL = runningSQLCatcher.Process(methodName, dataParamers);
                    if(!string.IsNullOrEmpty(runningSQL)) parms.Append(runningSQL);
                }
                else parms.Append($",{item ?? string.Empty}");
                if (item is ICollectionLoadResponse loadResponse) records = loadResponse.Items;
            }
            int argsArrayCount = args == null ? 0 : args.Count;
            attributes.Add("ReturnCount", Convert.ToString(argsArrayCount));
            attributes.Add("ResultValueList", parms.ToString());
            if (records != null) attributes.Add("ResultRecordCount", Convert.ToString(records.Count));

            return attributes;
        }
   
        public IMetric CreateMetric(string className, MethodInfo targetMethod)
        {
            if (targetMethod == null) throw new ArgumentNullException($"{typeof(MethodInfo).Name} ");
            var timingAttributes = new Dictionary<string, string>() { { "Class", className } };
            return metricFactory.CreateMetricWithAttributes(targetMethod.Name, timingAttributes);
        }
        public IMetric CreateMetricWithAttributes(string name, IDictionary<string, string> eventAttributes)
        {
            return metricFactory.CreateMetricWithAttributes(name, eventAttributes);
        }

    }
}
