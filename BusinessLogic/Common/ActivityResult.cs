using System.Collections.Generic;

namespace planthydra_api.BusinessLogic.Common
{
    public class ActivityResult<T> where T : class
    {
        public bool Success { get; private set; }
        public T Payload { get; private set; }

        public IEnumerable<string> Errors { get; private set; }

        public ActivityResult(bool success, T payload, IEnumerable<string>? errors)
        {
            Success = success;
            if (success)
            {
                Payload = payload;
            }
            else
            {
                if (errors == null)
                {
                    Errors = new List<string>();
                }
                else
                {
                    Errors = errors;
                }
            }
        }
    }
}