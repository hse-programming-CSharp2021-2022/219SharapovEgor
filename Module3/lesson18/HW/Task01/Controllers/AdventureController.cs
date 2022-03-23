using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using static Task01.Tools;

namespace Task01.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdventureController : ControllerBase
    {
        private const string ConnectionString = "Data Source=AdventureWorksLT.db";

        [HttpGet("get-all-products-data")]
        public IActionResult GetAllProductsInfo()
        {
            var sql = "SELECT * FROM Product";
            var dataTable = ExecuteSQL_DataTable(ConnectionString, sql);
            var jsonResult = JsonConvert.SerializeObject(dataTable);
            return jsonResult.Length <= 0 ? BadRequest("Продукты отсутсвуют!") : Ok(jsonResult);
        }

        [HttpGet("get-product-info-by-id/{productId:int}")]
        public IActionResult GetProductInfoById(int productId)
        {
            var sql = $"SELECT * FROM Product WHERE ProductId = {productId}";
            var dataTable = ExecuteSQL_DataTable(ConnectionString, sql);
            var jsonResult = JsonConvert.SerializeObject(dataTable);
            return jsonResult.Length <= 0 ? BadRequest("Продукт отсутсвует!") : Ok(jsonResult);
        }
        
        [HttpPut("update-product-data")]
        public IActionResult UpdateProductInfo(
            [Required] int id, [Required] string name, [Required] string number, 
            [Required] string color, [Required] int cost, [Required] int price
            )
        {
            var sql = $"UPDATE Product SET Name = '{name}', ProductNumber = '{number}', Color = '{color}', " +
                            $"StandardCost = {cost}, ListPrice = {price} WHERE ProductID = {id}";
            ExecuteSQL_DataTable(ConnectionString, sql);
            return Ok("Данные были успешно обновлены!");
        }
        
        [HttpPost("add-product-data")]
        public IActionResult InsertProductInfo(
            [Required] string name, [Required] string number, [Required] string color, 
            [Required] int cost, [Required] int price
            )
        {
            var newProductId = GenerateProductId();
            var newGuid = GenerateGuidNumber();
            var insertionIsSuccessful = true;
            try
            {
                var sql =
                    "INSERT INTO Product (ProductID, Name, ProductNumber, Color, StandardCost, ListPrice, SellStartDate, rowguid) " +
                    $"VALUES ({newProductId}, '{name}', '{number}', '{color}', {cost}, {price}, '2022-03-21 21:21:21', '{newGuid}')";
                ExecuteSQL_DataTable(ConnectionString, sql);
            }
            catch
            {
                insertionIsSuccessful = false;
            }
            return insertionIsSuccessful 
                ? Ok($"Продукт с id: {newProductId} и guid: {newGuid} был успешно добавлен!") 
                : BadRequest($"Данный продукт не может быть добвлен.");
        }
        
        [HttpDelete("delete-product-data-by-id/{productId:int}")]
        public IActionResult DeleteProductInfo(int productId)
        {
            var sql = $"DELETE FROM Product WHERE ProductID = {productId}";
            var deleteIsSuccessful = true;
            try
            {
                ExecuteSQL_DataTable(ConnectionString, sql);
            }
            catch
            {
                deleteIsSuccessful = false;
            }

            return deleteIsSuccessful ? Ok("Продукт успешно удалён.") : BadRequest($"Продукт с ID: {productId} не был найден!");
        }
        
    }
}