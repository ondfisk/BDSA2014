using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using Northwind.Entities;
using Northwind.Models;

namespace Northwind.Web.Controllers
{
    public class ContactController : Controller
    {
        private readonly IEmployeeRepository _repository;

        public ContactController(IEmployeeRepository repository)
        {
            _repository = repository;
        }

        // GET: Contact
        public async Task<ActionResult> Index()
        {
            var contacts = await _repository.Read();

            return View(contacts);
        }

        // GET: Contact/Details/5
        [HttpGet]
        public async Task<ActionResult> Details(int id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            var contact = await _repository.Read(id);

            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }

        // GET: Contact/Update/5
        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            var contact = await _repository.Read(id);

            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }

        // POST: Contact/Update/5
        [HttpPost]
        public async Task<ActionResult> Edit(Contact contact)
        {
            if (!ModelState.IsValid)
            {
                return View(contact);
            }

            await _repository.Update(contact);

            return RedirectToAction("Details", new {contact.Id});
        }

        // GET: Contact/Portrait
        public async Task<ActionResult> Portrait(int id)
        {
            var contact = await _repository.Portrait(id);

            return File(contact, "image/jpeg");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _repository.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}