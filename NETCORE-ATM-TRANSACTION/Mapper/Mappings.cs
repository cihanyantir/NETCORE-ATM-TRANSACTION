using AutoMapper;
using NETCORE_ATM_TRANSACTION.Repository.Models;
using NETCORE_ATM_TRANSACTION.Repository.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETCORE_ATM_TRANSACTION.Mapper
{
    public class Mappings : Profile
    {
        public Mappings()
        {
            CreateMap<Account, AccountDTO>().ReverseMap();
            CreateMap<Account, AccountCreateDTO>().ReverseMap();
            CreateMap<Account, AccountUpdateDTO>().ReverseMap();
            CreateMap<Customer, CustomerDTO>().ReverseMap();
            CreateMap<Customer, CustomerUpdateDTO>().ReverseMap();
            CreateMap<Customer, CustomerCreateDTO>().ReverseMap();
        }
    }
}
