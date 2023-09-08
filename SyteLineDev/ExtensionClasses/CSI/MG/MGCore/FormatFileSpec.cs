using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSI.Data.SQL.UDDT;
using System.Data;

namespace CSI.MG.MGCore
{
	public class FormatFileSpec : IFormatFileSpec
	{
		IApplicationDB appDB;


		public FormatFileSpec(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}

		public string FormatFileSpecFn(string StorageMethod,
		int? UseServerPathAsRootPath,
		string FileSpec,
		string RootPath)
		{
			StorageMethodType _StorageMethod = StorageMethod;
			ListYesNoType _UseServerPathAsRootPath = UseServerPathAsRootPath;
			FileSpecType _FileSpec = FileSpec;
			FileSpecType _RootPath = RootPath;

			using (IDbCommand cmd = appDB.CreateCommand())
			{

				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[FormatFileSpec](@StorageMethod, @UseServerPathAsRootPath, @FileSpec, @RootPath)";

				appDB.AddCommandParameter(cmd, "StorageMethod", _StorageMethod, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UseServerPathAsRootPath", _UseServerPathAsRootPath, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FileSpec", _FileSpec, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RootPath", _RootPath, ParameterDirection.Input);

				var Output = appDB.ExecuteScalar<string>(cmd);

				return Output;
			}
		}
	}
}
