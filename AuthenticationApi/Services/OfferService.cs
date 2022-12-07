

using AuthenticationApi.Db;
using AuthenticationApi.Dtos;
using AuthenticationApi.Entities;
using AutoMapper;

namespace AuthenticationApi.Services
{
    public class OfferService : Repository<Offer>, IOffer
    {
        private AppDbContext _appdbcontext;
        private readonly IMapper _mapper;

        public OfferService(AppDbContext appdbcontext, IMapper mapper) : base(appdbcontext)
        {
        _appdbcontext = appdbcontext;
            _mapper = mapper;
        }

        public IEnumerable<Offer> GetAllOffers()
        {
            return FindAll()
                              .OrderBy(ow => ow.price)
                              .ToList();
        }

        public void OfferCreate(OfferCreation model)
        {
            var offer = _mapper.Map<Offer>(model);
            Create(offer);
        _appdbcontext.SaveChanges();
        }

        public void DeleteOffer(int id)
        {
            var offers = _appDbContext.Offers?.Find(id);
            if (offers == null)
                throw new KeyNotFoundException($"Ponuda s {id} nije pronađena u bazi podataka");
            Delete(offers);
            _appDbContext.SaveChanges();
        }

        public void UpdateOffer(int id, OfferUpdate model)
        {
            var offer = _appdbcontext.Offers?.Find(id);
            if (offer == null)
                throw new KeyNotFoundException($"Ponuda s {id} nije pronađena u bazi podataka");
            offer.price = model.price;
            _mapper.Map(model, offer);

            Update(offer);
        _appdbcontext.SaveChanges();
        }
    }
}

