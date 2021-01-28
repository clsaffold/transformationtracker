using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransformationTracker.Models
{
    public class Pdsa
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public bool Shared { get; set; }
        public int TacticId { get; set; }
        public string Gap { get; set; }
        public string Plan { get; set; }
        public string Doing { get; set; }
        public string Study { get; set; }

        public Pdsa()
        {

        }

        public Pdsa(string username, string name, int tacticid, string gap, string plan, string doing, string study)
        {
            UserName = username;
            Name = name;
            TacticId = tacticid;
            Gap = gap;
            Plan = plan;
            Doing = doing;
            Study = study;
        }
    }
}
