//PROJECT NAME: Logistics
//CLASS NAME: ArtranUpdRemCall.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class ArtranUpdRemCall : IArtranUpdRemCall
	{
		readonly IApplicationDB appDB;
		
		
		public ArtranUpdRemCall(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? ArtranUpdRemCallSp(string Site,
		Guid? RowPointer,
		string ArtranType,
		string CustNum,
		string InvNum,
		int? InvSeq,
		int? CheckSeq,
		string CoNum,
		string Description,
		int? Active,
		DateTime? DueDate,
		DateTime? InvDate,
		DateTime? DiscDate,
		string ApplyToInvNum,
		DateTime? InvHdrTaxDate,
		decimal? ExchRate)
		{
			SiteType _Site = Site;
			RowPointerType _RowPointer = RowPointer;
			ArtranTypeType _ArtranType = ArtranType;
			CustNumType _CustNum = CustNum;
			InvNumType _InvNum = InvNum;
			InvSeqType _InvSeq = InvSeq;
			ArCheckNumType _CheckSeq = CheckSeq;
			CoNumType _CoNum = CoNum;
			DescriptionType _Description = Description;
			ListYesNoType _Active = Active;
			DateType _DueDate = DueDate;
			DateType _InvDate = InvDate;
			DateType _DiscDate = DiscDate;
			InvNumType _ApplyToInvNum = ApplyToInvNum;
			DateType _InvHdrTaxDate = InvHdrTaxDate;
			ExchRateType _ExchRate = ExchRate;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ArtranUpdRemCallSp";
				
				appDB.AddCommandParameter(cmd, "Site", _Site, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RowPointer", _RowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ArtranType", _ArtranType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvNum", _InvNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvSeq", _InvSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CheckSeq", _CheckSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoNum", _CoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Description", _Description, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Active", _Active, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DueDate", _DueDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvDate", _InvDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DiscDate", _DiscDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ApplyToInvNum", _ApplyToInvNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvHdrTaxDate", _InvHdrTaxDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExchRate", _ExchRate, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
