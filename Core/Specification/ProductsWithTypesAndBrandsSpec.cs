using System;
using System.Linq.Expressions;
using Core.Entities;

namespace Core.Specification
{
    public class ProductsWithTypesAndBrandsSpec : BaseSpecification<Product>
    {
        public ProductsWithTypesAndBrandsSpec(ProductSpecParams productParams):base(x => 
        (string.IsNullOrEmpty(productParams.Search) || x.Name.ToLower().Contains(productParams.Search)) &&
        (!productParams.BrandId.HasValue || x.ProductBrandId==productParams.BrandId) 
        && (!productParams.TypeId.HasValue || x.ProductTypeId==productParams.TypeId))
        {
            AddInclude(x=>x.ProductType);
            AddInclude(x=>x.ProductBrand);
            AddOrderBy(x=>x.Name);
            AddPaging(productParams.PageSize * (productParams.PageIndex -1), productParams.PageSize);

            if(!string.IsNullOrEmpty(productParams.Sort))
            {
                switch(productParams.Sort)
                {
                    case "priceAsc":
                    AddOrderBy(x=>x.Price);
                    break;

                    case "priceDsc":
                    AddOrderByDescending(x=>x.Price);
                    break;

                    default:
                    AddOrderBy(x=>x.Name);
                    break;
                }
            }
        }

         public ProductsWithTypesAndBrandsSpec(int id):base(x=>x.Id==id)
        {
            AddInclude(x=>x.ProductType);
            AddInclude(x=>x.ProductBrand);
        }
    }
}