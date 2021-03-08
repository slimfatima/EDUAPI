using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IEduCare.Shared.Dto;
using IEduCare.Shared.Interfaces;
using IEduCare.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IEduCare.API.Controllers
{
    [ApiController]
    public class LicenseTypesController : ControllerBase
    {
        private readonly ILicenseTypeManager _licenseTypeManager;

        public LicenseTypesController(ILicenseTypeManager licenseTypeManager)
        {
            _licenseTypeManager = licenseTypeManager;
        }

        [HttpGet("api/ieducare/licensetype/get")]
        public ActionResult<List<LicenseTypeDto>> Get()
        {
            var licenseTypes = _licenseTypeManager.Get();
            return licenseTypes;
        }

        [HttpPost("api/ieducare/licensetype/post")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<LicenseTypeDto> Post([FromBody] LicenseTypeModel model)
        {
            var licenseType = _licenseTypeManager.Add(model.Code, model.Name);

            return licenseType;
        }
    }
}
