using CSI.Data.SQL.UDDT;
using CSI.Data.Utilities;
using CSI.MG;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CSI.Data
{
    public class UntagErrorMessage : IUntagErrorMessage
    {
        readonly IApplicationDB appDB;
        readonly IStringUtil stringUtil;

        public UntagErrorMessage(IApplicationDB appDB, IStringUtil stringUtil)
        {
            this.appDB = appDB;
            this.stringUtil = stringUtil ?? throw new ArgumentNullException(nameof(stringUtil));
        }

        public string UntagErrorMessageFn(string TaggedErrorMessage)
        {
            VeryLongListType _TaggedErrorMessage = TaggedErrorMessage;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT  dbo.[UntagErrorMessage](@TaggedErrorMessage)";

                appDB.AddCommandParameter(cmd, "TaggedErrorMessage", _TaggedErrorMessage, ParameterDirection.Input);

                var Output = appDB.ExecuteScalar<string>(cmd);

                return Output;
            }
        }
    }
}
