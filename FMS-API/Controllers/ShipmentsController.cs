using AutoMapper;
using Domain.Models;
using FMS_API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FMS_API.Controllers
{
    //[Authorize]
    public class ShipmentsController : BaseApiController
    {
        private readonly IMapper _mapper;
        private readonly IShipmentRepository _shipmentRepository;

        public ShipmentsController(IShipmentRepository shipmentRepository, IMapper mapper)
        {
            _mapper = mapper;
            _shipmentRepository = shipmentRepository;
        }

        [HttpGet]
        [Route("getOceanImportList")]
        public async Task<IActionResult> getOceanImportList()
        {
            var data = await _shipmentRepository.getAllOceanImport();
            var result = _mapper.Map<List<VM_OIM>>(data);
            return Ok(result);
        }

        [HttpGet]
        [Route("getOceanImportDetail/{id}")]
        public async Task<IActionResult> getOceanImportDetail(string id)
        {
            var data = await _shipmentRepository.getOceanImportDetail(id);
            var result = _mapper.Map<VM_OIM_DETAIL>(data);
            var cont_data = await _shipmentRepository.getOceanImportContainerList(data.oim.F_ID.ToString());
            result.VM_CONTAINERS = _mapper.Map<List<VM_CONTAINER>>(cont_data);
            return Ok(result);
        }

        [HttpGet]
        [Route("getOceanImportContainerList/{fid}")]
        public async Task<IActionResult> getOceanImportContainerList(string fid)
        {
            var data = await _shipmentRepository.getOceanImportContainerList(fid);
            var result = _mapper.Map<List<VM_CONTAINER>>(data);
            return Ok(result);            
        }
    }
}
