﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI1.Examples;

namespace WebAPI1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly ISingle single;
        private readonly IScope scope;
        private readonly ITrans trans;
        private readonly IProof proof;
        public ValuesController(IScope _scop, ITrans _trans, ISingle _single, IProof _proof) 
        {
            single = _single;
            scope = _scop;
            trans = _trans;
            proof = _proof;
        }

        [HttpGet]
        [Route("/GetProof")]
        public string GetProof()
        {
            return $"Single: {single.GetCallNo()}, Scope: {scope.GetCallNo()}, Trans: {trans.GetCallNo()} : " + proof.GetProof();
        }
    }
}
