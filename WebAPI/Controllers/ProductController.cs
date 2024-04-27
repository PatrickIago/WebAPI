using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.WebSockets;
using WebAPI.Dto.ProductsDto;
using WebAPI.Models;
using WebAPI.Services.ProductModel;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet("GetAllProducts")]
    public async Task<ActionResult<ResponseModel<List<Product>>>> GetAllProducts()
    {
        var products = await _productService.GetAllProducts();
        return Ok(products);
    }

    [HttpGet("GetProductById")]
    public async Task<ActionResult<ResponseModel<Product>>> GetProductById(int idProduct)
    {
        var product = await _productService.GetProductById(idProduct);
        return Ok(product);
    }

    [HttpPost("CreateProduct")]
    public async Task<ActionResult<ResponseModel<Product>>> CreateProduct(CreateProductDto createProductDto)
    {
      var product = await _productService.CreateProduct(createProductDto);
      return Ok(product);
    }

    [HttpPut("UpdateProduct")]
    public async Task<ActionResult<ResponseModel<Product>>> UpdateProduct(UpdateProductDto updateProductDto)
    {
        var product = await _productService.UpdateProduct(updateProductDto);
        return Ok(product);
    }

    [HttpDelete("DeleteProduct")]
    public async Task<ActionResult<ResponseModel<Product>>> DeleteProduct(int idProduct)
    {
        var product = await _productService.DeleteProduct(idProduct);
        return Ok();
    }
}
