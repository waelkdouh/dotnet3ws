using Microsoft.AspNetCore.Mvc;
using MyShuttle.Data;
using MyShuttle.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace MyShuttle.API.Controllers
{
    [NoCacheFilter]
    public class DriversController : ControllerBase
    {
        IDriverRepository _driverRepository;
        private const int DefaultCarrierID = 0;

        public DriversController(IDriverRepository driverRepository)
        {
            _driverRepository = driverRepository;
        }

        public async Task<Driver> Get(int id)
        {
            return await _driverRepository.GetAsync(DefaultCarrierID, id);
        }

        [ActionName("search")]
        public async Task<IEnumerable<Driver>> Get(string filter, int pageSize, int pageCount)
        {
            if (String.IsNullOrEmpty(filter))
                filter = string.Empty;

            return await _driverRepository.GetDriversAsync(DefaultCarrierID, filter, pageSize, pageCount);
        }

        [ActionName("filter")]
        public async Task<IEnumerable<Driver>> GetDriversFilter()
        {
            return await _driverRepository.GetDriversFilterAsync(DefaultCarrierID);
        }

        [ActionName("count")]
        public async Task<int> GetCount(string filter)
        {
            if (String.IsNullOrEmpty(filter))
                filter = string.Empty;

            return await _driverRepository.GetCountAsync(DefaultCarrierID, filter);
        }

        [HttpPost]
        public async Task<int> Post([FromBody]Driver driver)
        {
            driver.CarrierId = DefaultCarrierID;
            return await _driverRepository.AddAsync(driver);
        }

        [HttpPut]
        public async Task Put([FromBody]Driver driver)
        {
            driver.CarrierId = DefaultCarrierID;
            await _driverRepository.UpdateAsync(driver);
        }

        [HttpDelete]
        public async Task Delete(int id)
        {
            await _driverRepository.DeleteAsync(id);
        }

    }
}
