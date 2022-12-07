using AuthenticationApi.Db;
using AuthenticationApi.Dtos;
using AuthenticationApi.Entities;
using AutoMapper;
using System;

namespace AuthenticationApi.Services
{
    public class Service_OfferService : Repository<Service_Offer>, IService_Offer
    {
        private AppDbContext _appdbcontext;
        private readonly IMapper _mapper;
        public Service_OfferService(AppDbContext appDbContext, IMapper mapper) : base(appDbContext)
        {
            _appdbcontext = appDbContext;
            _mapper = mapper;
        }

        public List<Service_Offer> DeleteService_Offer(int id)
        {
            return FindAll()
                                     .OrderBy(ow => ow.offerid)
                                     .ToList();
        }

        public IEnumerable<Service_Offer> GetAllService_Offer()
        {
            return FindAll()
                                          .OrderBy(ow => ow.offerid)
                                          .ToList();
        }

        public void Service_OfferCreate(Service_OfferCreation model)
        {
            var services = _mapper.Map<Service_Offer>(model);
            Create(services);
            _appdbcontext.SaveChanges();
        }

        public void UpdateService_Offer(int id, Service_OfferUpdate model)
        {
            var services = _appdbcontext.Service_offers?.Find(id);
            if (services == null)
                throw new KeyNotFoundException($"Usluga na ponudi s {id} nije pronađena u bazi podataka");
            services.offerid = model.offerid;
            _mapper.Map(model, services);
            Update(services);
            _appdbcontext.SaveChanges();
        }
    }
}
