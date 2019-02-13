using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.Linq;
using NLog;
using WristBandAPI.DataModel;

namespace WristBandAPI.Common
{
    public class InspectorAttribute : Attribute, IParameterInspector, IOperationBehavior
    {
        Logger logger = LogManager.GetCurrentClassLogger();

        public void AfterCall(string operationName, object[] outputs, object returnValue, object correlationState)
        {
            StaticData.S_LogUser = "UNKNOWN";
        }

        public object BeforeCall(string operationName, object[] inputs)
        {
            logger.Trace("[Start]");
            logger.Info("Method starting");
            //return null; //Todo Comment this line

            if (null == inputs)
            {
                logger.Info("Input null");
            }

            if (inputs.Length <= 0)
            {
                logger.Info("Input legthError");
                throw new FaultException("0003");
            }

            Request req = (Request)inputs[0];

            WristbandEntities context = new WristbandEntities();
            logger.Info("Get Session object");
            login_session session = context.login_session.Where(w => w.session_id == req.SessionId.ToString() && w.status == (short)ECSessionStatus.OPEN).FirstOrDefault();
            if (session == null)
            {
                logger.Info("-SESSION NOT FOUND-");
                context.Dispose();
                throw new FaultException("0004");
            }

            logger.Info("Get username by session");

            if (session.user != null)
            {
                StaticData.S_LogUser = session.user.username;
            }

            int sessionTimeout = 300;

            if (sessionTimeout == 0)
            {
                logger.Info("Timeout : 0");
                session.end_datetime = DateTime.Now;
                logger.Info("Changers save");
                context.SaveChanges();

                context.Dispose();
                return null;
            }
            else
            {
                if ((DateTime.Now - (DateTime)session.end_datetime).TotalMinutes <= sessionTimeout)
                {
                    logger.Info("Session set date information");
                    session.end_datetime = DateTime.Now;
                    context.SaveChanges();
                    logger.Info("Save information : With timeout");
                    context.Dispose();
                    return null;
                }
                else
                {
                    logger.Info("Date Exception");
                    context.Dispose();
                    throw new FaultException("0004");
                }
            }
        }

        public void AddBindingParameters(OperationDescription operationDescription, BindingParameterCollection bindingParameters)
        {
        }

        public void ApplyClientBehavior(OperationDescription operationDescription, ClientOperation clientOperation)
        {
        }

        public void ApplyDispatchBehavior(OperationDescription operationDescription, DispatchOperation dispatchOperation)
        {
            dispatchOperation.ParameterInspectors.Add(this);
        }

        public void Validate(OperationDescription operationDescription)
        {
        }
    }
}