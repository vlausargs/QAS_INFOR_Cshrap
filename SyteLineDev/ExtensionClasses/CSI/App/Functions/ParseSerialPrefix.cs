//PROJECT NAME: Data
//CLASS NAME: ParseSerialPrefix.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class ParseSerialPrefix : IParseSerialPrefix
	{
		readonly IApplicationDB appDB;
		
		public ParseSerialPrefix(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public string ParseSerialPrefixFn(
			string ItemPrefix,
			DateTime? Date,
			string RefType,
			string Site)
		{
			SerialPrefixType _ItemPrefix = ItemPrefix;
			DateTimeType _Date = Date;
			RefTypeJKOType _RefType = RefType;
			SiteType _Site = Site;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[ParseSerialPrefix](@ItemPrefix, @Date, @RefType, @Site)";
				
				appDB.AddCommandParameter(cmd, "ItemPrefix", _ItemPrefix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Date", _Date, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefType", _RefType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Site", _Site, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<string>(cmd);
				
				return Output;
			}
		}
	}
}
