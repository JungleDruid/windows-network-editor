using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Windows_Network_Editor {
    class NetworkProfile {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string Guid { get; private set; }

        public NetworkProfile(string name, string description, string guid) {
            Name = name;
            Description = description;
            Guid = guid;
        }

        public override string ToString() {
            return Name;
        }
    }
}
