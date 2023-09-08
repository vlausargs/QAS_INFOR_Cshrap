//PROJECT NAME: Finance
//CLASS NAME: Portal_CCILogCard.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance.CreditCard
{
	public class Portal_CCILogCard : IPortal_CCILogCard
	{
		readonly IApplicationDB appDB;
		
		
		public Portal_CCILogCard(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? Portal_CCILogCardSp(string CardNum,
		string CardSystem,
		string CustNum,
		int? CustSeq,
		string expDate,
		string NameOnCard,
		decimal? GatewayTransNum,
		string CardType,
		string Username = null,
		string CardSystemId = null)
		{
			CCICardNumType _CardNum = CardNum;
			CCICardSystemType _CardSystem = CardSystem;
			CustNumType _CustNum = CustNum;
			CustSeqType _CustSeq = CustSeq;
			CCIExpDateType _expDate = expDate;
			NameType _NameOnCard = NameOnCard;
			CCIGatewayTransNumType _GatewayTransNum = GatewayTransNum;
			CCICardTypeType _CardType = CardType;
			UsernameType _Username = Username;
			CCICardSystemIDType _CardSystemId = CardSystemId;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Portal_CCILogCardSp";
				
				appDB.AddCommandParameter(cmd, "CardNum", _CardNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CardSystem", _CardSystem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustSeq", _CustSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "expDate", _expDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NameOnCard", _NameOnCard, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "GatewayTransNum", _GatewayTransNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CardType", _CardType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Username", _Username, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CardSystemId", _CardSystemId, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
