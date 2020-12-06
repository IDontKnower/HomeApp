using AutoMapper;
using HomeApp.WebApi.Contexts.ShoppingList;
using HomeApp.WebApi.DTO.ShoppingList;

namespace HomeApp.WebApi.Mappers
{
    public class ShoppingListProfile: Profile
    {
        public ShoppingListProfile()
        {
            CreateMap<Product, ProductCategory>()
                .ForMember(dest => dest.CategoryId,
                    source => source.MapFrom(x => x.Category.Id))
                .ForMember(dest => dest.CategoryName,
                    source => source.MapFrom(x => x.Category.Name));
            CreateMap<ProductCategory, Product>()
               // .ForMember(dest => dest.Id, source => source.Ignore())
                .ForMember(dest => dest.CategoryId, source => source.ConvertUsing(new CategoryIdConverter()));
        }
    }
    
    public class CategoryIdConverter : IValueConverter<int, int?>
    {
        public int? Convert(int source, ResolutionContext context)
            => source <= 0 ? (int?)null : source;
    }
}