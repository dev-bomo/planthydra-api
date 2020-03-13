using GraphQL.Types;
using planthydra_api.Model.Models;

namespace planthydra_api.GraphQL.Types
{
    class UserType : ObjectGraphType<User>
    {
        public UserType()
        {
            Field(u => u.Id);
            Field(u => u.Name);
            Field(u => u.Devices);
        }
    }
}