using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using FindHouse.Business.Interfaces;
using FindHouse.Business.Notifications;

namespace FindHouse.API.Controllers
{   
    [ApiController]
    public abstract class MainController : ControllerBase
    {
        private readonly INotifier _notifier;

        public MainController(INotifier notifier)
        {
            _notifier = notifier;
        }

        protected bool OperacaoValida()
        {
            return !_notifier.TemNotificacao();
        }

       protected ActionResult CustomResponse(object result = null)
        {
            if(OperacaoValida())
            {
                return Ok(new 
                {
                    success = true, 
                    data = result 
                });
            }
            else
            {
                return BadRequest(new
                {
                    success = false,
                    errors = _notifier.ObterNotificacoes().Select(m => m.Message)
                });
            }
        }

       protected ActionResult CustomResponse (ModelStateDictionary modelState)
        {
            if (!modelState.IsValid) NotificarErroModelInvalida(modelState);

            return CustomResponse();
        }

        protected void NotificarErroModelInvalida(ModelStateDictionary modelState)
        {
            var erros = modelState.Values.SelectMany(m => m.Errors);
            foreach(var erro in erros)
            {
                var erroMsg = erro.Exception == null ? erro.ErrorMessage : erro.Exception.Message;
                NotificarErro(erroMsg);
            }
        }

        protected void NotificarErro(string mensagem)
        {
            _notifier.Handle(new Notification(mensagem));
        }
    }
}
