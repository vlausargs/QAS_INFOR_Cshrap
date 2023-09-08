using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSI.Data.SQL.UDDT;
using System.Data;

namespace CSI.MG.MGCore
{
	public class varbintohexsubstring : Ivarbintohexsubstring
	{
		IApplicationDB appDB;


		public varbintohexsubstring(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}

		public string varbintohexsubstringFn(bool? fsetprefix = true,
		byte[] pbinin = null,
		int? startoffset = 1,
		int? cbytesin = 0)
		{
			BooleanType _fsetprefix = fsetprefix;
			BinaryType _pbinin = pbinin;
			IntType _startoffset = startoffset;
			IntType _cbytesin = cbytesin;

			using (IDbCommand cmd = appDB.CreateCommand())
			{

				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[varbintohexsubstring](@fsetprefix, @pbinin, @startoffset, @cbytesin)";

				appDB.AddCommandParameter(cmd, "fsetprefix", _fsetprefix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pbinin", _pbinin, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "startoffset", _startoffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "cbytesin", _cbytesin, ParameterDirection.Input);

				var Output = appDB.ExecuteScalar<string>(cmd);

				return Output;
			}
		}
	}
}
