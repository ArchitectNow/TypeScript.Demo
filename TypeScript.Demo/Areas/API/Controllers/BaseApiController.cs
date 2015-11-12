using ArchitectNow.Framework.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TypeScript.Demo.Areas.API.Controllers
{
    public abstract class BaseApiController : ApiController
    {
        protected Envelope<T> BuildResult<T>(bool Success, string Message, T Content)
        {
            if (Content != null)
            {
                return new Envelope<T>() { Success = Success, Message = Message, Content = Content };
            }
            else
            {
                return new Envelope<T>() { Success = Success, Message = Message };
            }
        }

        protected Envelope<T> BuildResultError<T>(Exception exception)
        {
            var message = exception.Message;
            var aggregateException = exception as AggregateException;
            if (aggregateException != null)
            {
                message = aggregateException.Flatten().Message;
            }

            var entityException = exception as EntityException;
            if (entityException != null)
            {
                message = entityException.GetBaseException().Message;
            }

            return BuildResultError<T>(message, exception);
        }

        protected Envelope<T> BuildResultError<T>(string message, Exception exception = null)
        {
            var envelope = new Envelope<T>
            {
                Success = false,
                Message = message
            };

            return envelope;
        }
    }
}
