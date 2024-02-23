using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System;
using System.Security.Claims;
using TestProjectBackend.Data;
using TestProjectBackend.Models.DTO;
using TestProjectBackend.Models.Entities;
using TestProjectBackend.Models.Requests;

namespace TestProjectBackend.Services
{
    public interface IFakturaService
    {
        Task<List<Faktura>> GetAll();
        Task<Faktura> AddFaktura(Faktura faktura);
        Task<Faktura> GetFaktura(Guid id);
        Task<Faktura> UpdateFaktura(Guid id, Faktura faktura);
        Task<Faktura> DeleteFaktura(Guid id);
        
    }
    public class FakturaService : IFakturaService
    {
        private readonly AppDbContext _context;
        public FakturaService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Faktura> AddFaktura(Faktura faktura)
        {
            faktura.Rabat = 0;
            faktura.StavkeFakture =null;
            faktura.IznosBezPdv = 0;
            faktura.PostoRabata = 0;
            faktura.IznosSaRabatomBezPdv = 0;
            faktura.Pdv = 0;
            faktura.Ukupno = 0;

            _context.Fakture.Add(faktura);

            await _context.SaveChangesAsync();

            return faktura;
        }

        public async Task<Faktura> DeleteFaktura(Guid id)
        {
            var result = await _context.Fakture.Include(p => p.StavkeFakture).FirstOrDefaultAsync(a => a.Id == id);
            if (result != null)
            {
                _context.Fakture.Remove(result);
                await _context.SaveChangesAsync();
                return result;
            }

            return null;
           
        }

        public async Task<List<Faktura>> GetAll()
        {
            var fakture = await _context.Fakture.Include(p => p.StavkeFakture).ToListAsync();

            foreach(var faktura in fakture)
            {
                foreach (var stavka in faktura.StavkeFakture)
                {
                    faktura.IznosBezPdv += stavka.IznosBezPdv;
                    faktura.PostoRabata += stavka.PostoRabata;
                    faktura.Rabat += stavka.Rabat;
                    faktura.IznosSaRabatomBezPdv += stavka.IznosSaRabatomBezPdv;
                    faktura.Pdv += stavka.Pdv;
                    faktura.Ukupno += stavka.Ukupno;
                }
            }
            return fakture;
           
        }

        public async Task<Faktura> GetFaktura(Guid id)
        {
            var faktura = await _context.Fakture.Include(p => p.StavkeFakture).FirstOrDefaultAsync(p => p.Id == id);
            if (faktura == null)
            {
                throw new Exception("There is not faktura for ID:" + id);
            }

            foreach(var stavka in faktura.StavkeFakture)
            {
                faktura.IznosBezPdv += stavka.IznosBezPdv;
                faktura.PostoRabata += stavka.PostoRabata;
                faktura.Rabat += stavka.Rabat;
                faktura.IznosSaRabatomBezPdv += stavka.IznosSaRabatomBezPdv;
                faktura.Pdv += stavka.Pdv;
                faktura.Ukupno += stavka.Ukupno;
            }

            return faktura;

        }

        public async Task<Faktura> UpdateFaktura(Guid id, Faktura novaFaktura)
        {
            var faktura = await _context.Fakture.FirstOrDefaultAsync(p => p.Id == id);
            if (faktura == null)
            {
                throw new Exception("There is no faktura with ID:" + id);
            }
            faktura.Broj = novaFaktura.Broj;
            faktura.Datum = novaFaktura.Datum;
            faktura.Partner = novaFaktura.Partner;
            _context.Fakture.Update(faktura);
            await _context.SaveChangesAsync();

            return novaFaktura;

        }
    }
}
