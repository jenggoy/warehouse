using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using wearhouse_back_end.Connection;
using wearhouse_back_end.Models.DatabaseModels;
using wearhouse_back_end.Models.Request;
using wearhouse_back_end.Models.Response;

namespace wearhouse_back_end.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : Controller
    {
        private readonly AppDbContext _dbcontext;

        public CategoryController(AppDbContext dbContext)
        {
            _dbcontext = dbContext;
        }

        [HttpGet("GetCategory")]
        public async Task<ActionResult<CategoryResponse>> GetCategory(string UserID)
        {
            var dataCatList = new List<CategoryResponse>();

            var dataCategory = await _dbcontext.MsCategory.Where(x => x.UserID == UserID).OrderBy(x => x.categorydate).ToListAsync();

            foreach (var item in dataCategory)
            {
                var dataCat = new CategoryResponse
                {
                    CategoryID = item.CategoryID,
                    Category = item.Category
                };
                dataCatList.Add(dataCat);
            }

            return Ok(dataCatList);
        }


        [HttpPost("AddCategory")]
        [Produces("application/json")]
        public async Task<ActionResult<LoginResponse>> AddCategory([FromBody] AddCategoryRequest catergoryRequest)
        {
            var newCategory = new MsCategory
            {
                CategoryID = Guid.NewGuid().ToString("D"),
                Category = catergoryRequest.Category,
                UserID = catergoryRequest.UserID,
                categorydate = DateTime.Now
            };

            try
            {
                _dbcontext.MsCategory.Add(newCategory);
                await _dbcontext.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("Faild to add new catergory");
            }
        }

        [HttpPost("EditCategory")]
        [Produces("application/json")]
        public async Task<ActionResult> EditCategory([FromBody] EditCategoryRequest categoryRequest)
        {
            var oldCategory = await _dbcontext.MsCategory.FirstOrDefaultAsync(x => x.CategoryID == categoryRequest.CategoryID 
                                                                                && x.UserID == categoryRequest.UserID);

            if (oldCategory != null)
            {
                oldCategory.Category = categoryRequest.Category;
                try
                {
                    _dbcontext.MsCategory.Update(oldCategory);
                    await _dbcontext.SaveChangesAsync();
                    return Ok();
                }
                catch (Exception ex)
                {
                    return BadRequest("Failed to edit category: " + ex.Message);
                }
            }
            else
            {
                return NotFound("Category not found");
            }
        }

        [HttpDelete("DeleteCategory")]
        [Produces("application/json")]
        public async Task<ActionResult> DeleteCategory([FromBody] DeleteCategoryRequest categoryRequest)
        {
            var deleteCategory = await _dbcontext.MsCategory.FirstOrDefaultAsync(x => x.CategoryID == categoryRequest.CategoryID && x.UserID == categoryRequest.UserID);

            if (deleteCategory != null)
            {
                try
                {
                    _dbcontext.MsCategory.Remove(deleteCategory);
                    await _dbcontext.SaveChangesAsync();
                    return Ok();
                }
                catch (Exception ex)
                {
                    return BadRequest("Failed to delete category: " + ex.Message);
                }
            }
            else
            {
                return NotFound("Category not found");
            }
        }


    }
}
