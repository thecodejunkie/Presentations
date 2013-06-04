namespace TheCodeJunkie.DevSum2013.MarkerInterfaces
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

    public class TestEndPoint : EndPoint
    {
        public override Response GetResponse()
        {
            //return Response.AsJson(new Model());
            return new JsonResponse<Model>(new Model());
        }
    }

    public interface IMarkerInterface
    {
    }

    public static class ResponseExtensions
    {
        public static Response AsJson<T>(this IMarkerInterface marker, T model)
        {
            return new JsonResponse<T>(model);
        }
    }

    public class Model
    {
    }

    public class Response
    {
    }

    public class JsonResponse<T> : Response
    {
        public JsonResponse(T model)
        {
        }
    }
}
