﻿using System;

using AutoMapper;

using Contoso.Domain.Models;
using Contoso.DataSource.Dtos;

//https://www.cnblogs.com/jiguixin/archive/2011/09/19/2181521.html
//https://github.com/AutoMapper

namespace Contoso.DataSource.AutoMapper
{
    public class AutoMapperProfileConfiguration : Profile
    {
        public AutoMapperProfileConfiguration()
        {
            //Order => OrderDto
            CreateMap<Order, OrderDto>()
                .ForMember(dto => dto.Status, (map) => map.MapFrom(m => (Contoso.DataSource.Dtos.OrderStatus)Enum.Parse(typeof(Contoso.DataSource.Dtos.OrderStatus), m.Status.ToString())))
                .ForMember(dto => dto.BillingAddress, (map) => map.MapFrom(m => m.DetailedOrder.BillingAddress))
                .ForMember(dto => dto.ShippingAddress, (map) => map.MapFrom(m => m.DetailedOrder.ShippingAddress))
                .ForMember(dto => dto.Version, (map) => map.MapFrom(m => m.DetailedOrder.Version));

            //OrderDto => Order
            CreateMap<OrderDto, Order>()
                .ForMember(m => m.Status, (map) => map.MapFrom(dto => (Contoso.Domain.Models.OrderStatus)Enum.Parse(typeof(Contoso.Domain.Models.OrderStatus), dto.Status.ToString())))
                .ForPath(m => m.DetailedOrder.BillingAddress, (map) => map.MapFrom(dto => dto.BillingAddress))
                .ForPath(m => m.DetailedOrder.ShippingAddress, (map) => map.MapFrom(dto => dto.ShippingAddress))
                .ForPath(m => m.DetailedOrder.Status, (map) => map.MapFrom(dto => (Contoso.Domain.Models.OrderStatus)Enum.Parse(typeof(Contoso.Domain.Models.OrderStatus), dto.Status.ToString())))
                .ForPath(m => m.DetailedOrder.Version, dto => dto.Ignore());

            //SaleOrder => SaleOrderDto
            CreateMap<SaleOrder, SaleOrderDto>()
                .ForMember(dto => dto.CustomerId, (map) => map.MapFrom(m => m.CustomerName))
                .ForMember(dto => dto.Status, (map) => map.MapFrom(m => (Contoso.DataSource.Dtos.OrderStatus)Enum.Parse(typeof(Contoso.DataSource.Dtos.OrderStatus), m.Status.ToString())))
                .ForMember(dto => dto.OrderLineItems, (map) => map.MapFrom(m => m.OrderItems))
                .ForMember(dto => dto.TotalCostExcludeTax, m => m.Ignore())
                .ForMember(dto => dto.TotalCostTax, m => m.Ignore())
                .ForMember(dto => dto.TotalCostIncludeTax, m => m.Ignore())
                .ForMember(dto => dto.BillingAddressCity, (map) => map.MapFrom(m => m.Addresses.BillingAddress.City))
                .ForMember(dto => dto.BillingAddressStreet, (map) => map.MapFrom(m => m.Addresses.BillingAddress.Street))
                .ForMember(dto => dto.ShippingAddressCity, (map) => map.MapFrom(m => m.Addresses.ShippingAddress.City))
                .ForMember(dto => dto.ShippingAddressStreet, (map) => map.MapFrom(m => m.Addresses.ShippingAddress.Street));

            //SaleOrderItem => SaleOrderLineItemDto
            CreateMap<SaleOrderItem, SaleOrderLineItemDto>()
               .ForMember(dto => dto.UnitPriceIncludeTax, m => m.Ignore())
               .ForMember(dto => dto.TotalCostExcludeTax, m => m.Ignore())
               .ForMember(dto => dto.TotalCostTax, m => m.Ignore())
               .ForMember(dto => dto.TotalCostIncludeTax, m => m.Ignore());

            ////SaleOrderDto => SaleOrder
            CreateMap<SaleOrderDto, SaleOrder>()
                .ForMember(m => m.CustomerName, (map) => map.MapFrom(dto => dto.CustomerId))
                .ForMember(m => m.Status, (map) => map.MapFrom(dto => (Contoso.Domain.Models.OrderStatus)Enum.Parse(typeof(Contoso.Domain.Models.OrderStatus), dto.Status.ToString())))
                .ForMember(m => m.OrderItems, (map) => map.MapFrom(dto => dto.OrderLineItems))
                .ForMember(m => m.TotalCostExcludeTax, dto => dto.Ignore())
                .ForMember(m => m.TotalCostTax, dto => dto.Ignore())
                .ForMember(m => m.TotalCostIncludeTax, dto => dto.Ignore())
                .ForPath(m => m.Addresses.BillingAddress, (map) => map.MapFrom(dto => new StreetAddress() { City = dto.BillingAddressCity, Street = dto.BillingAddressStreet}))
                .ForPath(m => m.Addresses.ShippingAddress, (map) => map.MapFrom(dto => new StreetAddress() { City = dto.ShippingAddressCity, Street = dto.ShippingAddressStreet}));

            //SaleOrderLineItemDto => SaleOrderItem
            CreateMap<SaleOrderLineItemDto, SaleOrderItem>()
                .ForMember(m => m.UnitPriceIncludeTax, dto => dto.Ignore())
                .ForMember(m => m.TotalCostExcludeTax, dto => dto.Ignore())
                .ForMember(m => m.TotalCostTax, dto => dto.Ignore())
                .ForMember(m => m.TotalCostIncludeTax, dto => dto.Ignore());
        }
    }
}
