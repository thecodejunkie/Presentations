namespace TheCodeJunkie.Leetspeak.MarkerInterfaces
{
    class Program
    {
        static void Main()
        {
        }
    }

    public abstract class EndPoint
    {
        public abstract Response GetResponse();

        public IMarkerInterface Response { get; private set; }
    }

    public interface IMarkerInterface
    {
    }

    public class TestEndPoint : EndPoint
    {
        public override Response GetResponse()
        {
            //return Response.AsJson(new Model());
            return new JsonResponse<Model>(new Model());
        }
    }

    public static class ResponseExtensions
    {
        //public static Response AsJson<T>(this IMarkerInterface marker, T model)
        //{
        //    return new JsonResponse<T>(model);
        //}
    }

    public class Response
    {
        public string Content { get; set; }
    }

    public class JsonResponse<T> : Response
    {
        public JsonResponse(T model)
        {
            // Json serialize model and stick it in Content
        }
    }

    public class Model
    {
    }
}
