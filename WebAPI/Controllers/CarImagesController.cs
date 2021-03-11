﻿using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImagesController : ControllerBase
    {
        ICarImageService _carImageService;

        public CarImagesController(ICarImageService carImageService)
        {
            _carImageService = carImageService;
        }


        [HttpGet]
        public IActionResult GetAllImages()
        {
            var result = _carImageService.GetAll();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [Route("{id}")]
        [HttpGet]
        public IActionResult GetByImageId(int id)
        {
            var result = _carImageService.GetById(id);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }


        [Route("getbycarid/{id}")]
        [HttpGet]
        public IActionResult GetCarListByCarId(int id)
        {
            var result = _carImageService.GetByCarImages(id);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpPost]
        public IActionResult AddImage([FromForm] IFormFile file,[FromForm]CarImage carImage)
        {
            var result = _carImageService.AddImage(file, carImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPut]
        public IActionResult UpdateImage([FromForm] IFormFile file, [FromForm] CarImage carImage)
        {
            var result = _carImageService.UpdateImage(file, carImage); // todo:yemeyebilir
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete]
        public IActionResult DeleteImage([FromBody] CarImage carImage)
        {
            var result = _carImageService.DeleteImage(carImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }






    }
}
