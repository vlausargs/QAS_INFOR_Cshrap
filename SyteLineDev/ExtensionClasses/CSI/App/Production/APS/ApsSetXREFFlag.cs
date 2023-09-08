//PROJECT NAME: Production
//CLASS NAME: ApsSetXREFFlag.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class ApsSetXREFFlag : IApsSetXREFFlag
	{
		readonly IApplicationDB appDB;
		
		public ApsSetXREFFlag(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? ApsSetXREFFlagFn(
			string SupplyRefType,
			string SupplyRefNum,
			int? SupplyRefLineSuf,
			int? SupplyRefRelease,
			string DemandRefType,
			string DemandRefNum,
			int? DemandRefLineSuf,
			int? DemandRefRelease,
			int? DemandSequence,
			string Item)
		{
			JobTypeType _SupplyRefType = SupplyRefType;
			JobType _SupplyRefNum = SupplyRefNum;
			SuffixType _SupplyRefLineSuf = SupplyRefLineSuf;
			CoReleaseType _SupplyRefRelease = SupplyRefRelease;
			JobTypeType _DemandRefType = DemandRefType;
			JobType _DemandRefNum = DemandRefNum;
			SuffixType _DemandRefLineSuf = DemandRefLineSuf;
			CoReleaseType _DemandRefRelease = DemandRefRelease;
			JobmatlSequenceType _DemandSequence = DemandSequence;
			ItemType _Item = Item;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[ApsSetXREFFlag](@SupplyRefType, @SupplyRefNum, @SupplyRefLineSuf, @SupplyRefRelease, @DemandRefType, @DemandRefNum, @DemandRefLineSuf, @DemandRefRelease, @DemandSequence, @Item)";
				
				appDB.AddCommandParameter(cmd, "SupplyRefType", _SupplyRefType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SupplyRefNum", _SupplyRefNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SupplyRefLineSuf", _SupplyRefLineSuf, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SupplyRefRelease", _SupplyRefRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DemandRefType", _DemandRefType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DemandRefNum", _DemandRefNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DemandRefLineSuf", _DemandRefLineSuf, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DemandRefRelease", _DemandRefRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DemandSequence", _DemandSequence, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<int?>(cmd);
				
				return Output;
			}
		}
	}
}
