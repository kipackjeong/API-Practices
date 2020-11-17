using System.Collections.Generic;
using System.Linq;
using APIPractice1.Data;
using AppPractice1.Model;
using AutoMapper;
using Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.JsonPatch;

namespace Controllers
{
    [Route("api/todouseraccount")]
    [ApiController]
    public class ToDoUserAccountController : Controller
    {
        private readonly IToDoUserAccountRepo _repository;
        private readonly IMapper _mapper;


        //PROP
        //CTOR
        public ToDoUserAccountController(IToDoUserAccountRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }



        //Methods

        //GET api/todouseraccount
        [HttpGet]
        public ActionResult<IEnumerable<ToDoUserAccountReadDto>> GetAllUserAccounts()
        {
            var ToDoUserAccountModelFromRepo = _repository.GetAllUserAccounts();

            return Ok(_mapper.Map<IEnumerable<ToDoUserAccountReadDto>>(ToDoUserAccountModelFromRepo));
        }


        //GET api/todouseraccount/{id}
        [HttpGet("{id}", Name = "GetUserAccountById")]
        public ActionResult<ToDoUserAccount> GetUserAccountById(int id)
        {
            var ToDoUserAccountModelFromRepo = _repository.GetUserAccountById(id);

            if (ToDoUserAccountModelFromRepo != null)
            {
                return Ok(_mapper.Map<ToDoUserAccountReadDto>(ToDoUserAccountModelFromRepo));
            }
            return NotFound();// 404
        }

        //CREATE api/todouseraccount/{id}
        [HttpPost]
        public ActionResult CreateUserAccount(ToDoUserAccountCreateDto toDoUserAccountCreateDto)
        {
            // createdto -> todouseraccount model
            var toDoUserAccount = _mapper.Map<ToDoUserAccount>(toDoUserAccountCreateDto);

            // create and save in repo
            _repository.CreateUserAccount(toDoUserAccount);
            _repository.SaveChanges();
            
            // todouseraccound model -> readdto
            var toDoUserAccountReadDto = _mapper.Map<ToDoUserAccountReadDto>(toDoUserAccount);

            // return created model (readdto)
            return CreatedAtRoute(nameof(GetUserAccountById), new { id = toDoUserAccount.Id }, toDoUserAccountReadDto); // 201
        }
        [HttpPut("{id}")]
        public ActionResult UpdateUserAccount(int id, ToDoUserAccountUpdateDto toDoUserAccountUpdateDto)
        {
            // get model by id from repo
            var toDoUserAccountFromRepo = _repository.GetUserAccountById(id);
            if(toDoUserAccountFromRepo == null)
            {
                return NotFound();// 404
            }


            // use updatedto to model
            _mapper.Map(toDoUserAccountUpdateDto, toDoUserAccountFromRepo);
            _repository.UpdateUserAccount(toDoUserAccountFromRepo);
            _repository.SaveChanges();

            return NoContent(); // 204
            // 
        }

        //PATCH api/todouseraccount/{id}
        [HttpPatch("{id}")]
        public ActionResult PatchUserAccount(int id, JsonPatchDocument<ToDoUserAccountUpdateDto> patchDocument)
        {
            // bring data from repo by id
            var toDoUserAccountFromRepo = _repository.GetUserAccountById(id);

            // validation check for repo data
            if(toDoUserAccountFromRepo == null)
            {
                return NotFound(); //404
            }

            // repo data -> update dto
            var userAccountUpdateDtoToPatch = _mapper.Map<ToDoUserAccountUpdateDto>(toDoUserAccountFromRepo);

            // apply patch document to update dto
            patchDocument.ApplyTo(userAccountUpdateDtoToPatch);
            // validation check for patched update dto
            if(!TryValidateModel(userAccountUpdateDtoToPatch))
            {
                return ValidationProblem(ModelState);
            }
            
            // update the repo data with patched update dto
            _mapper.Map(userAccountUpdateDtoToPatch, toDoUserAccountFromRepo);

            // update repo and savechanges
            _repository.UpdateUserAccount(toDoUserAccountFromRepo);
            _repository.SaveChanges();

            // 500
            return NoContent();

        }

        [HttpDelete("{id}")]
        public ActionResult DeleteUserAccount(int id)
        {
            // bring model from repo by id
            var accountToDelete = _repository.GetUserAccountById(id);
            _repository.DeleteUserAccount(accountToDelete);
            _repository.SaveChanges();

            return NoContent();
        }

        

    }
}