//PROJECT NAME: CSIVendor
//CLASS NAME: ChgPoStat.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public interface IChgPoStat
	{
		(ICollectionLoadResponse Data, int? ReturnCode, string Infobar) ChgPoStatSp(string ProcSel,
		string IPoType,
		string IOldPoStat,
		string INewPoStat,
		string SPoNum,
		string EPoNum,
		DateTime? SPoOrderDate,
		DateTime? EPoOrderDate,
		string Infobar,
		short? StartOrderDateOffset = null,
		short? EndOrderDateOffset = null,
		int? BgTaskID = null);
	}
	
	public class ChgPoStat : IChgPoStat
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public ChgPoStat(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode, string Infobar) ChgPoStatSp(string ProcSel,
		string IPoType,
		string IOldPoStat,
		string INewPoStat,
		string SPoNum,
		string EPoNum,
		DateTime? SPoOrderDate,
		DateTime? EPoOrderDate,
		string Infobar,
		short? StartOrderDateOffset = null,
		short? EndOrderDateOffset = null,
		int? BgTaskID = null)
		{
			bunchedLoadCollection.StartBunching();
			
			try
			{
				LongListType _ProcSel = ProcSel;
				PoTypeType _IPoType = IPoType;
				PoStatType _IOldPoStat = IOldPoStat;
				PoStatType _INewPoStat = INewPoStat;
				PoNumType _SPoNum = SPoNum;
				PoNumType _EPoNum = EPoNum;
				DateType _SPoOrderDate = SPoOrderDate;
				DateType _EPoOrderDate = EPoOrderDate;
				InfobarType _Infobar = Infobar;
				DateOffsetType _StartOrderDateOffset = StartOrderDateOffset;
				DateOffsetType _EndOrderDateOffset = EndOrderDateOffset;
				GenericNoType _BgTaskID = BgTaskID;
				
				using (IDbCommand cmd = appDB.CreateCommand())
				{
					DataTable dtReturn = new DataTable();
					
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.CommandText = "ChgPoStatSp";
					
					appDB.AddCommandParameter(cmd, "ProcSel", _ProcSel, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "IPoType", _IPoType, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "IOldPoStat", _IOldPoStat, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "INewPoStat", _INewPoStat, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "SPoNum", _SPoNum, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "EPoNum", _EPoNum, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "SPoOrderDate", _SPoOrderDate, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "EPoOrderDate", _EPoOrderDate, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
					appDB.AddCommandParameter(cmd, "StartOrderDateOffset", _StartOrderDateOffset, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "EndOrderDateOffset", _EndOrderDateOffset, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "BgTaskID", _BgTaskID, ParameterDirection.Input);
					
					IntType returnVal = 0;
					IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
					dbParm.DbType = DbType.Int32;

                    dtReturn = appDB.ExecuteQuery(cmd);

                    Infobar = _Infobar;
					
					return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value, Infobar);
				}
			}
			finally
			{
				bunchedLoadCollection.EndBunching();
			}
		}
	}
}
