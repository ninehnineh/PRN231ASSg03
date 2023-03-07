using AutoMapper;
using BusinessObject.Entities;
using DTO.CategoryDTOs;
using DTO.OrderDetailDTOs;
using DTO.OrderDTOs;
using DTO.ProductDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region Product Mapping
            CreateMap<Product, ProductListDto>().ReverseMap();
            CreateMap<Product, ProductDetailsDto>().ReverseMap();
            CreateMap<Product, UpdateProductQuantityDto>().ReverseMap();
            CreateMap<Product, CreateProductDto>().ReverseMap();
            CreateMap<Product, UpdateProductDto>().ReverseMap();
            #endregion

            #region Order Mapping
            CreateMap<Order, CreateOrderDto>().ReverseMap();
            CreateMap<Order, OrderListDto>().ReverseMap();
            #endregion

            #region OrderDetail Mapping
            CreateMap<OrderDetail, CreateOrderDetailDto>().ReverseMap();
            CreateMap<OrderDetail, ListOrderDetailDto>().ReverseMap();
            #endregion

            #region Category Mapping
            CreateMap<Category, CategoryDto>().ReverseMap();
            #endregion
        }
    }
}
