//PROJECT NAME: Data
//CLASS NAME: GetFullName.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Data.Functions
{
	public class GetFullName : IGetFullName
	{
		readonly IApplicationDB appDB;

		public GetFullName(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}

		public string GetFullNameFn(
			string lname,
			string fname,
			string mi,
			string sname)
		{
			SurnameType _lname = lname;
			GivenNameType _fname = fname;
			InitialType _mi = mi;
			SuffixNameType _sname = sname;

			using (IDbCommand cmd = appDB.CreateCommand())
			{

				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[GetFullName](@lname, @fname, @mi, @sname)";

				appDB.AddCommandParameter(cmd, "lname", _lname, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "fname", _fname, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "mi", _mi, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "sname", _sname, ParameterDirection.Input);

				var Output = appDB.ExecuteScalar<string>(cmd);

				return Output;
			}
		}
	}
}
