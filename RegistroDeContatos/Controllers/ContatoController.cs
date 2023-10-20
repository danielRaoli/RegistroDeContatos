using Microsoft.AspNetCore.Mvc;
using RegistroDeContatos.Data.Dtos;
using RegistroDeContatos.Repository;

namespace RegistroDeContatos.Controllers
{
    public class ContatoController : Controller
    {
        private IContatoRepository _contatoRepository;

        public ContatoController(IContatoRepository contatoRepository)
        {
            _contatoRepository = contatoRepository;
        }
        public IActionResult Index()
        {
            var contatos = _contatoRepository.FindAll();
            return View(contatos);
        }

        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Edit(int? id)
        {
            var contato = _contatoRepository.FindById(id);
            if (contato == null)
            {
                return NotFound();
            }
            return View(contato);
        }

        public IActionResult ConfirmDelete(int? id)
        {
            var contatoDto = _contatoRepository.FindById(id);
            if(contatoDto == null)
            {
                return BadRequest();
            }
            return View(contatoDto);
        }

        public IActionResult Delete(int id)
        {
            _contatoRepository.Delete(id);
            return RedirectToAction(nameof(Index));

        }


        [HttpPost]
        public IActionResult Create(CreateContatoDto contatoDto)
        {
            try
            {
                if (TryValidateModel(contatoDto))
                {
                    _contatoRepository.CreateContato(contatoDto);
                    TempData["SuccessMensage"] = "Usuário criado com sucesso";
                    return RedirectToAction(nameof(Index));
                }
                return View("Create", contatoDto);
            }catch (Exception ex)
            {
                TempData["ErrorMensage"] = "Erro ao tentar registrar novo cliente";
                return RedirectToAction(nameof(Index));
            }
            
        }

        [HttpPost]
        public IActionResult Edit(ReadContatoDto contatoDto)
        {
            try
            {
            if (TryValidateModel(contatoDto))
            {
                _contatoRepository.EditContato(contatoDto);
                    TempData["SuccessMensage"] = "Usuário editado com sucesso";
                return RedirectToAction(nameof(Index));
            }
            return View("Edit",contatoDto);

            }catch(Exception ex)
            {
                TempData["errorMensage"] = "Erro ao tentar criar usuário";
                return RedirectToAction(nameof(Index));
            }

        }

        
    }

}
