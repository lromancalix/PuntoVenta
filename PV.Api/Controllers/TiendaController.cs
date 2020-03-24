using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BLL.Catalogos;
using BLL.Contratos;
using DAL;
using Entities.DTO;
using Entities.Request;
using Entities.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace PV.Api.Controllers
{
    public class TiendaController : Controller
    {

        private readonly IMapper _mapper;
        private readonly ICrud<TiendaDTO> _iCrud;


        public TiendaController(IConfiguration configuration, IMapper mapper)
        {
            ApiConfig _ApiConfig = new ApiConfig() { connectionString = configuration.GetSection("AppConfig").GetSection("ConnectionString").Value };
            this._mapper = mapper;

            ICrud<TiendaDTO> iTienda = new Tienda(_ApiConfig);

            _iCrud = new ContextCRUD<TiendaDTO>(iTienda);
        }

        #region GET

        // GET: Obtener
        [HttpGet("Obtener/{id=0}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<TiendaResponse>>> Obtener(int? id = 0)
        {
            try
            {
                List<TiendaDTO> resp = await this._iCrud.Obtener(id);
                List<TiendaResponse> response = this._mapper.Map<List<TiendaResponse>>(resp);
                return Ok(response);

            }
            catch (Exception e)
            {
                List<TiendaResponse> response = new List<TiendaResponse>() { new TiendaResponse() { _error = true, estatus = "ERROR", descripcion = e.ToString() } };
                return BadRequest(response);
            }
        }


        #endregion

        #region POST

        // POST: agregar
        [HttpPost("agregar")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TiendaResponse>> Guardar(TiendaRequest request)
        {
            try
            {

                TiendaDTO DTO_ = this._mapper.Map<TiendaDTO>(request);

                var response = await this._iCrud.Guardar(DTO_);

                TiendaResponse respuesta = this._mapper.Map<TiendaResponse>(response);

                return Ok(respuesta);

            }
            catch (Exception e)
            {

                List<TiendaResponse> response = new List<TiendaResponse>() { new TiendaResponse() { _error = true, estatus = "ERROR", descripcion = e.ToString() } };
                return BadRequest(response);
            }
        }

        #endregion

        #region PUT

        // PUT: actualizar
        [HttpPut("actualizar")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TiendaResponse>> Actualizar(TiendaRequest request)
        {
            try
            {

                if (request.idTienda == 0)
                {
                    return BadRequest(new Estatus() { descripcion = "idMarca incorrrecto.", estatus = "ERROR", _error = true });
                }

                TiendaDTO dto_ = this._mapper.Map<TiendaDTO>(request);
                var respuesta = await this._iCrud.Guardar(dto_);

                return Ok(respuesta);

            }
            catch (Exception e)
            {

                List<MarcaResponse> response = new List<MarcaResponse>() { new MarcaResponse() { _error = true, estatus = "ERROR", descripcion = e.ToString() } };
                return BadRequest(response);
            }
        }

        #endregion

        #region DELETE

        // DELETE: actualizar
        [HttpDelete("eliminar/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TiendaResponse>> Eliminar(int id)
        {
            try
            {

                if (id == 0)
                {
                    return BadRequest(new Estatus() { descripcion = "id incorrrecto.", estatus = "ERROR", _error = true });
                }

                var respuesta = await this._iCrud.Eliminar(id);

                return Ok(respuesta);

            }
            catch (Exception e)
            {

                List<TiendaResponse> response = new List<TiendaResponse>() { new TiendaResponse() { _error = true, estatus = "ERROR", descripcion = e.ToString() } };
                return BadRequest(response);
            }
        }

        #endregion

    }
}