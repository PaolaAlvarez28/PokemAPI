﻿using PokAPI.Business.Poke;
using PokAPI.Business.service;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class PokemonController : ControllerBase
{
    private readonly PokeServices _pokeServices;
    public PokemonController(PokeServices pokeServices)
    {
        _pokeServices = pokeServices;
    }
    [HttpGet("{pokemonname}")]
    public async Task<ActionResult<Pokemon>> GetResult(string pokemonname)
    {
        var poke = await _pokeServices.GetFavPokemon(pokemonname);
        return Ok(poke);
    }
}
