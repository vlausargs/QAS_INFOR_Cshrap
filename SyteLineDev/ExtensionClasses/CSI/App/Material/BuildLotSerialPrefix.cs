//PROJECT NAME: Material
//CLASS NAME: BuildLotSerialPrefix.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public class BuildLotSerialPrefix : IBuildLotSerialPrefix
	{
		readonly IApplicationDB appDB;
		
		public BuildLotSerialPrefix(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public string BuildLotSerialPrefixFn(
			string ItemPrefix,
			string ParmsPrefix,
			string RefType,
			string RefNum,
			int? RefLineSuf,
			int? RefRelease,
			string Site)
		{
			SerialPrefixType _ItemPrefix = ItemPrefix;
			SerialPrefixType _ParmsPrefix = ParmsPrefix;
			RefTypeIJKOPRSTWType _RefType = RefType;
			EmpJobCoPoRmaProjPsTrnNumType _RefNum = RefNum;
			CoLineSuffixPoLineProjTaskRmaTrnLineType _RefLineSuf = RefLineSuf;
			CoReleaseOperNumPoReleaseType _RefRelease = RefRelease;
			SiteType _Site = Site;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[BuildLotSerialPrefix](@ItemPrefix, @ParmsPrefix, @RefType, @RefNum, @RefLineSuf, @RefRelease, @Site)";
				
				appDB.AddCommandParameter(cmd, "ItemPrefix", _ItemPrefix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ParmsPrefix", _ParmsPrefix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefType", _RefType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefNum", _RefNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefLineSuf", _RefLineSuf, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefRelease", _RefRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Site", _Site, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<string>(cmd);
				
				return Output;
			}
		}
	}
}
