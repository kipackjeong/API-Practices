using APIPractice2.Data;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.JsonPatch;

using System.Collections.Generic;
using APIPractice2.Model;
using APIPractice2.Dto;
using System.Collections;
using System;


namespace Controllers
{
    [Route("api/customers")]
    [ApiController]
    public class CustomerController : Controller
    {

        //PROP
        private readonly ICustomerRepo _repo;
        private readonly IMapper _mapper;


        //CTOR
        public CustomerController(ICustomerRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        //HTTP REQUESTS
        
        //GET ALL
        [HttpGet]
        public ActionResult<IEnumerable<CustomerReadDto>> GetAllCustomers()
        {
            var customersFromRepo = _repo.GetAllCustomers();
            if(customersFromRepo == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<IEnumerable<CustomerReadDto>>(customersFromRepo));
        }

        [HttpGet("{id}", Name = "GetCustomerById")]
        public ActionResult<CustomerReadDto> GetCustomerById(int id)
        {
            var customerFromRepo = _repo.GetCustomerById(id);
            if(customerFromRepo == null)
            {
                return NotFound();
            }


            // repo model -> readdto

            return Ok(_mapper.Map<CustomerReadDto>(customerFromRepo));
        }
    [HttpPost]
    public ActionResult CreateCustomer(CustomerCreatedDto customerCreatedDto)
    {
        // map the created dto to customer
        var customerToCreate = _mapper.Map<Customer>(customerCreatedDto);
        
        // put the mapped customer to repo
        _repo.CreateCustomer(customerToCreate);
        _repo.SaveChanges();

        // create readdto
        var customerReadDto = _mapper.Map<CustomerReadDto>(customerToCreate);
        return CreatedAtRoute(nameof(GetCustomerById), new {id = customerToCreate}, customerReadDto); // 201 Created 
    }

    [HttpPut("{id}")]
    public ActionResult PutCustomer(int id ,CustomerUpdateDto customerUpdateDto)
    {
        // bring model from repo
        var customerFromRepo = _repo.GetCustomerById(id);
        if(customerFromRepo == null)
        {
            return NotFound(); // 404
        }
        // map
        _mapper.Map(customerUpdateDto, customerFromRepo);

        // update to repo
        _repo.UpdateCustomer(customerFromRepo);
        _repo.SaveChanges();

        return NoContent();
    }    

    //PATCH

    [HttpPatch("{id}")]
    public ActionResult PatchCustomer(JsonPatchDocument<CustomerUpdateDto> jsonDocument, int id)
    {
        // bring model from repo
        var customerFromRepo = _repo.GetCustomerById(id);
        if(customerFromRepo == null)
        {
            return NotFound();  // 404
        }
        // customerFromRepo -> customerUpdateDto
        var customerUpdateRepo = _mapper.Map<CustomerUpdateDto>(customerFromRepo);

        // apply json doc -> customerUpdate Dto
        jsonDocument.ApplyTo(customerUpdateRepo);
        if(!TryValidateModel(customerUpdateRepo))
        {
            return ValidationProblem(ModelState);
        }

        // customerUpdate -> Model repo
        _mapper.Map(customerUpdateRepo, customerFromRepo);
        
        // repo update, save
        _repo.UpdateCustomer(customerFromRepo);
        _repo.SaveChanges();

        // return
        return NoContent(); // 
    }

    [HttpDelete("{id}")]
    public ActionResult DeleteCustomer(int id)
    {
        // bring model from repo
        var customerFromRepo = _repo.GetCustomerById(id);
        if(customerFromRepo == null)
        {
            return NotFound(); //404
        }

        _repo.DeleteCustomer(customerFromRepo);
        _repo.SaveChanges();
        
        return NoContent();
    } 









    }
}