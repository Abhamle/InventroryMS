using System;
using System.Collections.Generic;

namespace Remote
{
    public class RemoteAccess<T>
    {
        //  To simplify the implimentation, i am returning the defult Type from remote store if the element is not cached.      

        public T GetActualData()
        {
            return default(T);
        }

    }

}
