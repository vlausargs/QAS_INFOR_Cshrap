//PROJECT NAME: Logistics
//CLASS NAME: IHome_MetricJobWIPCRUD.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IHome_MetricJobWIPCRUD
	{
		bool Optional_ModuleForExists();
        void DeclareAltgen();
		void Optional_Module1Insert();
		bool Tv_ALTGENForExists();
		(string ALTGEN_SpName, int? rowCount) Tv_ALTGEN1Load(string ALTGEN_SpName);
        void Tv_ALTGEN2Delete(string ALTGEN_SpName);
        ICollectionLoadResponse JobSelect(int? Count);
		ICollectionLoadResponse Job1Select();
		(ICollectionLoadResponse Data, int? ReturnCode) AltExtGen_Home_MetricJobWIPSp(string AltExtGenSp, int? Count);
	}
}

