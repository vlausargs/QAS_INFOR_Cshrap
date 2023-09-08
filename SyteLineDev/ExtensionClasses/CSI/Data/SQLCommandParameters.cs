using CSI.Data.SQL;
using CSI.Data.SQL.UDDT;
using CSI.MG;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSI.Data
{
    public class SQLCommandParameters : ICommandParameters
    {
        IAddCommandParameterWithValue addCommandParameterWithValue;

        IList<IUDDTType> outputParameters = new List<IUDDTType>();
        IList<string> outputParameterNames = new List<string>();

        public SQLCommandParameters(IAddCommandParameterWithValue addCommandParameterWithValue)
        {
            this.addCommandParameterWithValue = addCommandParameterWithValue;
        }

        public IDbDataParameter AddCommandParameterWithValue(IDbCommand cmd, string name, IUDDTType csiData, ParameterDirection direction = ParameterDirection.Input)
        {
            var dataParameter = addCommandParameterWithValue.AddCommandParameterWithValue(cmd, name, csiData.Value, direction);
            dataParameter.DbType = csiData.DbType;

            if (direction == ParameterDirection.InputOutput || direction == ParameterDirection.Output || direction == ParameterDirection.ReturnValue)
            {
                //save a reference to the parameter so we can update it after the call completes
                outputParameters.Add(csiData);
                outputParameterNames.Add("@" + name);

                switch (dataParameter.DbType)
                {
                    case DbType.Byte:
                    case DbType.Int16:
                    case DbType.Int32:
                    case DbType.Int64:
                    case DbType.Decimal:
                    case DbType.Double:
                    case DbType.Single:
                        dataParameter.Precision = csiData.Precision;
                        dataParameter.Scale = csiData.Scale;
                        break;
                    default:
                        dataParameter.Size = csiData.Length;
                        break;
                }
            }

            return dataParameter;
        }

        public void GetOutputParameters(IDbCommand cmd)
        {
            for (int i = 0; i < outputParameters.Count; i++)
                //update the output parameters that were originally passed in
                outputParameters[i].Value = ((IDbDataParameter)cmd.Parameters[outputParameterNames[i]]).Value;

            //reset so we're ready for the next call
            ClearOutputParameters();
        }

        public void ClearOutputParameters()
        {
            outputParameters.Clear();
            outputParameterNames.Clear();
        }

        public dynamic GetParameterValue(IDbDataParameter parm)
        {
            if (parm.Value == DBNull.Value) return null;

            switch (parm.DbType)
            {
                case DbType.String:
                    return (string)parm.Value;
                case DbType.Int32:
                    return (int)parm.Value;
                case DbType.Int16:
                    return (short)parm.Value;
                case DbType.Int64:
                    return (long)parm.Value;
                case DbType.Decimal:
                    return (decimal)parm.Value;
                case DbType.Double:
                    return (double)parm.Value;
                case DbType.Byte:
                    return (byte)parm.Value;
                case DbType.Binary:
                    return (byte[])parm.Value;
                case DbType.Boolean:
                    return (bool)parm.Value;
                case DbType.Guid:
                    return (Guid)parm.Value;
                default:
                    return null;
            }
        }
    }
}