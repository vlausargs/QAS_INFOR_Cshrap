using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using CSI.Data.SQL.UDDT;
using CSI.Data.Functions;

namespace CSI.Logistics.Customer
{
    public interface IGetFreightRateShopRequestCRUD
    {
        string GetScac(string shipVia);
        (string TransportationMode, string RoadTransportationType) GetTransportationMode(string shipVia);
        (string OriginCity, string OriginState, string OriginZip, string OriginCountry, string DestinationCity, string DestinationState, string DestinationZip, string DestinationCountry, DateTime? PickupDate, string WeightUM) ShipmentHeader(decimal? ShipmentId);
        ICollectionLoadResponse ShipmentPackage(decimal? ShipmentId);
        int? GetItemCountByShipmentPackage(decimal? ShipmentId, int? PackageTypeId);
        ICollectionLoadResponse ShipmentPackageByItem(decimal? ShipmentId);
        (string OriginCity, string OriginState, string OriginZip, string OriginCountry, string DestinationCity, string DestinationState, string DestinationZip, string DestinationCountry, DateTime? PickupDate, decimal? Weight, int? PackageQty) GetShipmentCOHeader(string CustNum, string CoNum);
        ICollectionLoadResponse GetShipmentCOPackage(string CustNum, string CoNum);
        ICollectionLoadResponse GetShipmentCOCommodities(string CustNum, string CoNum);
        string GetCOParmsDuePeriod();
        (string ShipmentWeightUM, string ShipmentDimensionUM) GetInvparmsShipmentUM();

        (int? OriginCityExist,
         int? OriginStateExist,
         int? OriginZipExist,
         int? OriginCountryExist,
         int? DestinationCityExist,
         int? DestinationStateExist,
         int? DestinationZipExist,
         int? DestinationCountryExist,
         int? OrderDateExist)
         GetCOHeaderExistValues(string CustNum, string CoNum);

        (int? PackageTypeExists,
         int? PackageTypeDimensionUMExists,
         int? PackageTypeLengthExists,
         int? PackageTypeWidthExists,
         int? PackageTypeHeightExists,
         int? PackageTypePackagingWeightUMExists,
         int? PackageTypePackagingWeightExists,
         int? ItemUnitWeightExists,
         int? ItemWeightUnitsExists,
         int? PackageTypeWeightUMExists,
         int? PackageTypeWeightExists)
        GetCOLinesExistValues(string CustNum, string CoNum);

        (int? OriginCityExist,
        int? OriginStateExist,
        int? OriginZipExist,
        int? OriginCountryExist,
        int? DestinationCityExist,
        int? DestinationStateExist,
        int? DestinationZipExist,
        int? DestinationCountryExist,
        int? PickUpDateExist)
        GetShipmentHeaderExistValues(decimal? ShipmentId);

        (int? PackageExists,
        int? PackageTypeExists,
        int? PackageTypeDimensionUMExists,
        int? PackageTypeLengthExists,
        int? PackageTypeWidthExists,
        int? PackageTypeHeightExists,
        int? PackageTypePackagingWeightUMExists,
        int? PackageTypePackagingWeightExists,
        int? ItemUnitWeightExists,
        int? ItemWeightUnitsExists,
        int? PackageTypeWeightUMExists,
        int? PackageTypeWeightExists)
        GetShipmentLinesExistValues(decimal? ShipmentId);
    }

    public class GetFreightRateShopRequestCRUD : IGetFreightRateShopRequestCRUD
    {
        ICollectionLoadRequestFactory collectionLoadRequestFactory;
        ICollectionLoadStatementRequestFactory collectionLoadStatementRequestFactory;
        IApplicationDB appDB;
        IRecordCollectionToDataTable recordCollectionToDataTable;
        IExistsChecker existsChecker;

        public GetFreightRateShopRequestCRUD(ICollectionLoadRequestFactory collectionLoadRequestFactory, IApplicationDB appDB, IRecordCollectionToDataTable recordCollectionToDataTable, ICollectionLoadStatementRequestFactory collectionLoadStatementRequestFactory, IExistsChecker existsChecker)
        {
            this.collectionLoadRequestFactory = collectionLoadRequestFactory;
            this.recordCollectionToDataTable = recordCollectionToDataTable;
            this.collectionLoadStatementRequestFactory = collectionLoadStatementRequestFactory;
            this.appDB = appDB;
            this.existsChecker = existsChecker;
        }


        public string GetScac(string shipVia)
        {
            StringType _ShipViaCode = DBNull.Value;
            string ShipViaCode = null;

            #region CRUD LoadToVariable
            var shipcodeLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                {
                    {_ShipViaCode,"ship_code"},
                },
                loadForChange: false,
                lockingType: LockingType.None,
                maximumRows: 1,
                tableName: "shipcode",
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause("ship_code = {0}", shipVia),
                orderByClause: collectionLoadRequestFactory.Clause("ship_code"));
            var shipcodeLoadResponse = this.appDB.Load(shipcodeLoadRequest);
            if (shipcodeLoadResponse.Items.Count > 0)
            {
                ShipViaCode = _ShipViaCode;
            }
            #endregion  LoadToVariable

            return ShipViaCode;
        }

        public (string TransportationMode, string RoadTransportationType) GetTransportationMode(string shipVia)
        {
            StringType _TransportationMode = DBNull.Value;
            string TransportationMode = null;
            StringType _RoadTransportationType = DBNull.Value;
            string RoadTransportationType = null;
            #region CRUD LoadToVariable
            var shipcodeLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                {
                    {_TransportationMode,"transport"},
                    {_RoadTransportationType,"road_transport_type"},
                },
                loadForChange: false,
                lockingType: LockingType.None,
                maximumRows: 1,
                tableName: "shipcode",
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause("ship_code = {0}", shipVia),
                orderByClause: collectionLoadRequestFactory.Clause("ship_code"));
            var shipcodeLoadResponse = this.appDB.Load(shipcodeLoadRequest);
            if (shipcodeLoadResponse.Items.Count > 0)
            {
                TransportationMode = _TransportationMode;
                RoadTransportationType = _RoadTransportationType;
            }
            #endregion  LoadToVariable

