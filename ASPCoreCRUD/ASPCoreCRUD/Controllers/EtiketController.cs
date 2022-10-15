using System;
using System.Linq;
using System.Threading.Tasks;
using ASPCoreCRUD.Data;
using ASPCoreCRUD.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASPCoreCRUD.Controllers
{
    
    [ApiController]
    [Route("v1/")]
    public class EtiketController: ControllerBase
    {
        private readonly ApplicationDbContext _db;
        public EtiketController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        [Route("GetEtiket")]
        public IActionResult GetEtiket()
        {
            return Ok(_db.Etiket.ToList());
        }
        [HttpPost]
        [Route("AddEtiket")]
        public async Task<IActionResult> AddEtiket([FromBody] Etiket objEtiket)
        {
            if (!ModelState.IsValid)
            {
                return new JsonResult("Error while creating new Etiket");
            }
            _db.Etiket.Add(objEtiket);
            await _db.SaveChangesAsync();
            return new JsonResult("Etiket created successfully");
        }

        [HttpPut]
        [Route("UpateEtiket")]
        public async Task<IActionResult> UpdateEtiket([FromRoute] int EtiketId,[FromBody] Etiket objEtiket)
        {
            if(objEtiket == null || EtiketId != objEtiket.EtiketId )
            {
                return new JsonResult("Etiket bulunamadı!");
            }
            else
            {
                _db.Etiket.Update(objEtiket);
                await _db.SaveChangesAsync();
                return new JsonResult("Başarılı bir şekilde değiştirilmiştir.");
            }
        }

      /*  [HttpDelete("{id}")]
        [Route("DeleteEtiket")]
        public async Task<IActionResult> DeleteEtiket([FromRoute] int etikedId)
        {
            var findEtiket = await _db.Etiket.FindAsync(etikedId);
            if (findEtiket == null )
            {
                return NotFound();
            } else
            {
                _db.Etiket.Remove(findEtiket);
                await _db.SaveChangesAsync();
                return new JsonResult("Başarılı bir şekilde kayıt silinmiştir.");
            }
        }*/
    }
}
