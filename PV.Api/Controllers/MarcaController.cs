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
    public class MarcaController : Controller
    {
        private readonly ApiConfig _ApiConfig;
        private readonly IMapper _mapper;
        private readonly ICrud<MarcaDTO> _iCrud;

        public MarcaController(IConfiguration configuration, IMapper mapper)
        {
            this._ApiConfig = new ApiConfig() { connectionString = configuration.GetSection("AppConfig").GetSection("ConnectionString").Value };
            this._mapper = mapper;
            
            ICrud<MarcaDTO> iMarca = new Marca(this._ApiConfig);
            this._iCrud = new ContextCRUD<MarcaDTO>(iMarca);
        }


        #region GET

        // GET: Obtener
        [HttpGet("Obtener/{id=0}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<MarcaResponse>>> ObtenerMarcas(int? id = 0)
        {
            try
            {
                List<MarcaDTO> marcas = await this._iCrud.Obtener(id);
                List<MarcaResponse> response = this._mapper.Map<List<MarcaResponse>>(marcas);
                return Ok(response);

            }
            catch (Exception e)
            {
                List<MarcaResponse> response = new List<MarcaResponse>() { new MarcaResponse() { _error = true, estatus = "ERROR", descripcion = e.ToString() } };
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
        public async Task<ActionResult<DetallesMarcaResponse>> GuardarMarca(RequestMarca marcaRequest)
        {
            try
            {

                MarcaDTO marcaDTO = this._mapper.Map<MarcaDTO>(marcaRequest);

                var response = await this._iCrud.Guardar(marcaDTO);

                DetallesMarcaResponse respuesta = this._mapper.Map<DetallesMarcaResponse>(response);

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
        public async Task<ActionResult<DetallesMarcaResponse>> ActualizarMarca(RequestMarca marcaRequest)
        {
            try
            {

                if (marcaRequest.idMarca == 0)
                {
                    return BadRequest(new Estatus() { descripcion = "idMarca incorrrecto.", estatus = "ERROR", _error = true });
                }

                var respuesta = await this.GuardarMarca(marcaRequest);

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
        public async Task<ActionResult<DetallesMarcaResponse>> EliminarMarca(int idMarca)
        {
            try
            {

                if (idMarca == 0)
                {
                    return BadRequest(new Estatus() { descripcion = "idMarca incorrrecto.", estatus = "ERROR", _error = true });
                }

                var respuesta = await this._iCrud.Eliminar(idMarca);

                return Ok(respuesta);

            }
            catch (Exception e)
            {

                List<MarcaResponse> response = new List<MarcaResponse>() { new MarcaResponse() { _error = true, estatus = "ERROR", descripcion = e.ToString() } };
                return BadRequest(response);
            }
        }

        #endregion


    }
}