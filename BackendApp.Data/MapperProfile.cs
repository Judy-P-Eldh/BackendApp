using AutoMapper;
using BackendApp.Core.DTOs;
using BackendApp.Core.Enteties;

namespace BackendApp.Data;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<Account, AccountDto>().ReverseMap();
        CreateMap<Transaction, TransactionDto>().ReverseMap();
        CreateMap<TransactionRequest, TransactionRequestDto>().ReverseMap();
    }
}
