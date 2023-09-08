//PROJECT NAME: Production
//CLASS NAME: IHome_GetTodaysKeyProjectValuesCRUD.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Projects
{
	public interface IHome_GetTodaysKeyProjectValuesCRUD
	{
		bool Optional_ModuleForExists();
        void DeclareAltgen();
		void Optional_Module1Insert();
		bool Tv_ALTGENForExists();
		(string ALTGEN_SpName, int? rowCount) Tv_ALTGEN1Load(string ALTGEN_SpName);
		void Tv_ALTGEN2Delete(string ALTGEN_SpName);
		(decimal? InvoiceAmountTot, int? rowCount) Inv_MsLoad(DateTime? Today, decimal? InvoiceAmountTot);
		(decimal? RevenueAmountTot, int? rowCount) Rev_MsLoad(DateTime? Today, decimal? RevenueAmountTot);
		(int? ReturnCode, decimal? InvoiceAmountTot,decimal? RevenueAmountTot) AltExtGen_Home_GetTodaysKeyProjectValuesSp(string AltExtGenSp, decimal? InvoiceAmountTot, decimal? RevenueAmountTot);
	}
}

