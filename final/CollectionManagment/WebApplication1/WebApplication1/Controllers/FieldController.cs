using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using WebApplication1.Controllers.dto;
using WebApplication1.Models;
using WebApplication1.Models.dto;
using WebApplication1.Service;

namespace WebApplication1.Controllers
{
    [ApiController]
    public class FieldController : ControllerBase
    {
        private readonly IFieldService fieldService;
        private readonly ICollectionService collectionService;

        public FieldController(IFieldService fieldService, ICollectionService collectionService)
        {
            this.fieldService = fieldService;
            this.collectionService = collectionService;
        }

        [Authorize]
        [HttpPost("createField")]
        public IActionResult CreateCollection(CreateFieldRequest fieldRequest)
        {
            Field field = new Field
            {
                Name = fieldRequest.Name,
                Type = (FieldType) Enum.Parse(typeof(FieldType), fieldRequest.FieldType, true),
                CollectionId = fieldRequest.CollectionId
            };
            fieldService.Create(field);
            return Ok();
        }
        [Authorize]
        [HttpGet("getUserCollectionFields/{collectionName}")]
        public IActionResult GetUserCollectionFields(string collectionName)
        {
            int collectionId = collectionService.GetByName(collectionName).Id;
            List<Field> fields = fieldService.GetAllByCollectionId(collectionId);
            if (fields == null)
            {
                return NotFound();
            }
           
            return Ok(fields);
        }

        [Authorize]
        [HttpPost("isFieldExist")]
        public IActionResult IsCollectionExist(FieldExistRequest request)
        {
            if (fieldService.IsExist(request.CollectionId,request.Name))
            {
                return Ok();
            }
            return NotFound();
        }
    }
}
