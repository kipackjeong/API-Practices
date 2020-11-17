using APIPractice2.Data;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
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






    }
}