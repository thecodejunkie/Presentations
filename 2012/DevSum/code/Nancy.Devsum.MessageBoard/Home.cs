namespace Nancy.Devsum.MessageBoard
{
    using ModelBinding;

    public class Home : NancyModule
    {
        public Home(IMessageService service)
        {
            Get["/"] = parameters => {
                return View["index", service];
            };

            Post["/"] = parameters => {
                var model =
                    this.Bind<MessageModel>(new[] { "Posted" });

                service.Add(model);

                return Response.AsRedirect("~/");
            };
        }
    }
}