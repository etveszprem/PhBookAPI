using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using InsOrUpdUsr.Models;
using Microsoft.EntityFrameworkCore;

namespace InsOrUpdUsr.Controllers
{
    /// <summary>
    /// Adatforrás-vezérlő PhoneUsr táblához
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class PhoneUsrController : ControllerBase
    {
        private readonly PhoneUsrContext _context;
        /// <summary>
        /// PhoneUsr adatforrás-vezérlő példányosítása
        /// </summary>
        /// <param name="context">PhoneUsr táblának megfelelő kontextus (környezeti változók)</param>
        public PhoneUsrController(PhoneUsrContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Egy PhoneUsr táblának megfelelő request
        /// </summary>
        public class PhoneUsrRequest
        {
            public long Id { get; set; }
            public string TrzsSzam { get; set; }
            public string FhNev { get; set; }
            public string Nev { get; set; }
            public string MhNev { get; set; }
            public string FTrzsSzam { get; set; }
            public string MPhoneNum { get; set; }
            public string VPhoneNum { get; set; }
            public string Email { get; set; }

            public bool IsDeleted { get; set; }
        }

        /// <summary>
        /// Beküld egy új PhoneUsr táblának megfelelő rekordot
        /// </summary>
        /// <param name="request">PhoneUsrRequest osztály elemei reprezentálják a PhoneUsr tábla oszlopait, ez jelenik meg kérésként</param>
        /// <returns>Visszaad hibát, vagy OK jelzést</returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PhoneUsrRequest request)
        {
            var entity = new PhoneEntity
            {
                //Id = request.Id,
                TrzsSzam = request.TrzsSzam,
                FhNev = request.FhNev,
                Nev = request.Nev,
                MhNev = request.MhNev,
                FTrzsSzam = request.FTrzsSzam,
                MPhoneNum = request.MPhoneNum,
                VPhoneNum = request.VPhoneNum,
                Email = request.Email,
                IsDeleted = request.IsDeleted
            };

            _context.PhoneUsr.Add(entity);
            await _context.SaveChangesAsync();

            return Ok(new { id = entity.Id });
        }

        /// <summary>
        /// Módosít egy PhoneUsr táblának megfelelő rekordot Id alapján. A request-ben lévő értékek az Id kivételével felülírásra kerülnek.
        /// </summary>
        /// <param name="id">A rekord egyedi azonosítója</param>
        /// <param name="request">PhoneUsrRequest osztály elemei reprezentálják a PhoneUsr tábla oszlopait, ez jelenik meg kérésként</param>
        /// <returns>Visszaad hibát, vagy OK jelzést</returns>
        [HttpPut("ModAllValueById{id}")]
        public async Task<IActionResult> Update(long id, [FromBody] PhoneUsrRequest request)
        {
            var entity = await _context.PhoneUsr.FindAsync(id);
            if (entity == null)
            {
                return NotFound();
            }

            // Entity frissítése a kérésből származó adatokkal
            entity.TrzsSzam = request.TrzsSzam;
            entity.FhNev = request.FhNev;
            entity.Nev = request.Nev;
            entity.MhNev = request.MhNev;
            entity.FTrzsSzam = request.FTrzsSzam;
            entity.MPhoneNum = request.MPhoneNum;
            entity.VPhoneNum = request.VPhoneNum;
            entity.Email = request.Email;
            entity.IsDeleted = request.IsDeleted;

            await _context.SaveChangesAsync();

            return Ok(entity);
        }
        /// <summary>
        /// Módosít egy PhoneUsr táblának megfelelő rekordot Id alapján. A request-ben lévő értékek közül csak a Trzs oszlop értékét változtatja meg.
        /// </summary>
        /// <param name="id">A rekord egyedi azonosítója</param>
        /// <param name="request">PhoneUsrRequest osztály elemei reprezentálják a PhoneUsr tábla oszlopait, ez jelenik meg kérésként</param>
        /// <returns>Visszaad hibát, vagy OK jelzést</returns>
        [HttpPut("ModTrzsSzamById{id}")]
        public async Task<IActionResult> UpdateTrzs(long id, [FromBody] PhoneUsrRequest request)
        {
            var entity = await _context.PhoneUsr.FindAsync(id);
            if (entity == null)
            {
                return NotFound();
            }

            // Entity Trzs frissítése a kérésből származó adatokkal
            entity.TrzsSzam = request.TrzsSzam;

            await _context.SaveChangesAsync();

            return Ok(entity);
        }
        /// <summary>
        /// Módosít egy PhoneUsr táblának megfelelő rekordot Id alapján. A request-ben lévő értékek közül csak az FhNev oszlop értékét változtatja meg.
        /// </summary>
        /// <param name="id">A rekord egyedi azonosítója</param>
        /// <param name="request">PhoneUsrRequest osztály elemei reprezentálják a PhoneUsr tábla oszlopait, ez jelenik meg kérésként</param>
        /// <returns>Visszaad hibát, vagy OK jelzést</returns>
        [HttpPut("ModFhNevById{id}")]
        public async Task<IActionResult> UpdateFhNev(long id, [FromBody] PhoneUsrRequest request)
        {
            var entity = await _context.PhoneUsr.FindAsync(id);
            if (entity == null)
            {
                return NotFound();
            }

            // Entity FhNev frissítése a kérésből származó adatokkal
            entity.FhNev = request.FhNev;
            
            await _context.SaveChangesAsync();

            return Ok(entity);
        }
        /// <summary>
        /// Módosít egy PhoneUsr táblának megfelelő rekordot Id alapján. A request-ben lévő értékek közül csak a Nev oszlop értékét változtatja meg.
        /// </summary>
        /// <param name="id">A rekord egyedi azonosítója</param>
        /// <param name="request">PhoneUsrRequest osztály elemei reprezentálják a PhoneUsr tábla oszlopait, ez jelenik meg kérésként</param>
        /// <returns>Visszaad hibát, vagy OK jelzést</returns>
        [HttpPut("ModNevById{id}")]
        public async Task<IActionResult> UpdateNev(long id, [FromBody] PhoneUsrRequest request)
        {
            var entity = await _context.PhoneUsr.FindAsync(id);
            if (entity == null)
            {
                return NotFound();
            }

            // Entity frissítése a kérésből származó adatokkal
            entity.Nev = request.Nev;

            await _context.SaveChangesAsync();

            return Ok(entity);
        }
        /// <summary>
        /// Módosít egy PhoneUsr táblának megfelelő rekordot Id alapján. A request-ben lévő értékek közül csak az MhNev oszlop értékét változtatja meg.
        /// </summary>
        /// <param name="id">A rekord egyedi azonosítója</param>
        /// <param name="request">PhoneUsrRequest osztály elemei reprezentálják a PhoneUsr tábla oszlopait, ez jelenik meg kérésként</param>
        /// <returns>Visszaad hibát, vagy OK jelzést</returns>
        [HttpPut("ModMhNevById{id}")]
        public async Task<IActionResult> UpdateMhNev(long id, [FromBody] PhoneUsrRequest request)
        {
            var entity = await _context.PhoneUsr.FindAsync(id);
            if (entity == null)
            {
                return NotFound();
            }

            // Entity frissítése a kérésből származó adatokkal
            entity.MhNev = request.MhNev;

            await _context.SaveChangesAsync();

            return Ok(entity);
        }
        /// <summary>
        /// Módosít egy PhoneUsr táblának megfelelő rekordot Id alapján. A request-ben lévő értékek közül csak a FTrzsSzam oszlop értékét változtatja meg.
        /// </summary>
        /// <param name="id">A rekord egyedi azonosítója</param>
        /// <param name="request">PhoneUsrRequest osztály elemei reprezentálják a PhoneUsr tábla oszlopait, ez jelenik meg kérésként</param>
        /// <returns>Visszaad hibát, vagy OK jelzést</returns>
        [HttpPut("ModFTrzsSzamById{id}")]
        public async Task<IActionResult> UpdateFTrzsSzam(long id, [FromBody] PhoneUsrRequest request)
        {
            var entity = await _context.PhoneUsr.FindAsync(id);
            if (entity == null)
            {
                return NotFound();
            }

            // Entity frissítése a kérésből származó adatokkal
            entity.FTrzsSzam = request.FTrzsSzam;

            await _context.SaveChangesAsync();

            return Ok(entity);
        }
        /// <summary>
        /// Módosít egy PhoneUsr táblának megfelelő rekordot Id alapján. A request-ben lévő értékek közül csak a MPhone oszlop értékét változtatja meg.
        /// </summary>
        /// <param name="id">A rekord egyedi azonosítója</param>
        /// <param name="request">PhoneUsrRequest osztály elemei reprezentálják a PhoneUsr tábla oszlopait, ez jelenik meg kérésként</param>
        /// <returns>Visszaad hibát, vagy OK jelzést</returns>
        [HttpPut("ModMPhoneNumById{id}")]
        public async Task<IActionResult> UpdateMPhoneNum(long id, [FromBody] PhoneUsrRequest request)
        {
            var entity = await _context.PhoneUsr.FindAsync(id);
            if (entity == null)
            {
                return NotFound();
            }

            // Entity frissítése a kérésből származó adatokkal
            entity.MPhoneNum = request.MPhoneNum;

            await _context.SaveChangesAsync();

            return Ok(entity);
        }
        /// <summary>
        /// Módosít egy PhoneUsr táblának megfelelő rekordot Id alapján. A request-ben lévő értékek közül csak a VPhone oszlop értékét változtatja meg.
        /// </summary>
        /// <param name="id">A rekord egyedi azonosítója</param>
        /// <param name="request">PhoneUsrRequest osztály elemei reprezentálják a PhoneUsr tábla oszlopait, ez jelenik meg kérésként</param>
        /// <returns>Visszaad hibát, vagy OK jelzést</returns>
        [HttpPut("ModVPhoneNumById{id}")]
        public async Task<IActionResult> UpdateVPhoneNum(long id, [FromBody] PhoneUsrRequest request)
        {
            var entity = await _context.PhoneUsr.FindAsync(id);
            if (entity == null)
            {
                return NotFound();
            }

            // Entity frissítése a kérésből származó adatokkal
            entity.VPhoneNum = request.VPhoneNum;

            await _context.SaveChangesAsync();

            return Ok(entity);
        }
        /// <summary>
        /// Módosít egy PhoneUsr táblának megfelelő rekordot Id alapján. A request-ben lévő értékek közül csak az Email oszlop értékét változtatja meg.
        /// </summary>
        /// <param name="id">A rekord egyedi azonosítója</param>
        /// <param name="request">PhoneUsrRequest osztály elemei reprezentálják a PhoneUsr tábla oszlopait, ez jelenik meg kérésként</param>
        /// <returns>Visszaad hibát, vagy OK jelzést</returns>
        [HttpPut("ModEmailAllById{id}")]
        public async Task<IActionResult> UpdateEmail(long id, [FromBody] PhoneUsrRequest request)
        {
            var entity = await _context.PhoneUsr.FindAsync(id);
            if (entity == null)
            {
                return NotFound();
            }

            // Entity frissítése a kérésből származó adatokkal
            entity.Email = request.Email;

            await _context.SaveChangesAsync();

            return Ok(entity);
        }
        /// <summary>
        /// Módosít egy PhoneUsr táblának megfelelő rekordot Id alapján. A request-ben lévő értékek közül csak az IsDeleted oszlop értékét változtatja meg. (Törlésre jelöl)
        /// </summary>
        /// <param name="id">A rekord egyedi azonosítója</param>
        /// <param name="request">PhoneUsrRequest osztály elemei reprezentálják a PhoneUsr tábla oszlopait, ez jelenik meg kérésként</param>
        /// <returns>Visszaad hibát, vagy OK jelzést</returns>
        [HttpPut("ModIsDeletedById{id}")]
        public async Task<IActionResult> UpdateIsDeleted(long id, [FromBody] PhoneUsrRequest request)
        {
            var entity = await _context.PhoneUsr.FindAsync(id);
            if (entity == null)
            {
                return NotFound();
            }

            // Entity frissítése a kérésből származó adatokkal
            entity.IsDeleted = request.IsDeleted;

            await _context.SaveChangesAsync();

            return Ok(entity);
        }

        /// <summary>
        /// Minden rekordot visszaad, a törölésre jelölteket is
        /// </summary>
        /// <returns>Visszaad null, vagy PhoneUsr táblának megfelelő struktúrát</returns>
        [HttpGet("WithDeleted")]
        public async Task<ActionResult<IEnumerable<PhoneEntity>>> GetAllWithDeleted()
        {
            return await _context.PhoneUsr.ToListAsync();
        }
        /// <summary>
        /// Minden rekordot visszaad (Kivéve a törölteket.)
        /// </summary>
        /// <returns>Visszaad null, vagy PhoneUsr táblának megfelelő struktúrát</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PhoneEntity>>> GetAll()
        {
            return await _context.PhoneUsr.Where(p => !p.IsDeleted).ToListAsync();
        }

        /// <summary>
        /// PhoneUsr elem lekérdezése Id alapján
        /// </summary>
        /// <param name="id">PhoneUsr elem egyedi azonosítója (bigint, long)</param>
        /// <returns>Visszaad null, vagy PhoneUsr táblának megfelelő struktúrát</returns>
        [HttpGet("GetById{id}")]
        public async Task<ActionResult<PhoneEntity>> Get(long id)
        {
            var phoneEntity = await _context.PhoneUsr.FindAsync(id);

            if (phoneEntity == null)
            {
                return NotFound();
            }

            return phoneEntity;
        }
    }
}
