//PROJECT NAME: Logistics
//CLASS NAME: SSSFSSROSiteInfo.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSSROSiteInfo : ISSSFSSROSiteInfo
	{
		readonly IApplicationDB appDB;
		
		public SSSFSSROSiteInfo(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			decimal? PQtyOnHand,
			decimal? PQtyRsvdCo,
			string PUM,
			int? PSuccess) SSSFSSROSiteInfoSP(
			string PSite = null,
			string PItem = null,
			int? ShowShortages = 1,
			DateTime? PSROStartDate = null,
			string PRefNum = null,
			int? PRefLineSuf = null,
			int? PRefRelease = null,
			decimal? PQtyOnHand = 0,
			decimal? PQtyRsvdCo = 0,
			string PUM = null,
			int? PSuccess = 1)
		{
			SiteType _PSite = PSite;
			ItemType _PItem = PItem;
			ListYesNoType _ShowShortages = ShowShortages;
			DateType _PSROStartDate = PSROStartDate;
			StringType _PRefNum = PRefNum;
			IntType _PRefLineSuf = PRefLineSuf;
			IntType _PRefRelease = PRefRelease;
			QtyTotlType _PQtyOnHand = PQtyOnHand;
			QtyTotlType _PQtyRsvdCo = PQtyRsvdCo;
			UMType _PUM = PUM;
			ListYesNoType _PSuccess = PSuccess;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSSROSiteInfoSP";
				
				appDB.AddCommandParameter(cmd, "PSite", _PSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PItem", _PItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShowShortages", _ShowShortages, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSROStartDate", _PSROStartDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PRefNum", _PRefNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PRefLineSuf", _PRefLineSuf, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PRefRelease", _PRefRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PQtyOnHand", _PQtyOnHand, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PQtyRsvdCo", _PQtyRsvdCo, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PUM", _PUM, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PSuccess", _PSuccess, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PQtyOnHand = _PQtyOnHand;
				PQtyRsvdCo = _PQtyRsvdCo;
				PUM = _PUM;
				PSuccess = _PSuccess;
				
				return (Severity, PQtyOnHand, PQtyRsvdCo, PUM, PSuccess);
			}
		}
	}
}
