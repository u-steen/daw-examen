using AutoMapper;
using webapi.Dto.Client;
using webapi.Dto.Comanda;
using webapi.Dto.Produs;
using webapi.Models;

namespace webapi;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Produs, ProdusDto>();
        CreateMap<CreateProdusDto, Produs>();
        CreateMap<Comanda, ComandaDto>();
        CreateMap<CreateComandaDto, Comanda>();
        CreateMap<Client, ClientDto>();
        CreateMap<CreateClientDto, Client>();
    }
}