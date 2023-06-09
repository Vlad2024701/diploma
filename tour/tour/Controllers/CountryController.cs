﻿using diploma.Db.Tour;
using diploma.Db.Tour.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Data.Entity;
using System.Net;
using tour.TourRepositories.IRepositories;
using tour.TourRepositories.Repositories;

namespace tour.Controllers
{
    [ApiController]
    [Route("api/country")]

    public class CountryController : ControllerBase
    {
        private readonly ILogger<CountryController> _logger;
        private readonly ICountryRepository countryRepository;

        public CountryController(ILogger<CountryController> logger, ICountryRepository countryRepository)
        {
            this.countryRepository = countryRepository;
            _logger = logger;
        }

        [HttpGet]
        [Route("GetCountries")]
        [ProducesResponseType(typeof(List<Country>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public IActionResult GetCities()
        {
            try
            {
                var countries = countryRepository.GetAll();
                if (countries != null)
                    return Ok(countries);
                else
                    throw new Exception();
            }
            catch (Exception ex)
            {
                return BadRequest($"Message: {ex.Message}");
            }
        }

        [HttpPost]
        [Route("AddCountry")]
        [ProducesResponseType(typeof(Country), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public IActionResult AddCountry(Country country)
        {
            try
            {
                var newCountry = countryRepository.AddCountry(country);
                return Ok(newCountry);
            }
            catch (Exception ex)
            {
                return BadRequest($"Message: {ex.Message}");
            }
        }
        [HttpDelete]
        [Route("deleteCountry")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public IActionResult DeleteHotel(int id)
        {
            try
            {
                var country = countryRepository.DeleteCountry(id);
                return Ok(country);
            }
            catch (Exception ex)
            {
                return BadRequest($"Message: {ex.Message}");
            }
        }
    }
}


