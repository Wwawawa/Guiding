namespace UnityControllerFactory
{
    /// <summary>
    /// Unity controller factory.
    /// </summary>
    public class UnityControllerFactory : DefaultControllerFactory
    {
        private readonly IUnityContainer container;

        public UnityControllerFactory(IUnityContainer container)
        {
            this.container = container;
        }
        
        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            if (requestContext == null)
            {
                throw new ArgumentNullException("requestContext");
            }

            IController controller = null;
            if (controllerType == null)
            {
                requestContext.HttpContext.Response.TrySkipIisCustomErrors = true;
                //// throw new HttpException(404, string.Format(Resources.Controller_For_Path_Not_Found_Format, requestContext.HttpContext.Request.Path));
            }

            if (controllerType != null && !typeof(IController).IsAssignableFrom(controllerType))
            {
                throw new ArgumentException(
                        string.Format(
                            "Type requested is not a controller: {0}",
                            controllerType.Name),
                            "controllerType");
            }

            if (controllerType != null)
            {
                try
                {
                    controller = this.container.Resolve(controllerType) as IController;
                }
                catch (Exception ex)
                {
                    throw new InvalidOperationException(
                        string.Format("Error resolving controller {0}", controllerType.Name), ex);
                }
            }

            return controller;
        }
    }
}
