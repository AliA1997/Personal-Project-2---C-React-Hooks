using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using Garago.Services.Service.GarageSales;
using Garago.Services.ViewModels.GarageSale;

namespace Garago.Web.Controllers
{
    [Route("api/garage_sales")]
    [ApiController]
    public class GarageSalesController : ControllerBase
    {
        private IGarageSaleService _garageSaleService;

        public GarageSalesController(IGarageSaleService garageSaleService)
        {
            _garageSaleService = garageSaleService;
        }
        // GET api/values
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var garageSalesToReturn = await _garageSaleService.GetGarageSales();
            return Ok(garageSalesToReturn);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {

            var garageSaleToReturn = await _garageSaleService.GetGarageSale(id);
                
            return Ok(garageSaleToReturn);

        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] GarageSaleVM garageSaleForm)
        {
            var garageSaleToReturn = await _garageSaleService.CreateGarageSale(garageSaleForm);
            return Ok(garageSaleToReturn);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] GarageSaleVM garageSaleForm)
        {
            string message = await _garageSaleService.UpdateGarageSale(id, garageSaleForm);
            return Ok(message);
        }

        [HttpPatch("{id}/update_location")]
        public async Task<IActionResult> UpdateLocation(Guid id,[FromBody] LocationVM newLocation)
        {
            string locationToUpdate = JsonConvert.SerializeObject(newLocation);

            GarageSaleVM garageSaleToUpdate = await _garageSaleService.GetGarageSale(id);

            garageSaleToUpdate.Location = locationToUpdate;

            string message = await _garageSaleService.UpdateGarageSale(id, garageSaleToUpdate);

            return Ok(message);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            string message = await _garageSaleService.DeleteGarageSale(id);

            return Ok(message);
        }
    }
}
