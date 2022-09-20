using Mango.Service.ProductAPI.Models.dto;
using Mango.Service.ProductAPI.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace Mango.Service.ProductAPI.Controllers
{
    [Route("api/products")]
    public class ProductAPIController : ControllerBase
    {
        protected ResponseDto _response;
        private IProductRepository _productRespository;

        public ProductAPIController(IProductRepository productRepository)
        {
            _productRespository = productRepository;
            this._response = new ResponseDto();
        }

        
        [HttpGet]
        [Authorize]
        public async Task<object> Get()
        {
            try
            {
                IEnumerable<ProductDto> productDtos = await _productRespository.GetProducts();
                _response.Result = productDtos;
            }
            catch (Exception e)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { e.Message };
            }
            return _response;
        }

        [HttpGet]
        [Authorize]
        [Route("{id}")]
        public async Task<object> Get(int id)
        {
            try
            {
                ProductDto productDto = await _productRespository.GetProductById(id);
                _response.Result = productDto;
            }
            catch (Exception e)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { e.Message };
            }
            return _response;
        }

        [HttpPost]
        [Authorize]
        public async Task<object> Post([FromBody] ProductDto productDto)
        {
            try
            {
                ProductDto model = await _productRespository.CreateUpdateProduct(productDto);
                _response.Result = model;
            }
            catch (Exception e)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { e.Message };
            }
            return _response;
        }

        [HttpPut]
        [Authorize]
        public async Task<object> Put([FromBody] ProductDto productDto)
        {
            try
            {
                ProductDto model = await _productRespository.CreateUpdateProduct(productDto);
                _response.Result = model;
            }
            catch (Exception e)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { e.Message };
            }
            return _response;
        }

        [HttpDelete]
        [Authorize(Roles="Admin")]
        [Route("{id}")]
        public async Task<object> Delete(int id)
        {
            try
            {
                bool isSuccessful = await _productRespository.DeleteProduct(id);
                _response.Result = isSuccessful;
            }
            catch (Exception e)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { e.Message };
            }
            return _response;
        }
    }
}
