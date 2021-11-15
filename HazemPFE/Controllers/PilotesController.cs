using HazemPFE.Models;
using HazemPFE.ViewModels;
using System.Linq;
using System.Web.Mvc;

namespace HazemPFE.Controllers
{
    public class PilotesController : Controller
    {

        private ApplicationDbContext _context;
        public PilotesController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public ActionResult New()
        {
            var viewModel = new PiloteFormViewModel
            {
                
            };
            return View("PiloteForm",viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Pilote pilote,int id)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new PiloteFormViewModel(pilote)
                {

                    
                };
                return View("PiloteForm", viewModel);
            }
            if (pilote.Id == 0)
                _context.Pilotes.Add(pilote);
            else
            {
                var piloteInDb = _context.Pilotes.Single(c => c.Id == pilote.Id);
                piloteInDb.Nom = pilote.Nom;
                piloteInDb.Prenom = pilote.Prenom;
                piloteInDb.Indicatif_Radio = pilote.Indicatif_Radio;
               
            }

            _context.SaveChanges();
            return RedirectToAction("Index", "Pilotes");
        }
        public ActionResult Details(int id)
        {
            var pilote = _context.Pilotes.SingleOrDefault(p => p.Id == id);
                
                if (pilote == null)
                return HttpNotFound();

            return View(pilote);
        }
        public ActionResult Edit(int id)
        {
            var pilote = _context.Pilotes.SingleOrDefault(p => p.Id == id);
                if (pilote == null)
                return HttpNotFound();
            var viewModel = new PiloteFormViewModel(pilote) { };
            
            return View("PiloteForm", viewModel);

        }
        
        // GET: Pilotes
        public ActionResult Index()
        {
            return View();
        }
    }
}