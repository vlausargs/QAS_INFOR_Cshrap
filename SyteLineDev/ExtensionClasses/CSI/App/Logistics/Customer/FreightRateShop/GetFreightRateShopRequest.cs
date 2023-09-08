using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.Utilities;
using CSI.Material;
using CSI.MG;
using CSI.Serializer;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CSI.Logistics.Customer
{
    public interface IGetFreightRateShopRequest
    {
        (int severity, string infobar, ICollectionLoadResponse freightRateShopJsonRequests) Process(string Customer, string CoNum, string ShipVia, string tenantId);
        (int severity, string infobar, ICollectionLoadResponse freightRateShopJsonRequests) Process(decimal? ShipmentID, string ShipVia, string tenantId);
    }
    public class GetFreightRateShopRequest : IGetFreightRateShopRequest
    {
        #region Const Variables
        private const string tripType = "ONE WAY";
        private const string movementDirection = "I";
        private const string rateType = "AP";
        private const string selectAll = "*";
        private const int numPackagePerRateCall = 5;
        private const string dateFormat = "MM/dd/yyyy";
        private const string timeFormat = "HH:mm:ss";
        private const string uomPCS = "PCS";
        private const int numberOfPiece = 1;
        private const int decimalPlaces = 2;
        #endregion

        IMsgApp msgApp;
        IGetFreightRateShopRequestCRUD getFreightRateShopRequestCRUD;
        ISerializerFactory serializerFactory;
        IFreightRateShopRequestManager freightRateShopRequestManager;
        IFreightRateShopShipmentManager freightRateShopShipmentManager;
        IFreightRateShopShipmentCommodityManager freightRateShopShipmentCommodityManager;
        IFreightRateShopShipmentPackageManager freightRateShopShipmentPackageManager;
        IGetUMConvFactor getUMConvFactor;
        IUomConvQty uomConvQty;
        IExpandKyByType expandKyByType;
        IMathUtil mathUtil;
        ICollectionLoadBuilderRequestFactory collectionLoadBuilderRequestFactory;
        IUnionUtil unionUtil;
        IApplicationDB appDB;

        public GetFreightRateShopRequest(IMsgApp msgApp, IGetFreightRateShopRequestCRUD getFreightRateShopRequestCRUD, ISerializerFactory serializerFactory, IFreightRateShopRequestManager freightRateShopRequestManager, IFreightRateShopShipmentManager freightRateShopShipmentManager, IFreightRateShopShipmentCommodityManager freightRateShopShipmentCommodityManager, IFreightRateShopShipmentPackageManager freightRateShopShipmentPackageManager, IGetUMConvFactor getUMConvFactor, IUomConvQty uomConvQty, IExpandKyByType expandKyByType, IMathUtil mathUtil, ICollectionLoadBuilderRequestFactory collectionLoadBuilderRequestFactory, IUnionUtil unionUtil, IApplicationDB appDB)
        {
            this.msgApp = msgApp;
            this.getFreightRateShopRequestCRUD = getFreightRateShopRequestCRUD;
            this.serializerFactory = serializerFactory;
            this.freightRateShopRequestManager = freightRateShopRequestManager;
            this.freightRateShopShipmentManager = freightRateShopShipmentManager;
            this.freightRateShopShipmentCommodityManager = freightRateShopShipmentCommodityManager;
            this.freightRateShopShipmentPackageManager = freightRateShopShipmentPackageManager;
            this.getUMConvFactor = getUMConvFactor;
            this.uomConvQty = uomConvQty;
            this.expandKyByType = expandKyByType;
            this.mathUtil = mathUtil;
            this.collectionLoadBuilderRequestFactory = collectionLoadBuilderRequestFactory;
            this.unionUtil = unionUtil;
            this.appDB = appDB;
        }

        public (int severity, string infobar, ICollectionLoadResponse freightRateShopJsonRequests) Process(string Customer, string CoNum, string ShipVia, string tenantId)
        {
            int severity = 0;
            string infobar = "";
            ICollectionLoadResponse freightRateShopJsonRequests = null;

            try
            {
                (severity, infobar) = this.ValidateShipment(Customer, CoNum, ShipVia);
                if (severity != 0)
                {
                    return (severity, infobar, freightRateShopJsonRequests);
                }

                (severity, infobar, freightRateShopJsonRequests) = this.FillFreightRateShopRequest(Customer, CoNum, ShipVia, tenantId);
            }
            catch (Exception e)
            {
                severity = 16;
                infobar = e.Message;
            }

            return (severity, infobar, freightRateShopJsonRequests);
        }

        public (int severity, string infobar, ICollectionLoadResponse freightRateShopJsonRequests) Process(decimal? ShipmentID, string ShipVia, string tenantId)
        {
            int severity = 0;
            string infobar = "";
            ICollectionLoadResponse freightRateShopJsonRequests = null;

            try
            {
                (severity, infobar) = this.ValidateShipment(ShipmentID);
                if (severity != 0)
                {
                    return (severity, infobar, freightRateShopJsonRequests);
                }

                (severity, infobar, freightRateShopJsonRequests) = this.FillFreightRateShopRequest(ShipmentID, ShipVia, tenantId);
                if (severity != 0)
                {
                    return (severity, infobar, freightRateShopJsonRequests);
                }
            }
            catch (Exception e)
            {
                severity = 16;
                infobar = e.Message;
            }

            return (severity, infobar, freightRateShopJsonRequests);
        }

        private (int severity, string infobar, ICollectionLoadResponse FreightRateShopRequests) FillFreightRateShopRequest(string Customer, string CoNum, string ShipVia, string tenantId)
        {
            #region Variables
            int severity = 0;
            string infobar = "";
            int PackageCount = 0;
            decimal totalShipmentWeightValue = 0M;
            string shipmentTotalQuantityUOM = uomPCS;
            int packageIdFrom = 0;
            int packageIdTo = 0;
            int tblShipmentCOPackagesCount = 0;
            ICollectionLoadResponse freightRateShopJsonRequests = null;
            #endregion

            string custNum = expandKyByType.ExpandKyByTypeFn("CustNumType", Customer);
            string coNum = expandKyByType.ExpandKyByTypeFn("CoNumType", CoNum);
            string Company = tenantId;
            string rateOwner = Company;
            string referenceNumber = coNum;
            string sourceSystem = Company;

            var serializer = serializerFactory.Create(SerializerType.NewtonConvert);

            var carrierCodes = this.FillCarrierCodes(ShipVia);
            freightRateShopRequestManager.AddFreightRateShopCarrierCodes(carrierCodes);

            var modes = this.FillTransportationModes(ShipVia);
            freightRateShopRequestManager.AddFreightRateShopModes(modes);

            this.FillEquipmentType();

            //Get Shipment Records
            var shipmentHeader = getFreightRateShopRequestCRUD.GetShipmentCOHeader(custNum, coNum);

            var origin = this.FillShipmentOrigin(
                shipmentHeader.OriginCity,
                shipmentHeader.OriginState,
                shipmentHeader.OriginZip,
                shipmentHeader.OriginCountry);

            var destination = FillShipmentDestination(
                shipmentHeader.DestinationCity,
                shipmentHeader.DestinationState,
                shipmentHeader.DestinationZip,
                shipmentHeader.DestinationCountry);

            DateTime orderDate =shipmentHeader.PickupDate ?? DateTime.Now;
            DateTime dueDate = orderDate.AddDays(Convert.ToDouble(getFreightRateShopRequestCRUD.GetCOParmsDuePeriod()));
            var pickUpDateTime = this.FillPickUpDateTime(dueDate);

            //Get CO Packages
            var shipmentUMs = getFreightRateShopRequestCRUD.GetInvparmsShipmentUM();
            string shipmentWeightUOM = shipmentUMs.ShipmentWeightUM;
            string shipmentDimensionUOM = shipmentUMs.ShipmentDimensionUM;

            var cOPackages = this.CreateCOPackages(custNum, coNum, shipmentWeightUOM);
            if (cOPackages.severity != 0)
            {
                severity = cOPackages.severity;
                infobar = cOPackages.infobar;
                return (severity, infobar, freightRateShopJsonRequests);
            }
            var tblShipmentCOPackages = cOPackages.coPackages;

            foreach (var tblShipmentCOPackage in tblShipmentCOPackages.Items)
            {
                PackageCount += 1;
                tblShipmentCOPackagesCount += 1;
                if (PackageCount == 1)
                { packageIdFrom = tblShipmentCOPackage.GetValue<int>("PackageId"); }

                //Shipment Packages
                var shipmentPackages = this.FillShipmentPackage(
                    tblShipmentCOPackage.GetValue<string>("PackageType"),
                    tblShipmentCOPackage.GetValue<string>("DimensionUM"),
                    tblShipmentCOPackage.GetValue<decimal>("Length"),
                    tblShipmentCOPackage.GetValue<decimal>("Width"),
                    tblShipmentCOPackage.GetValue<decimal>("Height"),
                    shipmentDimensionUOM,
                    tblShipmentCOPackage.GetValue<string>("WeightUM"),
                    tblShipmentCOPackage.GetValue<decimal>("Weight"),
                    shipmentWeightUOM);
                if (shipmentPackages.severity != 0)
                {
                    severity = shipmentPackages.severity;
                    infobar = shipmentPackages.infobar;
                    return (severity, infobar, freightRateShopJsonRequests);
                }
                totalShipmentWeightValue += shipmentPackages.freightRateShopShipmentPackages.PackageWeight.Value;

                freightRateShopShipmentManager.AddIFreightRateShopShipmentPackages(shipmentPackages.freightRateShopShipmentPackages);

                if ((PackageCount == numPackagePerRateCall && tblShipmentCOPackages.Items.Count >= numPackagePerRateCall) ||
                    (tblShipmentCOPackagesCount == tblShipmentCOPackages.Items.Count))
                {
                    packageIdTo = tblShipmentCOPackage.GetValue<int>("PackageId");

                    //Create Commodities
                    int sequence = 0;

                    var coCommodity = tblShipmentCOPackages.Items
                        .Where(x => x.GetValue<int>("PackageId") >= packageIdFrom && x.GetValue<int>("PackageId") <= packageIdTo)
                        .GroupBy(x => new
                        {
                            NMFC = x.GetValue<string>("NMFC"),
                            FreightClass = x.GetValue<string>("FreightClass"),
                            CommodityWeightUOM = x.GetValue<string>("WeightUM")
                        })
                        .Select(x => new
                        {
                            x.Key.NMFC,
                            x.Key.FreightClass,
                            CommodityCount = x.Count(),
                            CommodityWeight = x.Sum(y => y.GetValue<decimal>("Weight")),
                            x.Key.CommodityWeightUOM
                        });

                    foreach (var coCommodityRows in coCommodity)
                    {
                        sequence += 1;
                        var shipmentCommodity = this.FillShipmentCommodity(
                                sequence,
                                coCommodityRows.NMFC,
                                coCommodityRows.FreightClass,
                                coCommodityRows.CommodityWeightUOM,
                                coCommodityRows.CommodityWeight,
                                uomPCS,
                                coCommodityRows.CommodityCount,
                                shipmentWeightUOM);
                        if (shipmentCommodity.severity != 0)
                        {
                            severity = shipmentCommodity.severity;
                            infobar = shipmentCommodity.infobar;
                            return (severity, infobar, freightRateShopJsonRequests);
                        }
                        freightRateShopShipmentManager.AddIFreightRateShopShipmentCommodities(shipmentCommodity.freightRateShopShipmentCommodity);
                    }
                    sequence = 0;

                    var shipmentTotalQuantity = freightRateShopShipmentManager.CreateFreightRateShopShipmentTotalQuantity(shipmentTotalQuantityUOM, PackageCount);

                    var shipmentTotalWeight = freightRateShopShipmentManager.CreateFreightRateShopShipmentTotalWeight(shipmentWeightUOM, totalShipmentWeightValue);

                    var shipment = freightRateShopShipmentManager.GetFreightRateShopShipment(origin, destination, pickUpDateTime, shipmentTotalWeight, shipmentTotalQuantity);

                    var freightRateShopRequest = freightRateShopRequestManager.GetFreightRateShopRequest(rateOwner, tripType, movementDirection, rateType, referenceNumber, sourceSystem, shipment);

                    var nonTableLoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
                        {
                            {"freightRateShopRequest", serializer.Serialize<IFreightRateShopRequest>(freightRateShopRequest)}
                        });

                    var nonTableLoadResponse = this.appDB.Load(nonTableLoadRequest);
                    unionUtil.Add(nonTableLoadResponse);

                    PackageCount = 0; 
                    totalShipmentWeightValue = 0M;

                    freightRateShopShipmentManager.ClearFreightRateShopShipmentPackages();
                    freightRateShopShipmentManager.ClearFreightRateShopShipmentCommodities();
                }
            }
            freightRateShopJsonRequests = unionUtil.Process();
            unionUtil.Clear();

            return (severity,infobar,freightRateShopJsonRequests);
        }
        private (int severity,string infobar, ICollectionLoadResponse FreightRateShopRequests) FillFreightRateShopRequest(decimal? ShipmentID, string ShipVia, string tenantId)
        {

            #region Variable Declaration
            int severity = 0;
            string infobar = "";
            string shipmentWeightUOM;
            decimal shipmentWeightValue = 0M;
            string shipmentTotalQuantityUOM = uomPCS;
            int totalShipmentQuantityValue = 0;
            int sequence = 0;
            int PackageCount = 0;
            int? packageIdFrom = 0;
            int? packageIdTo = 0;
            int tblShipmentCOPackagesCount = 0;
            ICollectionLoadResponse freightRateShopJsonRequests = null;
            #endregion Variable Declaration

            var serializer = serializerFactory.Create(SerializerType.NewtonConvert);
            string Company = tenantId;
            string rateOwner = Company;
            string referenceNumber = Convert.ToString(ShipmentID);
            string sourceSystem = Company;

            var carrierCodes=this.FillCarrierCodes(ShipVia);
            freightRateShopRequestManager.AddFreightRateShopCarrierCodes(carrierCodes);

            var modes =this.FillTransportationModes(ShipVia);
            freightRateShopRequestManager.AddFreightRateShopModes(modes);

            this.FillEquipmentType();

            //Get Shipment Records
            var shipmentHeader = getFreightRateShopRequestCRUD.ShipmentHeader(ShipmentID);

            var origin = this.FillShipmentOrigin(
                shipmentHeader.OriginCity, 
                shipmentHeader.OriginState,
                shipmentHeader.OriginZip, 
                shipmentHeader.OriginCountry);

            var destination = FillShipmentDestination(
                shipmentHeader.DestinationCity,
                shipmentHeader.DestinationState,
                shipmentHeader.DestinationZip,
                shipmentHeader.DestinationCountry);

            var pickUpDateTime = this.FillPickUpDateTime(shipmentHeader.PickupDate);

            //Get Shipment Package Records
            var tblShipmentPackage = getFreightRateShopRequestCRUD.ShipmentPackage(ShipmentID);

            //Assign UOM for Shipment Total Weight and Quantity
            shipmentWeightUOM = shipmentHeader.WeightUM;
            string shipmentDimensionUOM = getFreightRateShopRequestCRUD.GetInvparmsShipmentUM().ShipmentDimensionUM; 

            foreach (var tblShipmentPackageRow in tblShipmentPackage.Items)
            {
                tblShipmentCOPackagesCount += 1;
                PackageCount += 1;
                if (PackageCount == 1)
                { packageIdFrom = tblShipmentPackageRow.GetValue<int>("PackageId"); }

                //Shipment Packages
                var shipmentPackages = this.FillShipmentPackage(
                    tblShipmentPackageRow.GetValue<string>("PackageType"),
                    tblShipmentPackageRow.GetValue<string>("DimensionUM"),
                    tblShipmentPackageRow.GetValue<decimal>("Length"),
                    tblShipmentPackageRow.GetValue<decimal>("Width"),
                    tblShipmentPackageRow.GetValue<decimal>("Height"),
                    shipmentDimensionUOM,
                    tblShipmentPackageRow.GetValue<string>("WeightUM"),
                    tblShipmentPackageRow.GetValue<decimal>("Weight"),
                    shipmentWeightUOM);

                if (shipmentPackages.severity != 0)
                {
                    severity = shipmentPackages.severity;
                    infobar = shipmentPackages.infobar;
                    return (severity, infobar, freightRateShopJsonRequests);
                }

                shipmentWeightValue += shipmentPackages.freightRateShopShipmentPackages.PackageWeight.Value;
                freightRateShopShipmentManager.AddIFreightRateShopShipmentPackages(shipmentPackages.freightRateShopShipmentPackages);

                if ((PackageCount == numPackagePerRateCall && tblShipmentPackage.Items.Count >= numPackagePerRateCall) || (tblShipmentCOPackagesCount == tblShipmentPackage.Items.Count))
                {
                    packageIdTo = tblShipmentPackageRow.GetValue<int>("PackageId");

                    //Get Shipment Commodity Records
                    var coCommodity = tblShipmentPackage.Items
                                         .Where(x => x.GetValue<int>("PackageId") >= packageIdFrom && x.GetValue<int>("PackageId") <= packageIdTo)
                                         .GroupBy(x => new
                                         {
                                             NMFC = x.GetValue<string>("NMFC"),
                                             FreightClass = x.GetValue<string>("FreightClass"),
                                             CommodityWeightUOM = x.GetValue<string>("WeightUM")
                                         })
                                         .Select(x => new
                                         {
                                             x.Key.NMFC,
                                             x.Key.FreightClass,
                                             CommodityCount = x.Count(),
                                             CommodityWeight = x.Sum(y => y.GetValue<decimal>("Weight")),
                                             x.Key.CommodityWeightUOM
                                         });

                    foreach (var coCommodityRows in coCommodity)
                    {
                        sequence += 1;
                        var shipmentCommodity = this.FillShipmentCommodity(
                                                        sequence,
                                                        coCommodityRows.NMFC,
                                                        coCommodityRows.FreightClass,
                                                        coCommodityRows.CommodityWeightUOM,
                                                        coCommodityRows.CommodityWeight,
                                                        uomPCS,
                                                        coCommodityRows.CommodityCount,
                                                        shipmentWeightUOM);

                        if (shipmentCommodity.severity != 0)
                        {
                            severity = shipmentCommodity.severity;
                            infobar = shipmentCommodity.infobar;
                            return (severity, infobar, freightRateShopJsonRequests);
                        }

                        freightRateShopShipmentManager.AddIFreightRateShopShipmentCommodities(shipmentCommodity.freightRateShopShipmentCommodity); //Add commodity to shipment    
                    }
                    sequence = 0;

                    //Shipment Total Weight
                    var shipmentTotalWeight = freightRateShopShipmentManager.CreateFreightRateShopShipmentTotalWeight(shipmentWeightUOM, shipmentWeightValue);

                    //Shipment Total Quantity
                    totalShipmentQuantityValue = PackageCount;
                    var shipmentTotalQuantity = freightRateShopShipmentManager.CreateFreightRateShopShipmentTotalQuantity(shipmentTotalQuantityUOM, totalShipmentQuantityValue);

                    var shipment = freightRateShopShipmentManager.GetFreightRateShopShipment(origin, destination, pickUpDateTime, shipmentTotalWeight, shipmentTotalQuantity);
                    var freightRateShopRequest = freightRateShopRequestManager.GetFreightRateShopRequest(rateOwner, tripType, movementDirection, rateType, referenceNumber, sourceSystem, shipment);

                    var nonTableLoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
                        {
                            {"freightRateShopRequest", serializer.Serialize<IFreightRateShopRequest>(freightRateShopRequest)}
                        });

                    var nonTableLoadResponse = this.appDB.Load(nonTableLoadRequest);

                    unionUtil.Add(nonTableLoadResponse);
                    PackageCount = 0;
                    shipmentWeightValue = 0M;

                    freightRateShopShipmentManager.ClearFreightRateShopShipmentPackages();
                    freightRateShopShipmentManager.ClearFreightRateShopShipmentCommodities();
                }

            }

            freightRateShopJsonRequests = unionUtil.Process();
            return (severity, infobar, freightRateShopJsonRequests);
        }
        private (int Severity, string InfoBar) ValidateShipment(string Customer, string CoNum, string ShipVia)
        {
            int severity = 0;
            string infobar = "";

            Customer = expandKyByType.ExpandKyByTypeFn("CustNumType", Customer);
            CoNum = expandKyByType.ExpandKyByTypeFn("CoNumType", CoNum);

            var cOHeaderExistValues = getFreightRateShopRequestCRUD.GetCOHeaderExistValues(Customer,CoNum);
            var cOLinesExistValues  = getFreightRateShopRequestCRUD.GetCOLinesExistValues(Customer, CoNum);

            if (cOHeaderExistValues.OriginCityExist == 0)
            {
                return (severity, infobar) = msgApp.MsgAppSp(infobar, "E=IsRequired", "@vrtx_post_head.sfcity");
            }
            else if (cOHeaderExistValues.OriginStateExist == 0)
            {
                return (severity, infobar) = msgApp.MsgAppSp(infobar, "E=IsRequired", "@vrtx_post_head.sfstate");
            }
            else if (cOHeaderExistValues.OriginZipExist == 0)
            {
                return (severity, infobar) = msgApp.MsgAppSp(infobar, "E=IsRequired", "@vrtx_post_head.sfzip");
            }
            else if (cOHeaderExistValues.OriginCountryExist == 0)
            {
                return (severity, infobar) = msgApp.MsgAppSp(infobar, "E=IsRequired", "@!ShipFromCountryCode");
            }
            else if (cOHeaderExistValues.DestinationCityExist == 0)
            {
                return (severity, infobar) = msgApp.MsgAppSp(infobar, "E=IsRequired", "@vrtx_post_head.stcity");
            }
            else if (cOHeaderExistValues.DestinationStateExist == 0)
            {
                return (severity, infobar) = msgApp.MsgAppSp(infobar, "E=IsRequired", "@vrtx_post_head.ststate");
            }
            else if (cOHeaderExistValues.DestinationZipExist == 0)
            {
                return (severity, infobar) = msgApp.MsgAppSp(infobar, "E=IsRequired", "@vrtx_post_head.stzip");
            }
            else if (cOHeaderExistValues.DestinationCountryExist == 0)
            {
                return (severity, infobar) = msgApp.MsgAppSp(infobar, "E=IsRequired", "@!ShipToCountryCode");
            }
            else if (cOLinesExistValues.PackageTypeExists == 0)
            {
                return (severity, infobar) = msgApp.MsgAppSp(infobar, "E=IsRequired2", "@package_type.package_type");
            }
            else if (cOLinesExistValues.PackageTypeDimensionUMExists == 0)
            {
                return (severity, infobar) = msgApp.MsgAppSp(infobar, "E=IsRequired2", "@package_type.dimension_u_m");
            }
            else if (cOLinesExistValues.PackageTypeLengthExists == 0)
            {
                return (severity, infobar) = msgApp.MsgAppSp(infobar, "E=IsRequired2", "@package_type.length");
            }
            else if (cOLinesExistValues.PackageTypeWidthExists == 0)
            {
                return (severity, infobar) = msgApp.MsgAppSp(infobar, "E=IsRequired2", "@package_type.width");
            }
            else if (cOLinesExistValues.PackageTypeHeightExists == 0)
            {
                return (severity, infobar) = msgApp.MsgAppSp(infobar, "E=IsRequired2", "@package_type.height");
            }
            else if (cOLinesExistValues.PackageTypePackagingWeightUMExists == 0)
            {
                return (severity, infobar) = msgApp.MsgAppSp(infobar, "E=IsRequired2", "@package_type.packaging_weight_u_m");
            }
            else if (cOLinesExistValues.PackageTypePackagingWeightExists == 0)
            {
                return (severity, infobar) = msgApp.MsgAppSp(infobar, "E=IsRequired2", "@package_type.packaging_weight");
            }
            else if (cOLinesExistValues.PackageTypeWeightUMExists == 0)
            {
                return (severity, infobar) = msgApp.MsgAppSp(infobar, "E=IsRequired2", "@package_type.weight_u_m");
            }
            else if (cOLinesExistValues.PackageTypeWeightExists == 0)
            {
                return (severity, infobar) = msgApp.MsgAppSp(infobar, "E=IsRequired2", "@package_type.weight");
            }
            else if (cOLinesExistValues.ItemUnitWeightExists == 0)
            {
                return (severity, infobar) = msgApp.MsgAppSp(infobar, "E=IsRequired2", "@item.unit_weight");
            }
            else if (cOLinesExistValues.ItemWeightUnitsExists == 0)
            {
                return (severity, infobar) = msgApp.MsgAppSp(infobar, "E=IsRequired2", "@item.weight_units");
            }
            else
            {
                return (severity, infobar);
            }
        }
        private (int Severity, string InfoBar) ValidateShipment(decimal? ShipmentID)
        {
            int severity = 0;
            string infobar = "";

            var shipmentHeaderExistValues = getFreightRateShopRequestCRUD.GetShipmentHeaderExistValues(ShipmentID);
            var shipmentLinesExistValues = getFreightRateShopRequestCRUD.GetShipmentLinesExistValues(ShipmentID);

            if (shipmentHeaderExistValues.OriginCityExist==0) //Header
            {
                return (severity, infobar) = msgApp.MsgAppSp(infobar, "E=IsRequired", "@vrtx_post_head.sfcity");
            }
            else if (shipmentHeaderExistValues.OriginStateExist == 0)
            {
                return (severity, infobar) = msgApp.MsgAppSp(infobar, "E=IsRequired", "@vrtx_post_head.sfstate");
            }
            else if (shipmentHeaderExistValues.OriginZipExist == 0)
            {
                return (severity, infobar) = msgApp.MsgAppSp(infobar, "E=IsRequired", "@vrtx_post_head.sfzip");
            }
            else if (shipmentHeaderExistValues.OriginCountryExist == 0) 
            {
                return (severity, infobar) = msgApp.MsgAppSp(infobar, "E=IsRequired", "@!ShipFromCountryCode");
            }
            else if (shipmentHeaderExistValues.DestinationCityExist == 0)
            {
                return (severity, infobar) = msgApp.MsgAppSp(infobar, "E=IsRequired", "@vrtx_post_head.stcity");
            }
            else if (shipmentHeaderExistValues.DestinationStateExist == 0)
            {
                return (severity, infobar) = msgApp.MsgAppSp(infobar, "E=IsRequired", "@vrtx_post_head.ststate");
            }
            else if (shipmentHeaderExistValues.DestinationZipExist == 0)
            {
                return (severity, infobar) = msgApp.MsgAppSp(infobar, "E=IsRequired", "@vrtx_post_head.stzip");
            }
            else if (shipmentHeaderExistValues.DestinationCountryExist == 0)
            {
                return (severity, infobar) = msgApp.MsgAppSp(infobar, "E=IsRequired", "@!ShipToCountryCode");
            }
            else if (shipmentHeaderExistValues.PickUpDateExist == 0)
            {
                return (severity, infobar) = msgApp.MsgAppSp(infobar, "E=IsRequired", "@edi_bol.pickup_date");
            }
            else if (shipmentLinesExistValues.PackageExists==0)
            {
                return (severity, infobar) = msgApp.MsgAppSp(infobar, "E=IsRequired", "@!Package");
            }
            else if (shipmentLinesExistValues.PackageTypeExists == 0) //Line
            {
                return (severity, infobar) = msgApp.MsgAppSp(infobar, "E=IsRequired2", "@package_type.package_type");
            }
            else if (shipmentLinesExistValues.PackageTypeLengthExists == 0)
            {
                return (severity, infobar) = msgApp.MsgAppSp(infobar, "E=IsRequired2", "@package_type.length");
            }
            else if (shipmentLinesExistValues.PackageTypeWidthExists == 0)
            {
                return (severity, infobar) = msgApp.MsgAppSp(infobar, "E=IsRequired2", "@package_type.width");
            }
            else if (shipmentLinesExistValues.PackageTypeHeightExists == 0)
            {
                return (severity, infobar) = msgApp.MsgAppSp(infobar, "E=IsRequired2", "@package_type.height");
            }
            else if (shipmentLinesExistValues.PackageTypeDimensionUMExists == 0)
            {
                return (severity, infobar) = msgApp.MsgAppSp(infobar, "E=IsRequired2", "@package_type.dimension_u_m");
            }
            else if (shipmentLinesExistValues.PackageTypePackagingWeightExists == 0)
            {
                return (severity, infobar) = msgApp.MsgAppSp(infobar, "E=IsRequired2", "@package_type.packaging_weight");
            }
            else if (shipmentLinesExistValues.PackageTypePackagingWeightUMExists == 0)
            {
                return (severity, infobar) = msgApp.MsgAppSp(infobar, "E=IsRequired2", "@package_type.packaging_weight_u_m");
            }
            else if (shipmentLinesExistValues.PackageTypeWeightExists == 0)
            {
                return (severity, infobar) = msgApp.MsgAppSp(infobar, "E=IsRequired2", "@package_type.weight");
            }
            else if (shipmentLinesExistValues.PackageTypeWeightUMExists == 0)
            {
                return (severity, infobar) = msgApp.MsgAppSp(infobar, "E=IsRequired2", "@package_type.weight_u_m");
            }
            else
            {
                return (severity, infobar);
            }
        }
        private string GetFreightRateShopTransportMode(string transportMode, string roadTransportType)
        {
            string freightRateShopTransportMode = "";

            switch (transportMode)
            {
                case "1":
                    freightRateShopTransportMode = "Ocean";
                    break;
                case "2":
                    freightRateShopTransportMode = "Rail";
                    break;
                case "3":
                    switch (roadTransportType)
                    {
                        case "A":
                            freightRateShopTransportMode = "LTL";
                            break;
                        case "B":
                            freightRateShopTransportMode = "SMALL PARCEL";
                            break;
                        case "C":
                            freightRateShopTransportMode = "Truck";
                            break;
                        default:
                            freightRateShopTransportMode = selectAll;
                            break;
                    }
                    break;
                case "4":
                    freightRateShopTransportMode = "Air";
                    break;
                default:
                    freightRateShopTransportMode = selectAll;
                    break;
            }


            return freightRateShopTransportMode;
        }
        private (int severity, string infobar, ICollectionLoadResponse coPackages) CreateCOPackages(string custNum, string coNum, string shipmentWeightUOM)
        {
            int severity = 0;
            string infobar = "";
            ICollectionLoadResponse data = null;
            var tblShipmentCOPackages = getFreightRateShopRequestCRUD.GetShipmentCOPackage(custNum, coNum);
            decimal packageWeightValue = 0M;
            decimal packagingWeightValue = 0M;
            decimal itemWeightValue = 0M;
            decimal totalWeightValue = 0M;
            string nMFC = "";
            string freightClass = "";
            foreach (var tblShipmentCOPackage in tblShipmentCOPackages.Items)
            {

                decimal maxQty = tblShipmentCOPackage.GetValue<decimal>("MaxQty");
                decimal orderedQty = tblShipmentCOPackage.GetValue<decimal>("QtyOrdered"); ;
                decimal itemCount = 0;
                decimal packageId = 0;

                packageWeightValue = tblShipmentCOPackage.GetValue<decimal>("PackageWeightValue");
                packagingWeightValue = tblShipmentCOPackage.GetValue<decimal>("PackagingWeightValue");
                for (decimal x = 1; x <= orderedQty; x++)
                {
                    itemCount += 1;


                    itemWeightValue += tblShipmentCOPackage.GetValue<decimal>("ItemUnitWeightValue");

                    if (maxQty <= itemCount || x == orderedQty)
                    {
                        packageId += 1;

                        //convert UM based on shipment_weight_u_m on invparms
                        var packageWeight = ConvertToFreightRateShopUOM(packageWeightValue, tblShipmentCOPackage.GetValue<string>("PackageWeightUM"), shipmentWeightUOM);
                        if (packageWeight.severity != 0)
                        {
                            severity = packageWeight.severity;
                            infobar = packageWeight.infobar;
                            return (severity, infobar, data);
                        }
                        decimal packageWeightValueConv = packageWeight.convValue;

                        var itemUnitWeight = ConvertToFreightRateShopUOM(itemWeightValue, tblShipmentCOPackage.GetValue<string>("ItemUnitWeightUM"), shipmentWeightUOM);
                        if (itemUnitWeight.severity != 0)
                        {
                            severity = itemUnitWeight.severity;
                            infobar = itemUnitWeight.infobar;
                            return (severity, infobar, data);
                        }
                        decimal itemUnitWeightValueConv = itemUnitWeight.convValue;

                        var packagingtWeight = ConvertToFreightRateShopUOM(packagingWeightValue, tblShipmentCOPackage.GetValue<string>("PackagingWeightUM"), shipmentWeightUOM);
                        if (packagingtWeight.severity != 0)
                        {
                            severity = packagingtWeight.severity;
                            infobar = packagingtWeight.infobar;
                            return (severity, infobar, data);
                        }
                        decimal packagingWeightValueConv = packagingtWeight.convValue;

                        totalWeightValue = itemUnitWeightValueConv + packageWeightValueConv + packagingWeightValueConv;

                        nMFC = tblShipmentCOPackage.GetValue<string>("NMFC");
                        freightClass = tblShipmentCOPackage.GetValue<string>("FreightClass");

                        if (string.IsNullOrEmpty(nMFC))
                        {
                            nMFC = "999999";
                        }
                        if (string.IsNullOrEmpty(freightClass))
                        {
                            freightClass = "55";
                        }

                        var nonTableLoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
                        {
                            {"PackageId",packageId},
                            {"PackageType",tblShipmentCOPackage.GetValue<string>("Code")},
                            {"DimensionUM",tblShipmentCOPackage.GetValue<string>("DimensionUM")},
                            {"Length",tblShipmentCOPackage.GetValue<decimal>("Length")},
                            {"Width",tblShipmentCOPackage.GetValue<decimal>("Width")},
                            {"Height",tblShipmentCOPackage.GetValue<decimal>("Height")},
                            {"Weight",totalWeightValue},
                            {"WeightUM",shipmentWeightUOM},
                            {"NMFC",nMFC},
                            {"FreightClass",freightClass},

                        });
                        var nonTableLoadResponse = this.appDB.Load(nonTableLoadRequest);
                        unionUtil.Add(nonTableLoadResponse);
                        itemCount = 0;
                        itemWeightValue = 0M;

                    }
                }

            }
            data = unionUtil.Process();
            unionUtil.Clear();

            return (severity,infobar,data);
        }
        private (int severity, string infobar, decimal convValue, string convUOM) ConvertToFreightRateShopUOM(decimal? Value, string UOM, string convUOM)
        {
            int severity = 0;
            string infobar = "";
            decimal convValue = 0M;
            decimal uomConvFactor;

            var mMConvFactor = getUMConvFactor.GetUMConvFactorSp(UOM, convUOM, 1, infobar);
            severity = mMConvFactor.ReturnCode ?? 0;
            infobar = mMConvFactor.Infobar;

            if (severity != 0)
            {
                return (severity, infobar, convValue, convUOM);
            }
            uomConvFactor = mMConvFactor.UomConvConvFactor.Value;

            convValue = uomConvQty.UomConvQtyFn(Value, uomConvFactor, "From Base") ?? 0;

            return (severity, infobar, convValue, convUOM);
        }
        private IFreightRateShopCarrierCodes FillCarrierCodes(string shipVia)
        {
            if (string.IsNullOrEmpty(shipVia))
            {
                shipVia = selectAll;
            }
            return freightRateShopRequestManager.CreateFreightRateShopCarrierCodes(shipVia);

        }
        private IFreightRateShopModes FillTransportationModes(string shipVia)
        {
            string mode = selectAll;
            if (!string.IsNullOrEmpty(shipVia))
            {
                var transportationModes = getFreightRateShopRequestCRUD.GetTransportationMode(shipVia);
                mode = this.GetFreightRateShopTransportMode(transportationModes.TransportationMode,
                   transportationModes.RoadTransportationType);
            }

            return freightRateShopRequestManager.CreateFreightRateShopModes(mode);

        }
        private void FillEquipmentType()
        {
            string equipmentTypes = selectAll;
            var equipmentType = freightRateShopRequestManager.CreateFreightRateShopEquipmentTypes(equipmentTypes);
            freightRateShopRequestManager.AddFreightRateShopEquipmentTypes(equipmentType);
        }
        private IFreightRateShopShipmentOrigin FillShipmentOrigin(
        string originCity,
        string originStateProvinceCode,
        string originPostalCode,
        string originCountryCode,
        string originPObox="",
        string originStreetNumber = "",
        string originAddressLine1 = "",
        string originAddressLine2 = "",
        string originAddressLine3 = "")
        {
            var originAddress = freightRateShopShipmentManager.CreateFreightRateShopShipmentAddress(originPObox, originStreetNumber, originAddressLine1, originAddressLine2, originAddressLine3, originCity, originStateProvinceCode, originPostalCode, originCountryCode);
            return freightRateShopShipmentManager.CreateFreightRateShopShipmentOrigin(originAddress);
        }

        private IFreightRateShopShipmentDestination FillShipmentDestination(
            string destinationCity,
            string destinationStateProvinceCode,
            string destinationPostalCode,
            string destinationCountryCode,
            string destinationPObox = "",
            string destinationStreetNumber = "",
            string destinationAddressLine1 = "",
            string destinationAddressLine2 = "",
            string destinationAddressLine3 = ""
            )
        {
            var destinationAddress = freightRateShopShipmentManager.CreateFreightRateShopShipmentAddress(destinationPObox,
                destinationStreetNumber, 
                destinationAddressLine1, 
                destinationAddressLine2, 
                destinationAddressLine3, 
                destinationCity, 
                destinationStateProvinceCode, 
                destinationPostalCode, 
                destinationCountryCode);
            return freightRateShopShipmentManager.CreateFreightRateShopShipmentDestination(destinationAddress);
        }

        private IFreightRateShopShipmentPickupDateTime FillPickUpDateTime(DateTime? pickUpDateTime)
        {
            DateTime _pickUpDateTime = pickUpDateTime?? DateTime.Now;
            string date = _pickUpDateTime.ToString(dateFormat);
            string time = _pickUpDateTime.ToString(timeFormat);
            return freightRateShopShipmentManager.CreateFreightRateShopShipmentPickupDateTime(date, time);
        }

        private (int severity,string infobar,IFreightRateShopShipmentPackages freightRateShopShipmentPackages)
            FillShipmentPackage(
            string packagingTypecode,
            string dimensionUOM,
            decimal dimensionLengthValue,
            decimal dimensionWidthValue,
            decimal dimensionHeightValue,
            string shipmentDimensionUOM,
            string packageWeightUOM,
            decimal packageWeightValue,
            string shipmentWeightUOM)
        {
            int severity = 0;
            string infobar = "";
            decimal dimensionLengthValueConv = 0M;
            decimal dimensionWidthValueConv = 0M;
            decimal dimensionHeightValueConv = 0M;
            decimal packageWeightValueConv = 0M;
            IFreightRateShopShipmentPackages freightRateShopShipmentPackages = null;

            var packageType = freightRateShopShipmentPackageManager.CreateFreightRateShopShipmentPackageType(packagingTypecode);

            var dimensionLength = ConvertToFreightRateShopUOM(dimensionLengthValue, dimensionUOM, shipmentDimensionUOM);
            if (dimensionLength.severity != 0)
            {
                severity = dimensionLength.severity;
                infobar = dimensionLength.infobar;
                return (severity, infobar, freightRateShopShipmentPackages);
            }
            dimensionLengthValueConv = mathUtil.Round<decimal>(dimensionLength.convValue, decimalPlaces);

            var dimensionWidth = ConvertToFreightRateShopUOM(dimensionWidthValue, dimensionUOM, shipmentDimensionUOM);
            if (dimensionLength.severity != 0)
            {
                severity = dimensionWidth.severity;
                infobar = dimensionWidth.infobar;
                return (severity, infobar, freightRateShopShipmentPackages);
            }
            dimensionWidthValueConv = mathUtil.Round<decimal>(dimensionWidth.convValue, decimalPlaces);

            var dimensionHeight = ConvertToFreightRateShopUOM(dimensionHeightValue, dimensionUOM, shipmentDimensionUOM);
            if (dimensionLength.severity != 0)
            {
                severity = dimensionHeight.severity;
                infobar = dimensionHeight.infobar;
                return (severity, infobar, freightRateShopShipmentPackages);
            }
            dimensionHeightValueConv = mathUtil.Round<decimal>(dimensionHeight.convValue, decimalPlaces);


            var packageWeightConv = ConvertToFreightRateShopUOM(packageWeightValue, packageWeightUOM, shipmentWeightUOM);
            if (dimensionLength.severity != 0)
            {
                severity = packageWeightConv.severity;
                infobar = packageWeightConv.infobar;
                return (severity, infobar, freightRateShopShipmentPackages);
            }
            packageWeightValueConv = mathUtil.Round<decimal>(packageWeightConv.convValue, decimalPlaces);



            var packageDimension = freightRateShopShipmentPackageManager.CreateFreightRateShopShipmentPackageDimensions(shipmentDimensionUOM, dimensionLengthValueConv, dimensionWidthValueConv, dimensionHeightValueConv);
            var packageWeight = freightRateShopShipmentPackageManager.CreateFreightRateShopShipmentPackageWeight(shipmentWeightUOM, packageWeightValueConv);
            freightRateShopShipmentPackages = freightRateShopShipmentPackageManager.GetFreightRateShopShipmentPackages(packageType, packageDimension, numberOfPiece, packageWeight);

            return (severity, infobar, freightRateShopShipmentPackages);
        }

        private (int severity,string infobar,IFreightRateShopShipmentCommodities freightRateShopShipmentCommodity)
        FillShipmentCommodity(
            int sequence,
            string code,
            string classCode,
            string commodityWeightUOM,
            decimal commodityWeightValue,
            string commoditQuantityUOM,
            int commodityQuantityValue,
            string shipmentWeightUOM
            )
        {
            int severity = 0;
            string infobar = "";
            IFreightRateShopShipmentCommodities freightRateShopShipmentCommodity = null;
            decimal commodityWeightValueConv = 0M;
            if (commodityWeightUOM != shipmentWeightUOM)
            {
                var commodityWeight = ConvertToFreightRateShopUOM(commodityWeightValue, commodityWeightUOM, shipmentWeightUOM);

                if (commodityWeight.severity != 0)
                {
                    severity = commodityWeight.severity;
                    infobar = commodityWeight.infobar;
                    return (severity, infobar, freightRateShopShipmentCommodity);
                }

                commodityWeightValueConv = mathUtil.Round<decimal>(commodityWeight.convValue, decimalPlaces);
            }
            else
            {
                commodityWeightValueConv = commodityWeightValue;
            }
            freightRateShopShipmentCommodity = freightRateShopShipmentCommodityManager.GetFreightRateShopShipmentCommodity(sequence, code, classCode, shipmentWeightUOM, commodityWeightValueConv, commoditQuantityUOM, commodityQuantityValue);


            return (severity, infobar, freightRateShopShipmentCommodity);
        }


    }
}
