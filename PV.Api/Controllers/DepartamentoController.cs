using AutoMapper;
using BLL.Catalogos;
using BLL.Contratos;
using Entities.DTO;
using Entities.Request;
using Entities.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PV.Api.Controllers
{
    public class DepartamentoController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ICrud<DepartamentoDTO> _iCrud;

        public DepartamentoController(IConfiguration configuration, IMapper mapper)
        {
            ApiConfig _ApiConfig = new ApiConfig() { connectionString = configuration.GetSection("AppConfig").GetSection("ConnectionString").Value };
            this._mapper = mapper;

            ICrud<DepartamentoDTO> iDepto = new Departamento(_ApiConfig);
            this._iCrud = new ContextCRUD<DepartamentoDTO>(iDepto);
        }

        #region GET

        // GET: Obtener
        [HttpGet("Obtener/{id=0}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<DepartamentoResponse>>> Obtener(int? id = 0)
        {
            try
            {
                List<DepartamentoDTO> marcas = await this._iCrud.Obtener(id);
                List<DepartamentoResponse> response = this._mapper.Map<List<DepartamentoResponse>>(marcas);
                return Ok(response);

            }
            catch (Exception e)
            {
                List<DepartamentoResponse> response = new List<DepartamentoResponse>() { new DepartamentoResponse() { _error = true, estatus = "ERROR", descripcion = e.ToString() } };
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
        public async Task<ActionResult<DepartamentoResponse>> Guardar(DepartamentoRequest request)
        {
            try
            {

                DepartamentoDTO DTO_ = this._mapper.Map<DepartamentoDTO>(request);

                var response = await this._iCrud.Guardar(DTO_);

                DepartamentoResponse respuesta = this._mapper.Map<DepartamentoResponse>(response);

                return Ok(respuesta);

            }
            catch (Exception e)
            {

                List<MarcaResponse> response = new List<MarcaResponse>() { new MarcaResponse() { _error = true, estatus = "ERROR", descripcion = e.ToString() } };
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
        public async Task<ActionResult<DepartamentoResponse>> Actualizar(DepartamentoRequest request)
        {
            try
            {

                if (request.idDepartamento  == 0)
                {
                    return BadRequest(new Estatus() { descripcion = "idMarca incorrrecto.", estatus = "ERROR", _error = true });
                }

                var respuesta = await this._iCrud.Guardar(request);

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
        public async Task<ActionResult<DetallesMarcaResponse>> Eliminar(int id)
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

                List<DepartamentoResponse> response = new List<DepartamentoResponse>() { new DepartamentoResponse() { _error = true, estatus = "ERROR", descripcion = e.ToString() } };
                return BadRequest(response);
            }
        }

        #endregion
    }
}