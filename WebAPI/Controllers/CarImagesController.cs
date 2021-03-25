using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
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
        [HttpGet("getall")]
        public IActionResult GetAll()
        {

            var result = _carImageService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(); 
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {

            var result = _carImageService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpPost("add")]
        public IResult Add([FromForm] CarImage carImage,[FromForm(Name =("Image"))] IFormFile file)
        {
         
            var result = _carImageService.Add(file,carImage);
            if (result.Success)
            {
                return new SuccessResult(Messages.CarImageAdded);
            }
            return new ErrorResult("error");
        }
        [HttpPost("update")]
        public IResult Update([FromForm] CarImage carImage, [FromForm(Name = ("Image"))] IFormFile file)
        {

            var result = _carImageService.Update(file, carImage);
            if (result.Success)
            {
                return new SuccessResult(Messages.CarImageAdded);
            }
            return new ErrorResult("error");
        }
        [HttpPost("delete")]
        public IResult Delete([FromForm] CarImage carImage)
        {

            var result = _carImageService.Delete(carImage);
            if (result.Success)
            {
                return new SuccessResult(Messages.CarImageAdded);
            }
            return new ErrorResult("error");
        }

    }
}
