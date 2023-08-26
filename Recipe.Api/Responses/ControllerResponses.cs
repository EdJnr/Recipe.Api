using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Api.Responses
{
    public static class ControllerResponses
    {
        public static string Created(string? ItemName)
        {
            return $"{ItemName ?? "Record"} created successfully";
        }

        public static string Updated(string? ItemName, int id)
        {
            return $"{ItemName ?? "Record"} with id {id} updated successfully";
        }

        public static string Deleted(string? ItemName, int id)
        {
            return $"{ItemName ?? "Record"} with id {id} deleted successfully";
        }

        public static string NotFound(string? ItemName, int id)
        {
            return $"No {ItemName ?? "Record"} matches the id {id}.";
        }

        public static string NotFoundSearch(string? ItemName, string searchtext)
        {
            return $"No {ItemName ?? "Record"} matches {searchtext}.";
        }
    }
}
