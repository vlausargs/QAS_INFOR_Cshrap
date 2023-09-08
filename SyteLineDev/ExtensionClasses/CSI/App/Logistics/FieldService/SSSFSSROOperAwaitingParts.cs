//PROJECT NAME: Logistics
//CLASS NAME: SSSFSSROOperAwaitingParts.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSSROOperAwaitingParts : ISSSFSSROOperAwaitingParts
	{
		readonly IApplicationDB appDB;
		
		public SSSFSSROOperAwaitingParts(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? SSSFSSROOperAwaitingPartsFn(
			string iSRONum,
			int? iSROLine = null,
			int? iSROOper = null)
		{
			FSSRONumType _iSRONum = iSRONum;
			FSSROLineType _iSROLine = iSROLine;
			FSSROOperType _iSROOper = iSROOper;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[SSSFSSROOperAwaitingParts](@iSRONum, @iSROLine, @iSROOper)";
				
				appDB.AddCommandParameter(cmd, "iSRONum", _iSRONum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iSROLine", _iSROLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iSROOper", _iSROOper, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<int?>(cmd);
				
				return Output;
			}
		}
	}
}