            return (TransportationMode, RoadTransportationType);
        }

        public
        (
            string OriginCity,
            string OriginState,
            string OriginZip,
            string OriginCountry,
            string DestinationCity,
            string DestinationState,
            string DestinationZip,
            string DestinationCountry,
            DateTime? PickupDate,
            string WeightUM
        )
        ShipmentHeader(decimal? ShipmentId)
        {

            CityType _OriginCity = DBNull.Value;
            StateType _OriginState = DBNull.Value;
            PostalCodeType _OriginZip = DBNull.Value;
            CountryType _OriginCountry = DBNull.Value;
            CityType _DestinationCity = DBNull.Value;
            StateType _DestinationState = DBNull.Value;
            PostalCodeType _DestinationZip = DBNull.Value;
            CountryType _DestinationCountry = DBNull.Value;
            DateType _PickupDate = DBNull.Value;
            UMType _WeightUM = DBNull.Value;

            string OriginCity = null;
            string OriginState = null;
            string OriginZip = null;
            string OriginCountry = null;
            string DestinationCity = null;
            string DestinationState = null;
            string DestinationZip = null;
            string DestinationCountry = null;
            DateTime? PickupDate = null;
            string WeightUM = null;

            #region CRUD LoadToVariable
            var shipcodeLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                {
                    {_OriginCity,"whse.city"},
                    {_OriginState,"whse.state"},
                    {_OriginZip,"whse.zip"},
                    {_OriginCountry,"oc.iso_country_code"},
                    {_DestinationCity,"custaddr.city"},
                    {_DestinationState,"custaddr.state"},
                    {_DestinationZip,"custaddr.zip"},
                    {_DestinationCountry,"dc.iso_country_code"},
                    {_PickupDate,"shipment.pickup_date"},
                    {_WeightUM,"shipment.weight_u_m"}
                },
                loadForChange: false,
                lockingType: LockingType.None,
                maximumRows: 1,
                tableName: "shipment",
                fromClause: collectionLoadRequestFactory.Clause("LEFT JOIN whse ON shipment.whse = whse.whse " +
                                                                "LEFT JOIN custaddr ON shipment.cust_num =custaddr.cust_num AND shipment.cust_seq =custaddr.cust_seq " +
                                                                "LEFT JOIN country oc on whse.country = oc.country " +
                                                                "LEFT JOIN country dc on custaddr.country = dc.country "),
                whereClause: collectionLoadRequestFactory.Clause("shipment_id = {0}", ShipmentId),
                orderByClause: collectionLoadRequestFactory.Clause("ship_code"));
            var shipcodeLoadResponse = this.appDB.Load(shipcodeLoadRequest);
            if (shipcodeLoadResponse.Items.Count > 0)
            {
                OriginCity = _OriginCity;
                OriginState = _OriginState;
                OriginZip = _OriginZip;
                OriginCountry = _OriginCountry;
                DestinationCity = _DestinationCity;
                DestinationState = _DestinationState;
                DestinationZip = _DestinationZip;
                DestinationCountry = _DestinationCountry;
                PickupDate = _PickupDate;
                WeightUM = _WeightUM;
            }
            #endregion  LoadToVariable

            return (OriginCity,
                    OriginState,
                    OriginZip,
                    OriginCountry,
                    DestinationCity,
                    DestinationState,
                    DestinationZip,
                    DestinationCountry,
                    PickupDate,
                    WeightUM);

        }

        public ICollectionLoadResponse ShipmentPackage(decimal? ShipmentId)
        {
            #region CRUD LoadToRecord
            var ShipmentLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
            {
                {"PackageId"," shipment_package.package_id"},
                {"PackageType"," shipment_package.package_type"},
                {"DimensionUM","package_type.dimension_u_m"},
                {"Length","package_type.length"},
                {"Width","package_type.width"},
                {"Height","package_type.height"},
                {"Weight","shipment_package.weight"},
                {"WeightUM","shipment.weight_u_m"},
                {"NMFC","ISNULL(shipment_package.nmfc,'999999')"},
                {"FreightClass","ISNULL(shipment_package.freight_class,'55')"}
            },
            loadForChange: false,
            lockingType: LockingType.None,
            tableName: "shipment_package",
            fromClause: collectionLoadRequestFactory.Clause("LEFT JOIN package_type ON package_type.package_type = shipment_package.package_type LEFT JOIN shipment ON shipment.shipment_id = shipment_package.shipment_id"),
            whereClause: collectionLoadRequestFactory.Clause("shipment_package.shipment_id={0}", ShipmentId),
            orderByClause: collectionLoadRequestFactory.Clause("package_id"));
            var ShipmentLoadResponse = this.appDB.Load(ShipmentLoadRequest);
            #endregion  LoadToRecord

            return ShipmentLoadResponse;

        }

        public int? GetItemCountByShipmentPackage(decimal? ShipmentId, int? PackageTypeId)
        {
            IntType _ItemCount = DBNull.Value;
            int? ItemCount = null;

            #region CRUD LoadToVariable
            var shipcodeLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                {
                    {_ItemCount,"COUNT(*)"},
                },
                loadForChange: false,
                lockingType: LockingType.None,
                maximumRows: 1,
                tableName: "shipment_seq",
                whereClause: collectionLoadRequestFactory.Clause("shipment_id = {0} AND package_id={1}", ShipmentId, PackageTypeId));
            var shipcodeLoadResponse = this.appDB.Load(shipcodeLoadRequest);
            if (shipcodeLoadResponse.Items.Count > 0)
            {
                ItemCount = _ItemCount;
            }
            #endregion  LoadToVariable


            return ItemCount;
        }

        public ICollectionLoadResponse ShipmentPackageByItem(decimal? ShipmentId)
        {
            #region CRUD LoadToRecord
            var ShipmentLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
            {
                {"PackageType","item.package_type"},
                {"DimensionUM","package_type.dimension_u_m"},
                {"Length","package_type.length"},
                {"Width","package_type.width"},
                {"Height","package_type.height"},
                {"Weight","package_type.weight.packaging_weight"},
                {"WeightUM","package_type.packaging_weight_u_m"}
            },
            loadForChange: false,
            lockingType: LockingType.None,
            tableName: "shipment_line",
            fromClause: collectionLoadRequestFactory.Clause("LEFT OUTER JOIN coitem ON shipment_line.ref_num = coitem.co_num AND shipment_line.ref_line_suf = coitem.co_line AND shipment_line.ref_release = coitem.co_release LEFT OUTER JOIN item ON item.item = coitem.item"),
            whereClause: collectionLoadRequestFactory.Clause("shipment_package.shipment_id={0}", ShipmentId),
            orderByClause: collectionLoadRequestFactory.Clause(""));
            var ShipmentLoadResponse = this.appDB.Load(ShipmentLoadRequest);
            #endregion  LoadToRecord

            return ShipmentLoadResponse;

        }

        public ICollectionLoadResponse ShipmentCommodities(decimal? ShipmentId, int? PackageIdFrom, int? PackageIdTo)
        {
            #region CRUD LoadArbitrary
            var shipmentLoadRequest = collectionLoadStatementRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                    {
                        {"CommodityCode","item.national_motor_freight_class"},
                        {"ClassCode","item.freight_class"},
                        {"UnitWeight","SUM(item.unit_weight)"},
                        {"WeightUM","item.weight_units"},
                        {"QtyOrdered","SUM(coitem.qty_ordered)"},
                        {"QtyOrderedUM","coitem.u_m"}
                    },
                selectStatement: collectionLoadRequestFactory.Clause(@"SELECT 
                                                                            @selectList
                                                                        FROM shipment_line
                                                                        LEFT OUTER JOIN coitem ON 
                                                                            shipment_line.ref_num = coitem.co_num 
                                                                            AND shipment_line.ref_line_suf = coitem.co_line 
                                                                            AND shipment_line.ref_release = coitem.co_release
                                                                        LEFT OUTER JOIN shipment_seq ON
                                                                            shipment_line.shipment_id=shipment_seq.shipment_id
                                                                            AND shipment_line.shipment_line=shipment_seq.shipment_line
                                                                        LEFT OUTER JOIN item ON item.item = coitem.item
                                                                        WHERE shipment_line.shipment_id ={0} AND shipment_seq.package_id BETWEEN {1} AND {2} 
                                                                        GROUP BY
                                                                        item.national_motor_freight_class,
                                                                        item.freight_class,
                                                                        item.weight_units,
                                                                        coitem.u_m", ShipmentId, PackageIdFrom, PackageIdTo));

            var shipmentLoadResponse = this.appDB.Load(shipmentLoadRequest);
            #endregion  LoadArbitrary

            return shipmentLoadResponse;

        }

        public
       (
           string OriginCity,
           string OriginState,
           string OriginZip,
           string OriginCountry,
           string DestinationCity,
           string DestinationState,
           string DestinationZip,
           string DestinationCountry,
           DateTime? PickupDate,
           decimal? Weight,
           int? PackageQty
       ) GetShipmentCOHeader(string CustNum, string CoNum)
        {
            CityType _OriginCity = DBNull.Value;
            StateType _OriginState = DBNull.Value;
            PostalCodeType _OriginZip = DBNull.Value;
            CountryType _OriginCountry = DBNull.Value;
            CityType _DestinationCity = DBNull.Value;
            StateType _DestinationState = DBNull.Value;
            PostalCodeType _DestinationZip = DBNull.Value;
            CountryType _DestinationCountry = DBNull.Value;
            DateType _PickupDate = DBNull.Value;
            TotalWeightType _Weight = DBNull.Value;
            PackagesType _PackageQty = DBNull.Value;

            string OriginCity = null;
            string OriginState = null;
            string OriginZip = null;
            string OriginCountry = null;
            string DestinationCity = null;
            string DestinationState = null;
            string DestinationZip = null;
            string DestinationCountry = null;
            DateTime? PickupDate = null;
            decimal? Weight = null;
            int? PackageQty = null;

            #region CRUD LoadToVariable
            var shipcodeLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                {
                    {_OriginCity,"whse.city"},
                    {_OriginState, "whse.state" },
                    {_OriginZip, "whse.zip" },
                    {_OriginCountry, "oc.iso_country_code" },
                    {_DestinationCity, "custaddr.city" },
                    {_DestinationState, "custaddr.state" },
                    {_DestinationZip, "custaddr.zip" },
                    {_DestinationCountry, "dc.iso_country_code" },
                    {_PickupDate, "co.order_date" },
                    {_Weight, "co.weight" },
                    {_PackageQty, "co.qty_packages" },

                },
                loadForChange: false,
                lockingType: LockingType.None,
                maximumRows: 1,
                tableName: "co",
                fromClause: collectionLoadRequestFactory.Clause("left outer join whse on co.whse = whse.whse " +
                                                            "left outer join custaddr on co.cust_num = custaddr.cust_num  AND co.cust_seq=custaddr.cust_seq " +
                                                            "left outer join country oc on whse.country = oc.country " +
                                                            "left outer join country dc on custaddr.country = dc.country "),
                whereClause: collectionLoadRequestFactory.Clause("co.co_num = {0} and co.cust_num = {1}", CoNum, CustNum),
                orderByClause: collectionLoadRequestFactory.Clause(""));

            var shipcodeLoadResponse = this.appDB.Load(shipcodeLoadRequest);
            if (shipcodeLoadResponse.Items.Count > 0)
            {
                OriginCity = _OriginCity;
                OriginState = _OriginState;
                OriginZip = _OriginZip;
                OriginCountry = _OriginCountry;
                DestinationCity = _DestinationCity;
                DestinationState = _DestinationState;
                DestinationZip = _DestinationZip;
                DestinationCountry = _DestinationCountry;
                PickupDate = _PickupDate;
                Weight = _Weight;
                PackageQty = _PackageQty;
            }
            #endregion  LoadToVariable

            return (OriginCity,
                    OriginState,
                    OriginZip,
                    OriginCountry,
                    DestinationCity,
                    DestinationState,
                    DestinationZip,
                    DestinationCountry,
                    PickupDate,
                    Weight,
                    PackageQty);

        }

        public ICollectionLoadResponse GetShipmentCOPackage(string CustNum, string CoNum)
        {
            #region CRUD LoadArbitrary
            var shipmentLoadRequest = collectionLoadStatementRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                    {
                        {"Item","coitem.item"},
                        {"QtyOrdered","SUM(coitem.qty_ordered)"},
                        {"Code","item.package_type"},
                        {"MaxQty","item.package_type_max_qty"},
                        {"DimensionUM", "package_type.dimension_u_m" },
                        {"Length", "package_type.length" },
                        {"Width", "package_type.width" },
                        {"Height", "package_type.height" },
                        {"PackageWeightValue", "package_type.weight" },
                        {"PackageWeightUM", "package_type.weight_u_m" },
                        {"PackagingWeightValue", "package_type.packaging_weight" },
                        {"PackagingWeightUM", "package_type.packaging_weight_u_m" },
                        {"ItemUnitWeightUM", "item.weight_units" },
                        {"ItemUnitWeightValue", "item.unit_weight" },
                        {"NMFC", "item.national_motor_freight_class" },
                        {"FreightClass", "item.freight_class" },
                    },
                selectStatement: collectionLoadRequestFactory.Clause(@"SELECT 
                                                                        @selectList
                                                                    FROM coitem
                                                                    LEFT OUTER JOIN co ON
                                                                        coitem.co_num=co.co_num
                                                                    LEFT OUTER JOIN item ON
                                                                         coitem.item=item.item
                                                                    LEFT OUTER JOIN package_type ON
                                                                         item.package_type=package_type.package_type
                                                                    WHERE coitem.co_num = {0} AND co.cust_num={1}
                                                                    GROUP BY 
                                                                        coitem.item,
                                                                        item.package_type,
                                                                        package_type.length,
                                                                        package_type.width,
                                                                        package_type.height,
                                                                        package_type.weight,
                                                                        package_type.dimension_u_m,
                                                                        package_type.weight_u_m,
                                                                        package_type.packaging_weight,
                                                                        package_type.packaging_weight_u_m,
                                                                        item.package_type_max_qty,
                                                                        item.weight_units,
                                                                        item.unit_weight,
                                                                        item.national_motor_freight_class,
                                                                        item.freight_class 
                                                                    ORDER BY coitem.item,
                                                                             item.package_type", CoNum, CustNum));

            var shipmentLoadResponse = this.appDB.Load(shipmentLoadRequest);
            #endregion  LoadArbitrary

            return shipmentLoadResponse;
        }

        public ICollectionLoadResponse GetShipmentCOCommodities(string CustNum, string CoNum)
        {
            #region CRUD LoadToRecord
            var shipmentCOCommoditiesLoadRequest = collectionLoadStatementRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                    {
                        {"CommodityCode","item.comm_code"},
                        {"ClassCode","LEFT(item.comm_code,2)"},
                        {"UnitWeight","SUM(item.unit_weight)"},
                        {"WeightUM","item.weight_units"},
                        {"QtyOrdered","SUM(coitem.qty_ordered)"},
                        {"QtyOrderedUM","coitem.u_m"}
                    },
               selectStatement: collectionLoadRequestFactory.Clause(@"SELECT @selectList
                                                                        FROM coitem
                                                                        LEFT OUTER JOIN item ON item.item = coitem.item
                                                                        LEFT OUTER JOIN co ON co.co_num = coitem.co_num
                                                                        WHERE co.co_num ={0} AND co.cust_num = {1}
                                                                                    GROUP BY
                                                                        item.comm_code,
                                                                        item.weight_units,
                                                                        coitem.u_m", CoNum, CustNum));
            var shipmentCOCommoditesLoadResponse = this.appDB.Load(shipmentCOCommoditiesLoadRequest);
            #endregion  LoadToRecord

            return shipmentCOCommoditesLoadResponse;
        }

        public string GetCOParmsDuePeriod()
        {
            StringType _DuePeriod = DBNull.Value;
            string DuePeriod = null;

            #region CRUD LoadToVariable
            var coparmsLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                {
                    {_DuePeriod,"due_period"},
                },
                loadForChange: false,
                lockingType: LockingType.None,
                maximumRows: 1,
                tableName: "coparms",
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause(""),
                orderByClause: collectionLoadRequestFactory.Clause(""));
            var coparmsLoadResponse = this.appDB.Load(coparmsLoadRequest);
            if (coparmsLoadResponse.Items.Count > 0)
            {
                DuePeriod = _DuePeriod;
            }
            #endregion  LoadToVariable

            return DuePeriod;
        }

        public (string ShipmentWeightUM, string ShipmentDimensionUM) GetInvparmsShipmentUM()
        {
            StringType _ShipmentWeightUM = DBNull.Value;
            string ShipmentWeightUM = null;

            StringType _ShipmentDimensionUM = DBNull.Value;
            string ShipmentDimensionUM = null;

            #region CRUD LoadToVariable
            var coparmsLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                {
                    {_ShipmentWeightUM,"shipment_weight_u_m"},
                    {_ShipmentDimensionUM,"shipment_package_dimension_u_m"},
                },
                loadForChange: false,
                lockingType: LockingType.None,
                maximumRows: 1,
                tableName: "invparms",
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause(""),
                orderByClause: collectionLoadRequestFactory.Clause(""));
            var coparmsLoadResponse = this.appDB.Load(coparmsLoadRequest);
            if (coparmsLoadResponse.Items.Count > 0)
            {
                ShipmentWeightUM = _ShipmentWeightUM;
                ShipmentDimensionUM = _ShipmentDimensionUM;
            }
            #endregion  LoadToVariable

            return (ShipmentWeightUM, ShipmentDimensionUM);
        }


        public (int? OriginCityExist,
        int? OriginStateExist,
        int? OriginZipExist,
        int? OriginCountryExist,
        int? DestinationCityExist,
        int? DestinationStateExist,
        int? DestinationZipExist,
        int? DestinationCountryExist,
        int? PickUpDateExist)
        GetShipmentHeaderExistValues(decimal? ShipmentId)
        {
            ListYesNoType _OriginCityExist = DBNull.Value;
            ListYesNoType _OriginStateExist = DBNull.Value;
            ListYesNoType _OriginZipExist = DBNull.Value;
            ListYesNoType _OriginCountryExist = DBNull.Value;
            ListYesNoType _DestinationCityExist = DBNull.Value;
            ListYesNoType _DestinationStateExist = DBNull.Value;
            ListYesNoType _DestinationZipExist = DBNull.Value;
            ListYesNoType _DestinationCountryExist = DBNull.Value;
            ListYesNoType _OrderDateExist = DBNull.Value;
            int? OriginCityExist = null;
            int? OriginStateExist = null;
            int? OriginZipExist = null;
            int? OriginCountryExist = null;
            int? DestinationCityExist = null;
            int? DestinationStateExist = null;
            int? DestinationZipExist = null;
            int? DestinationCountryExist = null;
            int? OrderDateExist = null;


            #region CRUD LoadToVariable
            var coparmsLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                {
                    {_OriginCityExist        ,"(CASE WHEN whse.city IS NULL THEN 0 ELSE 1 END)"},
                    {_OriginStateExist       ,"(CASE WHEN whse.state IS NULL THEN 0 ELSE 1 END)"},
                    {_OriginZipExist         ,"(CASE WHEN whse.zip IS NULL THEN 0 ELSE 1 END)"},
                    {_OriginCountryExist     ,"(CASE WHEN oc.iso_country_code IS NULL THEN 0 ELSE 1 END)"},
                    {_DestinationCityExist   ,"(CASE WHEN custaddr.city IS NULL THEN 0 ELSE 1 END)"},
                    {_DestinationStateExist  ,"(CASE WHEN custaddr.state IS NULL THEN 0 ELSE 1 END)"},
                    {_DestinationZipExist    ,"(CASE WHEN custaddr.zip IS NULL THEN 0 ELSE 1 END)"},
                    {_DestinationCountryExist,"(CASE WHEN dc.iso_country_code IS NULL THEN 0 ELSE 1 END)"},
                    {_OrderDateExist         ,"(CASE WHEN shipment.pickup_date IS NULL THEN 0 ELSE 1 END)"},
                },
                loadForChange: false,
                lockingType: LockingType.None,
                maximumRows: 1,
                tableName: "shipment",
                fromClause: collectionLoadRequestFactory.Clause("LEFT OUTER JOIN whse ON shipment.whse = whse.whse " +
                                                                "LEFT OUTER JOIN custaddr ON shipment.cust_num =custaddr.cust_num AND shipment.cust_seq =custaddr.cust_seq " +
                                                                "LEFT OUTER JOIN country dc on custaddr.country = dc.country LEFT OUTER JOIN country oc ON whse.country = oc.country"),
                whereClause: collectionLoadRequestFactory.Clause("shipment_id = {0}", ShipmentId),
                orderByClause: collectionLoadRequestFactory.Clause(""));
            var coparmsLoadResponse = this.appDB.Load(coparmsLoadRequest);
            if (coparmsLoadResponse.Items.Count > 0)
            {
                OriginCityExist = _OriginCityExist;
                OriginStateExist = _OriginStateExist;
                OriginZipExist = _OriginZipExist;
                OriginCountryExist = _OriginCountryExist;
                DestinationCityExist = _DestinationCityExist;
                DestinationStateExist = _DestinationStateExist;
                DestinationZipExist = _DestinationZipExist;
                DestinationCountryExist = _DestinationCountryExist;
                OrderDateExist = _OrderDateExist;
            }
            #endregion  LoadToVariable

            return (OriginCityExist,
                    OriginStateExist,
                    OriginZipExist,
                    OriginCountryExist,
                    DestinationCityExist,
                    DestinationStateExist,
                    DestinationZipExist,
                    DestinationCountryExist,
                    OrderDateExist);
        }

        public (int? PackageExists,
        int? PackageTypeExists,
        int? PackageTypeDimensionUMExists,
        int? PackageTypeLengthExists,
        int? PackageTypeWidthExists,
        int? PackageTypeHeightExists,
        int? PackageTypePackagingWeightUMExists,
        int? PackageTypePackagingWeightExists,
        int? ItemUnitWeightExists,
        int? ItemWeightUnitsExists,
        int? PackageTypeWeightUMExists,
        int? PackageTypeWeightExists)
        GetShipmentLinesExistValues(decimal? ShipmentId)
        {
            ListYesNoType _PackageExists = DBNull.Value;
            ListYesNoType _PackageTypeExists = DBNull.Value;
            ListYesNoType _PackageTypeDimensionUMExists = DBNull.Value;
            ListYesNoType _PackageTypeLengthExists = DBNull.Value;
            ListYesNoType _PackageTypeWidthExists = DBNull.Value;
            ListYesNoType _PackageTypeHeightExists = DBNull.Value;
            ListYesNoType _PackageTypePackagingWeightUMExists = DBNull.Value;
            ListYesNoType _PackageTypePackagingWeightExists = DBNull.Value;
            ListYesNoType _ItemUnitWeightExists = DBNull.Value;
            ListYesNoType _ItemWeightUnitsExists = DBNull.Value;
            ListYesNoType _PackageTypeWeightUMExists = DBNull.Value;
            ListYesNoType _PackageTypeWeightExists = DBNull.Value;

            int? PackageExists = null;
            int? PackageTypeExists = null;
            int? PackageTypeDimensionUMExists = null;
            int? PackageTypeLengthExists = null;
            int? PackageTypeWidthExists = null;
            int? PackageTypeHeightExists = null;
            int? PackageTypePackagingWeightUMExists = null;
            int? PackageTypePackagingWeightExists = null;
            int? ItemUnitWeightExists = null;
            int? ItemWeightUnitsExists = null;
            int? PackageTypeWeightUMExists = null;
            int? PackageTypeWeightExists = null;

            #region CRUD LoadToVariable
            var coparmsLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                {
                    {_PackageExists        ,"(CASE WHEN shipment_package.package_id IS NULL THEN 0 ELSE 1 END)"},
                    {_PackageTypeExists        ,"(CASE WHEN package_type.package_type IS NULL THEN 0 ELSE 1 END)"},
                    {_PackageTypeDimensionUMExists       ,"(CASE WHEN package_type.dimension_u_m IS NULL THEN 0 ELSE 1  END)"},
                    {_PackageTypeLengthExists         ,"(CASE WHEN package_type.length  = 0  THEN 0 ELSE 1  END)"},
                    {_PackageTypeWidthExists     ,"(CASE WHEN package_type.width  = 0  THEN 0 ELSE 1 END)"},
                    {_PackageTypeHeightExists   ,"(CASE WHEN package_type.height  = 0  THEN 0 ELSE 1 END)"},
                    {_PackageTypePackagingWeightUMExists  ,"(CASE WHEN package_type.packaging_weight_u_m IS NULL THEN 0 ELSE 1  END)"},
                    {_PackageTypePackagingWeightExists    ,"(CASE WHEN package_type.packaging_weight  = 0  THEN 0 ELSE 1  END)"},
                    {_PackageTypeWeightUMExists,"(CASE WHEN package_type.weight_u_m IS NULL THEN 0 ELSE 1  END)"},
                    {_PackageTypeWeightExists,"(CASE WHEN package_type.weight = 0 THEN 0 ELSE 1  END)"},
                    {_ItemUnitWeightExists         ,"(CASE WHEN item.unit_weight  = 0  THEN 0 ELSE 1 END)"},
                    {_ItemWeightUnitsExists         ,"(CASE WHEN item.weight_units IS NULL THEN 0 ELSE 1 END)"},
                },
                loadForChange: false,
                lockingType: LockingType.None,
                maximumRows: 1,
                tableName: "shipment_line",
                fromClause: collectionLoadRequestFactory.Clause("LEFT OUTER JOIN shipment_seq ON shipment_seq.shipment_id = shipment_line.shipment_id AND shipment_seq.shipment_line = shipment_line.shipment_line " +
                                                                "LEFT OUTER JOIN shipment_package ON shipment_package.shipment_id = shipment_seq.shipment_id AND shipment_package.package_id = shipment_seq.package_id " +
                                                                "LEFT OUTER JOIN package_type ON package_type.package_type = shipment_package.package_type " +
                                                                "LEFT OUTER JOIN coitem ON shipment_line.ref_num = coitem.co_num " +
                                                                    "AND shipment_line.ref_line_suf = coitem.co_line " +
                                                                    "AND shipment_line.ref_release = coitem.co_release " +
                                                                "LEFT OUTER JOIN item ON item.item = coitem.item"),
                whereClause: collectionLoadRequestFactory.Clause("(package_type.package_type IS NULL " +
                                                                    "OR package_type.dimension_u_m IS NULL " +
                                                                    "OR package_type.length  = 0  " +
                                                                    "OR package_type.width  = 0  " +
                                                                    "OR package_type.height  = 0  " +
                                                                    "OR package_type.packaging_weight_u_m IS NULL " +
                                                                    "OR package_type.packaging_weight  = 0  " +
                                                                    "OR package_type.weight_u_m IS NULL " +
                                                                    "OR package_type.weight  = 0  " +
                                                                    "OR item.unit_weight  = 0  " +
                                                                    "OR item.weight_units IS NULL) " +
                                                                    "AND shipment_line.shipment_id ={0}", ShipmentId),
                orderByClause: collectionLoadRequestFactory.Clause(""));
            var coparmsLoadResponse = this.appDB.Load(coparmsLoadRequest);
            if (coparmsLoadResponse.Items.Count > 0)
            {
                PackageExists = _PackageExists;
                PackageTypeExists = _PackageTypeExists;
                PackageTypeDimensionUMExists = _PackageTypeDimensionUMExists;
                PackageTypeLengthExists = _PackageTypeLengthExists;
                PackageTypeWidthExists = _PackageTypeWidthExists;
                PackageTypeHeightExists = _PackageTypeHeightExists;
                PackageTypePackagingWeightUMExists = _PackageTypePackagingWeightUMExists;
                PackageTypePackagingWeightExists = _PackageTypePackagingWeightExists;
                PackageTypeWeightUMExists = _PackageTypeWeightUMExists;
                PackageTypeWeightExists = _PackageTypeWeightExists;
                ItemUnitWeightExists = _ItemUnitWeightExists;
                ItemWeightUnitsExists = _ItemWeightUnitsExists;
            }
            #endregion  LoadToVariable

            return (PackageExists,
                    PackageTypeExists,
                    PackageTypeDimensionUMExists,
                    PackageTypeLengthExists,
                    PackageTypeWidthExists,
                    PackageTypeHeightExists,
                    PackageTypePackagingWeightUMExists,
                    PackageTypePackagingWeightExists,
                    ItemUnitWeightExists,
                    ItemWeightUnitsExists,
                    PackageTypeWeightUMExists,
                    PackageTypeWeightExists);
        }

        public (
                int? OriginCityExist,
                int? OriginStateExist,
                int? OriginZipExist,
                int? OriginCountryExist,
                int? DestinationCityExist,
                int? DestinationStateExist,
                int? DestinationZipExist,
                int? DestinationCountryExist,
                int? OrderDateExist
            ) GetCOHeaderExistValues(string CustNum, string CoNum)
        {
            ListYesNoType _OriginCityExist = DBNull.Value;
            ListYesNoType _OriginStateExist = DBNull.Value;
            ListYesNoType _OriginZipExist = DBNull.Value;
            ListYesNoType _OriginCountryExist = DBNull.Value;
            ListYesNoType _DestinationCityExist = DBNull.Value;
            ListYesNoType _DestinationStateExist = DBNull.Value;
            ListYesNoType _DestinationZipExist = DBNull.Value;
            ListYesNoType _DestinationCountryExist = DBNull.Value;
            ListYesNoType _OrderDateExist = DBNull.Value;
            int? OriginCityExist = null;
            int? OriginStateExist = null;
            int? OriginZipExist = null;
            int? OriginCountryExist = null;
            int? DestinationCityExist = null;
            int? DestinationStateExist = null;
            int? DestinationZipExist = null;
            int? DestinationCountryExist = null;
            int? OrderDateExist = null;


            #region CRUD LoadToVariable
            var coparmsLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                {
                    {_OriginCityExist        ,"(CASE WHEN whse.city IS NULL THEN 0 ELSE 1 END)"},
                    {_OriginStateExist       ,"(CASE WHEN whse.state IS NULL THEN 0 ELSE 1 END)"},
                    {_OriginZipExist         ,"(CASE WHEN whse.zip IS NULL THEN 0 ELSE 1 END)"},
                    {_OriginCountryExist     ,"(CASE WHEN oc.iso_country_code IS NULL THEN 0 ELSE 1 END)"},
                    {_DestinationCityExist   ,"(CASE WHEN custaddr.city IS NULL THEN 0 ELSE 1 END)"},
                    {_DestinationStateExist  ,"(CASE WHEN custaddr.state IS NULL THEN 0 ELSE 1 END)"},
                    {_DestinationZipExist    ,"(CASE WHEN custaddr.zip IS NULL THEN 0 ELSE 1 END)"},
                    {_DestinationCountryExist,"(CASE WHEN dc.iso_country_code IS NULL THEN 0 ELSE 1 END)"},
                    {_OrderDateExist         ,"(CASE WHEN co.order_date IS NULL THEN 0 ELSE 1 END)"},
                },
                loadForChange: false,
                lockingType: LockingType.None,
                maximumRows: 1,
                tableName: "co",
                fromClause: collectionLoadRequestFactory.Clause("LEFT OUTER JOIN whse ON co.whse = whse.whse " +
                                                                "LEFT OUTER JOIN country oc ON whse.country = oc.country " +
                                                                "LEFT OUTER JOIN custaddr ON co.cust_num = custaddr.cust_num " +
                                                                "LEFT OUTER JOIN country dc ON custaddr.country = dc.country "),
                whereClause: collectionLoadRequestFactory.Clause("co.co_num = {0} AND co.cust_num = {1}", CoNum, CustNum),
                orderByClause: collectionLoadRequestFactory.Clause(""));
            var coparmsLoadResponse = this.appDB.Load(coparmsLoadRequest);
            if (coparmsLoadResponse.Items.Count > 0)
            {
                OriginCityExist = _OriginCityExist;
                OriginStateExist = _OriginStateExist;
                OriginZipExist = _OriginZipExist;
                OriginCountryExist = _OriginCountryExist;
                DestinationCityExist = _DestinationCityExist;
                DestinationStateExist = _DestinationStateExist;
                DestinationZipExist = _DestinationZipExist;
                DestinationCountryExist = _DestinationCountryExist;
                OrderDateExist = _OrderDateExist;
            }
            #endregion  LoadToVariable

            return (OriginCityExist,
                    OriginStateExist,
                    OriginZipExist,
                    OriginCountryExist,
                    DestinationCityExist,
                    DestinationStateExist,
                    DestinationZipExist,
                    DestinationCountryExist,
                    OrderDateExist);
        }

        public
            (
                int? PackageTypeExists,
                int? PackageTypeDimensionUMExists,
                int? PackageTypeLengthExists,
                int? PackageTypeWidthExists,
                int? PackageTypeHeightExists,
                int? PackageTypePackagingWeightUMExists,
                int? PackageTypePackagingWeightExists,
                int? ItemUnitWeightExists,
                int? ItemWeightUnitsExists,
                int? PackageTypeWeightUMExists,
                int? PackageTypeWeightExists
            ) GetCOLinesExistValues(string CustNum, string CoNum)
        {

            ListYesNoType _PackageTypeExists = DBNull.Value;
            ListYesNoType _PackageTypeDimensionUMExists = DBNull.Value;
            ListYesNoType _PackageTypeLengthExists = DBNull.Value;
            ListYesNoType _PackageTypeWidthExists = DBNull.Value;
            ListYesNoType _PackageTypeHeightExists = DBNull.Value;
            ListYesNoType _PackageTypePackagingWeightUMExists = DBNull.Value;
            ListYesNoType _PackageTypePackagingWeightExists = DBNull.Value;
            ListYesNoType _ItemUnitWeightExists = DBNull.Value;
            ListYesNoType _ItemWeightUnitsExists = DBNull.Value;
            ListYesNoType _PackageTypeWeightUMExists = DBNull.Value;
            ListYesNoType _PackageTypeWeightExists = DBNull.Value;

            int? PackageTypeExists = null;
            int? PackageTypeDimensionUMExists = null;
            int? PackageTypeLengthExists = null;
            int? PackageTypeWidthExists = null;
            int? PackageTypeHeightExists = null;
            int? PackageTypePackagingWeightUMExists = null;
            int? PackageTypePackagingWeightExists = null;
            int? ItemUnitWeightExists = null;
            int? ItemWeightUnitsExists = null;
            int? PackageTypeWeightUMExists = null;
            int? PackageTypeWeightExists = null;

            #region CRUD LoadToVariable
            var coparmsLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                {
                    {_PackageTypeExists        ,"(CASE WHEN package_type.package_type IS NULL THEN 0 ELSE 1 END)"},
                    {_PackageTypeDimensionUMExists       ,"(CASE WHEN package_type.dimension_u_m IS NULL THEN 0 ELSE 1  END)"},
                    {_PackageTypeLengthExists         ,"(CASE WHEN package_type.length = 0 THEN 0 ELSE 1  END)"},
                    {_PackageTypeWidthExists     ,"(CASE WHEN package_type.width = 0 THEN 0 ELSE 1 END)"},
                    {_PackageTypeHeightExists   ,"(CASE WHEN package_type.height= 0 THEN 0 ELSE 1 END)"},
                    {_PackageTypePackagingWeightUMExists  ,"(CASE WHEN package_type.packaging_weight_u_m IS NULL THEN 0 ELSE 1  END)"},
                    {_PackageTypePackagingWeightExists    ,"(CASE WHEN package_type.packaging_weight = 0 THEN 0 ELSE 1  END)"},
                    {_PackageTypeWeightUMExists  ,"(CASE WHEN package_type.weight_u_m IS NULL THEN 0 ELSE 1  END)"},
                    {_PackageTypeWeightExists    ,"(CASE WHEN package_type.weight = 0 THEN 0 ELSE 1  END)"},
                    {_ItemUnitWeightExists         ,"(CASE WHEN item.unit_weight = 0 THEN 0 ELSE 1 END)"},
                    {_ItemWeightUnitsExists         ,"(CASE WHEN item.weight_units IS NULL THEN 0 ELSE 1 END)"},
                },
                loadForChange: false,
                lockingType: LockingType.None,
                maximumRows: 1,
                tableName: "coitem",
                fromClause: collectionLoadRequestFactory.Clause("LEFT OUTER JOIN item ON item.item = coitem.item " +
                                                                "LEFT OUTER JOIN co ON co.co_num = coitem.co_num " +
                                                                "LEFT OUTER JOIN package_type ON package_type.package_type = item.package_type"),
                whereClause: collectionLoadRequestFactory.Clause("(package_type.package_type IS NULL " +
                                                                    "OR package_type.dimension_u_m IS NULL " +
                                                                    "OR package_type.length =0 " +
                                                                    "OR package_type.width =0 " +
                                                                    "OR package_type.height =0 " +
                                                                    "OR package_type.packaging_weight_u_m IS NULL " +
                                                                    "OR package_type.packaging_weight=0 " +
                                                                    "OR package_type.weight_u_m IS NULL " +
                                                                    "OR package_type.weight =0 " +
                                                                    "OR item.unit_weight =0 " +
                                                                    "OR item.weight_units IS NULL) " +
                                                                    "AND co.co_num = {0} AND co.cust_num = {1}", CoNum, CustNum),
                orderByClause: collectionLoadRequestFactory.Clause(""));
            var coparmsLoadResponse = this.appDB.Load(coparmsLoadRequest);
            if (coparmsLoadResponse.Items.Count > 0)
            {
                PackageTypeExists = _PackageTypeExists;
                PackageTypeDimensionUMExists = _PackageTypeDimensionUMExists;
                PackageTypeLengthExists = _PackageTypeLengthExists;
                PackageTypeWidthExists = _PackageTypeWidthExists;
                PackageTypeHeightExists = _PackageTypeHeightExists;
                PackageTypePackagingWeightUMExists = _PackageTypePackagingWeightUMExists;
                PackageTypePackagingWeightExists = _PackageTypePackagingWeightExists;
                ItemUnitWeightExists = _ItemUnitWeightExists;
                ItemWeightUnitsExists = _ItemWeightUnitsExists;
                PackageTypeWeightUMExists = _PackageTypeWeightUMExists;
                PackageTypeWeightExists = _PackageTypeWeightExists;
            }
            #endregion  LoadToVariable

            return (PackageTypeExists,
                    PackageTypeDimensionUMExists,
                    PackageTypeLengthExists,
                    PackageTypeWidthExists,
                    PackageTypeHeightExists,
                    PackageTypePackagingWeightUMExists,
                    PackageTypePackagingWeightExists,
                    ItemUnitWeightExists,
                    ItemWeightUnitsExists,
                    PackageTypeWeightUMExists,
                    PackageTypeWeightExists);
        }


    }
}
