using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using WebApplication1.Controllers.dto;
using WebApplication1.Model.dto;
using WebApplication1.Models;
using WebApplication1.Service;

namespace WebApplication1.Controllers
{

    [ApiController]
    public class CollectionController : ControllerBase
    {
        private readonly ICollectionService collectionService;

        public CollectionController(ICollectionService collectionService)
        {
            this.collectionService = collectionService;
        }

        [Authorize]
        [HttpPost("createCollection")]
        public IActionResult CreateCollection(CreateCollectionRequest collectionRequest)
        {
            Collection collection = new Collection
            {
                Name = collectionRequest.Name,
                Description = collectionRequest.Description,
                CollectionType = (CollectionType)Enum.Parse(typeof(CollectionType), collectionRequest.CollectionType, true),
                PathToImg = collectionRequest.PathToImg,
                UserId = collectionRequest.UserId
            };
            return Ok(collectionService.Create(collection));
        }
        [Authorize]
        [HttpPost("isCollectionExist")]
        public IActionResult IsCollectionExist(NameRequest request)
        {
            if (collectionService.IsExist(request.Name))
            {
                return Ok();
            }
            return NotFound();
        }

        [HttpGet("getCollectionsByType/{type}")]
        public IActionResult GetCollectionsByType(string type)
        {
            List<Collection> collections =
                collectionService.GetByType((CollectionType)Enum.Parse(typeof(CollectionType), type, true));
            if (collections != null)
            {
                return Ok(collections);
            }
            return null;

        }
        [Authorize]
        [HttpGet("getCollectionsByUserIdAndType/{userId}/{type}")]
        public IActionResult GetCollectionsByUserIdAndType(int userId,string type)
        {
            List<Collection> collections =
                collectionService.GetByUserIdAndType(userId,(CollectionType)Enum.Parse(typeof(CollectionType), type, true));
            if (collections != null)
            {
                return Ok(collections);
            }
            return null;

        }

        [Authorize]
        [HttpDelete("removeCollection/{id}")]
        public IActionResult RemoveCollection(int id)
        {
            collectionService.Delete(id);
            return Ok();

        }
    }
}
