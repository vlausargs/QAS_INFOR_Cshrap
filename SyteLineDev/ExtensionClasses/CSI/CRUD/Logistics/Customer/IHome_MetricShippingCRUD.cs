//PROJECT NAME: Logistics
//CLASS NAME: IHome_MetricShippingCRUD.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
    public interface IHome_MetricShippingCRUD
    {
        bool Optional_ModuleForExists();
        void Optional_ModuleInsertSelect();
        bool Tv_ALTGENForExists();
        (string ALTGEN_SpName, int? rowCount) Tv_ALTGEN1Load(string ALTGEN_SpName);
        void Tv_ALTGEN2Delete(string ALTGEN_SpName);
        (string DomCurrCode, int? rowCount) CurrparmsLoad(string DomCurrCode);
        (string ParmsSite, int? rowCount) ParmsLoad(string ParmsSite);
        void Co_ShipInsert(DateTime? PeriodStart1, DateTime? PeriodEnd10);
        void CoshipUpdate();
        ICollectionLoadResponse Tv_Coship1Select(string DomCurrCode);
        void Coship2Update(int? Sequence, decimal? Price);
        (decimal? PeriodActual1,
             decimal? PeriodActual2,
             decimal? PeriodActual3,
             decimal? PeriodActual4,
             decimal? PeriodActual5,
             decimal? PeriodActual6,
             decimal? PeriodActual7,
             decimal? PeriodActual8,
             decimal? PeriodActual9,
             decimal? PeriodActual10, int? rowCount) Tv_Coship3Load(DateTime? PeriodStart1, DateTime? PeriodEnd1, DateTime? PeriodStart2, DateTime? PeriodEnd2, DateTime? PeriodStart3, DateTime? PeriodEnd3, DateTime? PeriodStart4, DateTime? PeriodEnd4, DateTime? PeriodStart5, DateTime? PeriodEnd5, DateTime? PeriodStart6, DateTime? PeriodEnd6, DateTime? PeriodStart7, DateTime? PeriodEnd7, DateTime? PeriodStart8, DateTime? PeriodEnd8, DateTime? PeriodStart9, DateTime? PeriodEnd9, DateTime? PeriodStart10, DateTime? PeriodEnd10, decimal? PeriodActual1, decimal? PeriodActual2, decimal? PeriodActual3, decimal? PeriodActual4, decimal? PeriodActual5, decimal? PeriodActual6, decimal? PeriodActual7, decimal? PeriodActual8, decimal? PeriodActual9, decimal? PeriodActual10);
        void CoitemInsert(DateTime? PeriodStart10, DateTime? PeriodEnd12);
        void CoitemUpdate();
        ICollectionLoadResponse Tv_Coitem1Select(string DomCurrCode);
        void Coitem2Update(int? Sequence, decimal? Price);
        (decimal? PeriodPlanned10, decimal? PeriodPlanned11, decimal? PeriodPlanned12, int? rowCount) Tv_Coitem3Load(DateTime? PeriodStart10, DateTime? PeriodEnd10, DateTime? PeriodStart11, DateTime? PeriodEnd11, DateTime? PeriodStart12, DateTime? PeriodEnd12, decimal? PeriodPlanned10, decimal? PeriodPlanned11, decimal? PeriodPlanned12);
        void NontableInsert(decimal? PeriodActual, DateTime? PeriodEnd);
        void Nontable2Insert(decimal? PeriodActual2, decimal? PeriodPlanned2, DateTime? PeriodEnd2);
        void Nontable3Insert(decimal? PeriodPlanned3, DateTime? PeriodEnd3);
        ICollectionLoadResponse Tv_ResultsSelect();
        (ICollectionLoadResponse Data, int? ReturnCode) AltExtGen_Home_MetricShippingSp(string AltExtGenSp, int? NumberOfRows);
    }
}