using System;
using System.Collections.Generic;
using System.Linq;

namespace ClassLibrary1.Model
{
    public class HotDogGroup
    {
        public int HotDogGroupId
        {
            get;
            set;
        }

        public string Title
        {
            get;
            set;
        }

        public string ImagePath
        {
            get;
            set;
        }

        public List<HotDog> HotDogs
        {
            get;
            set;
        }
    }
}
